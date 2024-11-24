using System;
using System.Net;
using System.Windows.Forms;

namespace WF.ChessUI
{
    public partial class Join : Form
    {
        private LANMode lanMode;

        // Constructor that accepts LANMode as the previous form
        public Join(LANMode previousForm)
        {
            InitializeComponent();
            lanMode = previousForm;
            BackButton.Click += BackButton_Click;
        }

        // Event when the Back button is clicked
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (lanMode != null && !lanMode.IsDisposed)
            {
                lanMode.Show();
            }
            // Không gọi this.Close() để tránh đóng toàn bộ ứng dụng
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            string[] subStrings = IPTextbox.Text.Split(':');

            if (subStrings.Length != 2)
            {
                MessageBox.Show("Invalid IP address or port number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IPAddress ip = IPAddress.Parse(subStrings[0]);
            int port = int.Parse(subStrings[1]);

            MainWindow mainWindow = new MainWindow("client", ip, port);
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