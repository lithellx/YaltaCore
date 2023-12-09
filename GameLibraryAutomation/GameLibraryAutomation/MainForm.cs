using GameLibraryAutomation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GameLibraryAutomation
{
    public partial class MainForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=YaltaCoreDb;Integrated Security=True");

        bool isWindowMax = false;

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public MainForm()
        {
            InitializeComponent();
        }

        List<string> games = new List<string>();
        List<string> mygames = new List<string>();
        List<string> friends = new List<string>();
        public static string MD5(string str) // parolalar için md5 şifreleme
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] arr = Encoding.UTF8.GetBytes(str);
            arr = md5.ComputeHash(arr);
            StringBuilder sb = new StringBuilder();

            foreach (byte ba in arr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            return sb.ToString();
        }

        int myId = 0;
        byte[] myProfilePic;
        byte[] myProfileBanner;
        string myUsername = "", myEmail = "", myPassword = "", myLevel = "", myRank = "", myBalance = "", myFirstname = "", myExplanation = "";
        byte[] myPic, myBanner;

        void readUserTable() // userTable tablosundaki tüm verileri çekme fonksiyonu
        {
            SqlCommand cmdProfile = new SqlCommand("SELECT * FROM userTable WHERE username=@username", con);
            cmdProfile.Parameters.AddWithValue("@username", userLabel.Text);

            con.Open();
            SqlDataReader reader = cmdProfile.ExecuteReader();
            while (reader.Read())
            {
                myId = reader.GetInt32(0);
                myUsername = reader.GetString(1);
                myEmail = reader.GetString(2);
                myPassword = reader.GetString(3);
                myLevel= reader.GetString(4);
                myRank= reader.GetString(5);
                myBalance= reader.GetString(6);
                if (!reader.IsDBNull(7))
                    myFirstname = reader.GetString(7);
                if (!reader.IsDBNull(8))
                    myExplanation = reader.GetString(8);
                if (!reader.IsDBNull(9))
                    myPic = (byte[])reader["profilepic"];
                if (!reader.IsDBNull(10))
                    myBanner = (byte[])reader["profilebanner"];
            }
            con.Close();

            profileUserLabel.Text = myUsername;
            editUserTextBox.Text = myUsername;
            emailTextBox.Text = myEmail;
            usrLevelLabel.Text = "Seviye: " + myLevel;
            balanceLabel.Text = myBalance + "₺";
            if (editFNameTextBox.Text != null) editFNameTextBox.Text = myFirstname;
            editBioTextBox.Text = myExplanation;
            explanationTBox.Text = myExplanation;
        }

        void readFriends()
        {
            //SqlCommand cmdFrnd = new SqlCommand("SELECT friendName FROM friendsTable WHERE userName=@userName", con);
            //cmdFrnd.Parameters.AddWithValue("@userName", myUsername);
            //SqlDataAdapter daFrnd = new SqlDataAdapter();
            //daFrnd.SelectCommand = cmdFrnd;
            //DataTable dtFrnd = new DataTable();
            //daFrnd.Fill(dtFrnd);

            //friendsListBox.DataSource = dtFrnd;
            //friendsListBox.DisplayMember = "friendName";

            //friendPLBox.DataSource = dtFrnd;
            //friendPLBox.DisplayMember = "friendName";

            //foreach (string str in friends)
            //{
            //    friendPLBox.Items.Add(str);
            //    friendsListBox.Items.Add(str);
            //}

            SqlCommand cmd = new SqlCommand("SELECT friendName FROM friendsTable WHERE userName=@userName", con);
            cmd.Parameters.AddWithValue("@userName", myUsername);
            DataTable dt = new DataTable();

            con.Open();

            dt.Load(cmd.ExecuteReader());

            friendsListBox.DataSource = dt;
            friendsListBox.DisplayMember = "friendName";

            friendPLBox.DataSource = dt;
            friendPLBox.DisplayMember = "friendName";

            con.Close();

        }

        void readLibrary()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM libTable JOIN gameTable ON libTable.id = gameTable.gameId JOIN userTable ON gameTable.userId = userTable.id WHERE userTable.id = @id ORDER BY libTable.gamename ASC;", con);
            cmd.Parameters.AddWithValue("@id", myId);
            DataTable dt = new DataTable();

            con.Open();

            dt.Load(cmd.ExecuteReader());

            tempGridView.DataSource = dt;

            gameListBox.DataSource = dt;
            gameListBox.DisplayMember = "gamename";

            myGamesListBox.DataSource = dt;
            myGamesListBox.DisplayMember = "gamename";

            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e) // MainForm çalışınca
        {
            storePanel.Visible = true;
            libraryPanel.Visible = false;
            profilePanel.Visible = false;
            settingsPanel.Visible = false;
            friendPanel.Visible = false;

            selectedPanel.Width = storeLabel.Width - 12;
            selectedPanel.Top = storeLabel.Bottom;
            selectedPanel.Left = storeLabel.Left + 5;

            readUserTable();

            SqlCommand cmdPP = new SqlCommand("SELECT * FROM userTable WHERE id=@id", con);
            cmdPP.Parameters.AddWithValue("@id", myId);
            SqlDataAdapter daP = new SqlDataAdapter();
            daP.SelectCommand = cmdPP;
            DataTable dtP = new DataTable();
            daP.Fill(dtP);
            myProfilePic = (byte[])dtP.Rows[0][9];
            myProfileBanner = (byte[])dtP.Rows[0][10];

            if (myProfilePic != null)
            {
                profileImage.Image = Image.FromStream(new MemoryStream(myProfilePic));
                profilePicBox.Image = Image.FromStream(new MemoryStream(myProfilePic));
                editProfilePicBox.Image = Image.FromStream(new MemoryStream(myProfilePic));
            }

            if(myProfileBanner != null)
            {
                profileBannerPicBox.Image = Image.FromStream(new MemoryStream(myProfileBanner));
                editBannerPicBox.Image = Image.FromStream(new MemoryStream(myProfileBanner));
            }

            daP.Dispose();

            readLibrary();
            readFriends();
        }

        // Panel ile pencere taşıma

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        // Panel ile pencere taşıma

        // Kapama alta atma tuşları

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.BackColor = topPanel.BackColor;
        }

        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.FromArgb(160, 0, 0);
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Kapama alta atma tuşları

        int sliderCount = 0;

        private void button1_Click(object sender, EventArgs e) // slider sağ
        {
            sliderCount++;

            if (sliderCount > 3)
                sliderCount = 0;
            else if (sliderCount < 0)
                sliderCount = 3;

            if(sliderCount == 0)
                sliderPBox.Image = GameLibraryAutomation.Properties.Resources.slider1;
            else if (sliderCount == 1)
                sliderPBox.Image = GameLibraryAutomation.Properties.Resources.slider2;
            else if (sliderCount == 2)
                sliderPBox.Image = GameLibraryAutomation.Properties.Resources.slider3;
            else if (sliderCount == 3)
                sliderPBox.Image = GameLibraryAutomation.Properties.Resources.slider4;

        }

        private void button2_Click(object sender, EventArgs e) // slider sol
        {
            sliderCount--;

            if (sliderCount > 3)
                sliderCount = 0;
            else if (sliderCount < 0)
                sliderCount = 3;

            if (sliderCount == 0)
                sliderPBox.Image = GameLibraryAutomation.Properties.Resources.slider1;
            else if (sliderCount == 1)
                sliderPBox.Image = GameLibraryAutomation.Properties.Resources.slider2;
            else if (sliderCount == 2)
                sliderPBox.Image = GameLibraryAutomation.Properties.Resources.slider3;
            else if (sliderCount == 3)
                sliderPBox.Image = GameLibraryAutomation.Properties.Resources.slider4;
        }

        private void storeLabel_Click(object sender, EventArgs e) // Mağaza label'ına basınca
        {
            selectedPanel.Visible = true;
            selectedPanel.Width = storeLabel.Width - 12;
            selectedPanel.Top = storeLabel.Bottom;
            selectedPanel.Left = storeLabel.Left + 5;

            storePanel.Visible = true;
            libraryPanel.Visible = false;
            profilePanel.Visible = false;
            settingsPanel.Visible = false;
            friendPanel.Visible = false;
        }

        private void libraryLabel_Click(object sender, EventArgs e) // Kütüphane label'ına basınca
        {
            selectedPanel.Visible = true;
            selectedPanel.Width = libraryLabel.Width - 12;
            selectedPanel.Top = libraryLabel.Bottom;
            selectedPanel.Left = libraryLabel.Left + 5;

            storePanel.Visible = false;
            libraryPanel.Visible = true;
            profilePanel.Visible = false;
            settingsPanel.Visible = false;
            friendPanel.Visible = false;
        }

        private void profileLabel_Click(object sender, EventArgs e) // Profil label'ına basınca
        {
            selectedPanel.Visible = true;
            selectedPanel.Width = profileLabel.Width - 12;
            selectedPanel.Top = profileLabel.Bottom;
            selectedPanel.Left = profileLabel.Left + 5;

            storePanel.Visible = false;
            libraryPanel.Visible = false;
            profilePanel.Visible = true;
            settingsPanel.Visible = false;
            friendPanel.Visible = false;
        }

        private void gameListBox_SelectedIndexChanged(object sender, EventArgs e) // oyun listesinde seçili oyun değiştirilmesi olayı
        {
            gamePBox.Image = null;
            gamePBox.Load(Convert.ToString(tempGridView.Rows[gameListBox.SelectedIndex].Cells["gameimgurl"].Value));
            minimumTextBox.Text = Convert.ToString(tempGridView.Rows[gameListBox.SelectedIndex].Cells["systemmin"].Value);
            recommendTextBox.Text = Convert.ToString(tempGridView.Rows[gameListBox.SelectedIndex].Cells["systemdef"].Value);
            gameInfoTBox.Text = Convert.ToString(tempGridView.Rows[gameListBox.SelectedIndex].Cells["gameinfo"].Value);
            gameStaticsTBox.Text = Convert.ToString(tempGridView.Rows[gameListBox.SelectedIndex].Cells["gamestatics"].Value);
        }

        bool isResult = false;

        private void searchTBox_Enter(object sender, EventArgs e) // arama textbox'ın içine mouse'ın girmesi olayı
        {
            if (searchTBox.Text == "Oyun Arayın")
            {
                searchTBox.Text = "";
                searchTBox.ForeColor = Color.White;
            }
        }

        private void searchTBox_Leave(object sender, EventArgs e) // arama textbox'ından mouse'ın uzaklaşması olayı
        {
            if (searchTBox.Text == "")
            {
                searchTBox.Text = "Oyun Arayın";
                searchTBox.ForeColor = Color.Gray;
            }

            if(isResult == false)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM libTable JOIN gameTable ON libTable.id = gameTable.gameId JOIN userTable ON gameTable.userId = userTable.id WHERE userTable.id = @id ORDER BY libTable.gamename ASC;", con);
                cmd.Parameters.AddWithValue("@id", myId);
                DataTable dt = new DataTable();

                con.Open();
                dt.Load(cmd.ExecuteReader());
                gameListBox.DataSource = dt;
                con.Close();
            }
        }

        private void searchTBox_TextChanged(object sender, EventArgs e) // arama textbox'ının yazısının değişmesi olayı
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM libTable JOIN gameTable ON libTable.id = gameTable.gameId JOIN userTable ON gameTable.userId = userTable.id WHERE userTable.id = @id ORDER BY libTable.gamename ASC;", con);
            cmd.Parameters.AddWithValue("@id", myId);
            DataTable dt = new DataTable();

            con.Open();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            
            if (searchTBox.Text != "Oyun Arayın")
            {
                isResult = true;
                DataView dv = new DataView(dt);
                dv.RowFilter = "gamename LIKE '%" + searchTBox.Text + "%'";
                gameListBox.DataSource = dv;
            }
            else
            {
                SqlCommand cmdx = new SqlCommand("SELECT * FROM libTable JOIN gameTable ON libTable.id = gameTable.gameId JOIN userTable ON gameTable.userId = userTable.id WHERE userTable.id = @id ORDER BY libTable.gamename ASC;", con);
                cmdx.Parameters.AddWithValue("@id", myId);
                DataTable dtx = new DataTable();

                con.Open();
                dtx.Load(cmdx.ExecuteReader());
                gameListBox.DataSource = dtx;
                con.Close();
            }
        }

        private void mngDlsLabel_Click(object sender, EventArgs e)
        {
            selectedPanel.Visible = false;

            friendPanel.Visible = false;
            storePanel.Visible = false;
            libraryPanel.Visible = false;
            profilePanel.Visible = false;
            settingsPanel.Visible = true;
        }

        Image pictureImg;
        Image bannerImg;

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) // sağ alttaki ikona çift tıklama olayı
        {
            this.Show();
            notifyIcon1.Visible = false;
        }

        bool profileSelected = false, bannerSelected = false;

        void buyGame(int gameId, string balanceVal)
        {
            string gameName = "", gameCost = "";

            SqlCommand cmd = new SqlCommand("SELECT gamename, gamecost FROM libTable WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", gameId);
            
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                gameName = reader.GetString(0);
                gameCost = reader.GetString(1);
            }
            con.Close();

            BuyForm buyForm = new BuyForm();
            buyForm.FormClosed += new FormClosedEventHandler(buyForm_FormClosed);
            buyForm.gameNameLabel.Text = gameName;
            buyForm.balanceTBox.Text = balanceVal;
            buyForm.costTBox.Text = gameCost;
            buyForm.userId = myId;
            buyForm.gameId = gameId;

            buyForm.Show();
        }

        void buyForm_FormClosed(object sender, FormClosedEventArgs e) 
        {
            string balance = "";
            SqlCommand cmd = new SqlCommand("SELECT balance FROM userTable WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", myId);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                balance = reader.GetString(0);
            }
            con.Close();

            balanceLabel.Text = balance + "₺";

            readLibrary();
        }

        private void gamePBox1_Click(object sender, EventArgs e)
        {
            buyGame(5, myBalance);
        }

        private void gamePBox2_Click(object sender, EventArgs e)
        {
            buyGame(7, myBalance);
        }

        private void gamePBox3_Click(object sender, EventArgs e)
        {
            buyGame(9, myBalance);
        }

        private void gamePBox4_Click(object sender, EventArgs e)
        {

        }

        private void gamePBox5_Click(object sender, EventArgs e)
        {

        }

        private void gamePBox6_Click(object sender, EventArgs e)
        {

        }

        private void gamePBox7_Click(object sender, EventArgs e)
        {

        }

        private void gamePBox8_Click(object sender, EventArgs e)
        {

        }

        private void gamePBox9_Click(object sender, EventArgs e)
        {

        }

        private void deleteFriendBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM friendsTable WHERE userName=@userName AND friendName=@friendName", con);
            cmd.Parameters.AddWithValue("@userName", myUsername);
            cmd.Parameters.AddWithValue("@friendName", Convert.ToString(friendPLBox.GetItemText(friendPLBox.SelectedItem)));

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            con.Close();

            readFriends();
        }
        private void addFriendBtn_Click(object sender, EventArgs e)
        {
            bool ifUserCorrect = false;
            SqlCommand cmdIfUser = new SqlCommand("SELECT username FROM userTable WHERE username=@username", con);
            cmdIfUser.Parameters.AddWithValue("@username", friendNameTBox.Text);

            con.Open();
            SqlDataReader drUserC = cmdIfUser.ExecuteReader();
            if (drUserC.HasRows)
                ifUserCorrect = true;
            con.Close();

            SqlCommand cmdUsers = new SqlCommand("SELECT userName FROM friendsTable WHERE userName=@userName AND friendName=@friendName", con);
            cmdUsers.Parameters.AddWithValue("@userName", myUsername);
            cmdUsers.Parameters.AddWithValue("@friendName", Convert.ToString(friendNameTBox.Text));

            con.Open();
            SqlDataReader drUsers = cmdUsers.ExecuteReader();

            if (ifUserCorrect == true)
            {
                if (!drUsers.HasRows)
                {
                    con.Close();

                    SqlCommand cmd = new SqlCommand("INSERT INTO friendsTable (userName, friendName) VALUES (@userName, @friendName)", con);
                    cmd.Parameters.AddWithValue("@userName", myUsername);
                    cmd.Parameters.AddWithValue("@friendName", Convert.ToString(friendNameTBox.Text));

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    con.Close();

                    readFriends();
                }
                else
                {
                    con.Close();
                    MessageBox.Show("Belirtilen kullanıcı ile zaten arkadaşsınız.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            { 
                con.Close();
                MessageBox.Show("Belirtilen kullanıcı bulunamadı.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void friendsLabel_Click(object sender, EventArgs e)
        {
            storePanel.Visible = false;
            libraryPanel.Visible = false;
            profilePanel.Visible = false;
            settingsPanel.Visible = false;
            friendPanel.Visible = true;
        }

        private void startButton_Click(object sender, EventArgs e) // oyun başlatma butonu
        {
            readUserTable(); // açılırsa her bastığımızda seviye artar

            if(int.Parse(myLevel) <= 999)
            {
                int tempLevel = int.Parse(myLevel);
                tempLevel++;

                //SqlCommand cmd = new SqlCommand("UPDATE userTable SET level=@level WHERE id=@id", con);
                //cmd.Parameters.AddWithValue("@id", myId);
                //cmd.Parameters.AddWithValue("@level", tempLevel.ToString());

                usrLevelLabel.Text = "Seviye: " + tempLevel.ToString();

                con.Open();
                //cmd.ExecuteNonQuery();
                con.Close();
            }

            GameForm gameForm = new GameForm();
            gameForm.ShowDialog();

            this.Hide();
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(10);
        }

        byte[] picbytes;
        private void editProfilePic_Click(object sender, EventArgs e) // profil fotoğrafını düzenle
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureImg = Image.FromFile(openFileDialog1.FileName);

                picbytes = (byte[])(new ImageConverter()).ConvertTo(pictureImg, typeof(byte[]));
                profileSelected = true;

                //SqlCommand cmd = new SqlCommand("UPDATE userTable SET profilepic=@profilepic WHERE id=@id", con);
                //cmd.Parameters.AddWithValue("@id", myId);
                //cmd.Parameters.Add("@profilepic", SqlDbType.VarBinary).Value = picbytes;

                con.Open();
                //cmd.ExecuteNonQuery();
                con.Close();
            }

            editProfilePicBox.Image = pictureImg;
        }

        byte[] banbytes;
        private void editBannerPic_Click(object sender, EventArgs e) // profil arkaplanını düzenle
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bannerImg = Image.FromFile(openFileDialog1.FileName);

                banbytes = (byte[])(new ImageConverter()).ConvertTo(bannerImg, typeof(byte[]));
                bannerSelected = true;

                //SqlCommand cmd = new SqlCommand("UPDATE userTable SET profilebanner=@profilebanner WHERE id=@id", con);
                //cmd.Parameters.AddWithValue("@id", myId);
                //cmd.Parameters.Add("@profilebanner", SqlDbType.VarBinary).Value = banbytes;

                con.Open();
                //cmd.ExecuteNonQuery();
                con.Close();
            }

            editBannerPicBox.Image = bannerImg;
        }

        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            string command = "UPDATE userTable SET email=@email, password=@password, firstname=@firstname, explanation=@explanation, profilepic=@profilepic, profilebanner=@profilebanner";
            SqlCommand cmdSave = new SqlCommand(command, con);

            bool queryErr = false, ifPwChanged = false;
            cmdSave.Parameters.AddWithValue("@email", myEmail);
            cmdSave.Parameters.AddWithValue("@password", myPassword);
            cmdSave.Parameters.AddWithValue("@firstname", myFirstname);
            cmdSave.Parameters.AddWithValue("@explanation", myExplanation);
            cmdSave.Parameters.Add("@profilepic", SqlDbType.VarBinary).Value = (byte[])(new ImageConverter()).ConvertTo(profilePicBox.Image, typeof(byte[]));
            cmdSave.Parameters.Add("@profilebanner", SqlDbType.VarBinary).Value = (byte[])(new ImageConverter()).ConvertTo(profileBannerPicBox.Image, typeof(byte[]));

            con.Open();

            if (emailTextBox.Text != myEmail)
            {
                cmdSave.Parameters["@email"].Value = emailTextBox.Text;
            }
            if (MD5(ogPwTextBox.Text) == myPassword)
            {
                if (newPwTextBox.Text != string.Empty && newPwTextBox2.Text != string.Empty)
                {
                    if (newPwTextBox.Text == newPwTextBox2.Text)
                    {
                        cmdSave.Parameters["@password"].Value = MD5(newPwTextBox.Text);
                        ifPwChanged = true;
                    }
                    else
                    {
                        MessageBox.Show("Lütfen 2 yeni şifrenin de aynı olduğundan emin olun.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        queryErr = true;
                    }
                }
            }
            if (editFNameTextBox.Text != myFirstname)
            {
                cmdSave.Parameters["@firstname"].Value = editFNameTextBox.Text;
            }
            if (editBioTextBox.Text != myExplanation)
            {
                cmdSave.Parameters["@explanation"].Value = editBioTextBox.Text;
            }
            if(picbytes != myPic && picbytes != null)
            {
              cmdSave.Parameters["@profilepic"].SqlValue = picbytes;
            }
            if (banbytes != myBanner && banbytes != null)
            {
              cmdSave.Parameters["@profilebanner"].SqlValue = banbytes;
            }

            command += " WHERE id=@id";
            cmdSave.Parameters.AddWithValue("@id", myId);
            cmdSave.CommandText = command;

            if (queryErr == false)
            {
                cmdSave.ExecuteNonQuery();
                if (profileSelected == true)
                {
                    profileImage.Image = pictureImg;
                    profilePicBox.Image = pictureImg;
                    editProfilePicBox.Image = pictureImg;
                }

                if (bannerSelected)
                {
                    editBannerPicBox.Image = bannerImg;
                    profileBannerPicBox.Image = bannerImg;
                }

                if (ifPwChanged == false)
                    MessageBox.Show("Değişiklikler kaydedildi.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Değişiklikler kaydedildi. Lütfen uygulamayı yeniden çalıştırın.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }

            con.Close();

            readUserTable();

            if (editFNameTextBox.Text != null) editFNameTextBox.Text = myFirstname;
            if (editBioTextBox.Text != null) editBioTextBox.Text = myExplanation;

            //if (myProfilePic != null)
            //{
            //    profileImage.Image = Image.FromStream(new MemoryStream(myProfilePic));
            //    profilePicBox.Image = Image.FromStream(new MemoryStream(myProfilePic));
            //}
            //if (myProfileBanner != null)
            //{
            //    editBannerPicBox.Image = Image.FromStream(new MemoryStream(myProfileBanner));
            //    profileBannerPicBox.Image = Image.FromStream(new MemoryStream(myProfileBanner));
            //}

            profileUserLabel.Text = myUsername;
            editUserTextBox.Text = myUsername;
            emailTextBox.Text = myEmail;
            explanationTBox.Text = myExplanation;
        }
    }
}