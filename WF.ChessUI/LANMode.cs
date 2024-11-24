using System;
using System.Windows.Forms;

namespace WF.ChessUI
{
    public partial class LANMode : Form
    {
        private PvPMode pvpMode;

        // Constructor nhận đối tượng PvPMode để quay lại
        public LANMode(PvPMode previousForm)
        {
            InitializeComponent();
            pvpMode = previousForm;
            BackButton.Click += BackButton_Click;
        }

        // Sự kiện khi nhấn nút Back
        private void BackButton_Click(object sender, EventArgs e)
        {
            // Hiển thị lại PvPMode và đóng form hiện tại
            this.Hide();

            // Kiểm tra nếu pvpMode chưa bị disposed hoặc null
            if (pvpMode != null && !pvpMode.IsDisposed)
            {
                pvpMode.Show();
            }
            else
            {
                // Nếu pvpMode bị disposed hoặc null, khởi tạo lại PvPMode
                pvpMode = new PvPMode();  // Tạo một instance mới của PvPMode nếu cần
                pvpMode.Show();
            }

            this.Close();
        }

        // Sự kiện khi nhấn nút HostButton
        private void HostButton_Click(object sender, EventArgs e)
        {
            // Tạo instance của Host form
            Host hostForm = new Host(this);

            // Hiển thị Host form
            hostForm.Show();

            // Ẩn LANMode
            this.Hide();

            // Đảm bảo LANMode đóng khi Host đóng
            hostForm.FormClosed += (s, args) => this.Close();
        }

        // Sự kiện khi nhấn nút JoinButton
        private void JoinButton_Click(object sender, EventArgs e)
        {
            // Tạo instance của Join form
            Join joinForm = new Join(this);

            // Hiển thị Join form
            joinForm.Show();

            // Ẩn LANMode
            this.Hide();

            // Đảm bảo LANMode đóng khi Join đóng
            joinForm.FormClosed += (s, args) => this.Close();
        }
    }
}
