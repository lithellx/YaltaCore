namespace GameLibraryAutomation
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.topPanel = new System.Windows.Forms.Panel();
            this.appLogo = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.Label();
            this.storeLabel = new System.Windows.Forms.Label();
            this.accLabel1 = new System.Windows.Forms.Label();
            this.regLabel = new System.Windows.Forms.Label();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.resetPwLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.passwordLTBox = new System.Windows.Forms.TextBox();
            this.usernameLTBox = new System.Windows.Forms.TextBox();
            this.userPBox = new System.Windows.Forms.PictureBox();
            this.registerPanel = new System.Windows.Forms.Panel();
            this.emailRTBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.registerButton = new System.Windows.Forms.Button();
            this.passwordRTBox = new System.Windows.Forms.TextBox();
            this.usernameRTBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.resetPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.emailResTBox = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appLogo)).BeginInit();
            this.loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPBox)).BeginInit();
            this.registerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.resetPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.topPanel.Controls.Add(this.appLogo);
            this.topPanel.Controls.Add(this.buttonClose);
            this.topPanel.Controls.Add(this.buttonMinimize);
            this.topPanel.Controls.Add(this.username);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(800, 33);
            this.topPanel.TabIndex = 0;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseUp);
            // 
            // appLogo
            // 
            this.appLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.appLogo.Image = global::YaltaCore.Properties.Resources.icon;
            this.appLogo.Location = new System.Drawing.Point(3, 3);
            this.appLogo.Name = "appLogo";
            this.appLogo.Size = new System.Drawing.Size(27, 28);
            this.appLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.appLogo.TabIndex = 23;
            this.appLogo.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.buttonClose.Image = ((System.Drawing.Image)(resources.GetObject("buttonClose.Image")));
            this.buttonClose.Location = new System.Drawing.Point(774, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.buttonClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonClose.Size = new System.Drawing.Size(24, 26);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonClose.MouseEnter += new System.EventHandler(this.buttonClose_MouseEnter);
            this.buttonClose.MouseLeave += new System.EventHandler(this.buttonClose_MouseLeave);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.buttonMinimize.Image = ((System.Drawing.Image)(resources.GetObject("buttonMinimize.Image")));
            this.buttonMinimize.Location = new System.Drawing.Point(745, 2);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.buttonMinimize.Size = new System.Drawing.Size(24, 26);
            this.buttonMinimize.TabIndex = 4;
            this.buttonMinimize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonMinimize.UseVisualStyleBackColor = true;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.username.Location = new System.Drawing.Point(174, 15);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(0, 13);
            this.username.TabIndex = 22;
            // 
            // storeLabel
            // 
            this.storeLabel.AutoSize = true;
            this.storeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.storeLabel.ForeColor = System.Drawing.Color.White;
            this.storeLabel.Location = new System.Drawing.Point(12, 3);
            this.storeLabel.Name = "storeLabel";
            this.storeLabel.Size = new System.Drawing.Size(260, 29);
            this.storeLabel.TabIndex = 8;
            this.storeLabel.Text = "YaltaCore - Giriş Yap";
            // 
            // accLabel1
            // 
            this.accLabel1.AutoSize = true;
            this.accLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.accLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.accLabel1.ForeColor = System.Drawing.Color.White;
            this.accLabel1.Location = new System.Drawing.Point(588, 13);
            this.accLabel1.Name = "accLabel1";
            this.accLabel1.Size = new System.Drawing.Size(137, 16);
            this.accLabel1.TabIndex = 9;
            this.accLabel1.Text = "Hesabınız yok mu?";
            // 
            // regLabel
            // 
            this.regLabel.AutoSize = true;
            this.regLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.regLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.regLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(3)))));
            this.regLabel.Location = new System.Drawing.Point(723, 13);
            this.regLabel.Name = "regLabel";
            this.regLabel.Size = new System.Drawing.Size(74, 16);
            this.regLabel.TabIndex = 10;
            this.regLabel.Text = "Kayıt olun";
            this.regLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.storeLabel);
            this.loginPanel.Controls.Add(this.resetPwLabel);
            this.loginPanel.Controls.Add(this.label2);
            this.loginPanel.Controls.Add(this.loginButton);
            this.loginPanel.Controls.Add(this.passwordLTBox);
            this.loginPanel.Controls.Add(this.usernameLTBox);
            this.loginPanel.Controls.Add(this.userPBox);
            this.loginPanel.Controls.Add(this.regLabel);
            this.loginPanel.Controls.Add(this.accLabel1);
            this.loginPanel.Location = new System.Drawing.Point(0, 39);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(800, 563);
            this.loginPanel.TabIndex = 17;
            // 
            // resetPwLabel
            // 
            this.resetPwLabel.AutoSize = true;
            this.resetPwLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.resetPwLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.resetPwLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(3)))));
            this.resetPwLabel.Location = new System.Drawing.Point(447, 374);
            this.resetPwLabel.Name = "resetPwLabel";
            this.resetPwLabel.Size = new System.Drawing.Size(47, 16);
            this.resetPwLabel.TabIndex = 21;
            this.resetPwLabel.Text = "Sıfırla";
            this.resetPwLabel.Click += new System.EventHandler(this.resetPwLabel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(318, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Şifreni mi unuttun?";
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(3)))));
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loginButton.Location = new System.Drawing.Point(281, 334);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(252, 28);
            this.loginButton.TabIndex = 19;
            this.loginButton.Text = "Giriş Yap";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // passwordLTBox
            // 
            this.passwordLTBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.passwordLTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordLTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.passwordLTBox.ForeColor = System.Drawing.Color.Gray;
            this.passwordLTBox.Location = new System.Drawing.Point(214, 296);
            this.passwordLTBox.Multiline = true;
            this.passwordLTBox.Name = "passwordLTBox";
            this.passwordLTBox.PasswordChar = '*';
            this.passwordLTBox.Size = new System.Drawing.Size(383, 28);
            this.passwordLTBox.TabIndex = 18;
            this.passwordLTBox.Text = "Şifre";
            this.passwordLTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordLTBox.UseSystemPasswordChar = true;
            this.passwordLTBox.Enter += new System.EventHandler(this.passwordTBox_Enter);
            this.passwordLTBox.Leave += new System.EventHandler(this.passwordTBox_Leave);
            // 
            // usernameLTBox
            // 
            this.usernameLTBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.usernameLTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameLTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.usernameLTBox.ForeColor = System.Drawing.Color.Gray;
            this.usernameLTBox.Location = new System.Drawing.Point(214, 257);
            this.usernameLTBox.Multiline = true;
            this.usernameLTBox.Name = "usernameLTBox";
            this.usernameLTBox.Size = new System.Drawing.Size(383, 28);
            this.usernameLTBox.TabIndex = 17;
            this.usernameLTBox.Text = "Kullanıcı Adı";
            this.usernameLTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.usernameLTBox.Enter += new System.EventHandler(this.usernameTBox_Enter);
            this.usernameLTBox.Leave += new System.EventHandler(this.usernameTBox_Leave);
            // 
            // userPBox
            // 
            this.userPBox.Image = global::YaltaCore.Properties.Resources.logo;
            this.userPBox.Location = new System.Drawing.Point(214, 43);
            this.userPBox.Name = "userPBox";
            this.userPBox.Size = new System.Drawing.Size(383, 238);
            this.userPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userPBox.TabIndex = 16;
            this.userPBox.TabStop = false;
            // 
            // registerPanel
            // 
            this.registerPanel.Controls.Add(this.emailRTBox);
            this.registerPanel.Controls.Add(this.label3);
            this.registerPanel.Controls.Add(this.registerButton);
            this.registerPanel.Controls.Add(this.passwordRTBox);
            this.registerPanel.Controls.Add(this.usernameRTBox);
            this.registerPanel.Controls.Add(this.pictureBox1);
            this.registerPanel.Controls.Add(this.loginLabel);
            this.registerPanel.Controls.Add(this.label7);
            this.registerPanel.Location = new System.Drawing.Point(0, 39);
            this.registerPanel.Name = "registerPanel";
            this.registerPanel.Size = new System.Drawing.Size(800, 563);
            this.registerPanel.TabIndex = 18;
            // 
            // emailRTBox
            // 
            this.emailRTBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.emailRTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailRTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.emailRTBox.ForeColor = System.Drawing.Color.Gray;
            this.emailRTBox.Location = new System.Drawing.Point(214, 292);
            this.emailRTBox.Multiline = true;
            this.emailRTBox.Name = "emailRTBox";
            this.emailRTBox.Size = new System.Drawing.Size(383, 28);
            this.emailRTBox.TabIndex = 27;
            this.emailRTBox.TabStop = false;
            this.emailRTBox.Text = "E-Posta";
            this.emailRTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.emailRTBox.Enter += new System.EventHandler(this.emailRTBox_Enter);
            this.emailRTBox.Leave += new System.EventHandler(this.emailRTBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 29);
            this.label3.TabIndex = 22;
            this.label3.Text = "YaltaCore - Kayıt Ol";
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(3)))));
            this.registerButton.FlatAppearance.BorderSize = 0;
            this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.registerButton.ForeColor = System.Drawing.Color.White;
            this.registerButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.registerButton.Location = new System.Drawing.Point(281, 366);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(252, 28);
            this.registerButton.TabIndex = 29;
            this.registerButton.TabStop = false;
            this.registerButton.Text = "Kayıt Ol";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // passwordRTBox
            // 
            this.passwordRTBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.passwordRTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordRTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.passwordRTBox.ForeColor = System.Drawing.Color.Gray;
            this.passwordRTBox.Location = new System.Drawing.Point(214, 328);
            this.passwordRTBox.Multiline = true;
            this.passwordRTBox.Name = "passwordRTBox";
            this.passwordRTBox.PasswordChar = '*';
            this.passwordRTBox.Size = new System.Drawing.Size(383, 28);
            this.passwordRTBox.TabIndex = 28;
            this.passwordRTBox.TabStop = false;
            this.passwordRTBox.Text = "Şifre";
            this.passwordRTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordRTBox.UseSystemPasswordChar = true;
            this.passwordRTBox.Enter += new System.EventHandler(this.passwordRTBox_Enter);
            this.passwordRTBox.Leave += new System.EventHandler(this.passwordRTBox_Leave);
            // 
            // usernameRTBox
            // 
            this.usernameRTBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.usernameRTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameRTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.usernameRTBox.ForeColor = System.Drawing.Color.Gray;
            this.usernameRTBox.Location = new System.Drawing.Point(214, 257);
            this.usernameRTBox.Multiline = true;
            this.usernameRTBox.Name = "usernameRTBox";
            this.usernameRTBox.Size = new System.Drawing.Size(383, 28);
            this.usernameRTBox.TabIndex = 26;
            this.usernameRTBox.TabStop = false;
            this.usernameRTBox.Text = "Kullanıcı Adı";
            this.usernameRTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.usernameRTBox.Enter += new System.EventHandler(this.usernameRTBox_Enter);
            this.usernameRTBox.Leave += new System.EventHandler(this.usernameRTBox_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::YaltaCore.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(214, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(383, 238);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.loginLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(3)))));
            this.loginLabel.Location = new System.Drawing.Point(716, 13);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(81, 16);
            this.loginLabel.TabIndex = 24;
            this.loginLabel.Text = "Giriş yapın";
            this.loginLabel.Click += new System.EventHandler(this.loginLabel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(588, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "Hesabınız var mı?";
            // 
            // resetPanel
            // 
            this.resetPanel.Controls.Add(this.closeButton);
            this.resetPanel.Controls.Add(this.label8);
            this.resetPanel.Controls.Add(this.label1);
            this.resetPanel.Controls.Add(this.resetButton);
            this.resetPanel.Controls.Add(this.emailResTBox);
            this.resetPanel.Controls.Add(this.pictureBox2);
            this.resetPanel.Location = new System.Drawing.Point(0, 39);
            this.resetPanel.Name = "resetPanel";
            this.resetPanel.Size = new System.Drawing.Size(800, 563);
            this.resetPanel.TabIndex = 19;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeButton.Location = new System.Drawing.Point(281, 376);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(252, 24);
            this.closeButton.TabIndex = 39;
            this.closeButton.TabStop = false;
            this.closeButton.Text = "Vazgeç";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(92, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(620, 16);
            this.label8.TabIndex = 37;
            this.label8.Text = "Eğer girilen E-posta adresi mevcutsa adresinize şifre sıfırlama bağlantısı gönder" +
    "ilecektir.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 29);
            this.label1.TabIndex = 30;
            this.label1.Text = "YaltaCore - Şifre Sıfırla";
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(3)))));
            this.resetButton.FlatAppearance.BorderSize = 0;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.resetButton.ForeColor = System.Drawing.Color.White;
            this.resetButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.resetButton.Location = new System.Drawing.Point(281, 342);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(252, 28);
            this.resetButton.TabIndex = 35;
            this.resetButton.TabStop = false;
            this.resetButton.Text = "Gönder";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // emailResTBox
            // 
            this.emailResTBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.emailResTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailResTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.emailResTBox.ForeColor = System.Drawing.Color.Gray;
            this.emailResTBox.Location = new System.Drawing.Point(214, 302);
            this.emailResTBox.Multiline = true;
            this.emailResTBox.Name = "emailResTBox";
            this.emailResTBox.Size = new System.Drawing.Size(383, 28);
            this.emailResTBox.TabIndex = 34;
            this.emailResTBox.TabStop = false;
            this.emailResTBox.Text = "E-posta";
            this.emailResTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.emailResTBox.Enter += new System.EventHandler(this.emailResTBox_Enter);
            this.emailResTBox.Leave += new System.EventHandler(this.emailResTBox_Leave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::YaltaCore.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(214, 43);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(383, 238);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.resetPanel);
            this.Controls.Add(this.registerPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YaltaCore";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appLogo)).EndInit();
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPBox)).EndInit();
            this.registerPanel.ResumeLayout(false);
            this.registerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.resetPanel.ResumeLayout(false);
            this.resetPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.PictureBox userPBox;
        private System.Windows.Forms.Label storeLabel;
        private System.Windows.Forms.Label accLabel1;
        private System.Windows.Forms.Label regLabel;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.TextBox passwordLTBox;
        private System.Windows.Forms.Panel registerPanel;
        private System.Windows.Forms.Panel resetPanel;
        private System.Windows.Forms.Label resetPwLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loginButton;
        public System.Windows.Forms.TextBox usernameLTBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.TextBox passwordRTBox;
        public System.Windows.Forms.TextBox usernameRTBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox emailRTBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button resetButton;
        public System.Windows.Forms.TextBox emailResTBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Label username;
        private System.Windows.Forms.PictureBox appLogo;
        private System.Windows.Forms.Button closeButton;
    }
}