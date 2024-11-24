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

    public partial class Menu : Form
    {
        private PlayMode playMode;
        public Menu()
        {
            InitializeComponent();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (playMode == null || playMode.IsDisposed)
            {
                playMode = new PlayMode(this);
            }
            this.Hide();
            playMode.Show();

            // Đảm bảo PlayMode sẽ đóng ứng dụng nếu người dùng thoát
            playMode.FormClosed += (s, args) => this.Close();
        }

    }
}
