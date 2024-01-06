using YaltaCore.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLibraryAutomation
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }

        NotifyIcon nIcon;

        private void GameForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            progressBar1.Maximum = 50;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                this.Close();
            }
            else
                progressBar1.Value += 1;
        }
    }
}
