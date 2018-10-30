namespace ReceivingStation
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьПриемToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.остановитьПриемToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStartDecoding = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStopDecoding = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pChannel1 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pChannel2 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pChannel3 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pChannel4 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.pChannel5 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.pChannel6 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pACChannel1 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.pACChannel2 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.pACChannel3 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.pACChannel4 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.pACChannel5 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.pACChannel6 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.slWorkingTimeKPA = new System.Windows.Forms.ToolStripStatusLabel();
            this.slWorkingTimeSystem = new System.Windows.Forms.ToolStripStatusLabel();
            this.slMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.collapsiblePanel1 = new CollapsiblePanel.CollapsiblePanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbFCP = new System.Windows.Forms.GroupBox();
            this.rbFCPReserve = new System.Windows.Forms.RadioButton();
            this.rbFCPMain = new System.Windows.Forms.RadioButton();
            this.gbInterlivingReceive = new System.Windows.Forms.GroupBox();
            this.rbInterlivingReceiveOn = new System.Windows.Forms.RadioButton();
            this.rbInterlivingReceiveOff = new System.Windows.Forms.RadioButton();
            this.gbPRD = new System.Windows.Forms.GroupBox();
            this.rbPRDReserve = new System.Windows.Forms.RadioButton();
            this.rbPRDMain = new System.Windows.Forms.RadioButton();
            this.gbFreq = new System.Windows.Forms.GroupBox();
            this.rbFreq2 = new System.Windows.Forms.RadioButton();
            this.rbFreq1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStartRecieve = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnStopRecieve = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.collapsiblePanel2 = new CollapsiblePanel.CollapsiblePanel();
            this.gbDecodeParameters = new System.Windows.Forms.GroupBox();
            this.gbNRZ = new System.Windows.Forms.GroupBox();
            this.rbNRZNo = new System.Windows.Forms.RadioButton();
            this.rbNRZYes = new System.Windows.Forms.RadioButton();
            this.gbRS = new System.Windows.Forms.GroupBox();
            this.rbRSNo = new System.Windows.Forms.RadioButton();
            this.rbRSYes = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblFramesCounter = new System.Windows.Forms.Label();
            this.btnStartDecode = new System.Windows.Forms.Button();
            this.btnStopDecode = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlScroll.SuspendLayout();
            this.panel1.SuspendLayout();
            this.collapsiblePanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbFCP.SuspendLayout();
            this.gbInterlivingReceive.SuspendLayout();
            this.gbPRD.SuspendLayout();
            this.gbFreq.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.collapsiblePanel2.SuspendLayout();
            this.gbDecodeParameters.SuspendLayout();
            this.gbNRZ.SuspendLayout();
            this.gbRS.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.управлениеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1188, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFileOpen,
            this.tsmiSettings,
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
            this.tsmiFileOpen.Size = new System.Drawing.Size(175, 22);
            this.tsmiFileOpen.Text = "Открыть";
            this.tsmiFileOpen.Click += new System.EventHandler(this.tsmiFileOpen_Click);
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Image = global::ReceivingStation.Properties.Resources.settings_icon;
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsmiSettings.Size = new System.Drawing.Size(175, 22);
            this.tsmiSettings.Text = "Настройки";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Image = global::ReceivingStation.Properties.Resources.exit_icon;
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.tsmiExit.Size = new System.Drawing.Size(175, 22);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // управлениеToolStripMenuItem
            // 
            this.управлениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.начатьПриемToolStripMenuItem,
            this.остановитьПриемToolStripMenuItem,
            this.tsmiStartDecoding,
            this.tsmiStopDecoding});
            this.управлениеToolStripMenuItem.Name = "управлениеToolStripMenuItem";
            this.управлениеToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.управлениеToolStripMenuItem.Text = "Управление";
            // 
            // начатьПриемToolStripMenuItem
            // 
            this.начатьПриемToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("начатьПриемToolStripMenuItem.Image")));
            this.начатьПриемToolStripMenuItem.Name = "начатьПриемToolStripMenuItem";
            this.начатьПриемToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.начатьПриемToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.начатьПриемToolStripMenuItem.Text = "Начать прием данных";
            // 
            // остановитьПриемToolStripMenuItem
            // 
            this.остановитьПриемToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("остановитьПриемToolStripMenuItem.Image")));
            this.остановитьПриемToolStripMenuItem.Name = "остановитьПриемToolStripMenuItem";
            this.остановитьПриемToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.остановитьПриемToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.остановитьПриемToolStripMenuItem.Text = "Остановить прием данных";
            // 
            // tsmiStartDecoding
            // 
            this.tsmiStartDecoding.Enabled = false;
            this.tsmiStartDecoding.Image = ((System.Drawing.Image)(resources.GetObject("tsmiStartDecoding.Image")));
            this.tsmiStartDecoding.Name = "tsmiStartDecoding";
            this.tsmiStartDecoding.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.tsmiStartDecoding.Size = new System.Drawing.Size(299, 22);
            this.tsmiStartDecoding.Text = "Начать расшифровку данных";
            this.tsmiStartDecoding.Click += new System.EventHandler(this.tsmiStartDecoding_Click);
            // 
            // tsmiStopDecoding
            // 
            this.tsmiStopDecoding.Enabled = false;
            this.tsmiStopDecoding.Image = global::ReceivingStation.Properties.Resources.stop_icon;
            this.tsmiStopDecoding.Name = "tsmiStopDecoding";
            this.tsmiStopDecoding.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.tsmiStopDecoding.Size = new System.Drawing.Size(299, 22);
            this.tsmiStopDecoding.Text = "Остановить расшифровку данных";
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
            this.tabControl1.Location = new System.Drawing.Point(265, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(923, 708);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.pChannel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(915, 682);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Канал 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pChannel1
            // 
            this.pChannel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pChannel1.Location = new System.Drawing.Point(3, 3);
            this.pChannel1.Name = "pChannel1";
            this.pChannel1.Size = new System.Drawing.Size(909, 24);
            this.pChannel1.TabIndex = 0;
            this.pChannel1.BackgroundImageChanged += new System.EventHandler(this.DoubleBufferedPanel_BackgroundImageChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.pChannel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(915, 682);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Канал 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pChannel2
            // 
            this.pChannel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pChannel2.Location = new System.Drawing.Point(3, 3);
            this.pChannel2.Name = "pChannel2";
            this.pChannel2.Size = new System.Drawing.Size(909, 24);
            this.pChannel2.TabIndex = 0;
            this.pChannel2.BackgroundImageChanged += new System.EventHandler(this.DoubleBufferedPanel_BackgroundImageChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.pChannel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(915, 682);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Канал 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pChannel3
            // 
            this.pChannel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pChannel3.Location = new System.Drawing.Point(3, 3);
            this.pChannel3.Name = "pChannel3";
            this.pChannel3.Size = new System.Drawing.Size(909, 24);
            this.pChannel3.TabIndex = 1;
            this.pChannel3.BackgroundImageChanged += new System.EventHandler(this.DoubleBufferedPanel_BackgroundImageChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.Controls.Add(this.pChannel4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(915, 682);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Канал 4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pChannel4
            // 
            this.pChannel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pChannel4.Location = new System.Drawing.Point(3, 3);
            this.pChannel4.Name = "pChannel4";
            this.pChannel4.Size = new System.Drawing.Size(909, 24);
            this.pChannel4.TabIndex = 1;
            this.pChannel4.BackgroundImageChanged += new System.EventHandler(this.DoubleBufferedPanel_BackgroundImageChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.AutoScroll = true;
            this.tabPage5.Controls.Add(this.pChannel5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(915, 682);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Канал 5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // pChannel5
            // 
            this.pChannel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pChannel5.Location = new System.Drawing.Point(3, 3);
            this.pChannel5.Name = "pChannel5";
            this.pChannel5.Size = new System.Drawing.Size(909, 24);
            this.pChannel5.TabIndex = 1;
            this.pChannel5.BackgroundImageChanged += new System.EventHandler(this.DoubleBufferedPanel_BackgroundImageChanged);
            // 
            // tabPage6
            // 
            this.tabPage6.AutoScroll = true;
            this.tabPage6.Controls.Add(this.pChannel6);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(915, 682);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Канал 6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // pChannel6
            // 
            this.pChannel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pChannel6.Location = new System.Drawing.Point(3, 3);
            this.pChannel6.Name = "pChannel6";
            this.pChannel6.Size = new System.Drawing.Size(909, 24);
            this.pChannel6.TabIndex = 1;
            this.pChannel6.BackgroundImageChanged += new System.EventHandler(this.DoubleBufferedPanel_BackgroundImageChanged);
            // 
            // tabPage7
            // 
            this.tabPage7.AutoScroll = true;
            this.tabPage7.Controls.Add(this.tableLayoutPanel3);
            this.tabPage7.Controls.Add(this.tableLayoutPanel2);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(915, 682);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Все каналы";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.Controls.Add(this.label6, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(909, 41);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(805, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Канал 6";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(653, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Канал 5";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Канал 4";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Канал 3";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Канал 2";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Канал 1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Controls.Add(this.pACChannel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pACChannel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pACChannel3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.pACChannel4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.pACChannel5, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.pACChannel6, 5, 0);
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 47);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(909, 632);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pACChannel1
            // 
            this.pACChannel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pACChannel1.Location = new System.Drawing.Point(3, 3);
            this.pACChannel1.Name = "pACChannel1";
            this.pACChannel1.Size = new System.Drawing.Size(145, 626);
            this.pACChannel1.TabIndex = 6;
            this.pACChannel1.BackgroundImageChanged += new System.EventHandler(this.DoubleBufferedPanel_BackgroundImageChanged);
            // 
            // pACChannel2
            // 
            this.pACChannel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pACChannel2.Location = new System.Drawing.Point(154, 3);
            this.pACChannel2.Name = "pACChannel2";
            this.pACChannel2.Size = new System.Drawing.Size(145, 626);
            this.pACChannel2.TabIndex = 7;
            this.pACChannel2.BackgroundImageChanged += new System.EventHandler(this.DoubleBufferedPanel_BackgroundImageChanged);
            // 
            // pACChannel3
            // 
            this.pACChannel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pACChannel3.Location = new System.Drawing.Point(305, 3);
            this.pACChannel3.Name = "pACChannel3";
            this.pACChannel3.Size = new System.Drawing.Size(145, 626);
            this.pACChannel3.TabIndex = 8;
            this.pACChannel3.BackgroundImageChanged += new System.EventHandler(this.DoubleBufferedPanel_BackgroundImageChanged);
            // 
            // pACChannel4
            // 
            this.pACChannel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pACChannel4.Location = new System.Drawing.Point(456, 3);
            this.pACChannel4.Name = "pACChannel4";
            this.pACChannel4.Size = new System.Drawing.Size(145, 626);
            this.pACChannel4.TabIndex = 9;
            this.pACChannel4.BackgroundImageChanged += new System.EventHandler(this.DoubleBufferedPanel_BackgroundImageChanged);
            // 
            // pACChannel5
            // 
            this.pACChannel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pACChannel5.Location = new System.Drawing.Point(607, 3);
            this.pACChannel5.Name = "pACChannel5";
            this.pACChannel5.Size = new System.Drawing.Size(145, 626);
            this.pACChannel5.TabIndex = 10;
            this.pACChannel5.BackgroundImageChanged += new System.EventHandler(this.DoubleBufferedPanel_BackgroundImageChanged);
            // 
            // pACChannel6
            // 
            this.pACChannel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pACChannel6.Location = new System.Drawing.Point(758, 3);
            this.pACChannel6.Name = "pACChannel6";
            this.pACChannel6.Size = new System.Drawing.Size(148, 626);
            this.pACChannel6.TabIndex = 11;
            this.pACChannel6.BackgroundImageChanged += new System.EventHandler(this.DoubleBufferedPanel_BackgroundImageChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slTime,
            this.slWorkingTimeKPA,
            this.slWorkingTimeSystem,
            this.slMode});
            this.statusStrip1.Location = new System.Drawing.Point(0, 732);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(1188, 24);
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
            this.slTime.Size = new System.Drawing.Size(362, 19);
            this.slTime.Spring = true;
            this.slTime.Text = "01/01/1668 12:12:01";
            this.slTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.slTime.ToolTipText = "Дата/Время";
            // 
            // slWorkingTimeKPA
            // 
            this.slWorkingTimeKPA.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.slWorkingTimeKPA.Image = global::ReceivingStation.Properties.Resources.time_icon;
            this.slWorkingTimeKPA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.slWorkingTimeKPA.Name = "slWorkingTimeKPA";
            this.slWorkingTimeKPA.Size = new System.Drawing.Size(79, 19);
            this.slWorkingTimeKPA.Text = "12:12:01";
            this.slWorkingTimeKPA.ToolTipText = "Время наработки КПА (ЧЧ:ММ:СС)";
            // 
            // slWorkingTimeSystem
            // 
            this.slWorkingTimeSystem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.slWorkingTimeSystem.Image = global::ReceivingStation.Properties.Resources.time_icon;
            this.slWorkingTimeSystem.Name = "slWorkingTimeSystem";
            this.slWorkingTimeSystem.Size = new System.Drawing.Size(364, 19);
            this.slWorkingTimeSystem.Spring = true;
            this.slWorkingTimeSystem.Text = "12:12:01";
            this.slWorkingTimeSystem.ToolTipText = "Время наработки системы (ЧЧ:ММ:СС)";
            // 
            // slMode
            // 
            this.slMode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.slMode.Image = global::ReceivingStation.Properties.Resources.mode_icon;
            this.slMode.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.slMode.Name = "slMode";
            this.slMode.Size = new System.Drawing.Size(364, 19);
            this.slMode.Spring = true;
            this.slMode.Text = "Местное управление";
            this.slMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.91958F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.67482F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.49301F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(265, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(923, 0);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.Controls.Add(this.panel1);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlScroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pnlScroll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pnlScroll.Location = new System.Drawing.Point(0, 24);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(265, 708);
            this.pnlScroll.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.collapsiblePanel1);
            this.panel1.Controls.Add(this.collapsiblePanel2);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 394);
            this.panel1.TabIndex = 22;
            // 
            // collapsiblePanel1
            // 
            this.collapsiblePanel1.Controls.Add(this.groupBox1);
            this.collapsiblePanel1.Controls.Add(this.groupBox2);
            this.collapsiblePanel1.ExpandedHeight = 575;
            this.collapsiblePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.collapsiblePanel1.Location = new System.Drawing.Point(3, 3);
            this.collapsiblePanel1.Name = "collapsiblePanel1";
            this.collapsiblePanel1.NextPanel = this.collapsiblePanel2;
            this.collapsiblePanel1.PanelState = CollapsiblePanel.PanelStateOptions.Collapsed;
            this.collapsiblePanel1.PanelTitle = "Прием потока";
            this.collapsiblePanel1.Size = new System.Drawing.Size(242, 28);
            this.collapsiblePanel1.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbFCP);
            this.groupBox1.Controls.Add(this.gbInterlivingReceive);
            this.groupBox1.Controls.Add(this.gbPRD);
            this.groupBox1.Controls.Add(this.gbFreq);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(0, 235);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(242, 365);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // gbFCP
            // 
            this.gbFCP.Controls.Add(this.rbFCPReserve);
            this.gbFCP.Controls.Add(this.rbFCPMain);
            this.gbFCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbFCP.Location = new System.Drawing.Point(25, 23);
            this.gbFCP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbFCP.Name = "gbFCP";
            this.gbFCP.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbFCP.Size = new System.Drawing.Size(194, 79);
            this.gbFCP.TabIndex = 13;
            this.gbFCP.TabStop = false;
            this.gbFCP.Text = "ФЦП-М";
            // 
            // rbFCPReserve
            // 
            this.rbFCPReserve.AutoSize = true;
            this.rbFCPReserve.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbFCPReserve.Location = new System.Drawing.Point(103, 35);
            this.rbFCPReserve.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbFCPReserve.Name = "rbFCPReserve";
            this.rbFCPReserve.Size = new System.Drawing.Size(90, 19);
            this.rbFCPReserve.TabIndex = 7;
            this.rbFCPReserve.Text = "Резервный";
            this.rbFCPReserve.UseVisualStyleBackColor = true;
            // 
            // rbFCPMain
            // 
            this.rbFCPMain.AutoSize = true;
            this.rbFCPMain.Checked = true;
            this.rbFCPMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbFCPMain.Location = new System.Drawing.Point(6, 35);
            this.rbFCPMain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbFCPMain.Name = "rbFCPMain";
            this.rbFCPMain.Size = new System.Drawing.Size(82, 19);
            this.rbFCPMain.TabIndex = 6;
            this.rbFCPMain.TabStop = true;
            this.rbFCPMain.Text = "Основной";
            this.rbFCPMain.UseVisualStyleBackColor = true;
            // 
            // gbInterlivingReceive
            // 
            this.gbInterlivingReceive.Controls.Add(this.rbInterlivingReceiveOn);
            this.gbInterlivingReceive.Controls.Add(this.rbInterlivingReceiveOff);
            this.gbInterlivingReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbInterlivingReceive.Location = new System.Drawing.Point(25, 272);
            this.gbInterlivingReceive.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbInterlivingReceive.Name = "gbInterlivingReceive";
            this.gbInterlivingReceive.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbInterlivingReceive.Size = new System.Drawing.Size(194, 74);
            this.gbInterlivingReceive.TabIndex = 13;
            this.gbInterlivingReceive.TabStop = false;
            this.gbInterlivingReceive.Text = "Интерливинг";
            // 
            // rbInterlivingReceiveOn
            // 
            this.rbInterlivingReceiveOn.AutoSize = true;
            this.rbInterlivingReceiveOn.Checked = true;
            this.rbInterlivingReceiveOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbInterlivingReceiveOn.Location = new System.Drawing.Point(6, 35);
            this.rbInterlivingReceiveOn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbInterlivingReceiveOn.Name = "rbInterlivingReceiveOn";
            this.rbInterlivingReceiveOn.Size = new System.Drawing.Size(82, 19);
            this.rbInterlivingReceiveOn.TabIndex = 8;
            this.rbInterlivingReceiveOn.TabStop = true;
            this.rbInterlivingReceiveOn.Text = "Включить";
            this.rbInterlivingReceiveOn.UseVisualStyleBackColor = true;
            // 
            // rbInterlivingReceiveOff
            // 
            this.rbInterlivingReceiveOff.AutoSize = true;
            this.rbInterlivingReceiveOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbInterlivingReceiveOff.Location = new System.Drawing.Point(102, 35);
            this.rbInterlivingReceiveOff.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbInterlivingReceiveOff.Name = "rbInterlivingReceiveOff";
            this.rbInterlivingReceiveOff.Size = new System.Drawing.Size(91, 19);
            this.rbInterlivingReceiveOff.TabIndex = 9;
            this.rbInterlivingReceiveOff.Text = "Выключить";
            this.rbInterlivingReceiveOff.UseVisualStyleBackColor = true;
            // 
            // gbPRD
            // 
            this.gbPRD.Controls.Add(this.rbPRDReserve);
            this.gbPRD.Controls.Add(this.rbPRDMain);
            this.gbPRD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbPRD.Location = new System.Drawing.Point(26, 108);
            this.gbPRD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbPRD.Name = "gbPRD";
            this.gbPRD.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbPRD.Size = new System.Drawing.Size(193, 78);
            this.gbPRD.TabIndex = 14;
            this.gbPRD.TabStop = false;
            this.gbPRD.Text = "ПРД";
            // 
            // rbPRDReserve
            // 
            this.rbPRDReserve.AutoSize = true;
            this.rbPRDReserve.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbPRDReserve.Location = new System.Drawing.Point(102, 35);
            this.rbPRDReserve.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbPRDReserve.Name = "rbPRDReserve";
            this.rbPRDReserve.Size = new System.Drawing.Size(90, 19);
            this.rbPRDReserve.TabIndex = 7;
            this.rbPRDReserve.Text = "Резервный";
            this.rbPRDReserve.UseVisualStyleBackColor = true;
            // 
            // rbPRDMain
            // 
            this.rbPRDMain.AutoSize = true;
            this.rbPRDMain.Checked = true;
            this.rbPRDMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbPRDMain.Location = new System.Drawing.Point(6, 35);
            this.rbPRDMain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbPRDMain.Name = "rbPRDMain";
            this.rbPRDMain.Size = new System.Drawing.Size(82, 19);
            this.rbPRDMain.TabIndex = 6;
            this.rbPRDMain.TabStop = true;
            this.rbPRDMain.Text = "Основной";
            this.rbPRDMain.UseVisualStyleBackColor = true;
            // 
            // gbFreq
            // 
            this.gbFreq.Controls.Add(this.rbFreq2);
            this.gbFreq.Controls.Add(this.rbFreq1);
            this.gbFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbFreq.Location = new System.Drawing.Point(26, 192);
            this.gbFreq.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbFreq.Name = "gbFreq";
            this.gbFreq.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbFreq.Size = new System.Drawing.Size(193, 74);
            this.gbFreq.TabIndex = 12;
            this.gbFreq.TabStop = false;
            this.gbFreq.Text = "Несущая частота (МГц)";
            // 
            // rbFreq2
            // 
            this.rbFreq2.AutoSize = true;
            this.rbFreq2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbFreq2.Location = new System.Drawing.Point(74, 35);
            this.rbFreq2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbFreq2.Name = "rbFreq2";
            this.rbFreq2.Size = new System.Drawing.Size(56, 19);
            this.rbFreq2.TabIndex = 7;
            this.rbFreq2.Text = "137.9";
            this.rbFreq2.UseVisualStyleBackColor = true;
            // 
            // rbFreq1
            // 
            this.rbFreq1.AutoSize = true;
            this.rbFreq1.Checked = true;
            this.rbFreq1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbFreq1.Location = new System.Drawing.Point(6, 35);
            this.rbFreq1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbFreq1.Name = "rbFreq1";
            this.rbFreq1.Size = new System.Drawing.Size(56, 19);
            this.rbFreq1.TabIndex = 6;
            this.rbFreq1.TabStop = true;
            this.rbFreq1.Text = "137.1";
            this.rbFreq1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStartRecieve);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnStopRecieve);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(0, 29);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(242, 200);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            // 
            // btnStartRecieve
            // 
            this.btnStartRecieve.AutoSize = true;
            this.btnStartRecieve.BackColor = System.Drawing.SystemColors.Control;
            this.btnStartRecieve.BackgroundImage = global::ReceivingStation.Properties.Resources.start_icon;
            this.btnStartRecieve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartRecieve.Location = new System.Drawing.Point(49, 19);
            this.btnStartRecieve.Name = "btnStartRecieve";
            this.btnStartRecieve.Size = new System.Drawing.Size(55, 52);
            this.btnStartRecieve.TabIndex = 6;
            this.btnStartRecieve.UseVisualStyleBackColor = false;
            this.btnStartRecieve.Click += new System.EventHandler(this.btnStartRecieve_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(10, 165);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "label10";
            // 
            // btnStopRecieve
            // 
            this.btnStopRecieve.AutoSize = true;
            this.btnStopRecieve.BackColor = System.Drawing.SystemColors.Control;
            this.btnStopRecieve.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStopRecieve.BackgroundImage")));
            this.btnStopRecieve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStopRecieve.Enabled = false;
            this.btnStopRecieve.Location = new System.Drawing.Point(122, 19);
            this.btnStopRecieve.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStopRecieve.Name = "btnStopRecieve";
            this.btnStopRecieve.Size = new System.Drawing.Size(59, 52);
            this.btnStopRecieve.TabIndex = 1;
            this.btnStopRecieve.UseVisualStyleBackColor = false;
            this.btnStopRecieve.Click += new System.EventHandler(this.btnStopRecieve_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(10, 141);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "label9";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(10, 93);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(10, 117);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "label8";
            // 
            // collapsiblePanel2
            // 
            this.collapsiblePanel2.Controls.Add(this.gbDecodeParameters);
            this.collapsiblePanel2.Controls.Add(this.groupBox4);
            this.collapsiblePanel2.ExpandedHeight = 327;
            this.collapsiblePanel2.Location = new System.Drawing.Point(3, 36);
            this.collapsiblePanel2.Name = "collapsiblePanel2";
            this.collapsiblePanel2.NextPanel = null;
            this.collapsiblePanel2.PanelTitle = "Расшифровка потока";
            this.collapsiblePanel2.Size = new System.Drawing.Size(242, 355);
            this.collapsiblePanel2.TabIndex = 21;
            // 
            // gbDecodeParameters
            // 
            this.gbDecodeParameters.Controls.Add(this.gbNRZ);
            this.gbDecodeParameters.Controls.Add(this.gbRS);
            this.gbDecodeParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbDecodeParameters.Location = new System.Drawing.Point(0, 170);
            this.gbDecodeParameters.Name = "gbDecodeParameters";
            this.gbDecodeParameters.Size = new System.Drawing.Size(242, 181);
            this.gbDecodeParameters.TabIndex = 33;
            this.gbDecodeParameters.TabStop = false;
            this.gbDecodeParameters.Text = "Параметры";
            // 
            // gbNRZ
            // 
            this.gbNRZ.Controls.Add(this.rbNRZNo);
            this.gbNRZ.Controls.Add(this.rbNRZYes);
            this.gbNRZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbNRZ.Location = new System.Drawing.Point(26, 101);
            this.gbNRZ.Name = "gbNRZ";
            this.gbNRZ.Size = new System.Drawing.Size(193, 65);
            this.gbNRZ.TabIndex = 12;
            this.gbNRZ.TabStop = false;
            this.gbNRZ.Text = "NRZ (Для Меторов 2.1/2.2)";
            // 
            // rbNRZNo
            // 
            this.rbNRZNo.AutoSize = true;
            this.rbNRZNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbNRZNo.Location = new System.Drawing.Point(102, 35);
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
            this.rbNRZYes.Location = new System.Drawing.Point(6, 35);
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
            this.gbRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbRS.Location = new System.Drawing.Point(26, 25);
            this.gbRS.Name = "gbRS";
            this.gbRS.Size = new System.Drawing.Size(193, 65);
            this.gbRS.TabIndex = 14;
            this.gbRS.TabStop = false;
            this.gbRS.Text = "Рида-Соломона";
            // 
            // rbRSNo
            // 
            this.rbRSNo.AutoSize = true;
            this.rbRSNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbRSNo.Location = new System.Drawing.Point(102, 35);
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
            this.rbRSYes.Location = new System.Drawing.Point(6, 35);
            this.rbRSYes.Name = "rbRSYes";
            this.rbRSYes.Size = new System.Drawing.Size(41, 19);
            this.rbRSYes.TabIndex = 6;
            this.rbRSYes.TabStop = true;
            this.rbRSYes.Text = "Да";
            this.rbRSYes.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.lblFileName);
            this.groupBox4.Controls.Add(this.lblFramesCounter);
            this.groupBox4.Controls.Add(this.btnStartDecode);
            this.groupBox4.Controls.Add(this.btnStopDecode);
            this.groupBox4.Location = new System.Drawing.Point(0, 30);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(242, 134);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(10, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 15);
            this.label12.TabIndex = 10;
            this.label12.Text = "Кол-во кадров:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(10, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 15);
            this.label11.TabIndex = 9;
            this.label11.Text = "Имя файла:";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFileName.Location = new System.Drawing.Point(91, 89);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(103, 15);
            this.lblFileName.TabIndex = 7;
            this.lblFileName.Text = "Файл не выбран";
            // 
            // lblFramesCounter
            // 
            this.lblFramesCounter.AutoSize = true;
            this.lblFramesCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFramesCounter.Location = new System.Drawing.Point(110, 105);
            this.lblFramesCounter.Name = "lblFramesCounter";
            this.lblFramesCounter.Size = new System.Drawing.Size(14, 15);
            this.lblFramesCounter.TabIndex = 3;
            this.lblFramesCounter.Text = "0";
            // 
            // btnStartDecode
            // 
            this.btnStartDecode.BackColor = System.Drawing.SystemColors.Control;
            this.btnStartDecode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStartDecode.BackgroundImage")));
            this.btnStartDecode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartDecode.Enabled = false;
            this.btnStartDecode.Location = new System.Drawing.Point(51, 19);
            this.btnStartDecode.Name = "btnStartDecode";
            this.btnStartDecode.Size = new System.Drawing.Size(56, 52);
            this.btnStartDecode.TabIndex = 0;
            this.btnStartDecode.UseVisualStyleBackColor = false;
            this.btnStartDecode.Click += new System.EventHandler(this.btnStartDecode_Click);
            // 
            // btnStopDecode
            // 
            this.btnStopDecode.BackColor = System.Drawing.SystemColors.Control;
            this.btnStopDecode.BackgroundImage = global::ReceivingStation.Properties.Resources.stop_icon;
            this.btnStopDecode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStopDecode.Enabled = false;
            this.btnStopDecode.Location = new System.Drawing.Point(122, 19);
            this.btnStopDecode.Name = "btnStopDecode";
            this.btnStopDecode.Size = new System.Drawing.Size(59, 52);
            this.btnStopDecode.TabIndex = 1;
            this.btnStopDecode.UseVisualStyleBackColor = false;
            this.btnStopDecode.Click += new System.EventHandler(this.btnStopDecode_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 756);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnlScroll);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1204, 795);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Приемная станция";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
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
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlScroll.ResumeLayout(false);
            this.pnlScroll.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.collapsiblePanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbFCP.ResumeLayout(false);
            this.gbFCP.PerformLayout();
            this.gbInterlivingReceive.ResumeLayout(false);
            this.gbInterlivingReceive.PerformLayout();
            this.gbPRD.ResumeLayout(false);
            this.gbPRD.PerformLayout();
            this.gbFreq.ResumeLayout(false);
            this.gbFreq.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.collapsiblePanel2.ResumeLayout(false);
            this.gbDecodeParameters.ResumeLayout(false);
            this.gbNRZ.ResumeLayout(false);
            this.gbNRZ.PerformLayout();
            this.gbRS.ResumeLayout(false);
            this.gbRS.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slTime;
        private System.Windows.Forms.ToolStripStatusLabel slMode;
        private System.Windows.Forms.GroupBox gbFreq;
        private System.Windows.Forms.RadioButton rbFreq2;
        private System.Windows.Forms.RadioButton rbFreq1;
        private System.Windows.Forms.GroupBox gbFCP;
        private System.Windows.Forms.RadioButton rbFCPReserve;
        private System.Windows.Forms.RadioButton rbFCPMain;
        private System.Windows.Forms.GroupBox gbPRD;
        private System.Windows.Forms.RadioButton rbPRDReserve;
        private System.Windows.Forms.RadioButton rbPRDMain;
        private System.Windows.Forms.GroupBox gbInterlivingReceive;
        private System.Windows.Forms.RadioButton rbInterlivingReceiveOn;
        private System.Windows.Forms.RadioButton rbInterlivingReceiveOff;
        private System.Windows.Forms.GroupBox gbNRZ;
        private System.Windows.Forms.RadioButton rbNRZNo;
        private System.Windows.Forms.RadioButton rbNRZYes;
        private System.Windows.Forms.GroupBox gbRS;
        private System.Windows.Forms.RadioButton rbRSNo;
        private System.Windows.Forms.RadioButton rbRSYes;
        private System.Windows.Forms.ToolStripMenuItem управлениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem начатьПриемToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem остановитьПриемToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiStartDecoding;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.Button btnStopDecode;
        private System.Windows.Forms.Button btnStartDecode;
        private System.Windows.Forms.Button btnStopRecieve;
        private CollapsiblePanel.CollapsiblePanel collapsiblePanel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private CollapsiblePanel.CollapsiblePanel collapsiblePanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbDecodeParameters;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblFramesCounter;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem tsmiStopDecoding;
        private System.Windows.Forms.ToolStripStatusLabel slWorkingTimeSystem;
        private System.Windows.Forms.Button btnStartRecieve;
        private Other.DoubleBufferedPanel pACChannel1;
        private Other.DoubleBufferedPanel pACChannel2;
        private Other.DoubleBufferedPanel pACChannel3;
        private Other.DoubleBufferedPanel pACChannel4;
        private Other.DoubleBufferedPanel pACChannel5;
        private Other.DoubleBufferedPanel pACChannel6;
        private Other.DoubleBufferedPanel pChannel1;
        private Other.DoubleBufferedPanel pChannel2;
        private System.Windows.Forms.ToolStripStatusLabel slWorkingTimeKPA;
        private Other.DoubleBufferedPanel pChannel3;
        private Other.DoubleBufferedPanel pChannel4;
        private Other.DoubleBufferedPanel pChannel5;
        private Other.DoubleBufferedPanel pChannel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}

