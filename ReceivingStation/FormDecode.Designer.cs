namespace ReceivingStation
{
    partial class FormDecode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDecode));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStartDecoding = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStopDecoding = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flpAllChannels4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAllChannels6 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAllChannels5 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAllChannels3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAllChannels2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAllChannels1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.slDecodeTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnStartStopDecode = new System.Windows.Forms.Button();
            this.gbDecodeParameters = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.gbNRZ = new System.Windows.Forms.GroupBox();
            this.rbNRZNo = new System.Windows.Forms.RadioButton();
            this.rbNRZYes = new System.Windows.Forms.RadioButton();
            this.gbRS = new System.Windows.Forms.GroupBox();
            this.rbRSNo = new System.Windows.Forms.RadioButton();
            this.rbRSYes = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFramesCounter = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bwImageSaver = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlScroll.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbDecodeParameters.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.gbNRZ.SuspendLayout();
            this.gbRS.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.управлениеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1204, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFileOpen,
            this.tsmiExit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // tsmiFileOpen
            // 
            this.tsmiFileOpen.Image = global::ReceivingStation.Properties.Resources.file_icon;
            this.tsmiFileOpen.Name = "tsmiFileOpen";
            this.tsmiFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmiFileOpen.Size = new System.Drawing.Size(164, 22);
            this.tsmiFileOpen.Text = "Открыть";
            this.tsmiFileOpen.Click += new System.EventHandler(this.tsmiFileOpen_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Image = global::ReceivingStation.Properties.Resources.exit_icon;
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.tsmiExit.Size = new System.Drawing.Size(164, 22);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // управлениеToolStripMenuItem
            // 
            this.управлениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStartDecoding,
            this.tsmiStopDecoding});
            this.управлениеToolStripMenuItem.Name = "управлениеToolStripMenuItem";
            this.управлениеToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.управлениеToolStripMenuItem.Text = "Управление";
            // 
            // tsmiStartDecoding
            // 
            this.tsmiStartDecoding.Enabled = false;
            this.tsmiStartDecoding.Image = global::ReceivingStation.Properties.Resources.start_icon;
            this.tsmiStartDecoding.Name = "tsmiStartDecoding";
            this.tsmiStartDecoding.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiStartDecoding.Size = new System.Drawing.Size(266, 22);
            this.tsmiStartDecoding.Text = "Начать декодирование";
            this.tsmiStartDecoding.Click += new System.EventHandler(this.tsmiStartDecoding_Click);
            // 
            // tsmiStopDecoding
            // 
            this.tsmiStopDecoding.Enabled = false;
            this.tsmiStopDecoding.Image = global::ReceivingStation.Properties.Resources.stop_icon;
            this.tsmiStopDecoding.Name = "tsmiStopDecoding";
            this.tsmiStopDecoding.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.tsmiStopDecoding.Size = new System.Drawing.Size(266, 22);
            this.tsmiStopDecoding.Text = "Остановить декодирование";
            this.tsmiStopDecoding.Click += new System.EventHandler(this.tsmiStopDecoding_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 111);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1204, 660);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flpChannel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1196, 634);
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
            this.flpChannel1.Size = new System.Drawing.Size(1190, 628);
            this.flpChannel1.TabIndex = 2;
            this.flpChannel1.WrapContents = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flpChannel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1180, 599);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Канал 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flpChannel2
            // 
            this.flpChannel2.AutoScroll = true;
            this.flpChannel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpChannel2.Location = new System.Drawing.Point(3, 3);
            this.flpChannel2.Name = "flpChannel2";
            this.flpChannel2.Size = new System.Drawing.Size(1174, 680);
            this.flpChannel2.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.flpChannel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1180, 599);
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
            this.flpChannel3.Size = new System.Drawing.Size(1174, 593);
            this.flpChannel3.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.flpChannel4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1180, 599);
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
            this.flpChannel4.Size = new System.Drawing.Size(1174, 593);
            this.flpChannel4.TabIndex = 3;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.flpChannel5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1180, 599);
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
            this.flpChannel5.Size = new System.Drawing.Size(1174, 593);
            this.flpChannel5.TabIndex = 3;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.flpChannel6);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1180, 599);
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
            this.flpChannel6.Size = new System.Drawing.Size(1174, 593);
            this.flpChannel6.TabIndex = 3;
            // 
            // tabPage7
            // 
            this.tabPage7.AutoScroll = true;
            this.tabPage7.Controls.Add(this.tableLayoutPanel1);
            this.tabPage7.Controls.Add(this.tableLayoutPanel2);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1180, 599);
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
            this.tableLayoutPanel1.Controls.Add(this.flpAllChannels4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpAllChannels6, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpAllChannels5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpAllChannels3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpAllChannels2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpAllChannels1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 44);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1174, 552);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flpAllChannels4
            // 
            this.flpAllChannels4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAllChannels4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAllChannels4.Location = new System.Drawing.Point(588, 3);
            this.flpAllChannels4.Name = "flpAllChannels4";
            this.flpAllChannels4.Size = new System.Drawing.Size(189, 546);
            this.flpAllChannels4.TabIndex = 3;
            this.flpAllChannels4.WrapContents = false;
            // 
            // flpAllChannels6
            // 
            this.flpAllChannels6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAllChannels6.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAllChannels6.Location = new System.Drawing.Point(978, 3);
            this.flpAllChannels6.Name = "flpAllChannels6";
            this.flpAllChannels6.Size = new System.Drawing.Size(193, 546);
            this.flpAllChannels6.TabIndex = 5;
            this.flpAllChannels6.WrapContents = false;
            // 
            // flpAllChannels5
            // 
            this.flpAllChannels5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAllChannels5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAllChannels5.Location = new System.Drawing.Point(783, 3);
            this.flpAllChannels5.Name = "flpAllChannels5";
            this.flpAllChannels5.Size = new System.Drawing.Size(189, 546);
            this.flpAllChannels5.TabIndex = 4;
            this.flpAllChannels5.WrapContents = false;
            // 
            // flpAllChannels3
            // 
            this.flpAllChannels3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpAllChannels3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAllChannels3.Location = new System.Drawing.Point(393, 3);
            this.flpAllChannels3.Name = "flpAllChannels3";
            this.flpAllChannels3.Size = new System.Drawing.Size(189, 546);
            this.flpAllChannels3.TabIndex = 2;
            this.flpAllChannels3.WrapContents = false;
            // 
            // flpAllChannels2
            // 
            this.flpAllChannels2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpAllChannels2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAllChannels2.Location = new System.Drawing.Point(198, 3);
            this.flpAllChannels2.Name = "flpAllChannels2";
            this.flpAllChannels2.Size = new System.Drawing.Size(189, 546);
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
            this.flpAllChannels1.Size = new System.Drawing.Size(189, 546);
            this.flpAllChannels1.TabIndex = 0;
            this.flpAllChannels1.WrapContents = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Controls.Add(this.label6, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1174, 41);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1048, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Канал 6";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(851, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Канал 5";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(656, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Канал 4";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(461, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Канал 3";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Канал 2";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Канал 1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slTime,
            this.slDecodeTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 771);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(1204, 24);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slTime
            // 
            this.slTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.slTime.Image = global::ReceivingStation.Properties.Resources.time_icon;
            this.slTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.slTime.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.slTime.Name = "slTime";
            this.slTime.Size = new System.Drawing.Size(1124, 19);
            this.slTime.Spring = true;
            this.slTime.Text = "01/01/1668 12:12:01";
            this.slTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.slTime.ToolTipText = "Дата/Время";
            // 
            // slDecodeTime
            // 
            this.slDecodeTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.slDecodeTime.Image = global::ReceivingStation.Properties.Resources.time_icon;
            this.slDecodeTime.Name = "slDecodeTime";
            this.slDecodeTime.Size = new System.Drawing.Size(63, 19);
            this.slDecodeTime.Text = "0:00:0";
            this.slDecodeTime.ToolTipText = "Время декодирования";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlScroll
            // 
            this.pnlScroll.Controls.Add(this.flowLayoutPanel1);
            this.pnlScroll.Controls.Add(this.panel1);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlScroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pnlScroll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pnlScroll.Location = new System.Drawing.Point(0, 24);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(1204, 87);
            this.pnlScroll.TabIndex = 23;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox4);
            this.flowLayoutPanel1.Controls.Add(this.gbDecodeParameters);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(7);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1204, 87);
            this.flowLayoutPanel1.TabIndex = 23;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnStartStopDecode);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.MinimumSize = new System.Drawing.Size(76, 83);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(76, 83);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            // 
            // btnStartStopDecode
            // 
            this.btnStartStopDecode.BackColor = System.Drawing.SystemColors.Control;
            this.btnStartStopDecode.BackgroundImage = global::ReceivingStation.Properties.Resources.start_icon;
            this.btnStartStopDecode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartStopDecode.Enabled = false;
            this.btnStartStopDecode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartStopDecode.Location = new System.Drawing.Point(9, 19);
            this.btnStartStopDecode.Name = "btnStartStopDecode";
            this.btnStartStopDecode.Size = new System.Drawing.Size(56, 52);
            this.btnStartStopDecode.TabIndex = 0;
            this.btnStartStopDecode.UseVisualStyleBackColor = false;
            this.btnStartStopDecode.Click += new System.EventHandler(this.btnStartStopDecode_Click);
            // 
            // gbDecodeParameters
            // 
            this.gbDecodeParameters.Controls.Add(this.tableLayoutPanel3);
            this.gbDecodeParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbDecodeParameters.Location = new System.Drawing.Point(85, 3);
            this.gbDecodeParameters.MinimumSize = new System.Drawing.Size(533, 83);
            this.gbDecodeParameters.Name = "gbDecodeParameters";
            this.gbDecodeParameters.Size = new System.Drawing.Size(533, 83);
            this.gbDecodeParameters.TabIndex = 33;
            this.gbDecodeParameters.TabStop = false;
            this.gbDecodeParameters.Text = "Параметры";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.gbNRZ, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.gbRS, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(527, 64);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // gbNRZ
            // 
            this.gbNRZ.Controls.Add(this.rbNRZNo);
            this.gbNRZ.Controls.Add(this.rbNRZYes);
            this.gbNRZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbNRZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbNRZ.Location = new System.Drawing.Point(266, 3);
            this.gbNRZ.Name = "gbNRZ";
            this.gbNRZ.Size = new System.Drawing.Size(258, 58);
            this.gbNRZ.TabIndex = 12;
            this.gbNRZ.TabStop = false;
            this.gbNRZ.Text = "NRZ (Для Меторов 2.1/2.2)";
            // 
            // rbNRZNo
            // 
            this.rbNRZNo.AutoSize = true;
            this.rbNRZNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbNRZNo.Location = new System.Drawing.Point(154, 23);
            this.rbNRZNo.Name = "rbNRZNo";
            this.rbNRZNo.Size = new System.Drawing.Size(48, 19);
            this.rbNRZNo.TabIndex = 7;
            this.rbNRZNo.Text = "Нет";
            this.rbNRZNo.UseVisualStyleBackColor = true;
            // 
            // rbNRZYes
            // 
            this.rbNRZYes.AutoSize = true;
            this.rbNRZYes.Checked = true;
            this.rbNRZYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbNRZYes.Location = new System.Drawing.Point(58, 23);
            this.rbNRZYes.Name = "rbNRZYes";
            this.rbNRZYes.Size = new System.Drawing.Size(41, 19);
            this.rbNRZYes.TabIndex = 6;
            this.rbNRZYes.TabStop = true;
            this.rbNRZYes.Text = "Да";
            this.rbNRZYes.UseVisualStyleBackColor = true;
            // 
            // gbRS
            // 
            this.gbRS.Controls.Add(this.rbRSNo);
            this.gbRS.Controls.Add(this.rbRSYes);
            this.gbRS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbRS.Location = new System.Drawing.Point(3, 3);
            this.gbRS.Name = "gbRS";
            this.gbRS.Size = new System.Drawing.Size(257, 58);
            this.gbRS.TabIndex = 14;
            this.gbRS.TabStop = false;
            this.gbRS.Text = "Рида-Соломона";
            // 
            // rbRSNo
            // 
            this.rbRSNo.AutoSize = true;
            this.rbRSNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbRSNo.Location = new System.Drawing.Point(148, 23);
            this.rbRSNo.Name = "rbRSNo";
            this.rbRSNo.Size = new System.Drawing.Size(48, 19);
            this.rbRSNo.TabIndex = 7;
            this.rbRSNo.Text = "Нет";
            this.rbRSNo.UseVisualStyleBackColor = true;
            // 
            // rbRSYes
            // 
            this.rbRSYes.AutoSize = true;
            this.rbRSYes.Checked = true;
            this.rbRSYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbRSYes.Location = new System.Drawing.Point(52, 23);
            this.rbRSYes.Name = "rbRSYes";
            this.rbRSYes.Size = new System.Drawing.Size(41, 19);
            this.rbRSYes.TabIndex = 6;
            this.rbRSYes.TabStop = true;
            this.rbRSYes.Text = "Да";
            this.rbRSYes.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblFileName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblFramesCounter);
            this.groupBox1.Location = new System.Drawing.Point(624, 3);
            this.groupBox1.MinimumSize = new System.Drawing.Size(0, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 83);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(6, 49);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.MinimumSize = new System.Drawing.Size(0, 2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 15);
            this.label12.TabIndex = 10;
            this.label12.Text = "Кол-во кадров:";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFileName.Location = new System.Drawing.Point(87, 25);
            this.lblFileName.Margin = new System.Windows.Forms.Padding(3);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(103, 15);
            this.lblFileName.TabIndex = 7;
            this.lblFileName.Text = "Файл не выбран";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(6, 25);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 15);
            this.label11.TabIndex = 9;
            this.label11.Text = "Имя файла:";
            // 
            // lblFramesCounter
            // 
            this.lblFramesCounter.AutoSize = true;
            this.lblFramesCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFramesCounter.Location = new System.Drawing.Point(106, 49);
            this.lblFramesCounter.Margin = new System.Windows.Forms.Padding(3);
            this.lblFramesCounter.MinimumSize = new System.Drawing.Size(0, 2);
            this.lblFramesCounter.Name = "lblFramesCounter";
            this.lblFramesCounter.Size = new System.Drawing.Size(14, 15);
            this.lblFramesCounter.TabIndex = 3;
            this.lblFramesCounter.Text = "0";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 22;
            // 
            // bwImageSaver
            // 
            this.bwImageSaver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwImageSaver_DoWork);
            // 
            // FormDecode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 795);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnlScroll);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1204, 795);
            this.Name = "FormDecode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Приемная станция";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDecode_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDecode_FormClosed);
            this.Load += new System.EventHandler(this.FormDecode_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlScroll.ResumeLayout(false);
            this.pnlScroll.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.gbDecodeParameters.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.gbNRZ.ResumeLayout(false);
            this.gbNRZ.PerformLayout();
            this.gbRS.ResumeLayout(false);
            this.gbRS.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileOpen;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slTime;
        private System.Windows.Forms.GroupBox gbNRZ;
        private System.Windows.Forms.RadioButton rbNRZNo;
        private System.Windows.Forms.RadioButton rbNRZYes;
        private System.Windows.Forms.GroupBox gbRS;
        private System.Windows.Forms.RadioButton rbRSNo;
        private System.Windows.Forms.RadioButton rbRSYes;
        private System.Windows.Forms.ToolStripMenuItem управлениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiStartDecoding;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.Button btnStartStopDecode;
        private System.Windows.Forms.GroupBox gbDecodeParameters;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblFramesCounter;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem tsmiStopDecoding;
        private System.Windows.Forms.ToolStripStatusLabel slDecodeTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flpChannel1;
        private System.Windows.Forms.FlowLayoutPanel flpChannel2;
        private System.Windows.Forms.FlowLayoutPanel flpChannel3;
        private System.Windows.Forms.FlowLayoutPanel flpChannel4;
        private System.Windows.Forms.FlowLayoutPanel flpChannel5;
        private System.Windows.Forms.FlowLayoutPanel flpChannel6;
        private System.Windows.Forms.FlowLayoutPanel flpAllChannels6;
        private System.Windows.Forms.FlowLayoutPanel flpAllChannels5;
        private System.Windows.Forms.FlowLayoutPanel flpAllChannels4;
        private System.Windows.Forms.FlowLayoutPanel flpAllChannels3;
        private System.Windows.Forms.FlowLayoutPanel flpAllChannels2;
        private System.Windows.Forms.FlowLayoutPanel flpAllChannels1;
        private System.ComponentModel.BackgroundWorker bwImageSaver;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}

