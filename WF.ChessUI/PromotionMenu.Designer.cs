using System.Windows.Forms;

namespace WF.ChessUI
{
    partial class PromotionMenu
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox QueenPictureBox;
        private PictureBox BishopPictureBox;
        private PictureBox RookPictureBox;
        private PictureBox KnightPictureBox;

        /// <summary>
        /// Dọn dẹp tài nguyên không sử dụng.
        /// </summary>
        /// <param name="disposing">True nếu đối tượng đang được hủy, ngược lại là False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Mã do trình thiết kế tạo ra

        /// <summary>
        /// Cần phải hỗ trợ trình thiết kế - không thay đổi mã ở đây.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromotionMenu));
            QueenPictureBox = new PictureBox();
            BishopPictureBox = new PictureBox();
            RookPictureBox = new PictureBox();
            KnightPictureBox = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)QueenPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BishopPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RookPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KnightPictureBox).BeginInit();
            SuspendLayout();
            // 
            // QueenPictureBox
            // 
            QueenPictureBox.Location = new System.Drawing.Point(22, 160);
            QueenPictureBox.Name = "QueenPictureBox";
            QueenPictureBox.Size = new System.Drawing.Size(198, 185);
            QueenPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            QueenPictureBox.TabIndex = 0;
            QueenPictureBox.TabStop = false;
            QueenPictureBox.Click += QueenPictureBox_Click;
            // 
            // BishopPictureBox
            // 
            BishopPictureBox.Location = new System.Drawing.Point(242, 160);
            BishopPictureBox.Name = "BishopPictureBox";
            BishopPictureBox.Size = new System.Drawing.Size(193, 185);
            BishopPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            BishopPictureBox.TabIndex = 1;
            BishopPictureBox.TabStop = false;
            BishopPictureBox.Click += BishopPictureBox_Click;
            // 
            // RookPictureBox
            // 
            RookPictureBox.Location = new System.Drawing.Point(454, 160);
            RookPictureBox.Name = "RookPictureBox";
            RookPictureBox.Size = new System.Drawing.Size(193, 185);
            RookPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            RookPictureBox.TabIndex = 2;
            RookPictureBox.TabStop = false;
            RookPictureBox.Click += RookPictureBox_Click;
            // 
            // KnightPictureBox
            // 
            KnightPictureBox.Location = new System.Drawing.Point(675, 160);
            KnightPictureBox.Name = "KnightPictureBox";
            KnightPictureBox.Size = new System.Drawing.Size(193, 185);
            KnightPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            KnightPictureBox.TabIndex = 3;
            KnightPictureBox.TabStop = false;
            KnightPictureBox.Click += KnightPictureBox_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Rockwell", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(260, 52);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(356, 49);
            label1.TabIndex = 4;
            label1.Text = "SELECT A PIECE";
            // 
            // PromotionMenu
            // 
            ClientSize = new System.Drawing.Size(880, 427);
            Controls.Add(label1);
            Controls.Add(KnightPictureBox);
            Controls.Add(RookPictureBox);
            Controls.Add(BishopPictureBox);
            Controls.Add(QueenPictureBox);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "PromotionMenu";
            Text = "Promotion";
            ((System.ComponentModel.ISupportInitialize)QueenPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)BishopPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)RookPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)KnightPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}
