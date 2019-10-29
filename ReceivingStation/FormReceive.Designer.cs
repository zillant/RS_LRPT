namespace ReceivingStation
{
    partial class FormReceive
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReceive));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.slWorkingTimeOnboard = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.slMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bwImageSaver = new System.ComponentModel.BackgroundWorker();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pImage1 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pImage2 = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pImage3 = new System.Windows.Forms.Panel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pImage4 = new System.Windows.Forms.Panel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.pImage5 = new System.Windows.Forms.Panel();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.pImage6 = new System.Windows.Forms.Panel();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.pImage7 = new System.Windows.Forms.Panel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.pImage8 = new System.Windows.Forms.Panel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.pImage9 = new System.Windows.Forms.Panel();
            this.pImage10 = new System.Windows.Forms.Panel();
            this.pImage11 = new System.Windows.Forms.Panel();
            this.pImage12 = new System.Windows.Forms.Panel();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.rtbMkoData = new ReceivingStation.Other.DisabledRichTextBox();
            this.rtbMkoTitle = new ReceivingStation.Other.DisabledRichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.rtbServiceTitle = new ReceivingStation.Other.DisabledRichTextBox();
            this.rtbServiceData = new ReceivingStation.Other.DisabledRichTextBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.DemodPanel = new System.Windows.Forms.TableLayoutPanel();
            this.scottPlotUC1 = new ScottPlot.ScottPlotUC();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.numUpD_FindedBitsInInterliving = new System.Windows.Forms.NumericUpDown();
            this.lbl_PSPMode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cBx_HardPSP = new System.Windows.Forms.CheckBox();
            this.numUpD_FindedBitsInPSP = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBx_datWriter = new System.Windows.Forms.CheckBox();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblFinded = new System.Windows.Forms.Label();
            this.lblLocked = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chBx_sWriter = new System.Windows.Forms.CheckBox();
            this.lblSizeS = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comBxModulation = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GainNM = new System.Windows.Forms.NumericUpDown();
            this.cBx_matchedFilter = new System.Windows.Forms.CheckBox();
            this.comBx_SampleRate = new System.Windows.Forms.ComboBox();
            this.comBx_carrier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cBx_iqFilter = new System.Windows.Forms.CheckBox();
            this.numUpD_PLLBw = new System.Windows.Forms.NumericUpDown();
            this.NumUpDown_Bandwidth = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cBx_output = new System.Windows.Forms.CheckBox();
            this.rbEYE = new System.Windows.Forms.RadioButton();
            this.cBx_Input = new System.Windows.Forms.CheckBox();
            this.rbConstel = new System.Windows.Forms.RadioButton();
            this.display1 = new ReceivingStation.Demodulator.Display();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.tlp1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnStartRecieve = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tlpReceivingParameters = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rbPRDReserve = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbPRDMain = new MaterialSkin.Controls.MaterialRadioButton();
            this.lblPRD = new MaterialSkin.Controls.MaterialLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbFreq2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbFreq1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.lblFreq = new MaterialSkin.Controls.MaterialLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbFCPReserve = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbFCPMain = new MaterialSkin.Controls.MaterialRadioButton();
            this.lblFCP = new MaterialSkin.Controls.MaterialLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbInterlivingReceiveOff = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbInterlivingReceiveOn = new MaterialSkin.Controls.MaterialRadioButton();
            this.lblInterliving = new MaterialSkin.Controls.MaterialLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.opnDlg = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.DemodTimer = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rtbMkoData = new ReceivingStation.Other.DisabledRichTextBox();
            this.rtbMkoTitle = new ReceivingStation.Other.DisabledRichTextBox();
            this.rtbServiceTitle = new ReceivingStation.Other.DisabledRichTextBox();
            this.rtbServiceData = new ReceivingStation.Other.DisabledRichTextBox();
            this.display1 = new ReceivingStation.Demodulator.Display();
            this.pModulation = new ReceivingStation.Other.DoubleBufferedPanel();
            this.rbQpsk = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbOqpsk = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.doubleBufferedPanel1 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.rtbDateTimeTitle = new ReceivingStation.Other.DisabledRichTextBox();
            this.pSourcePanel = new ReceivingStation.Other.DoubleBufferedPanel();
            this.lblSignDetect = new MaterialSkin.Controls.MaterialLabel();
            this.rbWav = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbFUNcube = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.rtbDateTime = new ReceivingStation.Other.DisabledRichTextBox();
            this.doubleBufferedPanel2 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.lblDemOn = new MaterialSkin.Controls.MaterialLabel();
            this.lblDongOn = new MaterialSkin.Controls.MaterialLabel();
            this.pbInterSyncOk = new System.Windows.Forms.PictureBox();
            this.pbSignalSyncOk = new System.Windows.Forms.PictureBox();
            this.pbInterSyncErr = new System.Windows.Forms.PictureBox();
            this.pbSignalSyncErr = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.DemodPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_FindedBitsInInterliving)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_FindedBitsInPSP)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GainNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_PLLBw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_Bandwidth)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tlp1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tlpReceivingParameters.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pModulation.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.doubleBufferedPanel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pSourcePanel.SuspendLayout();
            this.doubleBufferedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInterSyncOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignalSyncOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInterSyncErr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignalSyncErr)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slTime,
            this.toolStripStatusLabel2,
            this.slWorkingTimeOnboard,
            this.toolStripStatusLabel1,
            this.slMode});
            this.statusStrip1.Location = new System.Drawing.Point(0, 775);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(1570, 25);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slTime
            // 
            this.slTime.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.slTime.Image = global::ReceivingStation.Properties.Resources.time_icon;
            this.slTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.slTime.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.slTime.Name = "slTime";
            this.slTime.Size = new System.Drawing.Size(159, 20);
            this.slTime.Text = "01/01/1668 12:12:01";
            this.slTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.slTime.ToolTipText = "Текущие дата/время";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(537, 20);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // slWorkingTimeOnboard
            // 
            this.slWorkingTimeOnboard.DoubleClickEnabled = true;
            this.slWorkingTimeOnboard.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.slWorkingTimeOnboard.Image = global::ReceivingStation.Properties.Resources.time_icon;
            this.slWorkingTimeOnboard.Name = "slWorkingTimeOnboard";
            this.slWorkingTimeOnboard.Size = new System.Drawing.Size(148, 20);
            this.slWorkingTimeOnboard.Text = "Время наработки";
            this.slWorkingTimeOnboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.slWorkingTimeOnboard.ToolTipText = "Отобразить время наработки";
            this.slWorkingTimeOnboard.DoubleClick += new System.EventHandler(this.slWorkingTimeOnboard_DoubleClick);
            this.slWorkingTimeOnboard.MouseLeave += new System.EventHandler(this.slWorkingTimeOnboard_MouseLeave);
            this.slWorkingTimeOnboard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.slWorkingTimeOnboard_MouseMove);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(537, 20);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // slMode
            // 
            this.slMode.BackColor = System.Drawing.SystemColors.Window;
            this.slMode.DoubleClickEnabled = true;
            this.slMode.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.slMode.Image = global::ReceivingStation.Properties.Resources.mode_icon;
            this.slMode.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.slMode.Name = "slMode";
            this.slMode.Size = new System.Drawing.Size(172, 20);
            this.slMode.Text = "Местное управление";
            this.slMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.slMode.ToolTipText = "Режим управления";
            this.slMode.DoubleClick += new System.EventHandler(this.slMode_DoubleClick);
            this.slMode.MouseLeave += new System.EventHandler(this.slMode_MouseLeave);
            this.slMode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.slMode_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bwImageSaver
            // 
            this.bwImageSaver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwImageSaver_DoWork);
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Controls.Add(this.tabPage3);
            this.materialTabControl1.Controls.Add(this.tabPage4);
            this.materialTabControl1.Controls.Add(this.tabPage5);
            this.materialTabControl1.Controls.Add(this.tabPage6);
            this.materialTabControl1.Controls.Add(this.tabPage7);
            this.materialTabControl1.Controls.Add(this.tabPage8);
            this.materialTabControl1.Controls.Add(this.tabPage9);
            this.materialTabControl1.Controls.Add(this.tabPage10);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 213);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1570, 562);
            this.materialTabControl1.TabIndex = 36;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pImage1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1562, 536);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Канал 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pImage1
            // 
            this.pImage1.Location = new System.Drawing.Point(3, 3);
            this.pImage1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pImage1.Name = "pImage1";
            this.pImage1.Size = new System.Drawing.Size(1556, 530);
            this.pImage1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pImage2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1562, 536);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Канал 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pImage2
            // 
            this.pImage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pImage2.Location = new System.Drawing.Point(3, 3);
            this.pImage2.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pImage2.Name = "pImage2";
            this.pImage2.Size = new System.Drawing.Size(1556, 530);
            this.pImage2.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pImage3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1562, 536);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Канал 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pImage3
            // 
            this.pImage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pImage3.Location = new System.Drawing.Point(3, 3);
            this.pImage3.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pImage3.Name = "pImage3";
            this.pImage3.Size = new System.Drawing.Size(1556, 530);
            this.pImage3.TabIndex = 4;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pImage4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1562, 536);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Канал 4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pImage4
            // 
            this.pImage4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pImage4.Location = new System.Drawing.Point(3, 3);
            this.pImage4.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pImage4.Name = "pImage4";
            this.pImage4.Size = new System.Drawing.Size(1556, 530);
            this.pImage4.TabIndex = 4;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.pImage5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1562, 536);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Канал 5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // pImage5
            // 
            this.pImage5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pImage5.Location = new System.Drawing.Point(3, 3);
            this.pImage5.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pImage5.Name = "pImage5";
            this.pImage5.Size = new System.Drawing.Size(1556, 530);
            this.pImage5.TabIndex = 4;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.pImage6);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1562, 536);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Канал 6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // pImage6
            // 
            this.pImage6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pImage6.Location = new System.Drawing.Point(3, 3);
            this.pImage6.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pImage6.Name = "pImage6";
            this.pImage6.Size = new System.Drawing.Size(1556, 530);
            this.pImage6.TabIndex = 4;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.tableLayoutPanel1);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1562, 536);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Все каналы";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.materialLabel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pImage7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.pImage8, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel4, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.pImage9, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.pImage10, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.pImage11, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.pImage12, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.73684F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1556, 530);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // materialLabel3
            // 
            this.materialLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(97, 4);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(65, 19);
            this.materialLabel3.TabIndex = 8;
            this.materialLabel3.Text = "Канал 1";
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(356, 4);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(65, 19);
            this.materialLabel1.TabIndex = 6;
            this.materialLabel1.Text = "Канал 2";
            // 
            // materialLabel6
            // 
            this.materialLabel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(615, 4);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(65, 19);
            this.materialLabel6.TabIndex = 11;
            this.materialLabel6.Text = "Канал 3";
            // 
            // pImage7
            // 
            this.pImage7.Location = new System.Drawing.Point(10, 30);
            this.pImage7.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pImage7.Name = "pImage7";
            this.pImage7.Size = new System.Drawing.Size(235, 492);
            this.pImage7.TabIndex = 0;
            // 
            // materialLabel2
            // 
            this.materialLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(874, 4);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(65, 19);
            this.materialLabel2.TabIndex = 7;
            this.materialLabel2.Text = "Канал 4";
            // 
            // materialLabel5
            // 
            this.materialLabel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(1133, 4);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(65, 19);
            this.materialLabel5.TabIndex = 10;
            this.materialLabel5.Text = "Канал 5";
            // 
            // pImage8
            // 
            this.pImage8.Location = new System.Drawing.Point(269, 30);
            this.pImage8.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pImage8.Name = "pImage8";
            this.pImage8.Size = new System.Drawing.Size(235, 492);
            this.pImage8.TabIndex = 1;
            // 
            // materialLabel4
            // 
            this.materialLabel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(1393, 4);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(65, 19);
            this.materialLabel4.TabIndex = 9;
            this.materialLabel4.Text = "Канал 6";
            // 
            // pImage9
            // 
            this.pImage9.Location = new System.Drawing.Point(528, 30);
            this.pImage9.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pImage9.Name = "pImage9";
            this.pImage9.Size = new System.Drawing.Size(235, 492);
            this.pImage9.TabIndex = 2;
            // 
            // pImage10
            // 
            this.pImage10.Location = new System.Drawing.Point(787, 30);
            this.pImage10.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pImage10.Name = "pImage10";
            this.pImage10.Size = new System.Drawing.Size(235, 492);
            this.pImage10.TabIndex = 3;
            // 
            // pImage11
            // 
            this.pImage11.Location = new System.Drawing.Point(1046, 30);
            this.pImage11.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pImage11.Name = "pImage11";
            this.pImage11.Size = new System.Drawing.Size(235, 492);
            this.pImage11.TabIndex = 4;
            // 
            // pImage12
            // 
            this.pImage12.Location = new System.Drawing.Point(1305, 30);
            this.pImage12.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pImage12.Name = "pImage12";
            this.pImage12.Size = new System.Drawing.Size(241, 492);
            this.pImage12.TabIndex = 5;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.tableLayoutPanel3);
            this.tabPage8.Controls.Add(this.splitter1);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1562, 536);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "МКО";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.04041F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.95959F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 248F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 369F));
            this.tableLayoutPanel3.Controls.Add(this.rtbMkoData, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.rtbMkoTitle, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 49);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1556, 484);
            this.tableLayoutPanel3.TabIndex = 110;
            // 
            // rtbMkoData
            // 
            this.rtbMkoData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMkoData.Location = new System.Drawing.Point(957, 3);
            this.rtbMkoData.Name = "rtbMkoData";
            this.rtbMkoData.Size = new System.Drawing.Size(242, 478);
            this.rtbMkoData.TabIndex = 0;
            this.rtbMkoData.Text = "";
            // 
            // rtbMkoTitle
            // 
            this.rtbMkoTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMkoTitle.Location = new System.Drawing.Point(423, 3);
            this.rtbMkoTitle.Name = "rtbMkoTitle";
            this.rtbMkoTitle.Size = new System.Drawing.Size(528, 478);
            this.rtbMkoTitle.TabIndex = 1;
            this.rtbMkoTitle.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.Window;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(3, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1556, 46);
            this.splitter1.TabIndex = 109;
            this.splitter1.TabStop = false;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.tableLayoutPanel4);
            this.tabPage9.Controls.Add(this.splitter2);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1562, 536);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "Служебная информация";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.08559F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.91441F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 507F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.tableLayoutPanel4.Controls.Add(this.rtbServiceTitle, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.rtbServiceData, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 46);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1562, 490);
            this.tableLayoutPanel4.TabIndex = 112;
            // 
            // rtbServiceTitle
            // 
            this.rtbServiceTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbServiceTitle.Location = new System.Drawing.Point(425, 3);
            this.rtbServiceTitle.Name = "rtbServiceTitle";
            this.rtbServiceTitle.Size = new System.Drawing.Size(450, 484);
            this.rtbServiceTitle.TabIndex = 0;
            this.rtbServiceTitle.Text = "";
            // 
            // rtbServiceData
            // 
            this.rtbServiceData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbServiceData.Location = new System.Drawing.Point(881, 3);
            this.rtbServiceData.Name = "rtbServiceData";
            this.rtbServiceData.Size = new System.Drawing.Size(501, 484);
            this.rtbServiceData.TabIndex = 1;
            this.rtbServiceData.Text = "";
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.Window;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1562, 46);
            this.splitter2.TabIndex = 111;
            this.splitter2.TabStop = false;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.DemodPanel);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(1562, 536);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Text = "File FFT Data";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // DemodPanel
            // 
            this.DemodPanel.ColumnCount = 3;
            this.DemodPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.05232F));
            this.DemodPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.94768F));
            this.DemodPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 451F));
            this.DemodPanel.Controls.Add(this.scottPlotUC1, 0, 0);
            this.DemodPanel.Controls.Add(this.panel1, 0, 0);
            this.DemodPanel.Controls.Add(this.groupBox4, 1, 1);
            this.DemodPanel.Controls.Add(this.groupBox3, 2, 1);
            this.DemodPanel.Controls.Add(this.display1, 2, 0);
            this.DemodPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DemodPanel.Location = new System.Drawing.Point(0, 0);
            this.DemodPanel.Name = "DemodPanel";
            this.DemodPanel.RowCount = 2;
            this.DemodPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DemodPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.DemodPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.DemodPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.DemodPanel.Size = new System.Drawing.Size(1562, 536);
            this.DemodPanel.TabIndex = 29;
            // 
            // scottPlotUC1
            // 
            this.scottPlotUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scottPlotUC1.Location = new System.Drawing.Point(213, 2);
            this.scottPlotUC1.Margin = new System.Windows.Forms.Padding(2);
            this.scottPlotUC1.Name = "scottPlotUC1";
            this.scottPlotUC1.Size = new System.Drawing.Size(895, 467);
            this.scottPlotUC1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.numUpD_FindedBitsInInterliving);
            this.panel1.Controls.Add(this.lbl_PSPMode);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.numUpD_FindedBitsInPSP);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lblShift);
            this.panel1.Controls.Add(this.lblFinded);
            this.panel1.Controls.Add(this.lblLocked);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comBxModulation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 465);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(31, 371);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "Finded bits in interliving";
            // 
            // numUpD_FindedBitsInInterliving
            // 
            this.numUpD_FindedBitsInInterliving.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUpD_FindedBitsInInterliving.Location = new System.Drawing.Point(79, 387);
            this.numUpD_FindedBitsInInterliving.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numUpD_FindedBitsInInterliving.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numUpD_FindedBitsInInterliving.Name = "numUpD_FindedBitsInInterliving";
            this.numUpD_FindedBitsInInterliving.Size = new System.Drawing.Size(45, 20);
            this.numUpD_FindedBitsInInterliving.TabIndex = 64;
            this.numUpD_FindedBitsInInterliving.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // lbl_PSPMode
            // 
            this.lbl_PSPMode.AutoSize = true;
            this.lbl_PSPMode.ForeColor = System.Drawing.Color.Black;
            this.lbl_PSPMode.Location = new System.Drawing.Point(23, 108);
            this.lbl_PSPMode.Name = "lbl_PSPMode";
            this.lbl_PSPMode.Size = new System.Drawing.Size(83, 13);
            this.lbl_PSPMode.TabIndex = 63;
            this.lbl_PSPMode.Text = "correction mode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(31, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "Finded bits in sync marker";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cBx_HardPSP);
            this.groupBox5.Location = new System.Drawing.Point(25, 255);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(159, 45);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Hard mark search";
            // 
            // cBx_HardPSP
            // 
            this.cBx_HardPSP.AutoSize = true;
            this.cBx_HardPSP.ForeColor = System.Drawing.Color.Black;
            this.cBx_HardPSP.Location = new System.Drawing.Point(6, 20);
            this.cBx_HardPSP.Name = "cBx_HardPSP";
            this.cBx_HardPSP.Size = new System.Drawing.Size(65, 17);
            this.cBx_HardPSP.TabIndex = 9;
            this.cBx_HardPSP.Text = "Enabled";
            this.cBx_HardPSP.UseVisualStyleBackColor = true;
            // 
            // numUpD_FindedBitsInPSP
            // 
            this.numUpD_FindedBitsInPSP.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUpD_FindedBitsInPSP.Location = new System.Drawing.Point(79, 334);
            this.numUpD_FindedBitsInPSP.Maximum = new decimal(new int[] {
            96,
            0,
            0,
            0});
            this.numUpD_FindedBitsInPSP.Minimum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.numUpD_FindedBitsInPSP.Name = "numUpD_FindedBitsInPSP";
            this.numUpD_FindedBitsInPSP.Size = new System.Drawing.Size(45, 20);
            this.numUpD_FindedBitsInPSP.TabIndex = 61;
            this.numUpD_FindedBitsInPSP.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBx_datWriter);
            this.groupBox1.Location = new System.Drawing.Point(25, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 45);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = ".dat writer";
            // 
            // cBx_datWriter
            // 
            this.cBx_datWriter.AutoSize = true;
            this.cBx_datWriter.ForeColor = System.Drawing.Color.Black;
            this.cBx_datWriter.Location = new System.Drawing.Point(6, 20);
            this.cBx_datWriter.Name = "cBx_datWriter";
            this.cBx_datWriter.Size = new System.Drawing.Size(65, 17);
            this.cBx_datWriter.TabIndex = 9;
            this.cBx_datWriter.Text = "Enabled";
            this.cBx_datWriter.UseVisualStyleBackColor = true;
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.ForeColor = System.Drawing.Color.Black;
            this.lblShift.Location = new System.Drawing.Point(23, 88);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(52, 13);
            this.lblShift.TabIndex = 11;
            this.lblShift.Text = "Freq Shift";
            // 
            // lblFinded
            // 
            this.lblFinded.AutoSize = true;
            this.lblFinded.BackColor = System.Drawing.Color.Lime;
            this.lblFinded.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblFinded.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblFinded.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFinded.Location = new System.Drawing.Point(100, 62);
            this.lblFinded.Name = "lblFinded";
            this.lblFinded.Size = new System.Drawing.Size(84, 13);
            this.lblFinded.TabIndex = 10;
            this.lblFinded.Text = "MARK FINDED ";
            // 
            // lblLocked
            // 
            this.lblLocked.AutoSize = true;
            this.lblLocked.BackColor = System.Drawing.Color.Lime;
            this.lblLocked.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblLocked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblLocked.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLocked.Location = new System.Drawing.Point(22, 62);
            this.lblLocked.Name = "lblLocked";
            this.lblLocked.Size = new System.Drawing.Size(72, 13);
            this.lblLocked.TabIndex = 9;
            this.lblLocked.Text = "PLL LOCKED";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chBx_sWriter);
            this.groupBox2.Controls.Add(this.lblSizeS);
            this.groupBox2.Location = new System.Drawing.Point(25, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = ".s writer";
            // 
            // chBx_sWriter
            // 
            this.chBx_sWriter.AutoSize = true;
            this.chBx_sWriter.ForeColor = System.Drawing.Color.Black;
            this.chBx_sWriter.Location = new System.Drawing.Point(6, 20);
            this.chBx_sWriter.Name = "chBx_sWriter";
            this.chBx_sWriter.Size = new System.Drawing.Size(65, 17);
            this.chBx_sWriter.TabIndex = 9;
            this.chBx_sWriter.Text = "Enabled";
            this.chBx_sWriter.UseVisualStyleBackColor = true;
            // 
            // lblSizeS
            // 
            this.lblSizeS.AutoSize = true;
            this.lblSizeS.ForeColor = System.Drawing.Color.Black;
            this.lblSizeS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSizeS.Location = new System.Drawing.Point(6, 40);
            this.lblSizeS.Name = "lblSizeS";
            this.lblSizeS.Size = new System.Drawing.Size(27, 13);
            this.lblSizeS.TabIndex = 8;
            this.lblSizeS.Text = "Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Модель КА";
            // 
            // comBxModulation
            // 
            this.comBxModulation.FormattingEnabled = true;
            this.comBxModulation.Items.AddRange(new object[] {
            "Meteor-M2",
            "Meteor-M2.2"});
            this.comBxModulation.Location = new System.Drawing.Point(103, 14);
            this.comBxModulation.Name = "comBxModulation";
            this.comBxModulation.Size = new System.Drawing.Size(82, 21);
            this.comBxModulation.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.GainNM);
            this.groupBox4.Controls.Add(this.cBx_matchedFilter);
            this.groupBox4.Controls.Add(this.comBx_SampleRate);
            this.groupBox4.Controls.Add(this.comBx_carrier);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.cBx_iqFilter);
            this.groupBox4.Controls.Add(this.numUpD_PLLBw);
            this.groupBox4.Controls.Add(this.NumUpDown_Bandwidth);
            this.groupBox4.Location = new System.Drawing.Point(405, 474);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(510, 59);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RTL-SDR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Gain";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Sample Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Carrier";
            // 
            // GainNM
            // 
            this.GainNM.Location = new System.Drawing.Point(180, 33);
            this.GainNM.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.GainNM.Name = "GainNM";
            this.GainNM.Size = new System.Drawing.Size(41, 20);
            this.GainNM.TabIndex = 57;
            this.GainNM.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.GainNM.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // cBx_matchedFilter
            // 
            this.cBx_matchedFilter.AutoSize = true;
            this.cBx_matchedFilter.Checked = true;
            this.cBx_matchedFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBx_matchedFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cBx_matchedFilter.Location = new System.Drawing.Point(401, 31);
            this.cBx_matchedFilter.Name = "cBx_matchedFilter";
            this.cBx_matchedFilter.Size = new System.Drawing.Size(93, 17);
            this.cBx_matchedFilter.TabIndex = 41;
            this.cBx_matchedFilter.Text = "Matched Filter";
            this.cBx_matchedFilter.UseVisualStyleBackColor = true;
            // 
            // comBx_SampleRate
            // 
            this.comBx_SampleRate.FormattingEnabled = true;
            this.comBx_SampleRate.Items.AddRange(new object[] {
            "1024000",
            "2048000"});
            this.comBx_SampleRate.Location = new System.Drawing.Point(82, 32);
            this.comBx_SampleRate.Name = "comBx_SampleRate";
            this.comBx_SampleRate.Size = new System.Drawing.Size(92, 21);
            this.comBx_SampleRate.TabIndex = 1;
            // 
            // comBx_carrier
            // 
            this.comBx_carrier.FormattingEnabled = true;
            this.comBx_carrier.Items.AddRange(new object[] {
            "137.100",
            "137.900"});
            this.comBx_carrier.Location = new System.Drawing.Point(6, 32);
            this.comBx_carrier.Name = "comBx_carrier";
            this.comBx_carrier.Size = new System.Drawing.Size(70, 21);
            this.comBx_carrier.TabIndex = 0;
            this.comBx_carrier.SelectedValueChanged += new System.EventHandler(this.comBx_carrier_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(243, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "PLL Bandwidth";
            // 
            // cBx_iqFilter
            // 
            this.cBx_iqFilter.AutoSize = true;
            this.cBx_iqFilter.Checked = true;
            this.cBx_iqFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBx_iqFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cBx_iqFilter.Location = new System.Drawing.Point(250, 39);
            this.cBx_iqFilter.Name = "cBx_iqFilter";
            this.cBx_iqFilter.Size = new System.Drawing.Size(62, 17);
            this.cBx_iqFilter.TabIndex = 37;
            this.cBx_iqFilter.Text = "IQ Filter";
            this.cBx_iqFilter.UseVisualStyleBackColor = true;
            // 
            // numUpD_PLLBw
            // 
            this.numUpD_PLLBw.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numUpD_PLLBw.Location = new System.Drawing.Point(328, 17);
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
            this.numUpD_PLLBw.Size = new System.Drawing.Size(67, 20);
            this.numUpD_PLLBw.TabIndex = 39;
            this.numUpD_PLLBw.Value = new decimal(new int[] {
            400,
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
            this.NumUpDown_Bandwidth.Location = new System.Drawing.Point(328, 38);
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
            this.NumUpDown_Bandwidth.Size = new System.Drawing.Size(67, 20);
            this.NumUpDown_Bandwidth.TabIndex = 38;
            this.NumUpDown_Bandwidth.Value = new decimal(new int[] {
            180000,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.cBx_output);
            this.groupBox3.Controls.Add(this.rbEYE);
            this.groupBox3.Controls.Add(this.cBx_Input);
            this.groupBox3.Controls.Add(this.rbConstel);
            this.groupBox3.Location = new System.Drawing.Point(1171, 474);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(329, 59);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Constellation";
            // 
            // cBx_output
            // 
            this.cBx_output.AutoSize = true;
            this.cBx_output.Checked = true;
            this.cBx_output.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBx_output.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cBx_output.Location = new System.Drawing.Point(166, 32);
            this.cBx_output.Name = "cBx_output";
            this.cBx_output.Size = new System.Drawing.Size(122, 17);
            this.cBx_output.TabIndex = 33;
            this.cBx_output.Text = "Выходные отсчеты";
            this.cBx_output.UseVisualStyleBackColor = true;
            // 
            // rbEYE
            // 
            this.rbEYE.AutoSize = true;
            this.rbEYE.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbEYE.Location = new System.Drawing.Point(6, 33);
            this.rbEYE.Name = "rbEYE";
            this.rbEYE.Size = new System.Drawing.Size(139, 17);
            this.rbEYE.TabIndex = 31;
            this.rbEYE.Text = "Глазковая диаграмма";
            this.rbEYE.UseVisualStyleBackColor = true;
            // 
            // cBx_Input
            // 
            this.cBx_Input.AutoSize = true;
            this.cBx_Input.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cBx_Input.Location = new System.Drawing.Point(166, 15);
            this.cBx_Input.Name = "cBx_Input";
            this.cBx_Input.Size = new System.Drawing.Size(114, 17);
            this.cBx_Input.TabIndex = 32;
            this.cBx_Input.Text = "Входные отсчеты";
            this.cBx_Input.UseVisualStyleBackColor = true;
            // 
            // rbConstel
            // 
            this.rbConstel.AutoSize = true;
            this.rbConstel.Checked = true;
            this.rbConstel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbConstel.Location = new System.Drawing.Point(6, 17);
            this.rbConstel.Name = "rbConstel";
            this.rbConstel.Size = new System.Drawing.Size(80, 17);
            this.rbConstel.TabIndex = 30;
            this.rbConstel.TabStop = true;
            this.rbConstel.Text = "Созвездие";
            this.rbConstel.UseVisualStyleBackColor = true;
            // 
            // display1
            // 
            this.display1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.display1.Constellation = false;
            this.display1.Eye = false;
            this.display1.Gain = 1;
            this.display1.Input = false;
            this.display1.Location = new System.Drawing.Point(1129, 3);
            this.display1.Name = "display1";
            this.display1.Output = false;
            this.display1.Pause = false;
            this.display1.SamplesPerSymbol = 0;
            this.display1.Size = new System.Drawing.Size(430, 426);
            this.display1.TabIndex = 37;
            this.display1.Zoom = 1;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 173);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1570, 40);
            this.materialTabSelector1.TabIndex = 37;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialDivider1.Enabled = false;
            this.materialDivider1.Location = new System.Drawing.Point(0, 0);
            this.materialDivider1.MaximumSize = new System.Drawing.Size(1, 59);
            this.materialDivider1.MinimumSize = new System.Drawing.Size(1, 59);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(1, 59);
            this.materialDivider1.TabIndex = 38;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // tlp1
            // 
            this.tlp1.BackColor = System.Drawing.SystemColors.Window;
            this.tlp1.ColumnCount = 3;
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.79435F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.15424F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlp1.Controls.Add(this.panel5, 1, 0);
            this.tlp1.Controls.Add(this.tlpReceivingParameters, 0, 0);
            this.tlp1.Controls.Add(this.panel6, 2, 0);
            this.tlp1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp1.Location = new System.Drawing.Point(0, 59);
            this.tlp1.Name = "tlp1";
            this.tlp1.RowCount = 1;
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp1.Size = new System.Drawing.Size(1570, 114);
            this.tlp1.TabIndex = 46;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Window;
            this.panel5.Controls.Add(this.btnStartRecieve);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(706, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(153, 108);
            this.panel5.TabIndex = 43;
            // 
            // btnStartRecieve
            // 
            this.btnStartRecieve.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartRecieve.Depth = 0;
            this.btnStartRecieve.Location = new System.Drawing.Point(0, 41);
            this.btnStartRecieve.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStartRecieve.Name = "btnStartRecieve";
            this.btnStartRecieve.Primary = true;
            this.btnStartRecieve.Size = new System.Drawing.Size(153, 43);
            this.btnStartRecieve.TabIndex = 43;
            this.btnStartRecieve.Text = "Начать";
            this.btnStartRecieve.UseVisualStyleBackColor = true;
            this.btnStartRecieve.Click += new System.EventHandler(this.btnStartRecieve_Click);
            // 
            // tlpReceivingParameters
            // 
            this.tlpReceivingParameters.ColumnCount = 5;
            this.tlpReceivingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.87952F));
            this.tlpReceivingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.80269F));
            this.tlpReceivingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.37668F));
            this.tlpReceivingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tlpReceivingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tlpReceivingParameters.Controls.Add(this.panel7, 0, 0);
            this.tlpReceivingParameters.Controls.Add(this.panel3, 1, 0);
            this.tlpReceivingParameters.Controls.Add(this.panel4, 0, 0);
            this.tlpReceivingParameters.Controls.Add(this.panel2, 3, 0);
            this.tlpReceivingParameters.Controls.Add(this.pModulation, 4, 0);
            this.tlpReceivingParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpReceivingParameters.Location = new System.Drawing.Point(3, 3);
            this.tlpReceivingParameters.Name = "tlpReceivingParameters";
            this.tlpReceivingParameters.RowCount = 1;
            this.tlpReceivingParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpReceivingParameters.Size = new System.Drawing.Size(697, 108);
            this.tlpReceivingParameters.TabIndex = 45;
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel7.BackColor = System.Drawing.SystemColors.Window;
            this.panel7.Controls.Add(this.rbPRDReserve);
            this.panel7.Controls.Add(this.rbPRDMain);
            this.panel7.Controls.Add(this.lblPRD);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(137, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(118, 102);
            this.panel7.TabIndex = 45;
            // 
            // rbPRDReserve
            // 
            this.rbPRDReserve.AutoSize = true;
            this.rbPRDReserve.Depth = 0;
            this.rbPRDReserve.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbPRDReserve.Location = new System.Drawing.Point(7, 62);
            this.rbPRDReserve.Margin = new System.Windows.Forms.Padding(0);
            this.rbPRDReserve.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbPRDReserve.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbPRDReserve.Name = "rbPRDReserve";
            this.rbPRDReserve.Ripple = true;
            this.rbPRDReserve.Size = new System.Drawing.Size(102, 30);
            this.rbPRDReserve.TabIndex = 41;
            this.rbPRDReserve.Text = "Резервный";
            this.rbPRDReserve.UseVisualStyleBackColor = true;
            // 
            // rbPRDMain
            // 
            this.rbPRDMain.AutoSize = true;
            this.rbPRDMain.Checked = true;
            this.rbPRDMain.Depth = 0;
            this.rbPRDMain.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbPRDMain.Location = new System.Drawing.Point(7, 30);
            this.rbPRDMain.Margin = new System.Windows.Forms.Padding(0);
            this.rbPRDMain.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbPRDMain.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbPRDMain.Name = "rbPRDMain";
            this.rbPRDMain.Ripple = true;
            this.rbPRDMain.Size = new System.Drawing.Size(93, 30);
            this.rbPRDMain.TabIndex = 40;
            this.rbPRDMain.TabStop = true;
            this.rbPRDMain.Text = "Основной";
            this.rbPRDMain.UseVisualStyleBackColor = true;
            // 
            // lblPRD
            // 
            this.lblPRD.Depth = 0;
            this.lblPRD.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblPRD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPRD.Location = new System.Drawing.Point(3, 6);
            this.lblPRD.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPRD.Name = "lblPRD";
            this.lblPRD.Size = new System.Drawing.Size(64, 19);
            this.lblPRD.TabIndex = 38;
            this.lblPRD.Text = "ПРД";
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.rbFreq2);
            this.panel3.Controls.Add(this.rbFreq1);
            this.panel3.Controls.Add(this.lblFreq);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(261, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(184, 102);
            this.panel3.TabIndex = 43;
            // 
            // rbFreq2
            // 
            this.rbFreq2.AutoSize = true;
            this.rbFreq2.Depth = 0;
            this.rbFreq2.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbFreq2.Location = new System.Drawing.Point(7, 62);
            this.rbFreq2.Margin = new System.Windows.Forms.Padding(0);
            this.rbFreq2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbFreq2.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbFreq2.Name = "rbFreq2";
            this.rbFreq2.Ripple = true;
            this.rbFreq2.Size = new System.Drawing.Size(64, 30);
            this.rbFreq2.TabIndex = 43;
            this.rbFreq2.Text = "137.9";
            this.rbFreq2.UseVisualStyleBackColor = true;
            // 
            // rbFreq1
            // 
            this.rbFreq1.AutoSize = true;
            this.rbFreq1.Checked = true;
            this.rbFreq1.Depth = 0;
            this.rbFreq1.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbFreq1.Location = new System.Drawing.Point(7, 30);
            this.rbFreq1.Margin = new System.Windows.Forms.Padding(0);
            this.rbFreq1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbFreq1.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbFreq1.Name = "rbFreq1";
            this.rbFreq1.Ripple = true;
            this.rbFreq1.Size = new System.Drawing.Size(64, 30);
            this.rbFreq1.TabIndex = 42;
            this.rbFreq1.TabStop = true;
            this.rbFreq1.Text = "137.1";
            this.rbFreq1.UseVisualStyleBackColor = true;
            this.rbFreq1.CheckedChanged += new System.EventHandler(this.rbFreq1_CheckedChanged);
            // 
            // lblFreq
            // 
            this.lblFreq.Depth = 0;
            this.lblFreq.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFreq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFreq.Location = new System.Drawing.Point(3, 6);
            this.lblFreq.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFreq.Name = "lblFreq";
            this.lblFreq.Size = new System.Drawing.Size(177, 19);
            this.lblFreq.TabIndex = 38;
            this.lblFreq.Text = "Несущая частота (МГц)";
            // 
            // panel4
            // 
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Controls.Add(this.rbFCPReserve);
            this.panel4.Controls.Add(this.rbFCPMain);
            this.panel4.Controls.Add(this.lblFCP);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(128, 102);
            this.panel4.TabIndex = 44;
            // 
            // rbFCPReserve
            // 
            this.rbFCPReserve.AutoSize = true;
            this.rbFCPReserve.Depth = 0;
            this.rbFCPReserve.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbFCPReserve.Location = new System.Drawing.Point(13, 62);
            this.rbFCPReserve.Margin = new System.Windows.Forms.Padding(0);
            this.rbFCPReserve.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbFCPReserve.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbFCPReserve.Name = "rbFCPReserve";
            this.rbFCPReserve.Ripple = true;
            this.rbFCPReserve.Size = new System.Drawing.Size(102, 30);
            this.rbFCPReserve.TabIndex = 39;
            this.rbFCPReserve.Text = "Резервный";
            this.rbFCPReserve.UseVisualStyleBackColor = true;
            // 
            // rbFCPMain
            // 
            this.rbFCPMain.AutoSize = true;
            this.rbFCPMain.Checked = true;
            this.rbFCPMain.Depth = 0;
            this.rbFCPMain.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbFCPMain.Location = new System.Drawing.Point(13, 30);
            this.rbFCPMain.Margin = new System.Windows.Forms.Padding(0);
            this.rbFCPMain.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbFCPMain.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbFCPMain.Name = "rbFCPMain";
            this.rbFCPMain.Ripple = true;
            this.rbFCPMain.Size = new System.Drawing.Size(93, 30);
            this.rbFCPMain.TabIndex = 38;
            this.rbFCPMain.TabStop = true;
            this.rbFCPMain.Text = "Основной";
            this.rbFCPMain.UseVisualStyleBackColor = true;
            // 
            // lblFCP
            // 
            this.lblFCP.Depth = 0;
            this.lblFCP.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFCP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFCP.Location = new System.Drawing.Point(10, 6);
            this.lblFCP.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFCP.Name = "lblFCP";
            this.lblFCP.Size = new System.Drawing.Size(64, 19);
            this.lblFCP.TabIndex = 37;
            this.lblFCP.Text = "ФЦП-М";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.rbInterlivingReceiveOff);
            this.panel2.Controls.Add(this.rbInterlivingReceiveOn);
            this.panel2.Controls.Add(this.lblInterliving);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(451, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(116, 102);
            this.panel2.TabIndex = 42;
            // 
            // rbInterlivingReceiveOff
            // 
            this.rbInterlivingReceiveOff.AutoSize = true;
            this.rbInterlivingReceiveOff.Depth = 0;
            this.rbInterlivingReceiveOff.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbInterlivingReceiveOff.Location = new System.Drawing.Point(7, 62);
            this.rbInterlivingReceiveOff.Margin = new System.Windows.Forms.Padding(0);
            this.rbInterlivingReceiveOff.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbInterlivingReceiveOff.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbInterlivingReceiveOff.Name = "rbInterlivingReceiveOff";
            this.rbInterlivingReceiveOff.Ripple = true;
            this.rbInterlivingReceiveOff.Size = new System.Drawing.Size(105, 30);
            this.rbInterlivingReceiveOff.TabIndex = 45;
            this.rbInterlivingReceiveOff.Text = "Выключить";
            this.rbInterlivingReceiveOff.UseVisualStyleBackColor = true;
            // 
            // rbInterlivingReceiveOn
            // 
            this.rbInterlivingReceiveOn.AutoSize = true;
            this.rbInterlivingReceiveOn.Checked = true;
            this.rbInterlivingReceiveOn.Depth = 0;
            this.rbInterlivingReceiveOn.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbInterlivingReceiveOn.Location = new System.Drawing.Point(7, 30);
            this.rbInterlivingReceiveOn.Margin = new System.Windows.Forms.Padding(0);
            this.rbInterlivingReceiveOn.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbInterlivingReceiveOn.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbInterlivingReceiveOn.Name = "rbInterlivingReceiveOn";
            this.rbInterlivingReceiveOn.Ripple = true;
            this.rbInterlivingReceiveOn.Size = new System.Drawing.Size(94, 30);
            this.rbInterlivingReceiveOn.TabIndex = 44;
            this.rbInterlivingReceiveOn.TabStop = true;
            this.rbInterlivingReceiveOn.Text = "Включить";
            this.rbInterlivingReceiveOn.UseVisualStyleBackColor = true;
            // 
            // lblInterliving
            // 
            this.lblInterliving.Depth = 0;
            this.lblInterliving.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblInterliving.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblInterliving.Location = new System.Drawing.Point(3, 6);
            this.lblInterliving.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblInterliving.Name = "lblInterliving";
            this.lblInterliving.Size = new System.Drawing.Size(108, 19);
            this.lblInterliving.TabIndex = 38;
            this.lblInterliving.Text = "Интерливинг";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Window;
            this.panel6.Controls.Add(this.tableLayoutPanel2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(865, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(702, 108);
            this.panel6.TabIndex = 44;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.45324F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.54676F));
            this.tableLayoutPanel2.Controls.Add(this.doubleBufferedPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(702, 108);
            this.tableLayoutPanel2.TabIndex = 46;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::ReceivingStation.Properties.Resources.rss_logo;
            this.pictureBox1.Location = new System.Drawing.Point(591, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // opnDlg
            // 
            this.opnDlg.Filter = "WAV files|*.wav";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 50;
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 50;
            // 
            // DemodTimer
            // 
            this.DemodTimer.Enabled = true;
            this.DemodTimer.Tick += new System.EventHandler(this.DemodTimer_Tick);
            // 
            // rtbMkoData
            // 
            this.rtbMkoData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMkoData.Location = new System.Drawing.Point(941, 3);
            this.rtbMkoData.Name = "rtbMkoData";
            this.rtbMkoData.Size = new System.Drawing.Size(242, 478);
            this.rtbMkoData.TabIndex = 0;
            this.rtbMkoData.Text = "";
            // 
            // rtbMkoTitle
            // 
            this.rtbMkoTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMkoTitle.Location = new System.Drawing.Point(416, 3);
            this.rtbMkoTitle.Name = "rtbMkoTitle";
            this.rtbMkoTitle.Size = new System.Drawing.Size(519, 478);
            this.rtbMkoTitle.TabIndex = 1;
            this.rtbMkoTitle.Text = "";
            // 
            // rtbServiceTitle
            // 
            this.rtbServiceTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbServiceTitle.Location = new System.Drawing.Point(417, 3);
            this.rtbServiceTitle.Name = "rtbServiceTitle";
            this.rtbServiceTitle.Size = new System.Drawing.Size(442, 484);
            this.rtbServiceTitle.TabIndex = 0;
            this.rtbServiceTitle.Text = "";
            // 
            // rtbServiceData
            // 
            this.rtbServiceData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbServiceData.Location = new System.Drawing.Point(865, 3);
            this.rtbServiceData.Name = "rtbServiceData";
            this.rtbServiceData.Size = new System.Drawing.Size(501, 484);
            this.rtbServiceData.TabIndex = 1;
            this.rtbServiceData.Text = "";
            // 
            // display1
            // 
            this.display1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.display1.Constellation = false;
            this.display1.Eye = false;
            this.display1.Gain = 1;
            this.display1.Input = false;
            this.display1.Location = new System.Drawing.Point(1113, 3);
            this.display1.Name = "display1";
            this.display1.Output = false;
            this.display1.Pause = false;
            this.display1.SamplesPerSymbol = 0;
            this.display1.Size = new System.Drawing.Size(446, 426);
            this.display1.TabIndex = 37;
            this.display1.Zoom = 1;
            // 
            // pModulation
            // 
            this.pModulation.Controls.Add(this.rbQpsk);
            this.pModulation.Controls.Add(this.rbOqpsk);
            this.pModulation.Controls.Add(this.materialLabel7);
            this.pModulation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pModulation.Location = new System.Drawing.Point(573, 3);
            this.pModulation.Name = "pModulation";
            this.pModulation.Size = new System.Drawing.Size(121, 102);
            this.pModulation.TabIndex = 46;
            this.pModulation.Visible = false;
            // 
            // rbQpsk
            // 
            this.rbQpsk.AutoSize = true;
            this.rbQpsk.Depth = 0;
            this.rbQpsk.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbQpsk.Location = new System.Drawing.Point(8, 62);
            this.rbQpsk.Margin = new System.Windows.Forms.Padding(0);
            this.rbQpsk.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbQpsk.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbQpsk.Name = "rbQpsk";
            this.rbQpsk.Ripple = true;
            this.rbQpsk.Size = new System.Drawing.Size(64, 30);
            this.rbQpsk.TabIndex = 48;
            this.rbQpsk.Text = "QPSK";
            this.rbQpsk.UseVisualStyleBackColor = true;
            // 
            // rbOqpsk
            // 
            this.rbOqpsk.AutoSize = true;
            this.rbOqpsk.Checked = true;
            this.rbOqpsk.Depth = 0;
            this.rbOqpsk.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbOqpsk.Location = new System.Drawing.Point(8, 30);
            this.rbOqpsk.Margin = new System.Windows.Forms.Padding(0);
            this.rbOqpsk.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbOqpsk.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbOqpsk.Name = "rbOqpsk";
            this.rbOqpsk.Ripple = true;
            this.rbOqpsk.Size = new System.Drawing.Size(74, 30);
            this.rbOqpsk.TabIndex = 47;
            this.rbOqpsk.TabStop = true;
            this.rbOqpsk.Text = "OQPSK";
            this.rbOqpsk.UseVisualStyleBackColor = true;
            // 
            // materialLabel7
            // 
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(3, 6);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(94, 19);
            this.materialLabel7.TabIndex = 46;
            this.materialLabel7.Text = "Модуляция";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Window;
            this.panel6.Controls.Add(this.tableLayoutPanel2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(865, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(702, 108);
            this.panel6.TabIndex = 44;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.45324F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.54676F));
            this.tableLayoutPanel2.Controls.Add(this.doubleBufferedPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(702, 108);
            this.tableLayoutPanel2.TabIndex = 46;
            // 
            // doubleBufferedPanel1
            // 
            this.doubleBufferedPanel1.Controls.Add(this.panel8);
            this.doubleBufferedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferedPanel1.Location = new System.Drawing.Point(3, 3);
            this.doubleBufferedPanel1.Name = "doubleBufferedPanel1";
            this.doubleBufferedPanel1.Size = new System.Drawing.Size(579, 102);
            this.doubleBufferedPanel1.TabIndex = 46;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.rtbDateTimeTitle);
            this.panel8.Controls.Add(this.pSourcePanel);
            this.panel8.Controls.Add(this.rtbDateTime);
            this.panel8.Controls.Add(this.doubleBufferedPanel2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(579, 102);
            this.panel8.TabIndex = 53;
            // 
            // rtbDateTimeTitle
            // 
            this.rtbDateTimeTitle.Dock = System.Windows.Forms.DockStyle.Right;
            this.rtbDateTimeTitle.Location = new System.Drawing.Point(379, 0);
            this.rtbDateTimeTitle.Name = "rtbDateTimeTitle";
            this.rtbDateTimeTitle.Size = new System.Drawing.Size(100, 102);
            this.rtbDateTimeTitle.TabIndex = 50;
            this.rtbDateTimeTitle.Text = "";
            // 
            // pSourcePanel
            // 
            this.pSourcePanel.Controls.Add(this.lblSignDetect);
            this.pSourcePanel.Controls.Add(this.rbWav);
            this.pSourcePanel.Controls.Add(this.rbFUNcube);
            this.pSourcePanel.Controls.Add(this.materialLabel8);
            this.pSourcePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.pSourcePanel.Location = new System.Drawing.Point(200, 0);
            this.pSourcePanel.Name = "pSourcePanel";
            this.pSourcePanel.Size = new System.Drawing.Size(183, 102);
            this.pSourcePanel.TabIndex = 51;
            this.pSourcePanel.Visible = false;
            // 
            // lblSignDetect
            // 
            this.lblSignDetect.AutoSize = true;
            this.lblSignDetect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.lblSignDetect.Depth = 0;
            this.lblSignDetect.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblSignDetect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSignDetect.Location = new System.Drawing.Point(114, 73);
            this.lblSignDetect.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSignDetect.Name = "lblSignDetect";
            this.lblSignDetect.Size = new System.Drawing.Size(59, 19);
            this.lblSignDetect.TabIndex = 48;
            this.lblSignDetect.Text = "СИНХР";
            this.lblSignDetect.Visible = false;
            // 
            // rbWav
            // 
            this.rbWav.AutoSize = true;
            this.rbWav.Depth = 0;
            this.rbWav.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbWav.Location = new System.Drawing.Point(11, 54);
            this.rbWav.Margin = new System.Windows.Forms.Padding(0);
            this.rbWav.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbWav.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbWav.Name = "rbWav";
            this.rbWav.Ripple = true;
            this.rbWav.Size = new System.Drawing.Size(57, 30);
            this.rbWav.TabIndex = 56;
            this.rbWav.Text = ".wav";
            this.rbWav.UseVisualStyleBackColor = true;
            // 
            // rbFUNcube
            // 
            this.rbFUNcube.AutoSize = true;
            this.rbFUNcube.Checked = true;
            this.rbFUNcube.Depth = 0;
            this.rbFUNcube.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbFUNcube.Location = new System.Drawing.Point(11, 25);
            this.rbFUNcube.Margin = new System.Windows.Forms.Padding(0);
            this.rbFUNcube.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbFUNcube.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbFUNcube.Name = "rbFUNcube";
            this.rbFUNcube.Ripple = true;
            this.rbFUNcube.Size = new System.Drawing.Size(83, 30);
            this.rbFUNcube.TabIndex = 55;
            this.rbFUNcube.TabStop = true;
            this.rbFUNcube.Text = "FunCube";
            this.rbFUNcube.UseVisualStyleBackColor = true;
            // 
            // materialLabel8
            // 
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(7, 3);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(139, 19);
            this.materialLabel8.TabIndex = 54;
            this.materialLabel8.Text = "Источник сигнала";
            // 
            // rtbDateTime
            // 
            this.rtbDateTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.rtbDateTime.Location = new System.Drawing.Point(479, 0);
            this.rtbDateTime.Name = "rtbDateTime";
            this.rtbDateTime.Size = new System.Drawing.Size(100, 102);
            this.rtbDateTime.TabIndex = 49;
            this.rtbDateTime.Text = "";
            // 
            // doubleBufferedPanel2
            // 
            this.doubleBufferedPanel2.Controls.Add(this.lblDemOn);
            this.doubleBufferedPanel2.Controls.Add(this.lblDongOn);
            this.doubleBufferedPanel2.Controls.Add(this.pbInterSyncOk);
            this.doubleBufferedPanel2.Controls.Add(this.pbSignalSyncOk);
            this.doubleBufferedPanel2.Controls.Add(this.pbInterSyncErr);
            this.doubleBufferedPanel2.Controls.Add(this.pbSignalSyncErr);
            this.doubleBufferedPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.doubleBufferedPanel2.Location = new System.Drawing.Point(0, 0);
            this.doubleBufferedPanel2.Name = "doubleBufferedPanel2";
            this.doubleBufferedPanel2.Size = new System.Drawing.Size(200, 102);
            this.doubleBufferedPanel2.TabIndex = 57;
            // 
            // lblDemOn
            // 
            this.lblDemOn.AutoSize = true;
            this.lblDemOn.Depth = 0;
            this.lblDemOn.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDemOn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDemOn.Location = new System.Drawing.Point(34, 78);
            this.lblDemOn.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDemOn.Name = "lblDemOn";
            this.lblDemOn.Size = new System.Drawing.Size(49, 19);
            this.lblDemOn.TabIndex = 45;
            this.lblDemOn.Text = "label7";
            this.lblDemOn.Visible = false;
            // 
            // lblDongOn
            // 
            this.lblDongOn.AutoSize = true;
            this.lblDongOn.Depth = 0;
            this.lblDongOn.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDongOn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDongOn.Location = new System.Drawing.Point(118, 78);
            this.lblDongOn.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDongOn.Name = "lblDongOn";
            this.lblDongOn.Size = new System.Drawing.Size(49, 19);
            this.lblDongOn.TabIndex = 46;
            this.lblDongOn.Text = "label8";
            this.lblDongOn.Visible = false;
            // 
            // pbInterSyncOk
            // 
            this.pbInterSyncOk.Image = global::ReceivingStation.Properties.Resources.OkStatus;
            this.pbInterSyncOk.Location = new System.Drawing.Point(117, 25);
            this.pbInterSyncOk.Name = "pbInterSyncOk";
            this.pbInterSyncOk.Size = new System.Drawing.Size(50, 50);
            this.pbInterSyncOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInterSyncOk.TabIndex = 55;
            this.pbInterSyncOk.TabStop = false;
            this.toolTip1.SetToolTip(this.pbInterSyncOk, "Синхронизация фазы интерливинга");
            this.pbInterSyncOk.Visible = false;
            // 
            // pbSignalSyncOk
            // 
            this.pbSignalSyncOk.Image = global::ReceivingStation.Properties.Resources.OkStatus;
            this.pbSignalSyncOk.Location = new System.Drawing.Point(33, 25);
            this.pbSignalSyncOk.Name = "pbSignalSyncOk";
            this.pbSignalSyncOk.Size = new System.Drawing.Size(50, 50);
            this.pbSignalSyncOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSignalSyncOk.TabIndex = 54;
            this.pbSignalSyncOk.TabStop = false;
            this.toolTip1.SetToolTip(this.pbSignalSyncOk, "Синхронизация фазы сигнала");
            this.pbSignalSyncOk.Visible = false;
            // 
            // pbInterSyncErr
            // 
            this.pbInterSyncErr.Image = global::ReceivingStation.Properties.Resources.ErrorStatus;
            this.pbInterSyncErr.Location = new System.Drawing.Point(117, 25);
            this.pbInterSyncErr.Name = "pbInterSyncErr";
            this.pbInterSyncErr.Size = new System.Drawing.Size(50, 50);
            this.pbInterSyncErr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInterSyncErr.TabIndex = 54;
            this.pbInterSyncErr.TabStop = false;
            this.toolTip1.SetToolTip(this.pbInterSyncErr, "Синхронизация фазы интерливинга");
            this.pbInterSyncErr.Visible = false;
            // 
            // pbSignalSyncErr
            // 
            this.pbSignalSyncErr.Image = global::ReceivingStation.Properties.Resources.ErrorStatus;
            this.pbSignalSyncErr.Location = new System.Drawing.Point(33, 25);
            this.pbSignalSyncErr.Name = "pbSignalSyncErr";
            this.pbSignalSyncErr.Size = new System.Drawing.Size(50, 50);
            this.pbSignalSyncErr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSignalSyncErr.TabIndex = 53;
            this.pbSignalSyncErr.TabStop = false;
            this.toolTip1.SetToolTip(this.pbSignalSyncErr, "Синхронизация фазы сигнала");
            this.pbSignalSyncErr.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::ReceivingStation.Properties.Resources.rss_logo;
            this.pictureBox1.Location = new System.Drawing.Point(591, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // opnDlg
            // 
            this.opnDlg.Filter = "WAV files|*.wav";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 50;
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 50;
            // 
            // DemodTimer
            // 
            this.DemodTimer.Enabled = true;
            this.DemodTimer.Tick += new System.EventHandler(this.DemodTimer_Tick);
            // 
            // FormReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1570, 800);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.tlp1);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "FormReceive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Приемная станция: Прием";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormReceive_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormReceive_FormClosed);
            this.Load += new System.EventHandler(this.FormReceive_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormReceive_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.DemodPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_FindedBitsInInterliving)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_FindedBitsInPSP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GainNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_PLLBw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_Bandwidth)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tlp1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tlpReceivingParameters.ResumeLayout(false);
            this.tlpReceivingParameters.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pModulation.ResumeLayout(false);
            this.pModulation.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.doubleBufferedPanel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.pSourcePanel.ResumeLayout(false);
            this.pSourcePanel.PerformLayout();
            this.doubleBufferedPanel2.ResumeLayout(false);
            this.doubleBufferedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInterSyncOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignalSyncOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInterSyncErr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignalSyncErr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slTime;
        private System.Windows.Forms.ToolStripStatusLabel slMode;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker bwImageSaver;
        private System.Windows.Forms.ToolStripStatusLabel slWorkingTimeOnboard;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.TableLayoutPanel tlp1;
        private System.Windows.Forms.Panel panel5;
        private MaterialSkin.Controls.MaterialRaisedButton btnStartRecieve;
        private System.Windows.Forms.TableLayoutPanel tlpReceivingParameters;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private MaterialSkin.Controls.MaterialRadioButton rbPRDReserve;
        private MaterialSkin.Controls.MaterialRadioButton rbPRDMain;
        private MaterialSkin.Controls.MaterialLabel lblPRD;
        private MaterialSkin.Controls.MaterialRadioButton rbInterlivingReceiveOff;
        private MaterialSkin.Controls.MaterialRadioButton rbInterlivingReceiveOn;
        private MaterialSkin.Controls.MaterialLabel lblInterliving;
        private MaterialSkin.Controls.MaterialRadioButton rbFreq2;
        private MaterialSkin.Controls.MaterialRadioButton rbFreq1;
        private MaterialSkin.Controls.MaterialLabel lblFreq;
        private MaterialSkin.Controls.MaterialRadioButton rbFCPReserve;
        private MaterialSkin.Controls.MaterialRadioButton rbFCPMain;
        private MaterialSkin.Controls.MaterialLabel lblFCP;
        private System.Windows.Forms.Panel pImage1;
        private System.Windows.Forms.Panel pImage2;
        private System.Windows.Forms.Panel pImage3;
        private System.Windows.Forms.Panel pImage4;
        private System.Windows.Forms.Panel pImage5;
        private System.Windows.Forms.Panel pImage6;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Other.DoubleBufferedPanel doubleBufferedPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public MaterialSkin.Controls.MaterialLabel lblDemOn;
        public MaterialSkin.Controls.MaterialLabel lblDongOn;
        public MaterialSkin.Controls.MaterialLabel lblSignDetect;
        private Other.DisabledRichTextBox rtbDateTimeTitle;
        private Other.DisabledRichTextBox rtbDateTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.Panel pImage7;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.Panel pImage8;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.Panel pImage9;
        private System.Windows.Forms.Panel pImage10;
        private System.Windows.Forms.Panel pImage11;
        private System.Windows.Forms.Panel pImage12;
        private Other.DoubleBufferedPanel pModulation;
        private MaterialSkin.Controls.MaterialRadioButton rbQpsk;
        private MaterialSkin.Controls.MaterialRadioButton rbOqpsk;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage tabPage9;
        private Other.DoubleBufferedPanel pSourcePanel;
        private MaterialSkin.Controls.MaterialRadioButton rbWav;
        private MaterialSkin.Controls.MaterialRadioButton rbFUNcube;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private System.Windows.Forms.OpenFileDialog opnDlg;
        private System.Windows.Forms.NumericUpDown GainNM;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TableLayoutPanel DemodPanel;
        private ScottPlot.ScottPlotUC scottPlotUC1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFinded;
        private System.Windows.Forms.Label lblLocked;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSizeS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comBxModulation;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cBx_matchedFilter;
        private System.Windows.Forms.ComboBox comBx_SampleRate;
        private System.Windows.Forms.ComboBox comBx_carrier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cBx_iqFilter;
        private System.Windows.Forms.NumericUpDown numUpD_PLLBw;
        private System.Windows.Forms.NumericUpDown NumUpDown_Bandwidth;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cBx_output;
        private System.Windows.Forms.RadioButton rbEYE;
        private System.Windows.Forms.CheckBox cBx_Input;
        private System.Windows.Forms.RadioButton rbConstel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer DemodTimer;
        private Demodulator.Display display1;
        private System.Windows.Forms.CheckBox chBx_sWriter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cBx_datWriter;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cBx_HardPSP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numUpD_FindedBitsInPSP;
        private System.Windows.Forms.Label lbl_PSPMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numUpD_FindedBitsInInterliving;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Other.DisabledRichTextBox rtbMkoData;
        private Other.DisabledRichTextBox rtbMkoTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Other.DisabledRichTextBox rtbServiceTitle;
        private Other.DisabledRichTextBox rtbServiceData;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel8;
        private Other.DoubleBufferedPanel doubleBufferedPanel2;
        private System.Windows.Forms.PictureBox pbInterSyncOk;
        private System.Windows.Forms.PictureBox pbSignalSyncOk;
        private System.Windows.Forms.PictureBox pbInterSyncErr;
        private System.Windows.Forms.PictureBox pbSignalSyncErr;
    }
}

