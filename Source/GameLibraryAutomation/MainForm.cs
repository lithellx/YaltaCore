using YaltaCore.Properties;
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
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net.NetworkInformation;
using System.Threading;
using System.Diagnostics;

namespace GameLibraryAutomation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        // SQL BAĞLANTISI İÇİN GEREKEN CONNECTIONSTRING

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=YaltaCoreDb;Integrated Security=True");

        // SQL BAĞLANTISI İÇİN GEREKEN CONNECTIONSTRING

        // GÜVENLİK / PAROLALAR İÇİN MD5 ŞİFRELEME

        // GÜVENLİK / PAROLALAR İÇİN MD5 ŞİFRELEME

        public static string MD5(string str)
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

        // GÜVENLİK / PAROLALAR İÇİN MD5 ŞİFRELEME

        // KULLANICININ TÜM BİLGİLERİNİ OKUMA FONKSİYONU

        int myId = 0;
        byte[] myProfilePic, myProfileBanner, myPic, myBanner;
        string myUsername = "", myEmail = "", myPassword = "", myLevel = "", myRank = "", myBalance = "", myFirstname = "", myExplanation = "";

        void fetchMyData()
        {
            SqlCommand cmdProfile = new SqlCommand("SELECT * FROM accTable WHERE username=@username", con);
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

            // PROFİL / VERİLERİ AKTAR

            profileUserLabel.Text = myUsername;
            editUserTextBox.Text = myUsername;
            emailTextBox.Text = myEmail;
            usrLevelLabel.Text = "Seviye: " + myLevel;
            balanceLabel.Text = "₺" + myBalance;
            if (editFNameTextBox.Text != null) editFNameTextBox.Text = myFirstname;
            editBioTextBox.Text = myExplanation;
            explanationTBox.Text = myExplanation;

            // PROFİL / VERİLERİ AKTAR
        }

        // KULLANICININ TÜM BİLGİLERİNİ OKUMA FONKSİYONU

        // friendName TABLOSUNU OKUMA FONKSİYONU

        void readFriends()
        {
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

        // friendName TABLOSUNU OKUMA FONKSİYONU

        // libTable TABLOSUNDAN SATIN ALINAN OYUNLARI OKUMA FONKSİYONU

        void readMyLib()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM libTable JOIN gameTable ON libTable.id = gameTable.gameId JOIN accTable ON gameTable.userId = accTable.id WHERE accTable.id = @id ORDER BY libTable.gamename ASC;", con);
            cmd.Parameters.AddWithValue("@id", myId);
            DataTable dt = new DataTable();

            con.Open();

            dt.Load(cmd.ExecuteReader());

            //libGridView.DataSource = dt;

            gameListBox.DataSource = dt;
            gameListBox.DisplayMember = "gamename";

            myGamesListBox.DataSource = dt;
            myGamesListBox.DisplayMember = "gamename";

            con.Close();
        }

        // libTable TABLOSUNDAN SATIN ALINAN OYUNLARI OKUMA FONKSİYONU

        // libTable TABLOSUNU OKUMA FONKSİYONU

        void readLibTable()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM libTable", con);
            //cmd.Parameters.AddWithValue("@id", myId);
            DataTable dt = new DataTable();

            con.Open();
            dt.Load(cmd.ExecuteReader());
            libGridView.DataSource = dt;
            con.Close();
        }

        // libTable TABLOSUNU OKUMA FONKSİYONU

        // accTable TABLOSUNU OKUMA FONKSİYONU

        void readAccTable()
        {
            SqlCommand cmd = new SqlCommand("SELECT id, username, email, password, level, rank, balance, firstname, explanation FROM accTable", con);
            DataTable dt = new DataTable();

            con.Open();
            dt.Load(cmd.ExecuteReader());
            accGridView.DataSource = dt;
            con.Close();
        }

        // accTable TABLOSUNU OKUMA FONKSİYONU

        // MAINFORM / UYGULAMA ÇALIŞINCA

        private void Form1_Load(object sender, EventArgs e) // MainForm çalışınca
        {
            storePanel.Visible = true;
            libraryPanel.Visible = false;
            profilePanel.Visible = false;
            settingsPanel.Visible = false;
            friendPanel.Visible = false;
            adminPanel.Visible = false;

            libMngPanel.Visible = true;
            resetBannerBtn.Visible = false;

            selectedPanel.Width = storeLabel.Width - 12;
            selectedPanel.Top = storeLabel.Bottom;
            selectedPanel.Left = storeLabel.Left + 5;

            selectedPanel2.Width = libMngLabel.Width - 12;
            selectedPanel2.Top = libMngLabel.Bottom;
            selectedPanel2.Left = libMngLabel.Left + 5;

            fetchMyData();

            storePanel.Visible = true;
            libraryPanel.Visible = false;
            profilePanel.Visible = false;
            settingsPanel.Visible = false;
            friendPanel.Visible = false;

            if (myRank == "admin")
            {
                adminPanelLabel.Enabled = true;
                adminPanelLabel.Visible = true;
            }
            else if (myRank == "libAdmin")
            {
                adminPanelLabel.Enabled = true;
                adminPanelLabel.Visible = true;

                accMngLabel.Enabled = false;
                accMngLabel.Visible = false;
                resetBannerBtn.Enabled = false;
                resetBannerBtn.Visible = false;
                libMngPanel.Visible = true;

                selectedPanel2.Width = libMngLabel.Width - 12;
                selectedPanel2.Top = libMngLabel.Bottom;
                selectedPanel2.Left = libMngLabel.Left + 5;
            }
            else if (myRank == "accAdmin")
            {
                adminPanelLabel.Enabled = true;
                adminPanelLabel.Visible = true;

                libMngLabel.Enabled = false;
                libMngLabel.Visible = false;
                libMngPanel.Enabled = false;
                libMngPanel.Visible = false;
                resetBannerBtn.Visible = true;

                accMngLabel.Left = libMngLabel.Left;

                selectedPanel2.Width = accMngLabel.Width - 12;
                selectedPanel2.Top = accMngLabel.Bottom;
                selectedPanel2.Left = accMngLabel.Left + 5;
            }

            if (myUsername.Length > 9)
            {
                userPanel.Width = (myUsername.Length * 17);
                userPanel.Left = (userPanel.Left - userPanel.Width + 130);
                userPanel.PerformLayout();
            }

            if (myBalance.Length > 9)
            {
                userPanel.Width = (myBalance.Length * 18);
                userPanel.Left = (userPanel.Left - userPanel.Width + 115);
                userPanel.PerformLayout();
            }

            SqlCommand cmdPP = new SqlCommand("SELECT * FROM accTable WHERE id=@id", con);
            cmdPP.Parameters.AddWithValue("@id", myId);
            SqlDataAdapter daP = new SqlDataAdapter();
            daP.SelectCommand = cmdPP;
            DataTable dtP = new DataTable();
            daP.Fill(dtP);
            if(dtP.Rows[0][9] != DBNull.Value)
                myProfilePic = (byte[])dtP.Rows[0][9];
            if (dtP.Rows[0][10] != DBNull.Value)
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

            readMyLib();
            readFriends();
            readLibTable();
            readAccTable();
        }

        // MAINFORM / UYGULAMA ÇALIŞINCA

        // MAINFORM / PANEL İLE FORM SÜRÜKLEME / GEREKLİ DLL DOSYALARIN İÇERİ AKTARILMASI

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        // MAINFORM / PANEL İLE FORM SÜRÜKLEME / GEREKLİ DLL DOSYALARIN İÇERİ AKTARILMASI

        // ÜST PANEL / PANEL İLE FORM SÜRÜKLEME / MOUSE TIKLAYINCA

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // ÜST PANEL / PANEL İLE FORM SÜRÜKLEME / MOUSE TIKLAYINCA

        // ÜST PANEL / PANEL İLE FORM SÜRÜKLEME / MOUSE BIRAKINCA

        private void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        // ÜST PANEL / PANEL İLE FORM SÜRÜKLEME / MOUSE BIRAKINCA

        // ÜST PANEL / UYGULAMAYI KAPATMA

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        // ÜST PANEL / UYGULAMAYI KAPATMA

        // ÜST PANEL / UYGULAMAYI KAPATMA / İMLEÇ BUTONDAN AYRILINCA

        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.BackColor = topPanel.BackColor;
        }

        // ÜST PANEL / UYGULAMAYI KAPATMA / İMLEÇ BUTONDAN AYRILINCA

        // ÜST PANEL / UYGULAMAYI KAPATMA / BUTONA İMLEÇ TEMAS EDİNCE

        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.FromArgb(160, 0, 0);
        }

        // ÜST PANEL / UYGULAMAYI KAPATMA / BUTONA İMLEÇ TEMAS EDİNCE

        // ÜST PANEL / UYGULAMAYI KÜÇÜLTME

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // ÜST PANEL / UYGULAMAYI KÜÇÜLTME

        // MAĞAZA / GÖRÜNTÜLEME

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
            adminPanel.Visible = false;

        }

        // MAĞAZA / GÖRÜNTÜLEME

        // MAĞAZA / SLIDER / SAĞA KAYDIR

        int sliderCount = 0;

        private void button1_Click(object sender, EventArgs e) // slider sağ
        {
            sliderCount++;

            if (sliderCount > 3)
                sliderCount = 0;
            else if (sliderCount < 0)
                sliderCount = 3;

            if(sliderCount == 0)
                sliderPBox.Image = YaltaCore.Properties.Resources.slider1;
            else if (sliderCount == 1)
                sliderPBox.Image = YaltaCore.Properties.Resources.slider2;
            else if (sliderCount == 2)
                sliderPBox.Image = YaltaCore.Properties.Resources.slider3;
            else if (sliderCount == 3)
                sliderPBox.Image = YaltaCore.Properties.Resources.slider4;

        }

        // MAĞAZA / SLIDER / SAĞA KAYDIR

        // MAĞAZA / SLIDER / SOLA KAYDIR

        private void button2_Click(object sender, EventArgs e) // slider sol
        {
            sliderCount--;

            if (sliderCount > 3)
                sliderCount = 0;
            else if (sliderCount < 0)
                sliderCount = 3;

            if (sliderCount == 0)
                sliderPBox.Image = YaltaCore.Properties.Resources.slider1;
            else if (sliderCount == 1)
                sliderPBox.Image = YaltaCore.Properties.Resources.slider2;
            else if (sliderCount == 2)
                sliderPBox.Image = YaltaCore.Properties.Resources.slider3;
            else if (sliderCount == 3)
                sliderPBox.Image = YaltaCore.Properties.Resources.slider4;
        }

        // MAĞAZA / SLIDER / SOLA KAYDIR

        // MAĞAZA / UYGULAMAYI SİMGE DURUMUNDAN ÇIKART

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) // sağ alttaki ikona çift tıklama olayı
        {
            this.Show();
            notifyIcon1.Visible = false;
        }

        // MAĞAZA / UYGULAMAYI SİMGE DURUMUNDAN ÇIKART

        // MAĞAZA / BAKİYEYİ YENİDEN OKU (BAKİYE GÜNCELLE)

        void updateBalance()
        {
            string balance = "";
            SqlCommand cmd = new SqlCommand("SELECT balance FROM accTable WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", myId);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                balance = reader.GetString(0);
            }
            con.Close();

            balanceLabel.Text = "₺" + balance;

            readMyLib();

            if (myBalance.Length > 9)
            {
                userPanel.Width = (myBalance.Length * 17);
                userPanel.Left = (userPanel.Left - userPanel.Width + 115);
                userPanel.PerformLayout();
            }
        }

        // MAĞAZA / BAKİYEYİ YENİDEN OKU (BAKİYE GÜNCELLE)

        // MAĞAZA / PARA YATIRMA / DepositForm BAŞLAT

        public bool isDepositFormOpened = false;
        private void balanceLabel_Click(object sender, EventArgs e)
        {
            DepositForm depositForm = new DepositForm();
            if (isDepositFormOpened == false)
            {
                fetchMyData();
                depositForm.FormClosed += new FormClosedEventHandler(depositForm_FormClosed);
                depositForm.FormClosed += (s, args) => isDepositFormOpened = false;
                depositForm.userBalance = double.Parse(myBalance);
                depositForm.userId = myId;
                isDepositFormOpened = true;
                depositForm.Show();
            }
        }

        // MAĞAZA / PARA YATIRMA / DepositForm BAŞLAT

        // DEPOSITFORM / PARA YATIRMA / FORM KAPATILDIĞINDA...

        void depositForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            updateBalance();
        }

        // DEPOSITFORM / PARA YATIRMA / FORM KAPATILDIĞINDA...

        // MAĞAZA / OYUN SATIN ALMA VE BuyForm ÇALIŞTIRMA FONKSİYONU

        public bool isBuyFormOpened = false;

        void buyGame(int gameId)
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
            if (isBuyFormOpened == false)
            {
                buyForm.FormClosed += new FormClosedEventHandler(buyForm_FormClosed);
                buyForm.FormClosed += (s, args) => isBuyFormOpened = false;
                buyForm.gameNameLabel.Text = gameName;
                buyForm.balanceTBox.Text = balanceLabel.Text.Substring(1);
                buyForm.costTBox.Text = gameCost;
                buyForm.userId = myId;
                buyForm.gameId = gameId;
                isBuyFormOpened = true;
                buyForm.Show();
            }
        }

        // MAĞAZA / OYUN SATIN ALMA VE BuyForm ÇALIŞTIRMA FONKSİYONU

        // MAĞAZA / OYUNLARA TIKLANINCA buyGame(oyunId) ÇALIŞTIR

        private void gamePBox1_Click(object sender, EventArgs e)
        {
            buyGame(16);
        }

        private void gamePBox2_Click(object sender, EventArgs e)
        {
            buyGame(7);
        }

        private void gamePBox3_Click(object sender, EventArgs e)
        {
            buyGame(3);
        }

        private void gamePBox4_Click(object sender, EventArgs e)
        {
            buyGame(1);
        }

        private void gamePBox5_Click(object sender, EventArgs e)
        {
            buyGame(2);
        }

        private void gamePBox6_Click(object sender, EventArgs e)
        {
            buyGame(9);
        }

        private void gamePBox7_Click(object sender, EventArgs e)
        {
            buyGame(12);
        }

        private void gamePBox8_Click(object sender, EventArgs e)
        {
            buyGame(14);
        }

        private void gamePBox9_Click(object sender, EventArgs e)
        {
            buyGame(5);
        }

        // MAĞAZA / OYUNLARA TIKLANINCA buyGame(oyunId) ÇALIŞTIRMA

        // BUYFORM / SATIN ALMA / FORM KAPATILDIĞINDA...

        void buyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            updateBalance();
        }

        // BUYFORM / SATIN ALMA / FORM KAPATILDIĞINDA...

        // ÜST PANEL / KÜTÜPHANE PANELİ

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
            adminPanel.Visible = false;
        }

        // ÜST PANEL / KÜTÜPHANE PANELİ

        // KÜTÜPHANE / BİLGİLERİ AKTAR

        void UpdateGameValues()
        {
            gamePBox.Image = null;
            gamePBox.Load(Convert.ToString((gameListBox.SelectedItem as DataRowView)["gameimgurl"]));
            minimumTextBox.Text = Convert.ToString((gameListBox.SelectedItem as DataRowView)["systemmin"]);
            recommendTextBox.Text = Convert.ToString((gameListBox.SelectedItem as DataRowView)["systemdef"]);
            gameInfoTextBox.Text = Convert.ToString((gameListBox.SelectedItem as DataRowView)["gameinfo"]);
            gameStaticsTextBox.Text = Convert.ToString((gameListBox.SelectedItem as DataRowView)["gamestatics"]);
        }

        // KÜTÜPHANE / BİLGİLERİ AKTAR

        // KÜTÜPHANE / SEÇİLİ OYUN DEĞİŞİNCE

        private void gameListBox_SelectedIndexChanged(object sender, EventArgs e) // oyun listesinde seçili oyun değiştirilmesi olayı
        {
            UpdateGameValues();
        }

        // KÜTÜPHANE / SEÇİLİ OYUN DEĞİŞİNCE

        // KÜTÜPHANE / OYUN ARAMA / İMLEÇ TEXTBOXTA TEMAS EDİNCE

        private void searchTBox_Enter(object sender, EventArgs e) // arama textbox'ın içine mouse'ın girmesi olayı
        {
            if (searchTBox.Text == "Oyun Arayın")
            {
                searchTBox.Text = "";
                searchTBox.ForeColor = Color.White;
            }
        }

        // KÜTÜPHANE / OYUN ARAMA / İMLEÇ TEXTBOXTA TEMAS EDİNCE

        // KÜTÜPHANE / OYUN ARAMA / İMLEÇ TEXTBOXTAN AYRILINCA

        private void searchTBox_Leave(object sender, EventArgs e) // arama textbox'ından mouse'ın uzaklaşması olayı
        {
            if (searchTBox.Text == "")
            {
                searchTBox.Text = "Oyun Arayın";
                searchTBox.ForeColor = Color.Gray;
            }
        }

        // MAINFORM / UYGULAMAYI KAPATMA / İMLEÇ BUTONDAN AYRILINCA

        // KÜTÜPHANE / OYUN ARAMA

        private void searchTBox_TextChanged(object sender, EventArgs e) // arama textbox'ının yazısının değişmesi olayı
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM libTable JOIN gameTable ON libTable.id = gameTable.gameId JOIN accTable ON gameTable.userId = accTable.id WHERE accTable.id = @id ORDER BY libTable.gamename ASC;", con);
            cmd.Parameters.AddWithValue("@id", myId);
            DataTable dt = new DataTable();

            con.Open();
            dt.Load(cmd.ExecuteReader());
            UpdateGameValues();
            con.Close();
            
            if (searchTBox.Text != "Oyun Arayın")
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = "gamename LIKE '%" + searchTBox.Text + "%'";
                gameListBox.DataSource = dv;
            }
        }

        // KÜTÜPHANE / OYUN ARAMA

        // VALORANT

        private void VALORANT()
        {
            try
            {
                string cdRiotGames = "cd C:\\Riot Games\\Riot Client\\";
                string runValorant = "RiotClientServices.exe --launch-product=valorant --launch-patchline=live";

                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                process.StandardInput.WriteLine(cdRiotGames);
                process.StandardInput.WriteLine(runValorant);
                process.StandardInput.Flush();
                process.StandardInput.Close();
                process.Close();
            }
            catch (Exception ex) { }
        }

        // VALORANT

        // KÜTÜPHANE / OYUNU BAŞLAT

        private void startButton_Click(object sender, EventArgs e) // oyun başlatma butonu
        {
            // fetchMyData(); // açılırsa her bastığımızda seviye artar

            if (int.Parse(myLevel) <= 999)
            {
                int tempLevel = int.Parse(myLevel);
                tempLevel++;

                SqlCommand cmd = new SqlCommand("UPDATE accTable SET level=@level WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@id", myId);
                cmd.Parameters.AddWithValue("@level", tempLevel.ToString());

                usrLevelLabel.Text = "Seviye: " + tempLevel.ToString();

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            GameForm gameForm = new GameForm();
            gameForm.ShowDialog();

            this.Hide();
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(10);

            if (Convert.ToString((gameListBox.SelectedItem as DataRowView)["gamename"]) == "VALORANT")
                VALORANT();
        }

        // KÜTÜPHANE / OYUNU BAŞLAT

        // ÜST PANEL / PROFİL PANELİ

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
            adminPanel.Visible = false;
        }

        // ÜST PANEL / PROFİL PANELİ

        // ÜST PANEL / YÖNETİM PANELİ

        private void adminPanelLabel_Click(object sender, EventArgs e)
        {
            selectedPanel.Visible = true;
            selectedPanel.Width = adminPanelLabel.Width - 12;
            selectedPanel.Top = adminPanelLabel.Bottom;
            selectedPanel.Left = adminPanelLabel.Left + 5;

            storePanel.Visible = false;
            libraryPanel.Visible = false;
            profilePanel.Visible = false;
            settingsPanel.Visible = false;
            friendPanel.Visible = false;
            adminPanel.Visible = true;
        }

        // ÜST PANEL / YÖNETİM PANELİ

        // YÖNETİM / KÜTÜPHANE YÖNETİMİ / GÖRÜNTÜLEME

        private void libMngLabel_Click(object sender, EventArgs e)
        {
            resetBannerBtn.Visible = false;
            libMngPanel.Visible = true;

            selectedPanel2.Width = libMngLabel.Width - 12;
            selectedPanel2.Top = libMngLabel.Bottom;
            selectedPanel2.Left = libMngLabel.Left + 5;
        }

        // YÖNETİM / KÜTÜPHANE YÖNETİMİ / GÖRÜNTÜLEME

        // YÖNETİM / HESAP YÖNETİMİ / GÖRÜNTÜLEME

        private void accMngLabel_Click(object sender, EventArgs e)
        {
            resetBannerBtn.Visible = true;
            libMngPanel.Visible = false;

            selectedPanel2.Width = accMngLabel.Width - 12;
            selectedPanel2.Top = accMngLabel.Bottom;
            selectedPanel2.Left = accMngLabel.Left + 5;
        }

        // YÖNETİM / HESAP YÖNETİMİ / GÖRÜNTÜLEME

        // YÖNETİM / KÜTÜPHANE YÖNETİMİ / SEÇİLİ HÜCRELERİ (DEĞERİ) AL

        int libSelectedIndex, accSelectedIndex, libSelectedValue, accSelectedValue;
        private void GetSelectedCellValue()
        {
            libSelectedIndex = Convert.ToInt32(libGridView.SelectedRows[0].Index);
            accSelectedIndex = Convert.ToInt32(accGridView.SelectedRows[0].Index);

            libSelectedValue = Convert.ToInt32(libGridView.SelectedRows[0].Cells[0].Value);
            accSelectedValue = Convert.ToInt32(accGridView.SelectedRows[0].Cells[0].Value);
        }

        // YÖNETİM / KÜTÜPHANE YÖNETİMİ / SEÇİLİ HÜCRELERİ (DEĞERİ) AL

        // YÖNETİM / KÜTÜPHANE YÖNETİMİ / OYUN EKLE

        private void libAddButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO libTable (gamename, gamecost, gameimgurl, systemmin, systemdef, gameinfo, gamestatics) VALUES (@gamename, @gamecost, @gameimgurl, @systemmin, @systemdef, @gameinfo, @gamestatics)", con);
            cmd.Parameters.AddWithValue("@gamename", gamenameTBox.Text);
            cmd.Parameters.AddWithValue("@gamecost", gamecostTBox.Text);
            cmd.Parameters.AddWithValue("@gameimgurl", gameimgurlTBox.Text);
            cmd.Parameters.AddWithValue("@systemmin", systemminTBox.Text);
            cmd.Parameters.AddWithValue("@systemdef", systemdefTBox.Text);
            cmd.Parameters.AddWithValue("@gameinfo", gameinfoTBox.Text);
            cmd.Parameters.AddWithValue("@gamestatics", gamestaticsTBox.Text);

            con.Open();
            cmd.ExecuteReader();
            con.Close();

            readLibTable();
        }

        // YÖNETİM / KÜTÜPHANE YÖNETİMİ / OYUN EKLE

        // YÖNETİM / KÜTÜPHANE YÖNETİMİ / OYUN GÜNCELLE

        private void libUpdButton_Click(object sender, EventArgs e)
        {
            GetSelectedCellValue();

            SqlCommand cmd = new SqlCommand("UPDATE libTable SET gamename=@gamename, gamecost=@gamecost, gameimgurl=@gameimgurl, systemmin=@systemmin, systemdef=@systemdef, gameinfo=@gameinfo, gamestatics=@gamestatics WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", libSelectedValue);
            cmd.Parameters.AddWithValue("@gamename", gamenameTBox.Text);
            cmd.Parameters.AddWithValue("@gamecost", gamecostTBox.Text);
            cmd.Parameters.AddWithValue("@gameimgurl", gameimgurlTBox.Text);
            cmd.Parameters.AddWithValue("@systemmin", systemminTBox.Text);
            cmd.Parameters.AddWithValue("@systemdef", systemdefTBox.Text);
            cmd.Parameters.AddWithValue("@gameinfo", gameinfoTBox.Text);
            cmd.Parameters.AddWithValue("@gamestatics", gamestaticsTBox.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            readLibTable();
        }

        // YÖNETİM / KÜTÜPHANE YÖNETİMİ / OYUN GÜNCELLE

        // YÖNETİM / KÜTÜPHANE YÖNETİMİ / OYUN SİL

        private void libDelButton_Click(object sender, EventArgs e)
        {
            GetSelectedCellValue();

            SqlCommand cmd = new SqlCommand("DELETE FROM libTable WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", libSelectedValue);

            con.Open();
            cmd.ExecuteReader();
            con.Close();

            readLibTable();
        }

        // YÖNETİM / KÜTÜPHANE YÖNETİMİ / OYUN SİL

        // YÖNETİM / KÜTÜPHANE YÖNETİMİ / OYUN VERİLERİNİ GETİR

        private void getValButton_Click(object sender, EventArgs e)
        {
            GetSelectedCellValue();

            gamenameTBox.Text = libGridView.Rows[libSelectedIndex].Cells[1].Value.ToString();
            gamecostTBox.Text = libGridView.Rows[libSelectedIndex].Cells[2].Value.ToString();
            gameimgurlTBox.Text = libGridView.Rows[libSelectedIndex].Cells[3].Value.ToString();
            systemminTBox.Text = libGridView.Rows[libSelectedIndex].Cells[4].Value.ToString();
            systemdefTBox.Text = libGridView.Rows[libSelectedIndex].Cells[5].Value.ToString();
            gameinfoTBox.Text = libGridView.Rows[libSelectedIndex].Cells[6].Value.ToString();
            gamestaticsTBox.Text = libGridView.Rows[libSelectedIndex].Cells[7].Value.ToString();
        }

        // YÖNETİM / KÜTÜPHANE YÖNETİMİ / OYUN VERİLERİNİ GETİR

        // YÖNETİM / HESAP YÖNETİMİ / HESAP EKLE

        private void accAddButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO accTable (username, email, password, level, rank, balance, firstname, explanation) VALUES (@username, @email, @password, @level, @rank, @balance, @firstname, @explanation)", con);
            cmd.Parameters.AddWithValue("@username", usernameTBox.Text);
            cmd.Parameters.AddWithValue("@email", emailTBox.Text);
            cmd.Parameters.AddWithValue("@password", passTBox.Text);
            cmd.Parameters.AddWithValue("@level", levelTBox.Text);
            cmd.Parameters.AddWithValue("@rank", rankTBox.Text);
            cmd.Parameters.AddWithValue("@balance", balanceTBox.Text);
            cmd.Parameters.AddWithValue("@firstname", firstnameTBox.Text);
            cmd.Parameters.AddWithValue("@explanation", explnTBox.Text);
            byte[] profilebytes = (byte[])(new ImageConverter()).ConvertTo(Resources.pp, typeof(byte[]));
            cmd.Parameters.Add("@profilepic", SqlDbType.VarBinary).Value = profilebytes;
            byte[] bannerbytes = (byte[])(new ImageConverter()).ConvertTo(Resources.banner, typeof(byte[]));
            cmd.Parameters.Add("@profilebanner", SqlDbType.VarBinary).Value = bannerbytes;

            con.Open();
            cmd.ExecuteReader();
            con.Close();

            readAccTable();
        }

        // YÖNETİM / HESAP YÖNETİMİ / HESAP EKLE

        // YÖNETİM / HESAP YÖNETİMİ / HESAP GÜNCELLE

        private void accUpdButton_Click(object sender, EventArgs e)
        {
            GetSelectedCellValue();

            SqlCommand cmd = new SqlCommand("UPDATE accTable SET username=@username, email=@email, password=@password, level=@level, rank=@rank, balance=@balance, firstname=@firstname, explanation=@explanation WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", accSelectedValue);
            cmd.Parameters.AddWithValue("@username", usernameTBox.Text);
            cmd.Parameters.AddWithValue("@email", emailTBox.Text);
            cmd.Parameters.AddWithValue("@password", passTBox.Text);
            cmd.Parameters.AddWithValue("@level", levelTBox.Text);
            cmd.Parameters.AddWithValue("@rank", rankTBox.Text);
            cmd.Parameters.AddWithValue("@balance", balanceTBox.Text);
            cmd.Parameters.AddWithValue("@firstname", firstnameTBox.Text);
            cmd.Parameters.AddWithValue("@explanation", explnTBox.Text);

            con.Open();
            cmd.ExecuteReader();
            con.Close();

            readAccTable();
        }

        // YÖNETİM / HESAP YÖNETİMİ / HESAP GÜNCELLE

        // YÖNETİM / HESAP YÖNETİMİ / HESAP SİL

        private void accDelButton_Click(object sender, EventArgs e)
        {
            GetSelectedCellValue();

            SqlCommand cmd = new SqlCommand("DELETE FROM accTable WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", accSelectedValue);

            con.Open();
            cmd.ExecuteReader();
            con.Close();

            readAccTable();
        }

        // YÖNETİM / HESAP YÖNETİMİ / HESAP SİL

        // YÖNETİM / HESAP YÖNETİMİ / HESAP VERİLERİNİ GETİR

        private void getAccButton_Click(object sender, EventArgs e)
        {
            GetSelectedCellValue();

            usernameTBox.Text = accGridView.Rows[accSelectedIndex].Cells[1].Value.ToString();
            emailTBox.Text = accGridView.Rows[accSelectedIndex].Cells[2].Value.ToString();
            passTBox.Text = accGridView.Rows[accSelectedIndex].Cells[3].Value.ToString();
            levelTBox.Text = accGridView.Rows[accSelectedIndex].Cells[4].Value.ToString();
            rankTBox.Text = accGridView.Rows[accSelectedIndex].Cells[5].Value.ToString();
            balanceTBox.Text = accGridView.Rows[accSelectedIndex].Cells[6].Value.ToString();
            firstnameTBox.Text = accGridView.Rows[accSelectedIndex].Cells[7].Value.ToString();
            explnTBox.Text = accGridView.Rows[accSelectedIndex].Cells[8].Value.ToString();
        }

        // YÖNETİM / HESAP YÖNETİMİ / HESAP VERİLERİNİ GETİR

        // YÖNETİM / HESAP YÖNETİMİ / PAROLAYI ŞİFRELE

        private void encryptPassText_Click(object sender, EventArgs e)
        {
            if (defPassTBox.Text != String.Empty)
            {
                encPassTBox.Text = MD5(defPassTBox.Text);
            }
        }

        // YÖNETİM / HESAP YÖNETİMİ / PAROLAYI ŞİFRELE

        // YÖNETİM / HESAP YÖNETİMİ / SEÇİLİ HESABIN PROFİL RESMİNİ KALDIR

        private void resetProPicBtn_Click(object sender, EventArgs e)
        {
            GetSelectedCellValue();

            con.Open();

            SqlCommand cmdRegister = new SqlCommand("UPDATE accTable SET profilepic=@profilepic WHERE id=@id", con);
            cmdRegister.Parameters.AddWithValue("@id", accSelectedValue);
            byte[] profilebytes = (byte[])(new ImageConverter()).ConvertTo(Resources.pp, typeof(byte[]));
            cmdRegister.Parameters.Add("@profilepic", SqlDbType.VarBinary).Value = profilebytes;

            cmdRegister.ExecuteReader();
            con.Close();

            if (myId == accSelectedValue)
            {
                profileImage.Image = Resources.pp;
                profilePicBox.Image = Resources.pp;
                editProfilePicBox.Image = Resources.pp;
            }
            

            MessageBox.Show("Id numarası " + accSelectedValue + " olan kullanıcının profili sıfırlandı.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // YÖNETİM / HESAP YÖNETİMİ / SEÇİLİ HESABIN PROFİL RESMİNİ KALDIR

        // YÖNETİM / HESAP YÖNETİMİ / SEÇİLİ HESABIN ARKAPLAN RESMİNİ KALDIR

        private void resetBanPicBtn_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmdRegister = new SqlCommand("UPDATE accTable SET profilebanner=@profilebanner WHERE id=@id", con);
            cmdRegister.Parameters.AddWithValue("@id", accSelectedValue);
            byte[] bannerbytes = (byte[])(new ImageConverter()).ConvertTo(Resources.banner, typeof(byte[]));
            cmdRegister.Parameters.Add("@profilebanner", SqlDbType.VarBinary).Value = bannerbytes;

            cmdRegister.ExecuteReader();
            con.Close();

            if (myId == accSelectedValue)
            {
                editBannerPicBox.Image = Resources.banner;
                profileBannerPicBox.Image = Resources.banner;
            }

            MessageBox.Show("Id numarası " + accSelectedValue + " olan kullanıcının bannerı sıfırlandı.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        // YÖNETİM / HESAP YÖNETİMİ / SEÇİLİ HESABIN ARKAPLAN RESMİNİ KALDIR

        // ALT BAR / AYARLAR / GÖRÜNTÜLEME

        private void mngDlsLabel_Click(object sender, EventArgs e)
        {
            selectedPanel.Visible = false;

            friendPanel.Visible = false;
            storePanel.Visible = false;
            libraryPanel.Visible = false;
            profilePanel.Visible = false;
            settingsPanel.Visible = true;
            adminPanel.Visible = false;
        }

        // ALT BAR / AYARLAR / GÖRÜNTÜLEME

        // ALT BAR / ARKADAŞLAR / GÖRÜNTÜLEME

        private void friendsLabel_Click(object sender, EventArgs e)
        {
            storePanel.Visible = false;
            libraryPanel.Visible = false;
            profilePanel.Visible = false;
            settingsPanel.Visible = false;
            friendPanel.Visible = true;
            adminPanel.Visible = false;
        }

        // ALT BAR / ARKADAŞLAR / GÖRÜNTÜLEME

        bool profileSelected = false, bannerSelected = false;
        Image pictureImg, bannerImg;

        // AYARLAR / PROFİL RESMİ DEĞİŞİMİ

        byte[] picbytes;
        private void editProfilePic_Click(object sender, EventArgs e) // profil fotoğrafını düzenle
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureImg = Image.FromFile(openFileDialog1.FileName);

                picbytes = (byte[])(new ImageConverter()).ConvertTo(pictureImg, typeof(byte[]));
                profileSelected = true;
            }

            editProfilePicBox.Image = pictureImg;
        }

        // AYARLAR / PROFİL RESMİ DEĞİŞİMİ

        // AYARLAR / ARKAPLAN RESMİ DEĞİŞİMİ

        byte[] banbytes;
        private void editBannerPic_Click(object sender, EventArgs e) // profil arkaplanını düzenle
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bannerImg = Image.FromFile(openFileDialog1.FileName);

                banbytes = (byte[])(new ImageConverter()).ConvertTo(bannerImg, typeof(byte[]));
                bannerSelected = true;
            }

            editBannerPicBox.Image = bannerImg;
        }

        // AYARLAR / ARKAPLAN RESMİ DEĞİŞİMİ

        // AYARLAR / DEĞİŞİKLİKLERİ KAYDET

        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            string command = "UPDATE accTable SET email=@email, password=@password, firstname=@firstname, explanation=@explanation, profilepic=@profilepic, profilebanner=@profilebanner";
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

            fetchMyData();

            if (editFNameTextBox.Text != null) editFNameTextBox.Text = myFirstname;
            if (editBioTextBox.Text != null) editBioTextBox.Text = myExplanation;

            profileUserLabel.Text = myUsername;
            editUserTextBox.Text = myUsername;
            emailTextBox.Text = myEmail;
            explanationTBox.Text = myExplanation;
        }

        // AYARLAR / DEĞİŞİKLİKLERİ KAYDET

        // ARKADAŞLAR / ARKADAŞ EKLE

        private void addFriendBtn_Click(object sender, EventArgs e)
        {
            bool ifUserCorrect = false;
            SqlCommand cmdIfUser = new SqlCommand("SELECT username FROM accTable WHERE username=@username", con);
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

        // ARKADAŞLAR / ARKADAŞ EKLE

        // ARKADAŞLAR / ARKADAŞ ÇIKAR

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

        // ARKADAŞLAR / ARKADAŞ ÇIKAR
    }
}