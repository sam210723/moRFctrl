namespace moRFctrl
{
    partial class About
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.ddeRotorLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.vksdrLabel = new System.Windows.Forms.LinkLabel();
            this.updateBtn = new System.Windows.Forms.Button();
            this.updateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(171, 81);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 25);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // ddeRotorLabel
            // 
            this.ddeRotorLabel.AutoSize = true;
            this.ddeRotorLabel.Font = new System.Drawing.Font("Bahnschrift Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddeRotorLabel.ForeColor = System.Drawing.Color.White;
            this.ddeRotorLabel.Location = new System.Drawing.Point(8, 9);
            this.ddeRotorLabel.Name = "ddeRotorLabel";
            this.ddeRotorLabel.Size = new System.Drawing.Size(174, 45);
            this.ddeRotorLabel.TabIndex = 1;
            this.ddeRotorLabel.Text = "moRFctrl";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.ForeColor = System.Drawing.Color.White;
            this.versionLabel.Location = new System.Drawing.Point(176, 30);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(18, 19);
            this.versionLabel.TabIndex = 2;
            this.versionLabel.Text = "v";
            // 
            // vksdrLabel
            // 
            this.vksdrLabel.AutoSize = true;
            this.vksdrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vksdrLabel.LinkColor = System.Drawing.Color.Lime;
            this.vksdrLabel.Location = new System.Drawing.Point(13, 56);
            this.vksdrLabel.Name = "vksdrLabel";
            this.vksdrLabel.Size = new System.Drawing.Size(128, 16);
            this.vksdrLabel.TabIndex = 4;
            this.vksdrLabel.TabStop = true;
            this.vksdrLabel.Text = "vksdr.com/moRFctrl";
            this.vksdrLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.vksdrLabel_LinkClicked);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(7, 81);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(158, 25);
            this.updateBtn.TabIndex = 5;
            this.updateBtn.Text = "Update available (v)";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Visible = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // updateLabel
            // 
            this.updateLabel.AutoSize = true;
            this.updateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.updateLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.updateLabel.Location = new System.Drawing.Point(14, 85);
            this.updateLabel.Name = "updateLabel";
            this.updateLabel.Size = new System.Drawing.Size(143, 16);
            this.updateLabel.TabIndex = 6;
            this.updateLabel.Text = "Checking for updates...";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(254, 113);
            this.Controls.Add(this.updateLabel);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.vksdrLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.ddeRotorLabel);
            this.Controls.Add(this.closeBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label ddeRotorLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.LinkLabel vksdrLabel;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Label updateLabel;
    }
}