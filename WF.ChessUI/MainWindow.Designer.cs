using System.Windows.Forms;

namespace WF.ChessUI
{
    partial class MainWindow
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel boardGrid; // Dùng TableLayoutPanel làm lưới bàn cờ

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.boardGrid = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            this.boardGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BoardGrid_MouseDown); // Đảm bảo sự kiện được gán đúng

            // 
            // boardGrid
            // 
            this.boardGrid.ColumnCount = 8;
            this.boardGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.boardGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boardGrid.Location = new System.Drawing.Point(0, 0);
            this.boardGrid.Name = "boardGrid";
            this.boardGrid.Size = new System.Drawing.Size(800, 800);
            this.boardGrid.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.boardGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chess Board UI";
            this.ResumeLayout(false);
        }

    }
}
