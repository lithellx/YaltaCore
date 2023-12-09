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
    public partial class BuyForm : Form
    {
        public BuyForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=YaltaCoreDb;Integrated Security=True");

        bool isPaid = false;
        public int userId, gameId;
        public string balanceToWrite = "";

        private void BuyForm_Load(object sender, EventArgs e)
        {
            nBalanceTBox.Text = Convert.ToString(int.Parse(balanceTBox.Text) - int.Parse(costTBox.Text));
            balanceToWrite = nBalanceTBox.Text;
            nBalanceTBox.Text += "₺";
            costTBox.Text += "₺";
            balanceTBox.Text += "₺";
        }

        private void payButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();

            if(checkBox1.Checked)
            { // UPDATE userTable SET level=@level WHERE id=@id

                SqlCommand cmd = new SqlCommand("UPDATE userTable SET balance=@balance WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@balance", balanceToWrite);
                cmd.Parameters.AddWithValue("@id", userId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

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
                MessageBox.Show("Sözleşme şartları kabul edilmeden bu oyun satın alınamaz.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
