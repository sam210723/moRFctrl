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
            this.btnFreqSet = new System.Windows.Forms.Button();
            this.textFrequency = new System.Windows.Forms.TextBox();
            this.groupFunction = new System.Windows.Forms.GroupBox();
            this.radioFunctionGenerator = new System.Windows.Forms.RadioButton();
            this.radioFunctionMixer = new System.Windows.Forms.RadioButton();
            this.trackMixerI = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBiasTee = new System.Windows.Forms.CheckBox();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupFunction.SuspendLayout();
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
            this.menuStrip.Size = new System.Drawing.Size(553, 24);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 218);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(553, 22);
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
            // btnFreqSet
            // 
            this.btnFreqSet.Location = new System.Drawing.Point(107, 34);
            this.btnFreqSet.Name = "btnFreqSet";
            this.btnFreqSet.Size = new System.Drawing.Size(40, 23);
            this.btnFreqSet.TabIndex = 2;
            this.btnFreqSet.Text = "Set";
            this.btnFreqSet.UseVisualStyleBackColor = true;
            this.btnFreqSet.Click += new System.EventHandler(this.btnFreqSet_Click);
            // 
            // textFrequency
            // 
            this.textFrequency.Location = new System.Drawing.Point(12, 36);
            this.textFrequency.Name = "textFrequency";
            this.textFrequency.Size = new System.Drawing.Size(89, 20);
            this.textFrequency.TabIndex = 3;
            this.textFrequency.Text = "1000000000";
            // 
            // groupFunction
            // 
            this.groupFunction.Controls.Add(this.radioFunctionGenerator);
            this.groupFunction.Controls.Add(this.radioFunctionMixer);
            this.groupFunction.ForeColor = System.Drawing.Color.White;
            this.groupFunction.Location = new System.Drawing.Point(160, 34);
            this.groupFunction.Name = "groupFunction";
            this.groupFunction.Size = new System.Drawing.Size(88, 69);
            this.groupFunction.TabIndex = 4;
            this.groupFunction.TabStop = false;
            this.groupFunction.Text = "Function";
            // 
            // radioFunctionGenerator
            // 
            this.radioFunctionGenerator.AutoSize = true;
            this.radioFunctionGenerator.Location = new System.Drawing.Point(8, 42);
            this.radioFunctionGenerator.Name = "radioFunctionGenerator";
            this.radioFunctionGenerator.Size = new System.Drawing.Size(72, 17);
            this.radioFunctionGenerator.TabIndex = 1;
            this.radioFunctionGenerator.TabStop = true;
            this.radioFunctionGenerator.Text = "Generator";
            this.radioFunctionGenerator.UseVisualStyleBackColor = true;
            this.radioFunctionGenerator.CheckedChanged += new System.EventHandler(this.radioFunctionGenerator_CheckedChanged);
            // 
            // radioFunctionMixer
            // 
            this.radioFunctionMixer.AutoSize = true;
            this.radioFunctionMixer.Location = new System.Drawing.Point(9, 19);
            this.radioFunctionMixer.Name = "radioFunctionMixer";
            this.radioFunctionMixer.Size = new System.Drawing.Size(50, 17);
            this.radioFunctionMixer.TabIndex = 0;
            this.radioFunctionMixer.TabStop = true;
            this.radioFunctionMixer.Text = "Mixer";
            this.radioFunctionMixer.UseVisualStyleBackColor = true;
            this.radioFunctionMixer.CheckedChanged += new System.EventHandler(this.radioFunctionMixer_CheckedChanged);
            // 
            // trackMixerI
            // 
            this.trackMixerI.LargeChange = 1;
            this.trackMixerI.Location = new System.Drawing.Point(12, 63);
            this.trackMixerI.Maximum = 7;
            this.trackMixerI.Name = "trackMixerI";
            this.trackMixerI.Size = new System.Drawing.Size(135, 45);
            this.trackMixerI.TabIndex = 5;
            this.trackMixerI.Scroll += new System.EventHandler(this.trackMixerI_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(48, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mixer Current";
            // 
            // checkBiasTee
            // 
            this.checkBiasTee.AutoSize = true;
            this.checkBiasTee.ForeColor = System.Drawing.Color.White;
            this.checkBiasTee.Location = new System.Drawing.Point(12, 114);
            this.checkBiasTee.Name = "checkBiasTee";
            this.checkBiasTee.Size = new System.Drawing.Size(68, 17);
            this.checkBiasTee.TabIndex = 7;
            this.checkBiasTee.Text = "Bias Tee";
            this.checkBiasTee.UseVisualStyleBackColor = true;
            this.checkBiasTee.CheckedChanged += new System.EventHandler(this.checkBiasTee_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(553, 240);
            this.Controls.Add(this.checkBiasTee);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackMixerI);
            this.Controls.Add(this.groupFunction);
            this.Controls.Add(this.textFrequency);
            this.Controls.Add(this.btnFreqSet);
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
            this.groupFunction.ResumeLayout(false);
            this.groupFunction.PerformLayout();
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
        private System.Windows.Forms.Button btnFreqSet;
        private System.Windows.Forms.TextBox textFrequency;
        private System.Windows.Forms.GroupBox groupFunction;
        private System.Windows.Forms.RadioButton radioFunctionGenerator;
        private System.Windows.Forms.RadioButton radioFunctionMixer;
        private System.Windows.Forms.TrackBar trackMixerI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBiasTee;
    }
}

