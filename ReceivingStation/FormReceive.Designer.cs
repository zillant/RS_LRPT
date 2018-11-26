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
            this.flpChannel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flpChannel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.flpChannel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.flpChannel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.flpChannel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.flpChannel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flpAllChannels4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAllChannels6 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAllChannels5 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAllChannels3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAllChannels2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAllChannels1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.tlpReceiveSettings = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnStartRecieve = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tlpDecodingParameters = new System.Windows.Forms.TableLayoutPanel();
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
            this.label10 = new MaterialSkin.Controls.MaterialLabel();
            this.label9 = new MaterialSkin.Controls.MaterialLabel();
            this.label8 = new MaterialSkin.Controls.MaterialLabel();
            this.label7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel82 = new MaterialSkin.Controls.MaterialLabel();
            this.lblFramesCounter = new MaterialSkin.Controls.MaterialLabel();
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
            this.tlpReceiveSettings.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tlpDecodingParameters.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
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
            this.statusStrip1.Size = new System.Drawing.Size(1588, 25);
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
            this.slWorkingTimeOnboard.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.slWorkingTimeOnboard.Image = global::ReceivingStation.Properties.Resources.time_icon;
            this.slWorkingTimeOnboard.Name = "slWorkingTimeOnboard";
            this.slWorkingTimeOnboard.Size = new System.Drawing.Size(1240, 20);
            this.slWorkingTimeOnboard.Spring = true;
            this.slWorkingTimeOnboard.Text = "12:12:01";
            this.slWorkingTimeOnboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.slWorkingTimeOnboard.ToolTipText = "Время наработки системы (ЧЧ:ММ:СС)";
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
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 208);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1588, 562);
            this.materialTabControl1.TabIndex = 36;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flpChannel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1580, 536);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Канал 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flpChannel1
            // 
            this.flpChannel1.AutoScroll = true;
            this.flpChannel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.flpChannel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpChannel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpChannel1.Location = new System.Drawing.Point(3, 3);
            this.flpChannel1.Name = "flpChannel1";
            this.flpChannel1.Size = new System.Drawing.Size(1574, 530);
            this.flpChannel1.TabIndex = 2;
            this.flpChannel1.WrapContents = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flpChannel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1580, 536);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Канал 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flpChannel2
            // 
            this.flpChannel2.AutoScroll = true;
            this.flpChannel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpChannel2.Location = new System.Drawing.Point(3, 3);
            this.flpChannel2.Name = "flpChannel2";
            this.flpChannel2.Size = new System.Drawing.Size(1574, 530);
            this.flpChannel2.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.flpChannel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1580, 536);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Канал 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // flpChannel3
            // 
            this.flpChannel3.AutoScroll = true;
            this.flpChannel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpChannel3.Location = new System.Drawing.Point(3, 3);
            this.flpChannel3.Name = "flpChannel3";
            this.flpChannel3.Size = new System.Drawing.Size(1574, 530);
            this.flpChannel3.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.flpChannel4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1580, 536);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Канал 4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // flpChannel4
            // 
            this.flpChannel4.AutoScroll = true;
            this.flpChannel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpChannel4.Location = new System.Drawing.Point(3, 3);
            this.flpChannel4.Name = "flpChannel4";
            this.flpChannel4.Size = new System.Drawing.Size(1574, 530);
            this.flpChannel4.TabIndex = 3;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.flpChannel5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1580, 536);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Канал 5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // flpChannel5
            // 
            this.flpChannel5.AutoScroll = true;
            this.flpChannel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpChannel5.Location = new System.Drawing.Point(3, 3);
            this.flpChannel5.Name = "flpChannel5";
            this.flpChannel5.Size = new System.Drawing.Size(1574, 530);
            this.flpChannel5.TabIndex = 3;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.flpChannel6);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1580, 536);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Канал 6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // flpChannel6
            // 
            this.flpChannel6.AutoScroll = true;
            this.flpChannel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpChannel6.Location = new System.Drawing.Point(3, 3);
            this.flpChannel6.Name = "flpChannel6";
            this.flpChannel6.Size = new System.Drawing.Size(1574, 530);
            this.flpChannel6.TabIndex = 3;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.tableLayoutPanel4);
            this.tabPage7.Controls.Add(this.tableLayoutPanel5);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1580, 536);
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
            this.tableLayoutPanel4.Controls.Add(this.flpAllChannels4, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.flpAllChannels6, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.flpAllChannels5, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.flpAllChannels3, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.flpAllChannels2, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.flpAllChannels1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 44);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1574, 489);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // flpAllChannels4
            // 
            this.flpAllChannels4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAllChannels4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAllChannels4.Location = new System.Drawing.Point(789, 3);
            this.flpAllChannels4.Name = "flpAllChannels4";
            this.flpAllChannels4.Size = new System.Drawing.Size(256, 483);
            this.flpAllChannels4.TabIndex = 3;
            this.flpAllChannels4.WrapContents = false;
            // 
            // flpAllChannels6
            // 
            this.flpAllChannels6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAllChannels6.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAllChannels6.Location = new System.Drawing.Point(1313, 3);
            this.flpAllChannels6.Name = "flpAllChannels6";
            this.flpAllChannels6.Size = new System.Drawing.Size(258, 483);
            this.flpAllChannels6.TabIndex = 5;
            this.flpAllChannels6.WrapContents = false;
            // 
            // flpAllChannels5
            // 
            this.flpAllChannels5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAllChannels5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAllChannels5.Location = new System.Drawing.Point(1051, 3);
            this.flpAllChannels5.Name = "flpAllChannels5";
            this.flpAllChannels5.Size = new System.Drawing.Size(256, 483);
            this.flpAllChannels5.TabIndex = 4;
            this.flpAllChannels5.WrapContents = false;
            // 
            // flpAllChannels3
            // 
            this.flpAllChannels3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpAllChannels3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAllChannels3.Location = new System.Drawing.Point(527, 3);
            this.flpAllChannels3.Name = "flpAllChannels3";
            this.flpAllChannels3.Size = new System.Drawing.Size(256, 483);
            this.flpAllChannels3.TabIndex = 2;
            this.flpAllChannels3.WrapContents = false;
            // 
            // flpAllChannels2
            // 
            this.flpAllChannels2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpAllChannels2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAllChannels2.Location = new System.Drawing.Point(265, 3);
            this.flpAllChannels2.Name = "flpAllChannels2";
            this.flpAllChannels2.Size = new System.Drawing.Size(256, 483);
            this.flpAllChannels2.TabIndex = 1;
            this.flpAllChannels2.WrapContents = false;
            // 
            // flpAllChannels1
            // 
            this.flpAllChannels1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpAllChannels1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAllChannels1.Location = new System.Drawing.Point(3, 3);
            this.flpAllChannels1.Name = "flpAllChannels1";
            this.flpAllChannels1.Size = new System.Drawing.Size(256, 483);
            this.flpAllChannels1.TabIndex = 0;
            this.flpAllChannels1.WrapContents = false;
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
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1574, 41);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // materialLabel6
            // 
            this.materialLabel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(884, 11);
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
            this.materialLabel5.Location = new System.Drawing.Point(1146, 11);
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
            this.materialLabel4.Location = new System.Drawing.Point(1409, 11);
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
            this.materialLabel3.Location = new System.Drawing.Point(98, 11);
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
            this.materialLabel2.Location = new System.Drawing.Point(360, 11);
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
            this.materialLabel1.Location = new System.Drawing.Point(622, 11);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(65, 19);
            this.materialLabel1.TabIndex = 6;
            this.materialLabel1.Text = "Канал 3";
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 168);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1588, 40);
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
            // tlpReceiveSettings
            // 
            this.tlpReceiveSettings.BackColor = System.Drawing.SystemColors.Window;
            this.tlpReceiveSettings.ColumnCount = 3;
            this.tlpReceiveSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpReceiveSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpReceiveSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpReceiveSettings.Controls.Add(this.panel5, 1, 0);
            this.tlpReceiveSettings.Controls.Add(this.tlpDecodingParameters, 0, 0);
            this.tlpReceiveSettings.Controls.Add(this.panel6, 2, 0);
            this.tlpReceiveSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpReceiveSettings.Location = new System.Drawing.Point(0, 54);
            this.tlpReceiveSettings.Name = "tlpReceiveSettings";
            this.tlpReceiveSettings.RowCount = 1;
            this.tlpReceiveSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpReceiveSettings.Size = new System.Drawing.Size(1588, 114);
            this.tlpReceiveSettings.TabIndex = 46;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Window;
            this.panel5.Controls.Add(this.btnStartRecieve);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(717, 3);
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
            // tlpDecodingParameters
            // 
            this.tlpDecodingParameters.ColumnCount = 4;
            this.tlpDecodingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.82012F));
            this.tlpDecodingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.98066F));
            this.tlpDecodingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.19923F));
            this.tlpDecodingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 254F));
            this.tlpDecodingParameters.Controls.Add(this.panel7, 0, 0);
            this.tlpDecodingParameters.Controls.Add(this.panel2, 2, 0);
            this.tlpDecodingParameters.Controls.Add(this.panel3, 1, 0);
            this.tlpDecodingParameters.Controls.Add(this.panel4, 0, 0);
            this.tlpDecodingParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDecodingParameters.Location = new System.Drawing.Point(3, 3);
            this.tlpDecodingParameters.Name = "tlpDecodingParameters";
            this.tlpDecodingParameters.RowCount = 1;
            this.tlpDecodingParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDecodingParameters.Size = new System.Drawing.Size(708, 108);
            this.tlpDecodingParameters.TabIndex = 45;
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
            this.panel7.Location = new System.Drawing.Point(133, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(130, 102);
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
            this.panel2.Location = new System.Drawing.Point(456, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(249, 102);
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
            this.panel3.Location = new System.Drawing.Point(269, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 102);
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
            this.panel4.Size = new System.Drawing.Size(124, 102);
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
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.materialLabel82);
            this.panel6.Controls.Add(this.lblFramesCounter);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(875, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(710, 108);
            this.panel6.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Depth = 0;
            this.label10.Font = new System.Drawing.Font("Roboto", 11F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(16, 83);
            this.label10.MouseState = MaterialSkin.MouseState.HOVER;
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 19);
            this.label10.TabIndex = 40;
            this.label10.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Depth = 0;
            this.label9.Font = new System.Drawing.Font("Roboto", 11F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(15, 57);
            this.label9.MouseState = MaterialSkin.MouseState.HOVER;
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 19);
            this.label9.TabIndex = 39;
            this.label9.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Depth = 0;
            this.label8.Font = new System.Drawing.Font("Roboto", 11F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(16, 32);
            this.label8.MouseState = MaterialSkin.MouseState.HOVER;
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 19);
            this.label8.TabIndex = 38;
            this.label8.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Depth = 0;
            this.label7.Font = new System.Drawing.Font("Roboto", 11F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(16, 7);
            this.label7.MouseState = MaterialSkin.MouseState.HOVER;
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 19);
            this.label7.TabIndex = 37;
            this.label7.Text = "label7";
            // 
            // materialLabel82
            // 
            this.materialLabel82.AutoSize = true;
            this.materialLabel82.Depth = 0;
            this.materialLabel82.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel82.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel82.Location = new System.Drawing.Point(231, 9);
            this.materialLabel82.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel82.Name = "materialLabel82";
            this.materialLabel82.Size = new System.Drawing.Size(118, 19);
            this.materialLabel82.TabIndex = 36;
            this.materialLabel82.Text = "Кол-во кадров:";
            // 
            // lblFramesCounter
            // 
            this.lblFramesCounter.AutoSize = true;
            this.lblFramesCounter.Depth = 0;
            this.lblFramesCounter.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFramesCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFramesCounter.Location = new System.Drawing.Point(355, 9);
            this.lblFramesCounter.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFramesCounter.Name = "lblFramesCounter";
            this.lblFramesCounter.Size = new System.Drawing.Size(17, 19);
            this.lblFramesCounter.TabIndex = 35;
            this.lblFramesCounter.Text = "0";
            // 
            // FormReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1588, 795);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.tlpReceiveSettings);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1588, 795);
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
            this.tlpReceiveSettings.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tlpDecodingParameters.ResumeLayout(false);
            this.tlpDecodingParameters.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel flpChannel1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel flpChannel2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.FlowLayoutPanel flpChannel3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.FlowLayoutPanel flpChannel4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.FlowLayoutPanel flpChannel5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.FlowLayoutPanel flpChannel6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flpAllChannels4;
        private System.Windows.Forms.FlowLayoutPanel flpAllChannels6;
        private System.Windows.Forms.FlowLayoutPanel flpAllChannels5;
        private System.Windows.Forms.FlowLayoutPanel flpAllChannels3;
        private System.Windows.Forms.FlowLayoutPanel flpAllChannels2;
        private System.Windows.Forms.FlowLayoutPanel flpAllChannels1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.TableLayoutPanel tlpReceiveSettings;
        private System.Windows.Forms.Panel panel5;
        private MaterialSkin.Controls.MaterialRaisedButton btnStartRecieve;
        private System.Windows.Forms.TableLayoutPanel tlpDecodingParameters;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private MaterialSkin.Controls.MaterialLabel lblFramesCounter;
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
        public MaterialSkin.Controls.MaterialLabel label10;
        public MaterialSkin.Controls.MaterialLabel label9;
        public MaterialSkin.Controls.MaterialLabel label8;
        public MaterialSkin.Controls.MaterialLabel label7;
        private MaterialSkin.Controls.MaterialLabel materialLabel82;
    }
}

