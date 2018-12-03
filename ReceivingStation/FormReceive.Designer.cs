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
            this.slWorkingTimeOnboard = new System.Windows.Forms.ToolStripStatusLabel();
            this.slMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bwImageSaver = new System.ComponentModel.BackgroundWorker();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pScroll1 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pScroll2 = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pScroll3 = new System.Windows.Forms.Panel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pScroll4 = new System.Windows.Forms.Panel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.pScroll5 = new System.Windows.Forms.Panel();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.pScroll6 = new System.Windows.Forms.Panel();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.pScroll10 = new System.Windows.Forms.Panel();
            this.pScroll11 = new System.Windows.Forms.Panel();
            this.pScroll12 = new System.Windows.Forms.Panel();
            this.pScroll7 = new System.Windows.Forms.Panel();
            this.pScroll8 = new System.Windows.Forms.Panel();
            this.pScroll9 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTD1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblTD2 = new MaterialSkin.Controls.MaterialLabel();
            this.lblTD3 = new MaterialSkin.Controls.MaterialLabel();
            this.lblOSHV1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblBSHV1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblBSHV5 = new MaterialSkin.Controls.MaterialLabel();
            this.lblPCDM1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblBSHV4 = new MaterialSkin.Controls.MaterialLabel();
            this.lblPCDM2 = new MaterialSkin.Controls.MaterialLabel();
            this.lblPCDM3 = new MaterialSkin.Controls.MaterialLabel();
            this.lblBSHV2 = new MaterialSkin.Controls.MaterialLabel();
            this.lblBSHV3 = new MaterialSkin.Controls.MaterialLabel();
            this.lblPCDM4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel35 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel34 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel15 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel17 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel19 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel21 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel29 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel28 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel23 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel25 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel32 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbInterlivingReceiveOff = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbInterlivingReceiveOn = new MaterialSkin.Controls.MaterialRadioButton();
            this.lblInterliving = new MaterialSkin.Controls.MaterialLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbFreq2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbFreq1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.lblFreq = new MaterialSkin.Controls.MaterialLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.materialRadioButton2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbFCPMain = new MaterialSkin.Controls.MaterialRadioButton();
            this.lblFCP = new MaterialSkin.Controls.MaterialLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.doubleBufferedPanel1 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.lblLineTime = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.lblLineDate = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new MaterialSkin.Controls.MaterialLabel();
            this.label8 = new MaterialSkin.Controls.MaterialLabel();
            this.label10 = new MaterialSkin.Controls.MaterialLabel();
            this.label9 = new MaterialSkin.Controls.MaterialLabel();
            this.statusStrip1.SuspendLayout();
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlp1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tlpReceivingParameters.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.doubleBufferedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slTime,
            this.slWorkingTimeOnboard,
            this.slMode});
            this.statusStrip1.Location = new System.Drawing.Point(0, 770);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(1556, 25);
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
            this.slTime.ToolTipText = "Дата/Время";
            // 
            // slWorkingTimeOnboard
            // 
            this.slWorkingTimeOnboard.DoubleClickEnabled = true;
            this.slWorkingTimeOnboard.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.slWorkingTimeOnboard.Image = global::ReceivingStation.Properties.Resources.time_icon;
            this.slWorkingTimeOnboard.Name = "slWorkingTimeOnboard";
            this.slWorkingTimeOnboard.Size = new System.Drawing.Size(1208, 20);
            this.slWorkingTimeOnboard.Spring = true;
            this.slWorkingTimeOnboard.Text = "Время наработки";
            this.slWorkingTimeOnboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.slWorkingTimeOnboard.DoubleClick += new System.EventHandler(this.slWorkingTimeOnboard_DoubleClick);
            // 
            // slMode
            // 
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
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 208);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1556, 562);
            this.materialTabControl1.TabIndex = 36;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pScroll1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1548, 536);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Канал 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pScroll1
            // 
            this.pScroll1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pScroll1.Location = new System.Drawing.Point(3, 3);
            this.pScroll1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pScroll1.Name = "pScroll1";
            this.pScroll1.Size = new System.Drawing.Size(1542, 530);
            this.pScroll1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pScroll2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1548, 536);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Канал 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pScroll2
            // 
            this.pScroll2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pScroll2.Location = new System.Drawing.Point(3, 3);
            this.pScroll2.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pScroll2.Name = "pScroll2";
            this.pScroll2.Size = new System.Drawing.Size(1542, 530);
            this.pScroll2.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pScroll3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1548, 536);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Канал 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pScroll3
            // 
            this.pScroll3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pScroll3.Location = new System.Drawing.Point(3, 3);
            this.pScroll3.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pScroll3.Name = "pScroll3";
            this.pScroll3.Size = new System.Drawing.Size(1542, 530);
            this.pScroll3.TabIndex = 4;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pScroll4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1548, 536);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Канал 4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pScroll4
            // 
            this.pScroll4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pScroll4.Location = new System.Drawing.Point(3, 3);
            this.pScroll4.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pScroll4.Name = "pScroll4";
            this.pScroll4.Size = new System.Drawing.Size(1542, 530);
            this.pScroll4.TabIndex = 4;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.pScroll5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1548, 536);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Канал 5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // pScroll5
            // 
            this.pScroll5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pScroll5.Location = new System.Drawing.Point(3, 3);
            this.pScroll5.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pScroll5.Name = "pScroll5";
            this.pScroll5.Size = new System.Drawing.Size(1542, 530);
            this.pScroll5.TabIndex = 4;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.pScroll6);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1548, 536);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Канал 6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // pScroll6
            // 
            this.pScroll6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pScroll6.Location = new System.Drawing.Point(3, 3);
            this.pScroll6.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pScroll6.Name = "pScroll6";
            this.pScroll6.Size = new System.Drawing.Size(1542, 530);
            this.pScroll6.TabIndex = 4;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.tableLayoutPanel4);
            this.tabPage7.Controls.Add(this.tableLayoutPanel5);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1548, 536);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Все каналы";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoScroll = true;
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Controls.Add(this.pScroll10, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.pScroll11, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.pScroll12, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.pScroll7, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.pScroll8, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.pScroll9, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 44);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1542, 489);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // pScroll10
            // 
            this.pScroll10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pScroll10.Location = new System.Drawing.Point(778, 3);
            this.pScroll10.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pScroll10.Name = "pScroll10";
            this.pScroll10.Size = new System.Drawing.Size(236, 483);
            this.pScroll10.TabIndex = 6;
            // 
            // pScroll11
            // 
            this.pScroll11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pScroll11.Location = new System.Drawing.Point(1034, 3);
            this.pScroll11.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pScroll11.Name = "pScroll11";
            this.pScroll11.Size = new System.Drawing.Size(236, 483);
            this.pScroll11.TabIndex = 5;
            // 
            // pScroll12
            // 
            this.pScroll12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pScroll12.Location = new System.Drawing.Point(1290, 3);
            this.pScroll12.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pScroll12.Name = "pScroll12";
            this.pScroll12.Size = new System.Drawing.Size(242, 483);
            this.pScroll12.TabIndex = 4;
            // 
            // pScroll7
            // 
            this.pScroll7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pScroll7.Location = new System.Drawing.Point(10, 3);
            this.pScroll7.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pScroll7.Name = "pScroll7";
            this.pScroll7.Size = new System.Drawing.Size(236, 483);
            this.pScroll7.TabIndex = 3;
            // 
            // pScroll8
            // 
            this.pScroll8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pScroll8.Location = new System.Drawing.Point(266, 3);
            this.pScroll8.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pScroll8.Name = "pScroll8";
            this.pScroll8.Size = new System.Drawing.Size(236, 483);
            this.pScroll8.TabIndex = 2;
            // 
            // pScroll9
            // 
            this.pScroll9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pScroll9.Location = new System.Drawing.Point(522, 3);
            this.pScroll9.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pScroll9.Name = "pScroll9";
            this.pScroll9.Size = new System.Drawing.Size(236, 483);
            this.pScroll9.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 6;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.Controls.Add(this.materialLabel6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.materialLabel5, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.materialLabel4, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.materialLabel3, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.materialLabel2, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.materialLabel1, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1542, 41);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // materialLabel6
            // 
            this.materialLabel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(863, 11);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(65, 19);
            this.materialLabel6.TabIndex = 11;
            this.materialLabel6.Text = "Канал 4";
            // 
            // materialLabel5
            // 
            this.materialLabel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(1119, 11);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(65, 19);
            this.materialLabel5.TabIndex = 10;
            this.materialLabel5.Text = "Канал 5";
            // 
            // materialLabel4
            // 
            this.materialLabel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(1378, 11);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(65, 19);
            this.materialLabel4.TabIndex = 9;
            this.materialLabel4.Text = "Канал 6";
            // 
            // materialLabel3
            // 
            this.materialLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(95, 11);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(65, 19);
            this.materialLabel3.TabIndex = 8;
            this.materialLabel3.Text = "Канал 1";
            // 
            // materialLabel2
            // 
            this.materialLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(351, 11);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(65, 19);
            this.materialLabel2.TabIndex = 7;
            this.materialLabel2.Text = "Канал 2";
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(607, 11);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(65, 19);
            this.materialLabel1.TabIndex = 6;
            this.materialLabel1.Text = "Канал 3";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.tableLayoutPanel1);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1548, 536);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "МКО";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblTD1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTD2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTD3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblOSHV1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblBSHV1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblBSHV5, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblPCDM1, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.lblBSHV4, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblPCDM2, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.lblPCDM3, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.lblBSHV2, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblBSHV3, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblPCDM4, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel13, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel35, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel34, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel15, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel17, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel19, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel21, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel29, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel28, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel23, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel25, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel32, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel11, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1732, 536);
            this.tableLayoutPanel1.TabIndex = 90;
            // 
            // lblTD1
            // 
            this.lblTD1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTD1.AutoSize = true;
            this.lblTD1.Depth = 0;
            this.lblTD1.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTD1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTD1.Location = new System.Drawing.Point(869, 29);
            this.lblTD1.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTD1.Name = "lblTD1";
            this.lblTD1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblTD1.Size = new System.Drawing.Size(37, 19);
            this.lblTD1.TabIndex = 64;
            this.lblTD1.Text = "0";
            // 
            // lblTD2
            // 
            this.lblTD2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTD2.AutoSize = true;
            this.lblTD2.Depth = 0;
            this.lblTD2.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTD2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTD2.Location = new System.Drawing.Point(869, 67);
            this.lblTD2.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTD2.Name = "lblTD2";
            this.lblTD2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblTD2.Size = new System.Drawing.Size(37, 19);
            this.lblTD2.TabIndex = 66;
            this.lblTD2.Text = "0";
            // 
            // lblTD3
            // 
            this.lblTD3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTD3.AutoSize = true;
            this.lblTD3.Depth = 0;
            this.lblTD3.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTD3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTD3.Location = new System.Drawing.Point(869, 105);
            this.lblTD3.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTD3.Name = "lblTD3";
            this.lblTD3.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblTD3.Size = new System.Drawing.Size(37, 19);
            this.lblTD3.TabIndex = 68;
            this.lblTD3.Text = "0";
            // 
            // lblOSHV1
            // 
            this.lblOSHV1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOSHV1.AutoSize = true;
            this.lblOSHV1.Depth = 0;
            this.lblOSHV1.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblOSHV1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOSHV1.Location = new System.Drawing.Point(869, 143);
            this.lblOSHV1.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblOSHV1.Name = "lblOSHV1";
            this.lblOSHV1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblOSHV1.Size = new System.Drawing.Size(37, 19);
            this.lblOSHV1.TabIndex = 70;
            this.lblOSHV1.Text = "0";
            // 
            // lblBSHV1
            // 
            this.lblBSHV1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBSHV1.AutoSize = true;
            this.lblBSHV1.Depth = 0;
            this.lblBSHV1.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblBSHV1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBSHV1.Location = new System.Drawing.Point(869, 181);
            this.lblBSHV1.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBSHV1.Name = "lblBSHV1";
            this.lblBSHV1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblBSHV1.Size = new System.Drawing.Size(37, 19);
            this.lblBSHV1.TabIndex = 72;
            this.lblBSHV1.Text = "0";
            // 
            // lblBSHV5
            // 
            this.lblBSHV5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBSHV5.AutoSize = true;
            this.lblBSHV5.Depth = 0;
            this.lblBSHV5.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblBSHV5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBSHV5.Location = new System.Drawing.Point(869, 333);
            this.lblBSHV5.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBSHV5.Name = "lblBSHV5";
            this.lblBSHV5.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblBSHV5.Size = new System.Drawing.Size(37, 19);
            this.lblBSHV5.TabIndex = 80;
            this.lblBSHV5.Text = "0";
            // 
            // lblPCDM1
            // 
            this.lblPCDM1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPCDM1.AutoSize = true;
            this.lblPCDM1.Depth = 0;
            this.lblPCDM1.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblPCDM1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPCDM1.Location = new System.Drawing.Point(869, 371);
            this.lblPCDM1.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPCDM1.Name = "lblPCDM1";
            this.lblPCDM1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblPCDM1.Size = new System.Drawing.Size(37, 19);
            this.lblPCDM1.TabIndex = 81;
            this.lblPCDM1.Text = "0";
            // 
            // lblBSHV4
            // 
            this.lblBSHV4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBSHV4.AutoSize = true;
            this.lblBSHV4.Depth = 0;
            this.lblBSHV4.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblBSHV4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBSHV4.Location = new System.Drawing.Point(869, 295);
            this.lblBSHV4.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBSHV4.Name = "lblBSHV4";
            this.lblBSHV4.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblBSHV4.Size = new System.Drawing.Size(37, 19);
            this.lblBSHV4.TabIndex = 78;
            this.lblBSHV4.Text = "0";
            // 
            // lblPCDM2
            // 
            this.lblPCDM2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPCDM2.AutoSize = true;
            this.lblPCDM2.Depth = 0;
            this.lblPCDM2.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblPCDM2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPCDM2.Location = new System.Drawing.Point(869, 409);
            this.lblPCDM2.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPCDM2.Name = "lblPCDM2";
            this.lblPCDM2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblPCDM2.Size = new System.Drawing.Size(37, 19);
            this.lblPCDM2.TabIndex = 84;
            this.lblPCDM2.Text = "0";
            // 
            // lblPCDM3
            // 
            this.lblPCDM3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPCDM3.AutoSize = true;
            this.lblPCDM3.Depth = 0;
            this.lblPCDM3.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblPCDM3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPCDM3.Location = new System.Drawing.Point(869, 447);
            this.lblPCDM3.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPCDM3.Name = "lblPCDM3";
            this.lblPCDM3.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblPCDM3.Size = new System.Drawing.Size(37, 19);
            this.lblPCDM3.TabIndex = 85;
            this.lblPCDM3.Text = "0";
            // 
            // lblBSHV2
            // 
            this.lblBSHV2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBSHV2.AutoSize = true;
            this.lblBSHV2.Depth = 0;
            this.lblBSHV2.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblBSHV2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBSHV2.Location = new System.Drawing.Point(869, 219);
            this.lblBSHV2.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBSHV2.Name = "lblBSHV2";
            this.lblBSHV2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblBSHV2.Size = new System.Drawing.Size(37, 19);
            this.lblBSHV2.TabIndex = 74;
            this.lblBSHV2.Text = "0";
            // 
            // lblBSHV3
            // 
            this.lblBSHV3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBSHV3.AutoSize = true;
            this.lblBSHV3.Depth = 0;
            this.lblBSHV3.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblBSHV3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBSHV3.Location = new System.Drawing.Point(869, 257);
            this.lblBSHV3.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBSHV3.Name = "lblBSHV3";
            this.lblBSHV3.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblBSHV3.Size = new System.Drawing.Size(37, 19);
            this.lblBSHV3.TabIndex = 75;
            this.lblBSHV3.Text = "0";
            // 
            // lblPCDM4
            // 
            this.lblPCDM4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPCDM4.AutoSize = true;
            this.lblPCDM4.Depth = 0;
            this.lblPCDM4.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblPCDM4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPCDM4.Location = new System.Drawing.Point(869, 486);
            this.lblPCDM4.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPCDM4.Name = "lblPCDM4";
            this.lblPCDM4.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblPCDM4.Size = new System.Drawing.Size(37, 19);
            this.lblPCDM4.TabIndex = 88;
            this.lblPCDM4.Text = "0";
            // 
            // materialLabel13
            // 
            this.materialLabel13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel13.Location = new System.Drawing.Point(23, 67);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Padding = new System.Windows.Forms.Padding(450, 0, 0, 0);
            this.materialLabel13.Size = new System.Drawing.Size(840, 19);
            this.materialLabel13.TabIndex = 65;
            this.materialLabel13.Text = "Первый год в текущем четырехлетии";
            this.materialLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel35
            // 
            this.materialLabel35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel35.AutoSize = true;
            this.materialLabel35.Depth = 0;
            this.materialLabel35.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel35.Location = new System.Drawing.Point(23, 486);
            this.materialLabel35.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel35.Name = "materialLabel35";
            this.materialLabel35.Padding = new System.Windows.Forms.Padding(450, 0, 0, 0);
            this.materialLabel35.Size = new System.Drawing.Size(840, 19);
            this.materialLabel35.TabIndex = 86;
            this.materialLabel35.Text = "Положение КА по оси Z в формате IEEE-754 двойной";
            this.materialLabel35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel34
            // 
            this.materialLabel34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel34.AutoSize = true;
            this.materialLabel34.Depth = 0;
            this.materialLabel34.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel34.Location = new System.Drawing.Point(23, 447);
            this.materialLabel34.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel34.Name = "materialLabel34";
            this.materialLabel34.Padding = new System.Windows.Forms.Padding(450, 0, 0, 0);
            this.materialLabel34.Size = new System.Drawing.Size(840, 19);
            this.materialLabel34.TabIndex = 87;
            this.materialLabel34.Text = "Положение КА по оси Y в формате IEEE-754 двойной";
            this.materialLabel34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel15
            // 
            this.materialLabel15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel15.AutoSize = true;
            this.materialLabel15.Depth = 0;
            this.materialLabel15.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel15.Location = new System.Drawing.Point(23, 105);
            this.materialLabel15.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel15.Name = "materialLabel15";
            this.materialLabel15.Padding = new System.Windows.Forms.Padding(450, 0, 0, 0);
            this.materialLabel15.Size = new System.Drawing.Size(840, 19);
            this.materialLabel15.TabIndex = 67;
            this.materialLabel15.Text = "Номер текущих суток четырехлетия";
            this.materialLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel17
            // 
            this.materialLabel17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel17.AutoSize = true;
            this.materialLabel17.Depth = 0;
            this.materialLabel17.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel17.Location = new System.Drawing.Point(23, 143);
            this.materialLabel17.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel17.Name = "materialLabel17";
            this.materialLabel17.Padding = new System.Windows.Forms.Padding(450, 0, 0, 0);
            this.materialLabel17.Size = new System.Drawing.Size(840, 19);
            this.materialLabel17.TabIndex = 69;
            this.materialLabel17.Text = "Оцифрованная бортовая шкала времени (БШВ)";
            this.materialLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel19
            // 
            this.materialLabel19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel19.AutoSize = true;
            this.materialLabel19.Depth = 0;
            this.materialLabel19.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel19.Location = new System.Drawing.Point(23, 181);
            this.materialLabel19.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel19.Name = "materialLabel19";
            this.materialLabel19.Padding = new System.Windows.Forms.Padding(450, 0, 0, 0);
            this.materialLabel19.Size = new System.Drawing.Size(840, 19);
            this.materialLabel19.TabIndex = 71;
            this.materialLabel19.Text = "Время конца формирования ППО (БШВ)";
            this.materialLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel21
            // 
            this.materialLabel21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel21.AutoSize = true;
            this.materialLabel21.Depth = 0;
            this.materialLabel21.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel21.Location = new System.Drawing.Point(23, 219);
            this.materialLabel21.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel21.Name = "materialLabel21";
            this.materialLabel21.Padding = new System.Windows.Forms.Padding(450, 0, 0, 0);
            this.materialLabel21.Size = new System.Drawing.Size(840, 19);
            this.materialLabel21.TabIndex = 73;
            this.materialLabel21.Text = "Параметры кватерниона L0";
            this.materialLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel29
            // 
            this.materialLabel29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel29.AutoSize = true;
            this.materialLabel29.Depth = 0;
            this.materialLabel29.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel29.Location = new System.Drawing.Point(23, 409);
            this.materialLabel29.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel29.Name = "materialLabel29";
            this.materialLabel29.Padding = new System.Windows.Forms.Padding(450, 0, 0, 0);
            this.materialLabel29.Size = new System.Drawing.Size(840, 19);
            this.materialLabel29.TabIndex = 82;
            this.materialLabel29.Text = "Положение КА по оси X в формате IEEE-754 двойной";
            this.materialLabel29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel28
            // 
            this.materialLabel28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel28.AutoSize = true;
            this.materialLabel28.Depth = 0;
            this.materialLabel28.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel28.Location = new System.Drawing.Point(23, 371);
            this.materialLabel28.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel28.Name = "materialLabel28";
            this.materialLabel28.Padding = new System.Windows.Forms.Padding(450, 0, 0, 0);
            this.materialLabel28.Size = new System.Drawing.Size(840, 19);
            this.materialLabel28.TabIndex = 83;
            this.materialLabel28.Text = "Время конца формирования ПЦДМ (БШВ)";
            this.materialLabel28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel23
            // 
            this.materialLabel23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel23.AutoSize = true;
            this.materialLabel23.Depth = 0;
            this.materialLabel23.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel23.Location = new System.Drawing.Point(23, 257);
            this.materialLabel23.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel23.Name = "materialLabel23";
            this.materialLabel23.Padding = new System.Windows.Forms.Padding(450, 0, 0, 0);
            this.materialLabel23.Size = new System.Drawing.Size(840, 19);
            this.materialLabel23.TabIndex = 77;
            this.materialLabel23.Text = "Параметры кватерниона L1";
            this.materialLabel23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel25
            // 
            this.materialLabel25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel25.AutoSize = true;
            this.materialLabel25.Depth = 0;
            this.materialLabel25.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel25.Location = new System.Drawing.Point(23, 295);
            this.materialLabel25.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel25.Name = "materialLabel25";
            this.materialLabel25.Padding = new System.Windows.Forms.Padding(450, 0, 0, 0);
            this.materialLabel25.Size = new System.Drawing.Size(840, 19);
            this.materialLabel25.TabIndex = 76;
            this.materialLabel25.Text = "Параметры кватерниона L2";
            this.materialLabel25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel32
            // 
            this.materialLabel32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel32.AutoSize = true;
            this.materialLabel32.Depth = 0;
            this.materialLabel32.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel32.Location = new System.Drawing.Point(23, 333);
            this.materialLabel32.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel32.Name = "materialLabel32";
            this.materialLabel32.Padding = new System.Windows.Forms.Padding(450, 0, 0, 0);
            this.materialLabel32.Size = new System.Drawing.Size(840, 19);
            this.materialLabel32.TabIndex = 79;
            this.materialLabel32.Text = "Параметры кватерниона L3";
            this.materialLabel32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel11
            // 
            this.materialLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(23, 29);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Padding = new System.Windows.Forms.Padding(450, 0, 0, 0);
            this.materialLabel11.Size = new System.Drawing.Size(840, 19);
            this.materialLabel11.TabIndex = 63;
            this.materialLabel11.Text = "Время конца формирования ТД (БШВ)";
            this.materialLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 168);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1556, 40);
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
            this.materialDivider1.MaximumSize = new System.Drawing.Size(1, 54);
            this.materialDivider1.MinimumSize = new System.Drawing.Size(1, 54);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(1, 54);
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
            this.tlp1.Location = new System.Drawing.Point(0, 54);
            this.tlp1.Name = "tlp1";
            this.tlp1.RowCount = 1;
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp1.Size = new System.Drawing.Size(1556, 114);
            this.tlp1.TabIndex = 46;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Window;
            this.panel5.Controls.Add(this.btnStartRecieve);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(700, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(152, 108);
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
            this.btnStartRecieve.Size = new System.Drawing.Size(152, 43);
            this.btnStartRecieve.TabIndex = 43;
            this.btnStartRecieve.Text = "Начать";
            this.btnStartRecieve.UseVisualStyleBackColor = true;
            this.btnStartRecieve.Click += new System.EventHandler(this.btnStartRecieve_Click);
            // 
            // tlpReceivingParameters
            // 
            this.tlpReceivingParameters.ColumnCount = 4;
            this.tlpReceivingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.09931F));
            this.tlpReceivingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.25173F));
            this.tlpReceivingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.64896F));
            this.tlpReceivingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 265F));
            this.tlpReceivingParameters.Controls.Add(this.panel7, 0, 0);
            this.tlpReceivingParameters.Controls.Add(this.panel2, 2, 0);
            this.tlpReceivingParameters.Controls.Add(this.panel3, 1, 0);
            this.tlpReceivingParameters.Controls.Add(this.panel4, 0, 0);
            this.tlpReceivingParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpReceivingParameters.Location = new System.Drawing.Point(3, 3);
            this.tlpReceivingParameters.Name = "tlpReceivingParameters";
            this.tlpReceivingParameters.RowCount = 1;
            this.tlpReceivingParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpReceivingParameters.Size = new System.Drawing.Size(691, 108);
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
            this.panel7.Location = new System.Drawing.Point(126, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(110, 102);
            this.panel7.TabIndex = 45;
            // 
            // rbPRDReserve
            // 
            this.rbPRDReserve.AutoSize = true;
            this.rbPRDReserve.Depth = 0;
            this.rbPRDReserve.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbPRDReserve.Location = new System.Drawing.Point(7, 60);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.rbInterlivingReceiveOff);
            this.panel2.Controls.Add(this.rbInterlivingReceiveOn);
            this.panel2.Controls.Add(this.lblInterliving);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(427, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 102);
            this.panel2.TabIndex = 42;
            // 
            // rbInterlivingReceiveOff
            // 
            this.rbInterlivingReceiveOff.AutoSize = true;
            this.rbInterlivingReceiveOff.Depth = 0;
            this.rbInterlivingReceiveOff.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbInterlivingReceiveOff.Location = new System.Drawing.Point(7, 60);
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
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.rbFreq2);
            this.panel3.Controls.Add(this.rbFreq1);
            this.panel3.Controls.Add(this.lblFreq);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(242, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(179, 102);
            this.panel3.TabIndex = 43;
            // 
            // rbFreq2
            // 
            this.rbFreq2.AutoSize = true;
            this.rbFreq2.Depth = 0;
            this.rbFreq2.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbFreq2.Location = new System.Drawing.Point(7, 60);
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
            // 
            // lblFreq
            // 
            this.lblFreq.Depth = 0;
            this.lblFreq.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFreq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFreq.Location = new System.Drawing.Point(3, 6);
            this.lblFreq.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFreq.Name = "lblFreq";
            this.lblFreq.Size = new System.Drawing.Size(175, 19);
            this.lblFreq.TabIndex = 38;
            this.lblFreq.Text = "Несущая частота (МГц)";
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Controls.Add(this.materialRadioButton2);
            this.panel4.Controls.Add(this.rbFCPMain);
            this.panel4.Controls.Add(this.lblFCP);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(117, 102);
            this.panel4.TabIndex = 44;
            // 
            // materialRadioButton2
            // 
            this.materialRadioButton2.AutoSize = true;
            this.materialRadioButton2.Depth = 0;
            this.materialRadioButton2.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton2.Location = new System.Drawing.Point(13, 60);
            this.materialRadioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton2.Name = "materialRadioButton2";
            this.materialRadioButton2.Ripple = true;
            this.materialRadioButton2.Size = new System.Drawing.Size(102, 30);
            this.materialRadioButton2.TabIndex = 39;
            this.materialRadioButton2.Text = "Резервный";
            this.materialRadioButton2.UseVisualStyleBackColor = true;
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
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Window;
            this.panel6.Controls.Add(this.tableLayoutPanel2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(858, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(695, 108);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(695, 108);
            this.tableLayoutPanel2.TabIndex = 46;
            // 
            // doubleBufferedPanel1
            // 
            this.doubleBufferedPanel1.Controls.Add(this.label7);
            this.doubleBufferedPanel1.Controls.Add(this.label8);
            this.doubleBufferedPanel1.Controls.Add(this.label10);
            this.doubleBufferedPanel1.Controls.Add(this.label9);
            this.doubleBufferedPanel1.Controls.Add(this.lblLineTime);
            this.doubleBufferedPanel1.Controls.Add(this.materialLabel12);
            this.doubleBufferedPanel1.Controls.Add(this.materialLabel8);
            this.doubleBufferedPanel1.Controls.Add(this.lblLineDate);
            this.doubleBufferedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferedPanel1.Location = new System.Drawing.Point(3, 3);
            this.doubleBufferedPanel1.Name = "doubleBufferedPanel1";
            this.doubleBufferedPanel1.Size = new System.Drawing.Size(574, 102);
            this.doubleBufferedPanel1.TabIndex = 46;
            // 
            // lblLineTime
            // 
            this.lblLineTime.AutoSize = true;
            this.lblLineTime.BackColor = System.Drawing.SystemColors.Window;
            this.lblLineTime.Depth = 0;
            this.lblLineTime.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblLineTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblLineTime.Location = new System.Drawing.Point(489, 41);
            this.lblLineTime.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblLineTime.Name = "lblLineTime";
            this.lblLineTime.Size = new System.Drawing.Size(41, 19);
            this.lblLineTime.TabIndex = 35;
            this.lblLineTime.Text = "0:0:0";
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(426, 8);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(47, 19);
            this.materialLabel12.TabIndex = 44;
            this.materialLabel12.Text = "Дата:";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(426, 41);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(57, 19);
            this.materialLabel8.TabIndex = 36;
            this.materialLabel8.Text = "Время:";
            // 
            // lblLineDate
            // 
            this.lblLineDate.AutoSize = true;
            this.lblLineDate.BackColor = System.Drawing.SystemColors.Window;
            this.lblLineDate.Depth = 0;
            this.lblLineDate.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblLineDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblLineDate.Location = new System.Drawing.Point(488, 8);
            this.lblLineDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblLineDate.Name = "lblLineDate";
            this.lblLineDate.Size = new System.Drawing.Size(45, 19);
            this.lblLineDate.TabIndex = 43;
            this.lblLineDate.Text = "0/0/0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::ReceivingStation.Properties.Resources.rss_logo;
            this.pictureBox1.Location = new System.Drawing.Point(584, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Depth = 0;
            this.label7.Font = new System.Drawing.Font("Roboto", 11F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(28, 6);
            this.label7.MouseState = MaterialSkin.MouseState.HOVER;
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 19);
            this.label7.TabIndex = 45;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Depth = 0;
            this.label8.Font = new System.Drawing.Font("Roboto", 11F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(28, 31);
            this.label8.MouseState = MaterialSkin.MouseState.HOVER;
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 19);
            this.label8.TabIndex = 46;
            this.label8.Text = "label8";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Depth = 0;
            this.label10.Font = new System.Drawing.Font("Roboto", 11F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(28, 82);
            this.label10.MouseState = MaterialSkin.MouseState.HOVER;
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 19);
            this.label10.TabIndex = 48;
            this.label10.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Depth = 0;
            this.label9.Font = new System.Drawing.Font("Roboto", 11F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(27, 56);
            this.label9.MouseState = MaterialSkin.MouseState.HOVER;
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 19);
            this.label9.TabIndex = 47;
            this.label9.Text = "label9";
            // 
            // FormReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 795);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.tlp1);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1556, 795);
            this.Name = "FormReceive";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Приемная станция";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormReceive_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormReceive_FormClosed);
            this.Load += new System.EventHandler(this.FormReceive_Load);
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
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tlp1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tlpReceivingParameters.ResumeLayout(false);
            this.tlpReceivingParameters.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.doubleBufferedPanel1.ResumeLayout(false);
            this.doubleBufferedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
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
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton2;
        private MaterialSkin.Controls.MaterialRadioButton rbFCPMain;
        private MaterialSkin.Controls.MaterialLabel lblFCP;
        private System.Windows.Forms.Panel pScroll10;
        private System.Windows.Forms.Panel pScroll11;
        private System.Windows.Forms.Panel pScroll12;
        private System.Windows.Forms.Panel pScroll7;
        private System.Windows.Forms.Panel pScroll8;
        private System.Windows.Forms.Panel pScroll9;
        private System.Windows.Forms.Panel pScroll1;
        private System.Windows.Forms.Panel pScroll2;
        private System.Windows.Forms.Panel pScroll3;
        private System.Windows.Forms.Panel pScroll4;
        private System.Windows.Forms.Panel pScroll5;
        private System.Windows.Forms.Panel pScroll6;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialLabel lblTD1;
        private MaterialSkin.Controls.MaterialLabel lblTD2;
        private MaterialSkin.Controls.MaterialLabel lblTD3;
        private MaterialSkin.Controls.MaterialLabel lblOSHV1;
        private MaterialSkin.Controls.MaterialLabel lblBSHV1;
        private MaterialSkin.Controls.MaterialLabel lblBSHV5;
        private MaterialSkin.Controls.MaterialLabel lblPCDM1;
        private MaterialSkin.Controls.MaterialLabel lblBSHV4;
        private MaterialSkin.Controls.MaterialLabel lblPCDM2;
        private MaterialSkin.Controls.MaterialLabel lblPCDM3;
        private MaterialSkin.Controls.MaterialLabel lblBSHV2;
        private MaterialSkin.Controls.MaterialLabel lblBSHV3;
        private MaterialSkin.Controls.MaterialLabel lblPCDM4;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private MaterialSkin.Controls.MaterialLabel materialLabel35;
        private MaterialSkin.Controls.MaterialLabel materialLabel34;
        private MaterialSkin.Controls.MaterialLabel materialLabel15;
        private MaterialSkin.Controls.MaterialLabel materialLabel17;
        private MaterialSkin.Controls.MaterialLabel materialLabel19;
        private MaterialSkin.Controls.MaterialLabel materialLabel21;
        private MaterialSkin.Controls.MaterialLabel materialLabel29;
        private MaterialSkin.Controls.MaterialLabel materialLabel28;
        private MaterialSkin.Controls.MaterialLabel materialLabel23;
        private MaterialSkin.Controls.MaterialLabel materialLabel25;
        private MaterialSkin.Controls.MaterialLabel materialLabel32;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Other.DoubleBufferedPanel doubleBufferedPanel1;
        private MaterialSkin.Controls.MaterialLabel lblLineTime;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialLabel lblLineDate;
        private System.Windows.Forms.PictureBox pictureBox1;
        public MaterialSkin.Controls.MaterialLabel label7;
        public MaterialSkin.Controls.MaterialLabel label8;
        public MaterialSkin.Controls.MaterialLabel label10;
        public MaterialSkin.Controls.MaterialLabel label9;
    }
}

