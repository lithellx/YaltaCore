using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLibraryAutomation
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }
        Timer tmr;
        public static bool CheckInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            tmr = new Timer();
            tmr.Interval = 3000;
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            UserForm userForm = new UserForm();
            if (CheckInternetConnection())
            {
                this.Hide();
                userForm.Show();
            }
            else
            {
                MessageBox.Show("İnternet bağlantısı bulunamadı. Lütfen internete bağlanın.", "YaltaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
