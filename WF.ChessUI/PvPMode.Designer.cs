namespace WF.ChessUI
{
    partial class PvPMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PvPMode));
            panel1 = new System.Windows.Forms.Panel();
            BackButton = new System.Windows.Forms.PictureBox();
            LANModeButton = new System.Windows.Forms.PictureBox();
            SingleDeviceButton = new System.Windows.Forms.PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BackButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LANModeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SingleDeviceButton).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (System.Drawing.Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panel1.Controls.Add(BackButton);
            panel1.Controls.Add(LANModeButton);
            panel1.Controls.Add(SingleDeviceButton);
            panel1.Location = new System.Drawing.Point(-1, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(575, 871);
            panel1.TabIndex = 0;
            // 
            // BackButton
            // 
            BackButton.Image = (System.Drawing.Image)resources.GetObject("BackButton.Image");
            BackButton.Location = new System.Drawing.Point(188, 588);
            BackButton.Name = "BackButton";
            BackButton.Size = new System.Drawing.Size(200, 100);
            BackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            BackButton.TabIndex = 2;
            BackButton.TabStop = false;
            BackButton.Click += BackButton_Click;
            // 
            // LANModeButton
            // 
            LANModeButton.Image = (System.Drawing.Image)resources.GetObject("LANModeButton.Image");
            LANModeButton.Location = new System.Drawing.Point(188, 396);
            LANModeButton.Name = "LANModeButton";
            LANModeButton.Size = new System.Drawing.Size(200, 100);
            LANModeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            LANModeButton.TabIndex = 1;
            LANModeButton.TabStop = false;
            LANModeButton.Click += LANModeButton_Click;
            // 
            // SingleDeviceButton
            // 
            SingleDeviceButton.Image = (System.Drawing.Image)resources.GetObject("SingleDeviceButton.Image");
            SingleDeviceButton.Location = new System.Drawing.Point(188, 223);
            SingleDeviceButton.Name = "SingleDeviceButton";
            SingleDeviceButton.Size = new System.Drawing.Size(200, 100);
            SingleDeviceButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            SingleDeviceButton.TabIndex = 0;
            SingleDeviceButton.TabStop = false;
            SingleDeviceButton.Click += SingleDeviceButton_Click;
            // 
            // PvPMode
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(574, 879);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "PvPMode";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "PvPMode";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)BackButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)LANModeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)SingleDeviceButton).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox BackButton;
        private System.Windows.Forms.PictureBox LANModeButton;
        private System.Windows.Forms.PictureBox SingleDeviceButton;
    }
}