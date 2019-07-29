namespace ReceivingStation.Demodulator
{
    partial class FFT_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FFT_Form));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.cBx_output = new System.Windows.Forms.CheckBox();
            this.cBx_Input = new System.Windows.Forms.CheckBox();
            this.rbEYE = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comBxGain = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comBx_SampleRate = new System.Windows.Forms.ComboBox();
            this.comBx_carrier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numUpD_PLLBw = new System.Windows.Forms.NumericUpDown();
            this.NumUpDown_Bandwidth = new System.Windows.Forms.NumericUpDown();
            this.cBx_iqFilter = new System.Windows.Forms.CheckBox();
            this.rbConstel = new System.Windows.Forms.RadioButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.scottPlotUC1 = new ScottPlot.ScottPlotUC();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFinded = new System.Windows.Forms.Label();
            this.lblLocked = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSizeS = new System.Windows.Forms.Label();
            this.btnSave_S = new System.Windows.Forms.Button();
            this.cBx_matchedFilter = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.rbRTLSDR = new System.Windows.Forms.RadioButton();
            this.rbWAV = new System.Windows.Forms.RadioButton();
            this.grBx = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.comBxModulation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comBxInteliving = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.opnDlgBtn = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_PLLBw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_Bandwidth)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grBx.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 50;
            // 
            // cBx_output
            // 
            resources.ApplyResources(this.cBx_output, "cBx_output");
            this.cBx_output.Checked = true;
            this.cBx_output.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBx_output.Name = "cBx_output";
            this.cBx_output.UseVisualStyleBackColor = true;
            // 
            // cBx_Input
            // 
            resources.ApplyResources(this.cBx_Input, "cBx_Input");
            this.cBx_Input.Checked = true;
            this.cBx_Input.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBx_Input.Name = "cBx_Input";
            this.cBx_Input.UseVisualStyleBackColor = true;
            // 
            // rbEYE
            // 
            resources.ApplyResources(this.rbEYE, "rbEYE");
            this.rbEYE.Name = "rbEYE";
            this.rbEYE.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comBxGain);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // comBxGain
            // 
            this.comBxGain.FormattingEnabled = true;
            resources.ApplyResources(this.comBxGain, "comBxGain");
            this.comBxGain.Name = "comBxGain";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comBx_SampleRate);
            this.groupBox4.Controls.Add(this.comBx_carrier);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // comBx_SampleRate
            // 
            this.comBx_SampleRate.FormattingEnabled = true;
            this.comBx_SampleRate.Items.AddRange(new object[] {
            resources.GetString("comBx_SampleRate.Items"),
            resources.GetString("comBx_SampleRate.Items1")});
            resources.ApplyResources(this.comBx_SampleRate, "comBx_SampleRate");
            this.comBx_SampleRate.Name = "comBx_SampleRate";
            // 
            // comBx_carrier
            // 
            this.comBx_carrier.FormattingEnabled = true;
            this.comBx_carrier.Items.AddRange(new object[] {
            resources.GetString("comBx_carrier.Items"),
            resources.GetString("comBx_carrier.Items1")});
            resources.ApplyResources(this.comBx_carrier, "comBx_carrier");
            this.comBx_carrier.Name = "comBx_carrier";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // numUpD_PLLBw
            // 
            this.numUpD_PLLBw.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            resources.ApplyResources(this.numUpD_PLLBw, "numUpD_PLLBw");
            this.numUpD_PLLBw.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpD_PLLBw.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numUpD_PLLBw.Name = "numUpD_PLLBw";
            this.numUpD_PLLBw.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // NumUpDown_Bandwidth
            // 
            this.NumUpDown_Bandwidth.Increment = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            resources.ApplyResources(this.NumUpDown_Bandwidth, "NumUpDown_Bandwidth");
            this.NumUpDown_Bandwidth.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.NumUpDown_Bandwidth.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumUpDown_Bandwidth.Name = "NumUpDown_Bandwidth";
            this.NumUpDown_Bandwidth.Value = new decimal(new int[] {
            180000,
            0,
            0,
            0});
            // 
            // cBx_iqFilter
            // 
            resources.ApplyResources(this.cBx_iqFilter, "cBx_iqFilter");
            this.cBx_iqFilter.Checked = true;
            this.cBx_iqFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBx_iqFilter.Name = "cBx_iqFilter";
            this.cBx_iqFilter.UseVisualStyleBackColor = true;
            // 
            // rbConstel
            // 
            resources.ApplyResources(this.rbConstel, "rbConstel");
            this.rbConstel.Checked = true;
            this.rbConstel.Name = "rbConstel";
            this.rbConstel.TabStop = true;
            this.rbConstel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.scottPlotUC1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // scottPlotUC1
            // 
            resources.ApplyResources(this.scottPlotUC1, "scottPlotUC1");
            this.scottPlotUC1.Name = "scottPlotUC1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFinded);
            this.panel1.Controls.Add(this.lblLocked);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comBxInteliving);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comBxModulation);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Name = "panel1";
            // 
            // lblFinded
            // 
            resources.ApplyResources(this.lblFinded, "lblFinded");
            this.lblFinded.BackColor = System.Drawing.Color.Lime;
            this.lblFinded.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblFinded.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblFinded.Name = "lblFinded";
            // 
            // lblLocked
            // 
            resources.ApplyResources(this.lblLocked, "lblLocked");
            this.lblLocked.BackColor = System.Drawing.Color.Lime;
            this.lblLocked.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblLocked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblLocked.Name = "lblLocked";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSizeS);
            this.groupBox2.Controls.Add(this.btnSave_S);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // lblSizeS
            // 
            resources.ApplyResources(this.lblSizeS, "lblSizeS");
            this.lblSizeS.ForeColor = System.Drawing.Color.Black;
            this.lblSizeS.Name = "lblSizeS";
            // 
            // btnSave_S
            // 
            this.btnSave_S.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.btnSave_S, "btnSave_S");
            this.btnSave_S.Name = "btnSave_S";
            this.btnSave_S.UseVisualStyleBackColor = true;
            // 
            // cBx_matchedFilter
            // 
            resources.ApplyResources(this.cBx_matchedFilter, "cBx_matchedFilter");
            this.cBx_matchedFilter.Checked = true;
            this.cBx_matchedFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBx_matchedFilter.Name = "cBx_matchedFilter";
            this.cBx_matchedFilter.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // rbRTLSDR
            // 
            resources.ApplyResources(this.rbRTLSDR, "rbRTLSDR");
            this.rbRTLSDR.Name = "rbRTLSDR";
            this.rbRTLSDR.UseVisualStyleBackColor = true;
            // 
            // rbWAV
            // 
            resources.ApplyResources(this.rbWAV, "rbWAV");
            this.rbWAV.Checked = true;
            this.rbWAV.Name = "rbWAV";
            this.rbWAV.TabStop = true;
            this.rbWAV.UseVisualStyleBackColor = true;
            // 
            // grBx
            // 
            this.grBx.Controls.Add(this.rbWAV);
            this.grBx.Controls.Add(this.rbRTLSDR);
            resources.ApplyResources(this.grBx, "grBx");
            this.grBx.Name = "grBx";
            this.grBx.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // comBxModulation
            // 
            this.comBxModulation.FormattingEnabled = true;
            this.comBxModulation.Items.AddRange(new object[] {
            resources.GetString("comBxModulation.Items"),
            resources.GetString("comBxModulation.Items1")});
            resources.ApplyResources(this.comBxModulation, "comBxModulation");
            this.comBxModulation.Name = "comBxModulation";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // comBxInteliving
            // 
            this.comBxInteliving.FormattingEnabled = true;
            this.comBxInteliving.Items.AddRange(new object[] {
            resources.GetString("comBxInteliving.Items"),
            resources.GetString("comBxInteliving.Items1")});
            resources.ApplyResources(this.comBxInteliving, "comBxInteliving");
            this.comBxInteliving.Name = "comBxInteliving";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Name = "label4";
            // 
            // opnDlgBtn
            // 
            this.opnDlgBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.opnDlgBtn, "opnDlgBtn");
            this.opnDlgBtn.Name = "opnDlgBtn";
            this.opnDlgBtn.UseVisualStyleBackColor = true;
            // 
            // lblPath
            // 
            this.lblPath.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblPath, "lblPath");
            this.lblPath.Name = "lblPath";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.lblPath);
            this.groupBox1.Controls.Add(this.opnDlgBtn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // FFT_Form
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cBx_output);
            this.Controls.Add(this.cBx_Input);
            this.Controls.Add(this.rbEYE);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grBx);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numUpD_PLLBw);
            this.Controls.Add(this.NumUpDown_Bandwidth);
            this.Controls.Add(this.cBx_iqFilter);
            this.Controls.Add(this.rbConstel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cBx_matchedFilter);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FFT_Form";
            this.Load += new System.EventHandler(this.FFT_Form_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_PLLBw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_Bandwidth)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grBx.ResumeLayout(false);
            this.grBx.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox cBx_output;
        private System.Windows.Forms.CheckBox cBx_Input;
        private System.Windows.Forms.RadioButton rbEYE;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comBxGain;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comBx_SampleRate;
        private System.Windows.Forms.ComboBox comBx_carrier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numUpD_PLLBw;
        private System.Windows.Forms.NumericUpDown NumUpDown_Bandwidth;
        private System.Windows.Forms.CheckBox cBx_iqFilter;
        private System.Windows.Forms.RadioButton rbConstel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ScottPlot.ScottPlotUC scottPlotUC1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFinded;
        private System.Windows.Forms.Label lblLocked;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSizeS;
        private System.Windows.Forms.Button btnSave_S;
        private System.Windows.Forms.CheckBox cBx_matchedFilter;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button opnDlgBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comBxInteliving;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comBxModulation;
        private System.Windows.Forms.RadioButton rbRTLSDR;
        private System.Windows.Forms.RadioButton rbWAV;
        private System.Windows.Forms.GroupBox grBx;
    }
}