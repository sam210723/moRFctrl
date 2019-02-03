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
            this.components = new System.ComponentModel.Container();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSweep = new System.Windows.Forms.TabPage();
            this.tabPresets = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.btnLoadDefaults = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.numGqrxPort = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textGqrxIP = new System.Windows.Forms.TextBox();
            this.checkConfirmExit = new System.Windows.Forms.CheckBox();
            this.sweepFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.linkSweepOutFile = new System.Windows.Forms.LinkLabel();
            this.tipCSVFilePath = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMixerI)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStepSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStopFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDwellTime)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabSweep.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGqrxPort)).BeginInit();
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
            this.statusStrip.Location = new System.Drawing.Point(0, 304);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 3);
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
            10000000,
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
            this.labelSweepStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            1,
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
            this.labelSweepDwell.Size = new System.Drawing.Size(85, 18);
            this.labelSweepDwell.TabIndex = 10;
            this.labelSweepDwell.Text = "Dwell Time (sec)";
            // 
            // btnSweep
            // 
            this.btnSweep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnSweep.Location = new System.Drawing.Point(152, 107);
            this.btnSweep.Name = "btnSweep";
            this.btnSweep.Size = new System.Drawing.Size(75, 23);
            this.btnSweep.TabIndex = 1;
            this.btnSweep.Text = "Start";
            this.btnSweep.UseVisualStyleBackColor = false;
            this.btnSweep.Click += new System.EventHandler(this.btnSweep_Click);
            // 
            // progressSweep
            // 
            this.progressSweep.Location = new System.Drawing.Point(4, 108);
            this.progressSweep.Name = "progressSweep";
            this.progressSweep.Size = new System.Drawing.Size(145, 21);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSweep);
            this.tabControl1.Controls.Add(this.tabPresets);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Location = new System.Drawing.Point(12, 134);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(238, 159);
            this.tabControl1.TabIndex = 5;
            // 
            // tabSweep
            // 
            this.tabSweep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabSweep.Controls.Add(this.tableLayoutPanel1);
            this.tabSweep.Controls.Add(this.btnSweep);
            this.tabSweep.Controls.Add(this.progressSweep);
            this.tabSweep.ForeColor = System.Drawing.Color.White;
            this.tabSweep.Location = new System.Drawing.Point(4, 22);
            this.tabSweep.Name = "tabSweep";
            this.tabSweep.Padding = new System.Windows.Forms.Padding(3);
            this.tabSweep.Size = new System.Drawing.Size(230, 133);
            this.tabSweep.TabIndex = 0;
            this.tabSweep.Text = "Sweep";
            // 
            // tabPresets
            // 
            this.tabPresets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPresets.ForeColor = System.Drawing.Color.White;
            this.tabPresets.Location = new System.Drawing.Point(4, 22);
            this.tabPresets.Name = "tabPresets";
            this.tabPresets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPresets.Size = new System.Drawing.Size(230, 133);
            this.tabPresets.TabIndex = 1;
            this.tabPresets.Text = "Presets";
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabSettings.Controls.Add(this.btnLoadDefaults);
            this.tabSettings.Controls.Add(this.btnSaveSettings);
            this.tabSettings.Controls.Add(this.tableLayoutPanel2);
            this.tabSettings.ForeColor = System.Drawing.Color.White;
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(230, 133);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            // 
            // btnLoadDefaults
            // 
            this.btnLoadDefaults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnLoadDefaults.Location = new System.Drawing.Point(3, 107);
            this.btnLoadDefaults.Name = "btnLoadDefaults";
            this.btnLoadDefaults.Size = new System.Drawing.Size(110, 23);
            this.btnLoadDefaults.TabIndex = 7;
            this.btnLoadDefaults.Text = "Load Defaults";
            this.btnLoadDefaults.UseVisualStyleBackColor = false;
            this.btnLoadDefaults.Click += new System.EventHandler(this.btnLoadDefaults_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnSaveSettings.Location = new System.Drawing.Point(117, 107);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(110, 23);
            this.btnSaveSettings.TabIndex = 6;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.linkSweepOutFile, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.numGqrxPort, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textGqrxIP, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkConfirmExit, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(226, 100);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 50);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label4.Size = new System.Drawing.Size(89, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Sweep output file";
            // 
            // numGqrxPort
            // 
            this.numGqrxPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.numGqrxPort.ForeColor = System.Drawing.Color.White;
            this.numGqrxPort.Location = new System.Drawing.Point(116, 28);
            this.numGqrxPort.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numGqrxPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGqrxPort.Name = "numGqrxPort";
            this.numGqrxPort.Size = new System.Drawing.Size(107, 20);
            this.numGqrxPort.TabIndex = 14;
            this.numGqrxPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Gqrx TCP port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(82, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Gqrx IP address";
            // 
            // textGqrxIP
            // 
            this.textGqrxIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.textGqrxIP.ForeColor = System.Drawing.Color.White;
            this.textGqrxIP.Location = new System.Drawing.Point(116, 3);
            this.textGqrxIP.Name = "textGqrxIP";
            this.textGqrxIP.Size = new System.Drawing.Size(107, 20);
            this.textGqrxIP.TabIndex = 11;
            // 
            // checkConfirmExit
            // 
            this.checkConfirmExit.AutoSize = true;
            this.checkConfirmExit.Location = new System.Drawing.Point(3, 78);
            this.checkConfirmExit.Name = "checkConfirmExit";
            this.checkConfirmExit.Padding = new System.Windows.Forms.Padding(2, 3, 0, 0);
            this.checkConfirmExit.Size = new System.Drawing.Size(105, 19);
            this.checkConfirmExit.TabIndex = 12;
            this.checkConfirmExit.Text = "Exit confirmation";
            this.checkConfirmExit.UseVisualStyleBackColor = true;
            // 
            // linkSweepOutFile
            // 
            this.linkSweepOutFile.AutoSize = true;
            this.linkSweepOutFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSweepOutFile.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.linkSweepOutFile.Location = new System.Drawing.Point(116, 50);
            this.linkSweepOutFile.Name = "linkSweepOutFile";
            this.linkSweepOutFile.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.linkSweepOutFile.Size = new System.Drawing.Size(58, 18);
            this.linkSweepOutFile.TabIndex = 18;
            this.linkSweepOutFile.TabStop = true;
            this.linkSweepOutFile.Text = "sweep.csv";
            this.linkSweepOutFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSweepOutFile_LinkClicked);
            this.linkSweepOutFile.MouseHover += new System.EventHandler(this.linkSweepOutFile_MouseHover);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(262, 326);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.radioFunctionMixer);
            this.Controls.Add(this.radioFunctionGenerator);
            this.Controls.Add(this.label2);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStepSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStopFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDwellTime)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabSweep.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGqrxPort)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSweep;
        private System.Windows.Forms.TabPage tabPresets;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textGqrxIP;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.CheckBox checkConfirmExit;
        private System.Windows.Forms.NumericUpDown numGqrxPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadDefaults;
        private System.Windows.Forms.SaveFileDialog sweepFileDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkSweepOutFile;
        private System.Windows.Forms.ToolTip tipCSVFilePath;
    }
}

