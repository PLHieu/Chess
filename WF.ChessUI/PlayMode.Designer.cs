namespace WF.ChessUI
{
    partial class PlayMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayMode));
            panel1 = new System.Windows.Forms.Panel();
            BackButton = new System.Windows.Forms.PictureBox();
            PvEButton = new System.Windows.Forms.PictureBox();
            PvPButton = new System.Windows.Forms.PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BackButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PvEButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PvPButton).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (System.Drawing.Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panel1.Controls.Add(BackButton);
            panel1.Controls.Add(PvEButton);
            panel1.Controls.Add(PvPButton);
            panel1.Location = new System.Drawing.Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(550, 855);
            panel1.TabIndex = 0;
            // 
            // BackButton
            // 
            BackButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("BackButton.BackgroundImage");
            BackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            BackButton.Location = new System.Drawing.Point(181, 574);
            BackButton.Name = "BackButton";
            BackButton.Size = new System.Drawing.Size(200, 100);
            BackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            BackButton.TabIndex = 2;
            BackButton.TabStop = false;
            // 
            // PvEButton
            // 
            PvEButton.Image = (System.Drawing.Image)resources.GetObject("PvEButton.Image");
            PvEButton.Location = new System.Drawing.Point(181, 396);
            PvEButton.Name = "PvEButton";
            PvEButton.Size = new System.Drawing.Size(200, 100);
            PvEButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            PvEButton.TabIndex = 1;
            PvEButton.TabStop = false;
            PvEButton.Click += PvEButton_Click;
            // 
            // PvPButton
            // 
            PvPButton.Image = (System.Drawing.Image)resources.GetObject("PvPButton.Image");
            PvPButton.Location = new System.Drawing.Point(181, 225);
            PvPButton.Name = "PvPButton";
            PvPButton.Size = new System.Drawing.Size(200, 100);
            PvPButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            PvPButton.TabIndex = 0;
            PvPButton.TabStop = false;
            PvPButton.Click += PvPButton_Click;
            // 
            // PlayMode
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(574, 879);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "PlayMode";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "PlayMode";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)BackButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)PvEButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)PvPButton).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox BackButton;
        private System.Windows.Forms.PictureBox PvEButton;
        private System.Windows.Forms.PictureBox PvPButton;
    }
}