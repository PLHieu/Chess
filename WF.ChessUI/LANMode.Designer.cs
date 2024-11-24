namespace WF.ChessUI
{
    partial class LANMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LANMode));
            panel1 = new System.Windows.Forms.Panel();
            BackButton = new System.Windows.Forms.PictureBox();
            JoinButton = new System.Windows.Forms.PictureBox();
            HostButton = new System.Windows.Forms.PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BackButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)JoinButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HostButton).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (System.Drawing.Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panel1.Controls.Add(BackButton);
            panel1.Controls.Add(JoinButton);
            panel1.Controls.Add(HostButton);
            panel1.Location = new System.Drawing.Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(559, 859);
            panel1.TabIndex = 0;
            // 
            // BackButton
            // 
            BackButton.Image = (System.Drawing.Image)resources.GetObject("BackButton.Image");
            BackButton.Location = new System.Drawing.Point(159, 600);
            BackButton.Name = "BackButton";
            BackButton.Size = new System.Drawing.Size(238, 116);
            BackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            BackButton.TabIndex = 2;
            BackButton.TabStop = false;
            BackButton.Click += BackButton_Click;
            // 
            // JoinButton
            // 
            JoinButton.Image = (System.Drawing.Image)resources.GetObject("JoinButton.Image");
            JoinButton.Location = new System.Drawing.Point(159, 386);
            JoinButton.Name = "JoinButton";
            JoinButton.Size = new System.Drawing.Size(238, 116);
            JoinButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            JoinButton.TabIndex = 1;
            JoinButton.TabStop = false;
            JoinButton.Click += JoinButton_Click;
            // 
            // HostButton
            // 
            HostButton.Image = (System.Drawing.Image)resources.GetObject("HostButton.Image");
            HostButton.Location = new System.Drawing.Point(159, 179);
            HostButton.Name = "HostButton";
            HostButton.Size = new System.Drawing.Size(238, 116);
            HostButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            HostButton.TabIndex = 0;
            HostButton.TabStop = false;
            HostButton.Click += HostButton_Click;
            // 
            // LANMode
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(574, 879);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "LANMode";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "LAN Mode";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)BackButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)JoinButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)HostButton).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox JoinButton;
        private System.Windows.Forms.PictureBox HostButton;
        private System.Windows.Forms.PictureBox BackButton;
    }
}