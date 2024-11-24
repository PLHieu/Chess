namespace WF.ChessUI
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            panel1 = new System.Windows.Forms.Panel();
            QuitButton = new System.Windows.Forms.PictureBox();
            RankingButton = new System.Windows.Forms.PictureBox();
            ProfileButton = new System.Windows.Forms.PictureBox();
            PlayButton = new System.Windows.Forms.PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)QuitButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RankingButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProfileButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayButton).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            panel1.BackgroundImage = (System.Drawing.Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panel1.Controls.Add(QuitButton);
            panel1.Controls.Add(RankingButton);
            panel1.Controls.Add(ProfileButton);
            panel1.Controls.Add(PlayButton);
            panel1.Location = new System.Drawing.Point(12, 5);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(556, 872);
            panel1.TabIndex = 0;
            // 
            // QuitButton
            // 
            QuitButton.Image = (System.Drawing.Image)resources.GetObject("QuitButton.Image");
            QuitButton.Location = new System.Drawing.Point(185, 630);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new System.Drawing.Size(200, 100);
            QuitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            QuitButton.TabIndex = 3;
            QuitButton.TabStop = false;
            // 
            // RankingButton
            // 
            RankingButton.Image = (System.Drawing.Image)resources.GetObject("RankingButton.Image");
            RankingButton.Location = new System.Drawing.Point(185, 489);
            RankingButton.Name = "RankingButton";
            RankingButton.Size = new System.Drawing.Size(200, 100);
            RankingButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            RankingButton.TabIndex = 2;
            RankingButton.TabStop = false;
            // 
            // ProfileButton
            // 
            ProfileButton.Image = (System.Drawing.Image)resources.GetObject("ProfileButton.Image");
            ProfileButton.Location = new System.Drawing.Point(185, 342);
            ProfileButton.Name = "ProfileButton";
            ProfileButton.Size = new System.Drawing.Size(200, 100);
            ProfileButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            ProfileButton.TabIndex = 1;
            ProfileButton.TabStop = false;
            // 
            // PlayButton
            // 
            PlayButton.Image = (System.Drawing.Image)resources.GetObject("PlayButton.Image");
            PlayButton.Location = new System.Drawing.Point(185, 193);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new System.Drawing.Size(200, 100);
            PlayButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            PlayButton.TabIndex = 0;
            PlayButton.TabStop = false;
            PlayButton.Click += PlayButton_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            ClientSize = new System.Drawing.Size(574, 879);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "Menu";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Menu";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)QuitButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)RankingButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProfileButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayButton).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox QuitButton;
        private System.Windows.Forms.PictureBox RankingButton;
        private System.Windows.Forms.PictureBox ProfileButton;
        private System.Windows.Forms.PictureBox PlayButton;
    }
}