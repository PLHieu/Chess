using System;
using System.Windows.Forms;

namespace WF.ChessUI
{
    public partial class PvPMode : Form
    {
        PlayMode playMode;

        // Constructor không có tham số
        public PvPMode()
        {
            InitializeComponent();
        }

        // Constructor với tham số PlayMode
        public PvPMode(PlayMode playmode)
        {
            InitializeComponent();
            playMode = playmode;
            BackButton.Click += BackButton_Click;
        }

        // Sự kiện khi nhấn nút Back
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Kiểm tra nếu playMode còn tồn tại và chưa bị disposed
            if (playMode != null && !playMode.IsDisposed)
            {
                playMode.Show();
            }
            else
            {
                // Nếu playMode đã bị disposed hoặc là null, có thể khởi tạo lại nó
                playMode = new PlayMode();  // Khởi tạo lại PlayMode nếu không có đối tượng hợp lệ
                playMode.Show();
            }

            this.Close();
        }

        // Sự kiện khi nhấn nút SingleDeviceButton
        private void SingleDeviceButton_Click(object sender, EventArgs e)
        {
            // TODO be modified later, im so fcking tired
            MainWindow mainWindow = new MainWindow("other", null, 0);
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

        // Sự kiện khi nhấn nút LANModeButton
        private void LANModeButton_Click(object sender, EventArgs e)
        {
            // Tạo instance của LANMode và truyền 'this' (PvPMode hiện tại)
            LANMode lanMode = new LANMode(this);

            // Hiển thị LANMode
            lanMode.Show();

            // Ẩn PvPMode
            this.Hide();

            // Đảm bảo PvPMode đóng khi LANMode đóng
            lanMode.FormClosed += (s, args) => this.Close();
        }
    }
}
