using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLibraryAutomation
{
    public partial class DepositForm : Form
    {
        public DepositForm()
        {
            InitializeComponent();
        }

        public int userId;
        public double userBalance;

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=YaltaCoreDb;Integrated Security=True");

        private void DepositForm_Load(object sender, EventArgs e)
        {
            ccfPictureBox.Visible = true;
            ccbPictureBox.Visible = false;

            monthComboBox.SelectedIndex = 0;
            yearComboBox.SelectedIndex = 0;

            cardNumLabel.Parent = ccfPictureBox; cardNumLabel.BackColor = Color.Transparent;
            cardNameLabel.Parent = ccfPictureBox; cardNameLabel.BackColor = Color.Transparent;
            cardMonthLabel.Parent = ccfPictureBox; cardMonthLabel.BackColor = Color.Transparent;
            cardYearLabel.Parent = ccfPictureBox; cardYearLabel.BackColor = Color.Transparent;
            slashLabel.Parent = ccfPictureBox; slashLabel.BackColor = Color.Transparent;

            cardCvvLabel.Parent = ccbPictureBox; cardCvvLabel.BackColor = Color.Transparent;
        }

        private void payButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cardNameTBox.Text) && !string.IsNullOrEmpty(cardNumTBox.Text) && !string.IsNullOrEmpty(cvvTBox.Text) && cardNameLabel.Text.Length > 3 && cardNumLabel.Text.Length == 19 && cardCvvLabel.Text.Length == 3)
            {
                if (checkBox1.Checked)
                {
                    double newVal = userBalance + double.Parse(moneyCountTBox.Text);

                    if (newVal > 99999)
                        newVal = 99999;

                    if (int.Parse(moneyCountTBox.Text) > 0)
                    {
                        if (userBalance < 99999)
                        {
                            SqlCommand cmdx = new SqlCommand("UPDATE accTable SET balance=@balance WHERE id=@id", con);
                            cmdx.Parameters.AddWithValue("@id", userId);
                            cmdx.Parameters.AddWithValue("@balance", newVal);

                            con.Open();
                            cmdx.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Yükleme başarılı. İyi alışverişler!", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Daha fazla para yatıramazsınız. Maksimum yatırılabilecek bakiyeye ulaştınız.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen geçerli bir miktar girin.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Sözleşme şartları kabul edilmeden oyun satın alınamaz.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen kart bilgilerinizi doldurun.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void moneyCountTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void moneyCountTBox_Enter(object sender, EventArgs e)
        {
            if (moneyCountTBox.Text == "Bakiye girin")
            {
                moneyCountTBox.Text = "";
                moneyCountTBox.Multiline = false;
                moneyCountTBox.ForeColor = Color.White;
            }
        }

        private void moneyCountTBox_Leave(object sender, EventArgs e)
        {
            if (moneyCountTBox.Text == "")
            {
                moneyCountTBox.Text = "Bakiye girin";
                moneyCountTBox.Multiline = true;
                moneyCountTBox.ForeColor = Color.Gray;
            }
        }

        bool isFront = true;
        private void turnAroundButton_Click(object sender, EventArgs e)
        {
            if (isFront == true)
            {
                ccfPictureBox.Visible = false;
                ccbPictureBox.Visible = true;
                isFront = !isFront;
            }
            else
            {
                ccfPictureBox.Visible = true;
                ccbPictureBox.Visible = false;
                isFront = !isFront;
            }
        }

        private void cvvTBox_MouseEnter(object sender, EventArgs e)
        {
            ccfPictureBox.Visible = false;
            ccbPictureBox.Visible = true;
            isFront = false;
        }

        private void cvvTBox_MouseLeave(object sender, EventArgs e)
        {
            ccfPictureBox.Visible = true;
            ccbPictureBox.Visible = false;
            isFront = true;
        }

        private void cardNameTBox_TextChanged(object sender, EventArgs e)
        {
            cardNameLabel.Text = cardNameTBox.Text;
        }

        private void cardNumTBox_TextChanged(object sender, EventArgs e)
        {
            cardNumLabel.Text = cardNumTBox.Text;
        }

        private void monthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cardMonthLabel.Text = monthComboBox.SelectedItem.ToString();
        }

        private void yearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cardYearLabel.Text = yearComboBox.SelectedItem.ToString().Substring(2);
        }
        private void cvvTBox_TextChanged(object sender, EventArgs e)
        {
            cardCvvLabel.Text = cvvTBox.Text;
        }
    }
}
