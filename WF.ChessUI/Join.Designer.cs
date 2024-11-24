namespace WF.ChessUI
{
    partial class Join
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Join));
            panel1 = new System.Windows.Forms.Panel();
            BackButton = new System.Windows.Forms.PictureBox();
            JoinButton = new System.Windows.Forms.PictureBox();
            IPTextbox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BackButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)JoinButton).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (System.Drawing.Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panel1.Controls.Add(BackButton);
            panel1.Controls.Add(JoinButton);
            panel1.Controls.Add(IPTextbox);
            panel1.Controls.Add(label1);
            panel1.Location = new System.Drawing.Point(7, 8);
            panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(338, 534);
            panel1.TabIndex = 0;
            // 
            // BackButton
            // 
            BackButton.Image = (System.Drawing.Image)resources.GetObject("BackButton.Image");
            BackButton.Location = new System.Drawing.Point(122, 370);
            BackButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            BackButton.Name = "BackButton";
            BackButton.Size = new System.Drawing.Size(96, 48);
            BackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            BackButton.TabIndex = 4;
            BackButton.TabStop = false;
            BackButton.Click += BackButton_Click;
            // 
            // JoinButton
            // 
            JoinButton.Image = (System.Drawing.Image)resources.GetObject("JoinButton.Image");
            JoinButton.Location = new System.Drawing.Point(122, 291);
            JoinButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            JoinButton.Name = "JoinButton";
            JoinButton.Size = new System.Drawing.Size(96, 48);
            JoinButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            JoinButton.TabIndex = 3;
            JoinButton.TabStop = false;
            JoinButton.Click += JoinButton_Click;
            // 
            // IPTextbox
            // 
            IPTextbox.Location = new System.Drawing.Point(44, 142);
            IPTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            IPTextbox.Name = "IPTextbox";
            IPTextbox.Size = new System.Drawing.Size(261, 27);
            IPTextbox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Black;
            label1.Font = new System.Drawing.Font("Poor Richard", 12F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label1.Location = new System.Drawing.Point(44, 95);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(273, 23);
            label1.TabIndex = 1;
            label1.Text = "Server address and Port number";
            // 
            // Join
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(353, 549);
            Controls.Add(panel1);
            ForeColor = System.Drawing.SystemColors.ControlLight;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            Name = "Join";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Join";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BackButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)JoinButton).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox BackButton;
        private System.Windows.Forms.PictureBox JoinButton;
        private System.Windows.Forms.TextBox IPTextbox;
    }
}