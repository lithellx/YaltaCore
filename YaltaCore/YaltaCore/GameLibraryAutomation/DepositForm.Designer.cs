namespace GameLibraryAutomation
{
    partial class DepositForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepositForm));
            this.closeButton = new System.Windows.Forms.Button();
            this.payButton = new System.Windows.Forms.Button();
            this.gameNameLabel = new System.Windows.Forms.Label();
            this.moneyCountTBox = new System.Windows.Forms.TextBox();
            this.accLabel1 = new System.Windows.Forms.Label();
            this.cardYearLabel = new System.Windows.Forms.Label();
            this.cardMonthLabel = new System.Windows.Forms.Label();
            this.slashLabel = new System.Windows.Forms.Label();
            this.cardNameLabel = new System.Windows.Forms.Label();
            this.cardCvvLabel = new System.Windows.Forms.Label();
            this.cardNumLabel = new System.Windows.Forms.Label();
            this.turnAroundButton = new System.Windows.Forms.Button();
            this.ccfPictureBox = new System.Windows.Forms.PictureBox();
            this.ccbPictureBox = new System.Windows.Forms.PictureBox();
            this.cardNameTBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cvvTBox = new System.Windows.Forms.TextBox();
            this.cardNumTBox = new System.Windows.Forms.MaskedTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ccfPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeButton.Location = new System.Drawing.Point(300, 547);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(261, 24);
            this.closeButton.TabIndex = 87;
            this.closeButton.TabStop = false;
            this.closeButton.Text = "Vazgeç";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // payButton
            // 
            this.payButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(3)))));
            this.payButton.FlatAppearance.BorderSize = 0;
            this.payButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.payButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.payButton.ForeColor = System.Drawing.Color.White;
            this.payButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.payButton.Location = new System.Drawing.Point(300, 509);
            this.payButton.Name = "payButton";
            this.payButton.Size = new System.Drawing.Size(261, 32);
            this.payButton.TabIndex = 86;
            this.payButton.TabStop = false;
            this.payButton.Text = "Yatır";
            this.payButton.UseVisualStyleBackColor = false;
            this.payButton.Click += new System.EventHandler(this.payButton_Click);
            // 
            // gameNameLabel
            // 
            this.gameNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gameNameLabel.ForeColor = System.Drawing.Color.White;
            this.gameNameLabel.Location = new System.Drawing.Point(300, 360);
            this.gameNameLabel.Name = "gameNameLabel";
            this.gameNameLabel.Size = new System.Drawing.Size(275, 69);
            this.gameNameLabel.TabIndex = 44;
            this.gameNameLabel.Text = "Miktar Girin";
            this.gameNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // moneyCountTBox
            // 
            this.moneyCountTBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.moneyCountTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moneyCountTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.moneyCountTBox.ForeColor = System.Drawing.Color.Gray;
            this.moneyCountTBox.Location = new System.Drawing.Point(369, 441);
            this.moneyCountTBox.MaxLength = 7;
            this.moneyCountTBox.Multiline = true;
            this.moneyCountTBox.Name = "moneyCountTBox";
            this.moneyCountTBox.Size = new System.Drawing.Size(113, 31);
            this.moneyCountTBox.TabIndex = 85;
            this.moneyCountTBox.TabStop = false;
            this.moneyCountTBox.Text = "0";
            this.moneyCountTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moneyCountTBox.Enter += new System.EventHandler(this.moneyCountTBox_Enter);
            this.moneyCountTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.moneyCountTBox_KeyPress);
            this.moneyCountTBox.Leave += new System.EventHandler(this.moneyCountTBox_Leave);
            // 
            // accLabel1
            // 
            this.accLabel1.AutoSize = true;
            this.accLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.accLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.accLabel1.ForeColor = System.Drawing.Color.White;
            this.accLabel1.Location = new System.Drawing.Point(482, 444);
            this.accLabel1.Name = "accLabel1";
            this.accLabel1.Size = new System.Drawing.Size(25, 25);
            this.accLabel1.TabIndex = 46;
            this.accLabel1.Text = "₺";
            // 
            // cardYearLabel
            // 
            this.cardYearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cardYearLabel.ForeColor = System.Drawing.Color.White;
            this.cardYearLabel.Location = new System.Drawing.Point(219, 215);
            this.cardYearLabel.Name = "cardYearLabel";
            this.cardYearLabel.Size = new System.Drawing.Size(39, 32);
            this.cardYearLabel.TabIndex = 67;
            this.cardYearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardMonthLabel
            // 
            this.cardMonthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cardMonthLabel.ForeColor = System.Drawing.Color.White;
            this.cardMonthLabel.Location = new System.Drawing.Point(172, 215);
            this.cardMonthLabel.Name = "cardMonthLabel";
            this.cardMonthLabel.Size = new System.Drawing.Size(39, 32);
            this.cardMonthLabel.TabIndex = 66;
            this.cardMonthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // slashLabel
            // 
            this.slashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.slashLabel.ForeColor = System.Drawing.Color.White;
            this.slashLabel.Location = new System.Drawing.Point(172, 215);
            this.slashLabel.Name = "slashLabel";
            this.slashLabel.Size = new System.Drawing.Size(86, 32);
            this.slashLabel.TabIndex = 65;
            this.slashLabel.Text = "/";
            this.slashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardNameLabel
            // 
            this.cardNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cardNameLabel.ForeColor = System.Drawing.Color.White;
            this.cardNameLabel.Location = new System.Drawing.Point(33, 250);
            this.cardNameLabel.Name = "cardNameLabel";
            this.cardNameLabel.Size = new System.Drawing.Size(330, 32);
            this.cardNameLabel.TabIndex = 64;
            this.cardNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cardCvvLabel
            // 
            this.cardCvvLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cardCvvLabel.ForeColor = System.Drawing.Color.Black;
            this.cardCvvLabel.Location = new System.Drawing.Point(381, 107);
            this.cardCvvLabel.Name = "cardCvvLabel";
            this.cardCvvLabel.Size = new System.Drawing.Size(51, 32);
            this.cardCvvLabel.TabIndex = 63;
            this.cardCvvLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardNumLabel
            // 
            this.cardNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cardNumLabel.ForeColor = System.Drawing.Color.White;
            this.cardNumLabel.Location = new System.Drawing.Point(32, 163);
            this.cardNumLabel.Name = "cardNumLabel";
            this.cardNumLabel.Size = new System.Drawing.Size(340, 40);
            this.cardNumLabel.TabIndex = 62;
            this.cardNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // turnAroundButton
            // 
            this.turnAroundButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.turnAroundButton.FlatAppearance.BorderSize = 0;
            this.turnAroundButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.turnAroundButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.turnAroundButton.Image = global::YaltaCore.Properties.Resources.turnaround;
            this.turnAroundButton.Location = new System.Drawing.Point(550, 12);
            this.turnAroundButton.Name = "turnAroundButton";
            this.turnAroundButton.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.turnAroundButton.Size = new System.Drawing.Size(25, 25);
            this.turnAroundButton.TabIndex = 61;
            this.turnAroundButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.turnAroundButton.UseVisualStyleBackColor = false;
            this.turnAroundButton.Click += new System.EventHandler(this.turnAroundButton_Click);
            // 
            // ccfPictureBox
            // 
            this.ccfPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ccfPictureBox.Image")));
            this.ccfPictureBox.Location = new System.Drawing.Point(41, 26);
            this.ccfPictureBox.Name = "ccfPictureBox";
            this.ccfPictureBox.Size = new System.Drawing.Size(520, 305);
            this.ccfPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ccfPictureBox.TabIndex = 60;
            this.ccfPictureBox.TabStop = false;
            // 
            // ccbPictureBox
            // 
            this.ccbPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ccbPictureBox.Image")));
            this.ccbPictureBox.Location = new System.Drawing.Point(41, 26);
            this.ccbPictureBox.Name = "ccbPictureBox";
            this.ccbPictureBox.Size = new System.Drawing.Size(520, 305);
            this.ccbPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ccbPictureBox.TabIndex = 68;
            this.ccbPictureBox.TabStop = false;
            // 
            // cardNameTBox
            // 
            this.cardNameTBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.cardNameTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardNameTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cardNameTBox.ForeColor = System.Drawing.Color.White;
            this.cardNameTBox.Location = new System.Drawing.Point(41, 376);
            this.cardNameTBox.MaxLength = 23;
            this.cardNameTBox.Multiline = true;
            this.cardNameTBox.Name = "cardNameTBox";
            this.cardNameTBox.PasswordChar = '*';
            this.cardNameTBox.Size = new System.Drawing.Size(242, 28);
            this.cardNameTBox.TabIndex = 79;
            this.cardNameTBox.TabStop = false;
            this.cardNameTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cardNameTBox.UseSystemPasswordChar = true;
            this.cardNameTBox.TextChanged += new System.EventHandler(this.cardNameTBox_TextChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(37, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(246, 20);
            this.label6.TabIndex = 78;
            this.label6.Text = "Ad Soyad";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yearComboBox
            // 
            this.yearComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.yearComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yearComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yearComboBox.ForeColor = System.Drawing.Color.White;
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Items.AddRange(new object[] {
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035",
            "2036",
            "2037",
            "2038"});
            this.yearComboBox.Location = new System.Drawing.Point(123, 509);
            this.yearComboBox.MaxLength = 4;
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(76, 32);
            this.yearComboBox.TabIndex = 82;
            this.yearComboBox.TabStop = false;
            this.yearComboBox.SelectedIndexChanged += new System.EventHandler(this.yearComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(119, 486);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 76;
            this.label5.Text = "Yıl";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // monthComboBox
            // 
            this.monthComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.monthComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.monthComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.monthComboBox.ForeColor = System.Drawing.Color.White;
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.monthComboBox.Location = new System.Drawing.Point(41, 509);
            this.monthComboBox.MaxLength = 2;
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(76, 32);
            this.monthComboBox.TabIndex = 81;
            this.monthComboBox.TabStop = false;
            this.monthComboBox.SelectedIndexChanged += new System.EventHandler(this.monthComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(37, 486);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 74;
            this.label4.Text = "Ay";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(201, 486);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 73;
            this.label2.Text = "CVV";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 20);
            this.label1.TabIndex = 72;
            this.label1.Text = "Kart Numarası";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cvvTBox
            // 
            this.cvvTBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.cvvTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvvTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cvvTBox.ForeColor = System.Drawing.Color.White;
            this.cvvTBox.Location = new System.Drawing.Point(205, 509);
            this.cvvTBox.MaxLength = 3;
            this.cvvTBox.Multiline = true;
            this.cvvTBox.Name = "cvvTBox";
            this.cvvTBox.Size = new System.Drawing.Size(78, 32);
            this.cvvTBox.TabIndex = 83;
            this.cvvTBox.TabStop = false;
            this.cvvTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cvvTBox.TextChanged += new System.EventHandler(this.cvvTBox_TextChanged);
            this.cvvTBox.MouseEnter += new System.EventHandler(this.cvvTBox_MouseEnter);
            this.cvvTBox.MouseLeave += new System.EventHandler(this.cvvTBox_MouseLeave);
            // 
            // cardNumTBox
            // 
            this.cardNumTBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.cardNumTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardNumTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cardNumTBox.ForeColor = System.Drawing.Color.White;
            this.cardNumTBox.Location = new System.Drawing.Point(41, 441);
            this.cardNumTBox.Mask = "0000 0000 0000 0000";
            this.cardNumTBox.Name = "cardNumTBox";
            this.cardNumTBox.Size = new System.Drawing.Size(242, 31);
            this.cardNumTBox.TabIndex = 80;
            this.cardNumTBox.TabStop = false;
            this.cardNumTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cardNumTBox.TextChanged += new System.EventHandler(this.cardNumTBox_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(41, 554);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(197, 17);
            this.checkBox1.TabIndex = 84;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "Sözleşme koşullarını kabul ediyorum.";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(3)))));
            this.panel4.Location = new System.Drawing.Point(0, 597);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(600, 3);
            this.panel4.TabIndex = 83;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(3)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 3);
            this.panel3.TabIndex = 82;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(3)))));
            this.panel2.Location = new System.Drawing.Point(597, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 600);
            this.panel2.TabIndex = 81;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(169)))), ((int)(((byte)(3)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 600);
            this.panel1.TabIndex = 80;
            // 
            // DepositForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.cardYearLabel);
            this.Controls.Add(this.cardMonthLabel);
            this.Controls.Add(this.slashLabel);
            this.Controls.Add(this.cardNameLabel);
            this.Controls.Add(this.cardCvvLabel);
            this.Controls.Add(this.cardNumLabel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cardNameTBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.yearComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.monthComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cvvTBox);
            this.Controls.Add(this.cardNumTBox);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.turnAroundButton);
            this.Controls.Add(this.moneyCountTBox);
            this.Controls.Add(this.accLabel1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.payButton);
            this.Controls.Add(this.gameNameLabel);
            this.Controls.Add(this.ccfPictureBox);
            this.Controls.Add(this.ccbPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DepositForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YaltaCore";
            this.Load += new System.EventHandler(this.DepositForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ccfPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button closeButton;
        public System.Windows.Forms.Button payButton;
        public System.Windows.Forms.Label gameNameLabel;
        public System.Windows.Forms.TextBox moneyCountTBox;
        private System.Windows.Forms.Label accLabel1;
        public System.Windows.Forms.Label cardYearLabel;
        public System.Windows.Forms.Label cardMonthLabel;
        public System.Windows.Forms.Label slashLabel;
        public System.Windows.Forms.Label cardNameLabel;
        public System.Windows.Forms.Label cardCvvLabel;
        public System.Windows.Forms.Label cardNumLabel;
        private System.Windows.Forms.Button turnAroundButton;
        private System.Windows.Forms.PictureBox ccfPictureBox;
        private System.Windows.Forms.PictureBox ccbPictureBox;
        private System.Windows.Forms.TextBox cardNameTBox;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox yearComboBox;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox monthComboBox;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cvvTBox;
        private System.Windows.Forms.MaskedTextBox cardNumTBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}