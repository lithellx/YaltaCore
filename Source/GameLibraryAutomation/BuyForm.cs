﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLibraryAutomation
{
    public partial class BuyForm : Form
    {
        public BuyForm()
        {
            InitializeComponent();
        }

        string culture = "en-US";

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=YaltaCoreDb;Integrated Security=True");

        bool isPaid = false, isBalanceEnough = false;
        public int userId, gameId;
        public string balanceToWrite = "", gameCostToCalc = "", balanceDiff = "";

        private void BuyForm_Load(object sender, EventArgs e)
        {
            if (double.Parse(costTBox.Text) != double.Parse(balanceTBox.Text, new CultureInfo(culture)))
            {
                nBalanceTBox.Text = Convert.ToString(double.Parse(balanceTBox.Text, new CultureInfo(culture)) - double.Parse(costTBox.Text));
                isBalanceEnough = false;
            }
            else
            {
                nBalanceTBox.Text = "0";
                isBalanceEnough = true;
            }

            balanceToWrite = nBalanceTBox.Text;
            gameCostToCalc = costTBox.Text;

            balanceDiff = (double.Parse(costTBox.Text) - double.Parse(balanceTBox.Text, new CultureInfo(culture))).ToString();

            if(double.Parse(costTBox.Text) > double.Parse(balanceTBox.Text, new CultureInfo(culture)) && isBalanceEnough == false)
            {
                MessageBox.Show("Bakiyeniz yetersiz. ₺" + balanceDiff + " tutarında bakiye yüklemeniz gerekmektedir.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                nBalanceTBox.Text = "₺" + nBalanceTBox.Text;
                costTBox.Text = "₺" + costTBox.Text;
                balanceTBox.Text = "₺" + double.Parse(balanceTBox.Text, new CultureInfo(culture));
            }
        }

        private void cvvTBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void payButton_Click(object sender, EventArgs e)
        {
            if (int.Parse(gameCostToCalc) > 0)
            {
                if (checkBox1.Checked)
                { // UPDATE accTable SET level=@level WHERE id=@id

                    SqlCommand myGames = new SqlCommand("SELECT id FROM gameTable WHERE userId=@userId AND gameId=@gameId", con);
                    myGames.Parameters.AddWithValue("@userId", userId);
                    myGames.Parameters.AddWithValue("@gameId", gameId);

                    con.Open();
                    SqlDataReader dr = myGames.ExecuteReader();

                    if (dr.HasRows)
                    {
                        con.Close();
                        MessageBox.Show("Bu oyun zaten satın alınmış.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                    else
                    {
                        con.Close();

                        SqlCommand cmd = new SqlCommand("UPDATE accTable SET balance=@balance WHERE id=@id", con);
                        cmd.Parameters.AddWithValue("@balance", balanceToWrite);
                        cmd.Parameters.AddWithValue("@id", userId);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        SqlCommand cmdGame = new SqlCommand("INSERT INTO gameTable (userId, gameId) VALUES (@userId, @gameId)", con);
                        cmdGame.Parameters.AddWithValue("@userId", userId);
                        cmdGame.Parameters.AddWithValue("@gameId", gameId);

                        con.Open();
                        cmdGame.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show(gameNameLabel.Text + " oyunu başarıyla satın alındı ve kütüphanenize eklendi. İyi oyunlar!", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isPaid = true;

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Sözleşme şartları kabul edilmeden oyun satın alınamaz.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(int.Parse(gameCostToCalc) == 0)
            {
                if (checkBox1.Checked)
                { // UPDATE accTable SET level=@level WHERE id=@id

                    SqlCommand myGames = new SqlCommand("SELECT id FROM gameTable WHERE userId=@userId AND gameId=@gameId", con);
                    myGames.Parameters.AddWithValue("@userId", userId);
                    myGames.Parameters.AddWithValue("@gameId", gameId);

                    con.Open();
                    SqlDataReader dr = myGames.ExecuteReader();

                    if (dr.HasRows)
                    {
                        con.Close();
                        MessageBox.Show("Bu oyun zaten satın alınmış.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                    else
                    {
                        con.Close();

                        SqlCommand cmd = new SqlCommand("UPDATE accTable SET balance=@balance WHERE id=@id", con);
                        cmd.Parameters.AddWithValue("@balance", balanceToWrite);
                        cmd.Parameters.AddWithValue("@id", userId);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        SqlCommand cmdGame = new SqlCommand("INSERT INTO gameTable (userId, gameId) VALUES (@userId, @gameId)", con);
                        cmdGame.Parameters.AddWithValue("@userId", userId);
                        cmdGame.Parameters.AddWithValue("@gameId", gameId);

                        con.Open();
                        cmdGame.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show(gameNameLabel.Text + " oyunu başarıyla satın alındı ve kütüphanenize eklendi. İyi oyunlar!", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isPaid = true;

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Sözleşme şartları kabul edilmeden oyun satın alınamaz.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
