using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF.ChessUI
{
    public partial class PlayMode : Form
    {
        private Menu mainMenu;
        private PvPMode pvpMode;
        public PlayMode(Menu menu)
        {
            InitializeComponent();
            mainMenu = menu;
            BackButton.Click += BackButton_Click;
        }


        public PlayMode()
        {
            InitializeComponent();
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu.Show();
        }


        private void PvPButton_Click(object sender, EventArgs e)
        {
            if (pvpMode == null || pvpMode.IsDisposed)
            {
                pvpMode = new PvPMode(this);
            }
            this.Hide();
            pvpMode.Show();

        }


        private void PvEButton_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow("other", null, 0, true);
            mainWindow.Show();
            this.Hide();
            mainWindow.FormClosed += (s, args) =>
            {
                // Kiểm tra MainWindow có bị disposed không trước khi gọi Close
                if (mainWindow != null && !mainWindow.IsDisposed)
                {
                    this.Close();
                }
            };
        }
    }
}
