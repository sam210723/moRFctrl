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
            this.labelMixerI = new System.Windows.Forms.Label();
            this.checkBiasTee = new System.Windows.Forms.CheckBox();
            this.groupSweep = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numStepSize = new System.Windows.Forms.NumericUpDown();
            this.labelSweepStep = new System.Windows.Forms.Label();
            this.labelSweepStart = new System.Windows.Forms.Label();
            this.numStartFreq = new System.Windows.Forms.NumericUpDown();
            this.numStopFreq = new System.Windows.Forms.NumericUpDown();
            this.labelSweepStop = new System.Windows.Forms.Label();
            this.numDwellTime = new System.Windows.Forms.NumericUpDown();
            this.labelSweepDwell = new System.Windows.Forms.Label();
            this.btnSweep = new System.Windows.Forms.Button();
            this.progressSweep = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMixerI)).BeginInit();
            this.groupSweep.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStepSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStopFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDwellTime)).BeginInit();
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
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 300);
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
            this.textFrequency.MaxLength = 10;
            this.textFrequency.Name = "textFrequency";
            this.textFrequency.Size = new System.Drawing.Size(131, 32);
            this.textFrequency.TabIndex = 0;
            this.textFrequency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textFrequency_KeyPress);
            // 
            // radioFunctionGenerator
            // 
            this.radioFunctionGenerator.AutoSize = true;
            this.radioFunctionGenerator.ForeColor = System.Drawing.Color.White;
            this.radioFunctionGenerator.Location = new System.Drawing.Point(182, 100);
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
            this.radioFunctionMixer.Location = new System.Drawing.Point(182, 77);
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
            this.trackMixerI.Location = new System.Drawing.Point(12, 73);
            this.trackMixerI.Maximum = 7;
            this.trackMixerI.Name = "trackMixerI";
            this.trackMixerI.Size = new System.Drawing.Size(131, 45);
            this.trackMixerI.TabIndex = 5;
            this.trackMixerI.Scroll += new System.EventHandler(this.trackMixerI_Scroll);
            // 
            // labelMixerI
            // 
            this.labelMixerI.AutoSize = true;
            this.labelMixerI.ForeColor = System.Drawing.Color.White;
            this.labelMixerI.Location = new System.Drawing.Point(46, 102);
            this.labelMixerI.Name = "labelMixerI";
            this.labelMixerI.Size = new System.Drawing.Size(69, 13);
            this.labelMixerI.TabIndex = 6;
            this.labelMixerI.Text = "Mixer Current";
            // 
            // checkBiasTee
            // 
            this.checkBiasTee.AutoSize = true;
            this.checkBiasTee.ForeColor = System.Drawing.Color.White;
            this.checkBiasTee.Location = new System.Drawing.Point(181, 42);
            this.checkBiasTee.Name = "checkBiasTee";
            this.checkBiasTee.Size = new System.Drawing.Size(68, 17);
            this.checkBiasTee.TabIndex = 4;
            this.checkBiasTee.Text = "Bias-Tee";
            this.checkBiasTee.UseVisualStyleBackColor = true;
            this.checkBiasTee.CheckedChanged += new System.EventHandler(this.checkBiasTee_CheckedChanged);
            // 
            // groupSweep
            // 
            this.groupSweep.Controls.Add(this.tableLayoutPanel1);
            this.groupSweep.Controls.Add(this.btnSweep);
            this.groupSweep.Controls.Add(this.progressSweep);
            this.groupSweep.ForeColor = System.Drawing.Color.White;
            this.groupSweep.Location = new System.Drawing.Point(12, 138);
            this.groupSweep.Name = "groupSweep";
            this.groupSweep.Size = new System.Drawing.Size(238, 150);
            this.groupSweep.TabIndex = 8;
            this.groupSweep.TabStop = false;
            this.groupSweep.Text = "Sweep";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.numStepSize, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelSweepStep, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelSweepStart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numStartFreq, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numStopFreq, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSweepStop, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.numDwellTime, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelSweepDwell, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(226, 100);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // numStepSize
            // 
            this.numStepSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.numStepSize.ForeColor = System.Drawing.Color.White;
            this.numStepSize.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numStepSize.Location = new System.Drawing.Point(116, 53);
            this.numStepSize.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numStepSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStepSize.Name = "numStepSize";
            this.numStepSize.Size = new System.Drawing.Size(107, 20);
            this.numStepSize.TabIndex = 8;
            this.numStepSize.ThousandsSeparator = true;
            this.numStepSize.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numStepSize.ValueChanged += new System.EventHandler(this.numStepSize_ValueChanged);
            // 
            // labelSweepStep
            // 
            this.labelSweepStep.AutoSize = true;
            this.labelSweepStep.Location = new System.Drawing.Point(3, 50);
            this.labelSweepStep.Name = "labelSweepStep";
            this.labelSweepStep.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelSweepStep.Size = new System.Drawing.Size(74, 18);
            this.labelSweepStep.TabIndex = 7;
            this.labelSweepStep.Text = "Step Size (Hz)";
            // 
            // labelSweepStart
            // 
            this.labelSweepStart.AutoSize = true;
            this.labelSweepStart.Location = new System.Drawing.Point(3, 0);
            this.labelSweepStart.Name = "labelSweepStart";
            this.labelSweepStart.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelSweepStart.Size = new System.Drawing.Size(104, 18);
            this.labelSweepStart.TabIndex = 5;
            this.labelSweepStart.Text = "Start Frequency (Hz)";
            // 
            // numStartFreq
            // 
            this.numStartFreq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.numStartFreq.ForeColor = System.Drawing.Color.White;
            this.numStartFreq.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStartFreq.Location = new System.Drawing.Point(116, 3);
            this.numStartFreq.Maximum = new decimal(new int[] {
            1105032704,
            1,
            0,
            0});
            this.numStartFreq.Minimum = new decimal(new int[] {
            85000000,
            0,
            0,
            0});
            this.numStartFreq.Name = "numStartFreq";
            this.numStartFreq.Size = new System.Drawing.Size(107, 20);
            this.numStartFreq.TabIndex = 2;
            this.numStartFreq.ThousandsSeparator = true;
            this.numStartFreq.Value = new decimal(new int[] {
            85000000,
            0,
            0,
            0});
            this.numStartFreq.ValueChanged += new System.EventHandler(this.numStartFreq_ValueChanged);
            // 
            // numStopFreq
            // 
            this.numStopFreq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.numStopFreq.ForeColor = System.Drawing.Color.White;
            this.numStopFreq.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStopFreq.Location = new System.Drawing.Point(116, 28);
            this.numStopFreq.Maximum = new decimal(new int[] {
            1105032704,
            1,
            0,
            0});
            this.numStopFreq.Minimum = new decimal(new int[] {
            85000000,
            0,
            0,
            0});
            this.numStopFreq.Name = "numStopFreq";
            this.numStopFreq.Size = new System.Drawing.Size(107, 20);
            this.numStopFreq.TabIndex = 3;
            this.numStopFreq.ThousandsSeparator = true;
            this.numStopFreq.Value = new decimal(new int[] {
            1105032704,
            1,
            0,
            0});
            this.numStopFreq.ValueChanged += new System.EventHandler(this.numStopFreq_ValueChanged);
            // 
            // labelSweepStop
            // 
            this.labelSweepStop.AutoSize = true;
            this.labelSweepStop.Location = new System.Drawing.Point(3, 25);
            this.labelSweepStop.Name = "labelSweepStop";
            this.labelSweepStop.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelSweepStop.Size = new System.Drawing.Size(104, 18);
            this.labelSweepStop.TabIndex = 6;
            this.labelSweepStop.Text = "Stop Frequency (Hz)";
            // 
            // numDwellTime
            // 
            this.numDwellTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.numDwellTime.DecimalPlaces = 2;
            this.numDwellTime.ForeColor = System.Drawing.Color.White;
            this.numDwellTime.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numDwellTime.Location = new System.Drawing.Point(116, 78);
            this.numDwellTime.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numDwellTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numDwellTime.Name = "numDwellTime";
            this.numDwellTime.Size = new System.Drawing.Size(107, 20);
            this.numDwellTime.TabIndex = 9;
            this.numDwellTime.ThousandsSeparator = true;
            this.numDwellTime.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numDwellTime.ValueChanged += new System.EventHandler(this.numDwellTime_ValueChanged);
            // 
            // labelSweepDwell
            // 
            this.labelSweepDwell.AutoSize = true;
            this.labelSweepDwell.Location = new System.Drawing.Point(3, 75);
            this.labelSweepDwell.Name = "labelSweepDwell";
            this.labelSweepDwell.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelSweepDwell.Size = new System.Drawing.Size(73, 18);
            this.labelSweepDwell.TabIndex = 10;
            this.labelSweepDwell.Text = "Dwell Time (s)";
            // 
            // btnSweep
            // 
            this.btnSweep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnSweep.Location = new System.Drawing.Point(157, 121);
            this.btnSweep.Name = "btnSweep";
            this.btnSweep.Size = new System.Drawing.Size(75, 23);
            this.btnSweep.TabIndex = 1;
            this.btnSweep.Text = "Start";
            this.btnSweep.UseVisualStyleBackColor = false;
            this.btnSweep.Click += new System.EventHandler(this.btnSweep_Click);
            // 
            // progressSweep
            // 
            this.progressSweep.Location = new System.Drawing.Point(6, 122);
            this.progressSweep.Name = "progressSweep";
            this.progressSweep.Size = new System.Drawing.Size(147, 21);
            this.progressSweep.TabIndex = 0;
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
            this.ClientSize = new System.Drawing.Size(262, 322);
            this.Controls.Add(this.radioFunctionMixer);
            this.Controls.Add(this.radioFunctionGenerator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupSweep);
            this.Controls.Add(this.checkBiasTee);
            this.Controls.Add(this.labelMixerI);
            this.Controls.Add(this.trackMixerI);
            this.Controls.Add(this.textFrequency);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "moRFctrl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMixerI)).EndInit();
            this.groupSweep.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStepSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStopFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDwellTime)).EndInit();
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
        private System.Windows.Forms.Label labelMixerI;
        private System.Windows.Forms.CheckBox checkBiasTee;
        private System.Windows.Forms.GroupBox groupSweep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressSweep;
        private System.Windows.Forms.Button btnSweep;
        private System.Windows.Forms.NumericUpDown numStopFreq;
        private System.Windows.Forms.NumericUpDown numStartFreq;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numStepSize;
        private System.Windows.Forms.Label labelSweepStep;
        private System.Windows.Forms.Label labelSweepStart;
        private System.Windows.Forms.Label labelSweepStop;
        private System.Windows.Forms.NumericUpDown numDwellTime;
        private System.Windows.Forms.Label labelSweepDwell;
    }
}

