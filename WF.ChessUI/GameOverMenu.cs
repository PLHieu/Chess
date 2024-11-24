using System;
using System.Linq;
using System.Windows.Forms;
using ChessLogic;

namespace WF.ChessUI
{
    public partial class GameOverMenu : Form
    {
        public GameOverMenu(Player winner, EndReason reason)
        {
            InitializeComponent();

            // Hiển thị người thắng
            WinnerLabel.Text = winner == Player.None ? "IT'S A DRAW!" : $"{winner} WINS!";

            // Hiển thị lý do kết thúc trò chơi
            ReasonLabel.Text = reason switch
            {
                EndReason.Stalemate => "STALEMATE - Player cannot move",
                EndReason.Checkmate => "CHECKMATE - Player cannot move",
                EndReason.FiftyMoveRule => "FIFTY-MOVE RULE",
                EndReason.InsufficientMaterial => "INSUFFICIENT MATERIAL",
                EndReason.ThreefoldRepetition => "THREEFOLD REPETITION",
                _ => "Game Over"
            };
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainWindow = Application.OpenForms.OfType<MainWindow>().FirstOrDefault();
            mainWindow?.Hide(); // Đảm bảo chỉ đóng nếu có cửa sổ MainWindow cũ
            var menu = new Menu(); // Thay `MainMenu` bằng tên form Menu của bạn
            menu.Show();
            this.Close();
            
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn GameOverMenu

            // Đóng cửa sổ MainWindow cũ
            var mainWindow = Application.OpenForms.OfType<MainWindow>().FirstOrDefault();
            mainWindow?.Hide(); // Đảm bảo chỉ đóng nếu có cửa sổ MainWindow cũ

            // To be fixed later
            // Tạo và hiển thị form MainWindow mới
            var newGameForm = new MainWindow("server", null, 0);
            newGameForm.Show();
        }
    }
}
