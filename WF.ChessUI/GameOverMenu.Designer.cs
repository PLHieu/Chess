namespace WF.ChessUI
{
    partial class GameOverMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOverMenu));
            WinnerLabel = new System.Windows.Forms.Label();
            ReasonLabel = new System.Windows.Forms.Label();
            RestartButton = new System.Windows.Forms.Button();
            ExitButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // WinnerLabel
            // 
            WinnerLabel.AutoSize = true;
            WinnerLabel.Font = new System.Drawing.Font("Sans Serif Collection", 11.9999981F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            WinnerLabel.Location = new System.Drawing.Point(245, 70);
            WinnerLabel.Name = "WinnerLabel";
            WinnerLabel.Size = new System.Drawing.Size(276, 79);
            WinnerLabel.TabIndex = 0;
            WinnerLabel.Text = "WINNER";
            // 
            // ReasonLabel
            // 
            ReasonLabel.AutoSize = true;
            ReasonLabel.Location = new System.Drawing.Point(211, 167);
            ReasonLabel.Name = "ReasonLabel";
            ReasonLabel.Size = new System.Drawing.Size(95, 32);
            ReasonLabel.TabIndex = 1;
            ReasonLabel.Text = "Reason:";
            // 
            // RestartButton
            // 
            RestartButton.Font = new System.Drawing.Font("STZhongsong", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            RestartButton.Location = new System.Drawing.Point(170, 268);
            RestartButton.Name = "RestartButton";
            RestartButton.Size = new System.Drawing.Size(150, 46);
            RestartButton.TabIndex = 2;
            RestartButton.Text = "Restart";
            RestartButton.UseVisualStyleBackColor = true;
            RestartButton.Click += RestartButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Font = new System.Drawing.Font("STZhongsong", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ExitButton.Location = new System.Drawing.Point(459, 268);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new System.Drawing.Size(150, 46);
            ExitButton.TabIndex = 3;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // GameOverMenu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.MenuBar;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(ExitButton);
            Controls.Add(RestartButton);
            Controls.Add(ReasonLabel);
            Controls.Add(WinnerLabel);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "GameOverMenu";
            Text = "GameOverMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label WinnerLabel;
        private System.Windows.Forms.Label ReasonLabel;
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.Button ExitButton;
    }
}