using YaltaCore.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GameLibraryAutomation
{

    public partial class UserForm : Form
    {
        // SQL BAĞLANTISI İÇİN GEREKEN CONNECTIONSTRING

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=YaltaCoreDb;Integrated Security=True");

        // SQL BAĞLANTISI İÇİN GEREKEN CONNECTIONSTRING

        public static bool isLoggedIn = false;

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public UserForm()
        {
            InitializeComponent();
        }

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

        private void LoginForm_Load(object sender, EventArgs e)
        {
            loginPanel.Visible = true;
            registerPanel.Visible = false;
            resetPanel.Visible = false;

            //showLPassBox.Checked = true;

            //usernameLTBox.Text = "lithellx";
            //passwordLTBox.Text = "alp";
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            registerPanel.Visible = true;
            resetPanel.Visible = false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.BackColor = topPanel.BackColor;
        }

        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.FromArgb(160, 0, 0);
        }

        // Login

        private void usernameTBox_Enter(object sender, EventArgs e)
        {
            if(usernameLTBox.Text == "Kullanıcı Adı")
            {
                usernameLTBox.Text = "";
                usernameLTBox.Multiline = false;
                usernameLTBox.ForeColor = Color.White;
            }
        }

        private void usernameTBox_Leave(object sender, EventArgs e)
        {
            if (usernameLTBox.Text == "")
            {
                usernameLTBox.Text = "Kullanıcı Adı";
                usernameLTBox.Multiline = true;
                usernameLTBox.ForeColor = Color.Gray;
            }
        }

        private void passwordTBox_Enter(object sender, EventArgs e)
        {
            if (passwordLTBox.Text == "Şifre")
            {
                passwordLTBox.Text = "";
                passwordLTBox.Multiline = false;
                passwordLTBox.PasswordChar = '*';
                passwordLTBox.ForeColor = Color.White;
            }
        }

        private void passwordTBox_Leave(object sender, EventArgs e)
        {
            if (passwordLTBox.Text == "")
            {
                passwordLTBox.Text = "Şifre";
                passwordLTBox.Multiline = true;
                passwordLTBox.PasswordChar = ' ';
                passwordLTBox.ForeColor = Color.Gray;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            username.Text = usernameLTBox.Text;

            if ((usernameLTBox.Text != "Kullanıcı Adı" || passwordLTBox.Text != "Şifre") && (usernameLTBox.Text != string.Empty || passwordLTBox.Text != string.Empty))
            {
                SqlCommand cmd = new SqlCommand("SELECT username, password FROM accTable WHERE username=@username AND password=@password", con);
                cmd.Parameters.AddWithValue("@username", usernameLTBox.Text);
                cmd.Parameters.AddWithValue("@password", MD5(passwordLTBox.Text));

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    //MessageBox.Show("Giriş başarılı! Hoş geldiniz, " + usernameLTBox.Text, "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isLoggedIn = true;

                    MainForm mainForm = new MainForm();
                    mainForm.userLabel.Text = usernameLTBox.Text;
                    mainForm.profileUserLabel.Text = usernameLTBox.Text;

                    con.Close();

                    this.Close();
                    mainForm.Show();

                    username.Text = usernameLTBox.Text;
                }
                else
                {
                    con.Close();
                    MessageBox.Show("Hatalı kullanıcı adı veya şifre girdiniz!", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Kullanıcı adı veya şifre alanını boş bıraktınız!", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Register

        private void loginLabel_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = true;
            registerPanel.Visible = false;
            resetPanel.Visible = false;
        }

        private void usernameRTBox_Enter(object sender, EventArgs e)
        {
            if (usernameRTBox.Text == "Kullanıcı Adı")
            {
                usernameRTBox.Text = "";
                usernameRTBox.Multiline = false;
                usernameRTBox.ForeColor = Color.White;
            }
        }

        private void usernameRTBox_Leave(object sender, EventArgs e)
        {
            if (usernameRTBox.Text == "")
            {
                usernameRTBox.Text = "Kullanıcı Adı";
                usernameRTBox.Multiline = true;
                usernameRTBox.ForeColor = Color.Gray;
            }
        }

        private void emailRTBox_Enter(object sender, EventArgs e)
        {
            if (emailRTBox.Text == "E-posta")
            {
                emailRTBox.Text = "";
                emailRTBox.ForeColor = Color.White;
            }
        }

        private void emailRTBox_Leave(object sender, EventArgs e)
        {
            if (emailRTBox.Text == "")
            {
                emailRTBox.Text = "E-posta";
                emailRTBox.ForeColor = Color.Gray;
            }
        }

        private void passwordRTBox_Enter(object sender, EventArgs e)
        {
            if (passwordRTBox.Text == "Şifre")
            {
                passwordRTBox.Text = "";
                passwordRTBox.Multiline = false;
                passwordLTBox.PasswordChar = '*';
                passwordRTBox.ForeColor = Color.White;
            }
        }

        private void passwordRTBox_Leave(object sender, EventArgs e)
        {
            if (passwordRTBox.Text == "")
            {
                passwordRTBox.Text = "Şifre";
                passwordRTBox.Multiline = true;
                passwordLTBox.PasswordChar = ' ';
                passwordRTBox.ForeColor = Color.Gray;
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if ((usernameRTBox.Text != "Kullanıcı Adı" || emailRTBox.Text != "E-posta") && (usernameRTBox.Text != string.Empty || emailRTBox.Text != string.Empty))
            {
                SqlCommand cmdLogin = new SqlCommand("SELECT username, email FROM accTable WHERE username=@username AND email=@email", con);
                cmdLogin.Parameters.AddWithValue("@username", usernameRTBox.Text);
                cmdLogin.Parameters.AddWithValue("@email", emailRTBox.Text);

                con.Open();

                SqlDataReader dr = cmdLogin.ExecuteReader();

                if (dr.HasRows)
                    MessageBox.Show("Bu kullanıcı adı veya e-posta adresi zaten mevcut!", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    con.Close();
                    con.Open();

                    SqlCommand cmdRegister = new SqlCommand("INSERT INTO accTable (username, email, password, level, rank, balance, profilepic, profilebanner) VALUES (@username, @email, @password, @level, @rank, @balance, @profilepic, @profilebanner)", con);
                    cmdRegister.Parameters.AddWithValue("@username", usernameRTBox.Text);
                    cmdRegister.Parameters.AddWithValue("@email", emailRTBox.Text);
                    cmdRegister.Parameters.AddWithValue("@password", MD5(passwordRTBox.Text));
                    cmdRegister.Parameters.AddWithValue("@level", "1");
                    cmdRegister.Parameters.AddWithValue("@rank", "user");
                    cmdRegister.Parameters.AddWithValue("@balance", "100");
                    byte[] profilebytes = (byte[])(new ImageConverter()).ConvertTo(Resources.profile, typeof(byte[]));
                    cmdRegister.Parameters.Add("@profilepic", SqlDbType.VarBinary).Value = profilebytes;
                    byte[] bannerbytes = (byte[])(new ImageConverter()).ConvertTo(Resources.banner, typeof(byte[]));
                    cmdRegister.Parameters.Add("@profilebanner", SqlDbType.VarBinary).Value = bannerbytes;
                    

                    cmdRegister.ExecuteReader();
                    con.Close();

                    MessageBox.Show("Kaydınız başarıyla oluşturuldu. Lütfen giriş yapın.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    loginPanel.Visible = true;
                    registerPanel.Visible = false;
                    resetPanel.Visible = false;
                }
            }
            else
                MessageBox.Show("Kullanıcı adı veya şifre alanını boş bıraktınız!", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Reset Password

        private void resetLabelR_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            registerPanel.Visible = false;
            resetPanel.Visible = true;
        }
        private void resetPwLabel_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            registerPanel.Visible = false;
            resetPanel.Visible = true;
        }

        private void emailResTBox_Enter(object sender, EventArgs e)
        {
            if (emailResTBox.Text == "E-posta")
            {
                emailResTBox.Text = "";
                emailResTBox.ForeColor = Color.White;
            }
        }

        private void emailResTBox_Leave(object sender, EventArgs e)
        {
            if (emailResTBox.Text == "")
            {
                emailResTBox.Text = "E-posta";
                emailResTBox.ForeColor = Color.Gray;
            }
        }

        private void resLoginButton_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = true;
            registerPanel.Visible = false;
            resetPanel.Visible = false;
        }

        private void resRegisterButton_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            registerPanel.Visible = true;
            resetPanel.Visible = false;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (emailResTBox.Text != "E-posta" && emailResTBox.Text != string.Empty)
            {
                SqlCommand cmd = new SqlCommand("SELECT email FROM accTable WHERE email=@email", con);
                cmd.Parameters.AddWithValue("@email", emailResTBox.Text);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    MessageBox.Show(emailResTBox.Text + " adresine şifre sıfırlama bağlantısı gönderildi.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    emailResTBox.Text = string.Empty;

                    loginPanel.Visible = true;
                    registerPanel.Visible = false;
                    resetPanel.Visible = false;
                }
                else
                    MessageBox.Show("Girdiğinz e-posta adresi bulunamadı!", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }
            else
                MessageBox.Show("Kullanıcı adı veya şifre alanını boş bıraktınız!", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            emailResTBox.Text = string.Empty;

            loginPanel.Visible = true;
            registerPanel.Visible = false;
            resetPanel.Visible = false;
        }
    }
}