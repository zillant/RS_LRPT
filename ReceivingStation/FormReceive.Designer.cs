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
            this.rtbMkoData = new ReceivingStation.Other.DisabledRichTextBox();
            this.rtbMkoTitle = new ReceivingStation.Other.DisabledRichTextBox();
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
            this.rbFCPReserve = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbFCPMain = new MaterialSkin.Controls.MaterialRadioButton();
            this.lblFCP = new MaterialSkin.Controls.MaterialLabel();
            this.pModulation = new ReceivingStation.Other.DoubleBufferedPanel();
            this.rbQpsk = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbOqpsk = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.doubleBufferedPanel1 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.rtbDateTimeTitle = new ReceivingStation.Other.DisabledRichTextBox();
            this.rtbDateTime = new ReceivingStation.Other.DisabledRichTextBox();
            this.DemOnlbl = new MaterialSkin.Controls.MaterialLabel();
            this.DongOnlbl = new MaterialSkin.Controls.MaterialLabel();
            this.SignDetectlbl = new MaterialSkin.Controls.MaterialLabel();
            this.LockOnlbl = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.tlp1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tlpReceivingParameters.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pModulation.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.doubleBufferedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Window;
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
            this.slTime.Size = new System.Drawing.Size(694, 20);
            this.slTime.Spring = true;
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
            this.slWorkingTimeOnboard.Size = new System.Drawing.Size(148, 20);
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
            this.slMode.Size = new System.Drawing.Size(696, 20);
            this.slMode.Spring = true;
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
            this.materialTabControl1.Location = new System.Drawing.Point(0, 213);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1556, 557);
            this.materialTabControl1.TabIndex = 36;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pImage1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1548, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Канал 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pImage1
            // 
            this.pImage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pImage1.Location = new System.Drawing.Point(3, 3);
            this.pImage1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pImage1.Name = "pImage1";
            this.pImage1.Size = new System.Drawing.Size(1542, 525);
            this.pImage1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pImage2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1548, 531);
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
            this.pImage2.Size = new System.Drawing.Size(1542, 525);
            this.pImage2.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pImage3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1548, 531);
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
            this.pImage3.Size = new System.Drawing.Size(1542, 525);
            this.pImage3.TabIndex = 4;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pImage4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1548, 531);
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
            this.pImage4.Size = new System.Drawing.Size(1542, 525);
            this.pImage4.TabIndex = 4;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.pImage5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1548, 531);
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
            this.pImage5.Size = new System.Drawing.Size(1542, 525);
            this.pImage5.TabIndex = 4;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.pImage6);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1548, 531);
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
            this.pImage6.Size = new System.Drawing.Size(1542, 525);
            this.pImage6.TabIndex = 4;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.tableLayoutPanel1);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1548, 531);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1542, 525);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // materialLabel3
            // 
            this.materialLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(95, 4);
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
            this.materialLabel1.Location = new System.Drawing.Point(351, 4);
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
            this.materialLabel6.Location = new System.Drawing.Point(607, 4);
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
            this.pImage7.Size = new System.Drawing.Size(236, 492);
            this.pImage7.TabIndex = 0;
            // 
            // materialLabel2
            // 
            this.materialLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(863, 4);
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
            this.materialLabel5.Location = new System.Drawing.Point(1119, 4);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(65, 19);
            this.materialLabel5.TabIndex = 10;
            this.materialLabel5.Text = "Канал 5";
            // 
            // pImage8
            // 
            this.pImage8.Location = new System.Drawing.Point(266, 30);
            this.pImage8.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pImage8.Name = "pImage8";
            this.pImage8.Size = new System.Drawing.Size(236, 492);
            this.pImage8.TabIndex = 1;
            // 
            // materialLabel4
            // 
            this.materialLabel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(1378, 4);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(65, 19);
            this.materialLabel4.TabIndex = 9;
            this.materialLabel4.Text = "Канал 6";
            // 
            // pImage9
            // 
            this.pImage9.Location = new System.Drawing.Point(522, 30);
            this.pImage9.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pImage9.Name = "pImage9";
            this.pImage9.Size = new System.Drawing.Size(236, 492);
            this.pImage9.TabIndex = 2;
            // 
            // pImage10
            // 
            this.pImage10.Location = new System.Drawing.Point(778, 30);
            this.pImage10.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pImage10.Name = "pImage10";
            this.pImage10.Size = new System.Drawing.Size(236, 492);
            this.pImage10.TabIndex = 3;
            // 
            // pImage11
            // 
            this.pImage11.Location = new System.Drawing.Point(1034, 30);
            this.pImage11.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pImage11.Name = "pImage11";
            this.pImage11.Size = new System.Drawing.Size(236, 492);
            this.pImage11.TabIndex = 4;
            // 
            // pImage12
            // 
            this.pImage12.Location = new System.Drawing.Point(1290, 30);
            this.pImage12.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pImage12.Name = "pImage12";
            this.pImage12.Size = new System.Drawing.Size(241, 492);
            this.pImage12.TabIndex = 5;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.rtbMkoData);
            this.tabPage8.Controls.Add(this.rtbMkoTitle);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1548, 531);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "МКО";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // rtbMkoData
            // 
            this.rtbMkoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbMkoData.Location = new System.Drawing.Point(972, 31);
            this.rtbMkoData.Name = "rtbMkoData";
            this.rtbMkoData.Size = new System.Drawing.Size(191, 475);
            this.rtbMkoData.TabIndex = 108;
            this.rtbMkoData.Text = "";
            // 
            // rtbMkoTitle
            // 
            this.rtbMkoTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbMkoTitle.Location = new System.Drawing.Point(385, 31);
            this.rtbMkoTitle.Name = "rtbMkoTitle";
            this.rtbMkoTitle.Size = new System.Drawing.Size(581, 475);
            this.rtbMkoTitle.TabIndex = 107;
            this.rtbMkoTitle.Text = "";
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 173);
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
            this.tlpReceivingParameters.ColumnCount = 5;
            this.tlpReceivingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.37063F));
            this.tlpReceivingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.73893F));
            this.tlpReceivingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.89044F));
            this.tlpReceivingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tlpReceivingParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tlpReceivingParameters.Controls.Add(this.panel7, 0, 0);
            this.tlpReceivingParameters.Controls.Add(this.panel2, 2, 0);
            this.tlpReceivingParameters.Controls.Add(this.panel3, 1, 0);
            this.tlpReceivingParameters.Controls.Add(this.panel4, 0, 0);
            this.tlpReceivingParameters.Controls.Add(this.pModulation, 4, 0);
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
            this.panel7.Location = new System.Drawing.Point(129, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(113, 102);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.rbInterlivingReceiveOff);
            this.panel2.Controls.Add(this.rbInterlivingReceiveOn);
            this.panel2.Controls.Add(this.lblInterliving);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(433, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(119, 102);
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
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.rbFreq2);
            this.panel3.Controls.Add(this.rbFreq1);
            this.panel3.Controls.Add(this.lblFreq);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(248, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(179, 102);
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
            // 
            // lblFreq
            // 
            this.lblFreq.Depth = 0;
            this.lblFreq.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFreq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFreq.Location = new System.Drawing.Point(3, 6);
            this.lblFreq.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFreq.Name = "lblFreq";
            this.lblFreq.Size = new System.Drawing.Size(174, 19);
            this.lblFreq.TabIndex = 38;
            this.lblFreq.Text = "Несущая частота (МГц)";
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Controls.Add(this.rbFCPReserve);
            this.panel4.Controls.Add(this.rbFCPMain);
            this.panel4.Controls.Add(this.lblFCP);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(120, 102);
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
            // pModulation
            // 
            this.pModulation.Controls.Add(this.rbQpsk);
            this.pModulation.Controls.Add(this.rbOqpsk);
            this.pModulation.Controls.Add(this.materialLabel7);
            this.pModulation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pModulation.Location = new System.Drawing.Point(558, 3);
            this.pModulation.Name = "pModulation";
            this.pModulation.Size = new System.Drawing.Size(130, 102);
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
            this.doubleBufferedPanel1.Controls.Add(this.rtbDateTimeTitle);
            this.doubleBufferedPanel1.Controls.Add(this.rtbDateTime);
            this.doubleBufferedPanel1.Controls.Add(this.DemOnlbl);
            this.doubleBufferedPanel1.Controls.Add(this.DongOnlbl);
            this.doubleBufferedPanel1.Controls.Add(this.SignDetectlbl);
            this.doubleBufferedPanel1.Controls.Add(this.LockOnlbl);
            this.doubleBufferedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferedPanel1.Location = new System.Drawing.Point(3, 3);
            this.doubleBufferedPanel1.Name = "doubleBufferedPanel1";
            this.doubleBufferedPanel1.Size = new System.Drawing.Size(574, 102);
            this.doubleBufferedPanel1.TabIndex = 46;
            // 
            // rtbDateTimeTitle
            // 
            this.rtbDateTimeTitle.Dock = System.Windows.Forms.DockStyle.Right;
            this.rtbDateTimeTitle.Location = new System.Drawing.Point(374, 0);
            this.rtbDateTimeTitle.Name = "rtbDateTimeTitle";
            this.rtbDateTimeTitle.Size = new System.Drawing.Size(100, 102);
            this.rtbDateTimeTitle.TabIndex = 50;
            this.rtbDateTimeTitle.Text = "";
            // 
            // rtbDateTime
            // 
            this.rtbDateTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.rtbDateTime.Location = new System.Drawing.Point(474, 0);
            this.rtbDateTime.Name = "rtbDateTime";
            this.rtbDateTime.Size = new System.Drawing.Size(100, 102);
            this.rtbDateTime.TabIndex = 49;
            this.rtbDateTime.Text = "";
            // 
            // DemOnlbl
            // 
            this.DemOnlbl.AutoSize = true;
            this.DemOnlbl.Depth = 0;
            this.DemOnlbl.Font = new System.Drawing.Font("Roboto", 11F);
            this.DemOnlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DemOnlbl.Location = new System.Drawing.Point(28, 6);
            this.DemOnlbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.DemOnlbl.Name = "DemOnlbl";
            this.DemOnlbl.Size = new System.Drawing.Size(49, 19);
            this.DemOnlbl.TabIndex = 45;
            this.DemOnlbl.Text = "label7";
            // 
            // DongOnlbl
            // 
            this.DongOnlbl.AutoSize = true;
            this.DongOnlbl.Depth = 0;
            this.DongOnlbl.Font = new System.Drawing.Font("Roboto", 11F);
            this.DongOnlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DongOnlbl.Location = new System.Drawing.Point(28, 31);
            this.DongOnlbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.DongOnlbl.Name = "DongOnlbl";
            this.DongOnlbl.Size = new System.Drawing.Size(49, 19);
            this.DongOnlbl.TabIndex = 46;
            this.DongOnlbl.Text = "label8";
            // 
            // SignDetectlbl
            // 
            this.SignDetectlbl.AutoSize = true;
            this.SignDetectlbl.Depth = 0;
            this.SignDetectlbl.Font = new System.Drawing.Font("Roboto", 11F);
            this.SignDetectlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SignDetectlbl.Location = new System.Drawing.Point(28, 82);
            this.SignDetectlbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.SignDetectlbl.Name = "SignDetectlbl";
            this.SignDetectlbl.Size = new System.Drawing.Size(57, 19);
            this.SignDetectlbl.TabIndex = 48;
            this.SignDetectlbl.Text = "label10";
            // 
            // LockOnlbl
            // 
            this.LockOnlbl.AutoSize = true;
            this.LockOnlbl.Depth = 0;
            this.LockOnlbl.Font = new System.Drawing.Font("Roboto", 11F);
            this.LockOnlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LockOnlbl.Location = new System.Drawing.Point(27, 56);
            this.LockOnlbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.LockOnlbl.Name = "LockOnlbl";
            this.LockOnlbl.Size = new System.Drawing.Size(49, 19);
            this.LockOnlbl.TabIndex = 47;
            this.LockOnlbl.Text = "label9";
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
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1556, 795);
            this.Name = "FormReceive";
            this.Sizable = false;
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
            this.pModulation.ResumeLayout(false);
            this.pModulation.PerformLayout();
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
        public MaterialSkin.Controls.MaterialLabel DemOnlbl;
        public MaterialSkin.Controls.MaterialLabel DongOnlbl;
        public MaterialSkin.Controls.MaterialLabel SignDetectlbl;
        public MaterialSkin.Controls.MaterialLabel LockOnlbl;
        private Other.DisabledRichTextBox rtbMkoData;
        private Other.DisabledRichTextBox rtbMkoTitle;
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
    }
}

