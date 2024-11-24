using ChessLogic;
using System;
using System.Windows.Forms;

namespace WF.ChessUI
{
    public partial class PromotionMenu : Form
    {
        // Sự kiện sẽ được phát ra khi người chơi chọn quân cờ
        public event Action<PieceType> PieceSelected;

        // Constructor nhận vào người chơi
        public PromotionMenu(Player player)
        {
            InitializeComponent();
            // Gán hình ảnh cho các quân cờ (Queen, Bishop, Rook, Knight)
            QueenPictureBox.Image = Images.GetImage(player, PieceType.Queen);
            BishopPictureBox.Image = Images.GetImage(player, PieceType.Bishop);
            RookPictureBox.Image = Images.GetImage(player, PieceType.Rook);
            KnightPictureBox.Image = Images.GetImage(player, PieceType.Knight);
        }

        private void QueenPictureBox_Click(object sender, EventArgs e)
        {
            PieceSelected?.Invoke(PieceType.Queen);  // Gọi sự kiện với quân Queen
            this.Close();  // Đóng cửa sổ khi quân cờ đã được chọn
        }

        private void BishopPictureBox_Click(object sender, EventArgs e)
        {
            PieceSelected?.Invoke(PieceType.Bishop);  // Gọi sự kiện với quân Bishop
            this.Close();  // Đóng cửa sổ khi quân cờ đã được chọn
        }

        private void RookPictureBox_Click(object sender, EventArgs e)
        {
            PieceSelected?.Invoke(PieceType.Rook);  // Gọi sự kiện với quân Rook
            this.Close();  // Đóng cửa sổ khi quân cờ đã được chọn
        }

        private void KnightPictureBox_Click(object sender, EventArgs e)
        {
            PieceSelected?.Invoke(PieceType.Knight);  // Gọi sự kiện với quân Knight
            this.Close();  // Đóng cửa sổ khi quân cờ đã được chọn
        }

    }
}
