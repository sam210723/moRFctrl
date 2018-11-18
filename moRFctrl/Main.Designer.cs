namespace moRFctrl
{
    partial class Main
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.textFrequency = new System.Windows.Forms.TextBox();
            this.radioFunctionGenerator = new System.Windows.Forms.RadioButton();
            this.radioFunctionMixer = new System.Windows.Forms.RadioButton();
            this.trackMixerI = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBiasTee = new System.Windows.Forms.CheckBox();
            this.groupSweep = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMixerI)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(262, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 358);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(262, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel.Text = "...";
            // 
            // textFrequency
            // 
            this.textFrequency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.textFrequency.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFrequency.ForeColor = System.Drawing.Color.White;
            this.textFrequency.Location = new System.Drawing.Point(12, 34);
            this.textFrequency.Name = "textFrequency";
            this.textFrequency.Size = new System.Drawing.Size(131, 32);
            this.textFrequency.TabIndex = 0;
            this.textFrequency.Text = "1000000000";
            this.textFrequency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textFrequency_KeyPress);
            // 
            // radioFunctionGenerator
            // 
            this.radioFunctionGenerator.AutoSize = true;
            this.radioFunctionGenerator.ForeColor = System.Drawing.Color.White;
            this.radioFunctionGenerator.Location = new System.Drawing.Point(182, 98);
            this.radioFunctionGenerator.Name = "radioFunctionGenerator";
            this.radioFunctionGenerator.Size = new System.Drawing.Size(72, 17);
            this.radioFunctionGenerator.TabIndex = 3;
            this.radioFunctionGenerator.Text = "Generator";
            this.radioFunctionGenerator.UseVisualStyleBackColor = true;
            this.radioFunctionGenerator.CheckedChanged += new System.EventHandler(this.radioFunctionGenerator_CheckedChanged);
            // 
            // radioFunctionMixer
            // 
            this.radioFunctionMixer.AutoSize = true;
            this.radioFunctionMixer.ForeColor = System.Drawing.Color.White;
            this.radioFunctionMixer.Location = new System.Drawing.Point(182, 75);
            this.radioFunctionMixer.Name = "radioFunctionMixer";
            this.radioFunctionMixer.Size = new System.Drawing.Size(50, 17);
            this.radioFunctionMixer.TabIndex = 2;
            this.radioFunctionMixer.Text = "Mixer";
            this.radioFunctionMixer.UseVisualStyleBackColor = true;
            this.radioFunctionMixer.CheckedChanged += new System.EventHandler(this.radioFunctionMixer_CheckedChanged);
            // 
            // trackMixerI
            // 
            this.trackMixerI.LargeChange = 1;
            this.trackMixerI.Location = new System.Drawing.Point(12, 71);
            this.trackMixerI.Maximum = 7;
            this.trackMixerI.Name = "trackMixerI";
            this.trackMixerI.Size = new System.Drawing.Size(131, 45);
            this.trackMixerI.TabIndex = 5;
            this.trackMixerI.Scroll += new System.EventHandler(this.trackMixerI_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(46, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mixer Current";
            // 
            // checkBiasTee
            // 
            this.checkBiasTee.AutoSize = true;
            this.checkBiasTee.ForeColor = System.Drawing.Color.White;
            this.checkBiasTee.Location = new System.Drawing.Point(182, 42);
            this.checkBiasTee.Name = "checkBiasTee";
            this.checkBiasTee.Size = new System.Drawing.Size(68, 17);
            this.checkBiasTee.TabIndex = 4;
            this.checkBiasTee.Text = "Bias-Tee";
            this.checkBiasTee.UseVisualStyleBackColor = true;
            this.checkBiasTee.CheckedChanged += new System.EventHandler(this.checkBiasTee_CheckedChanged);
            // 
            // groupSweep
            // 
            this.groupSweep.ForeColor = System.Drawing.Color.White;
            this.groupSweep.Location = new System.Drawing.Point(12, 122);
            this.groupSweep.Name = "groupSweep";
            this.groupSweep.Size = new System.Drawing.Size(238, 225);
            this.groupSweep.TabIndex = 8;
            this.groupSweep.TabStop = false;
            this.groupSweep.Text = "Sweep";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(143, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Hz";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(262, 380);
            this.Controls.Add(this.radioFunctionMixer);
            this.Controls.Add(this.radioFunctionGenerator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupSweep);
            this.Controls.Add(this.checkBiasTee);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackMixerI);
            this.Controls.Add(this.textFrequency);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "moRFctrl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMixerI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TextBox textFrequency;
        private System.Windows.Forms.RadioButton radioFunctionGenerator;
        private System.Windows.Forms.RadioButton radioFunctionMixer;
        private System.Windows.Forms.TrackBar trackMixerI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBiasTee;
        private System.Windows.Forms.GroupBox groupSweep;
        private System.Windows.Forms.Label label2;
    }
}

