namespace ReceivingStation
{
    partial class FormSelfTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelfTest));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.doubleBufferedPanel2 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.doubleBufferedPanel4 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbInterlivingReceiveOff = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbInterlivingReceiveOn = new MaterialSkin.Controls.MaterialRadioButton();
            this.lblInterliving = new MaterialSkin.Controls.MaterialLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbFreq2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbFreq1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.lblFreq = new MaterialSkin.Controls.MaterialLabel();
            this.rtbTestServer = new ReceivingStation.Other.DisabledRichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbRandomSending = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbSequentialSending = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.doubleBufferedPanel1 = new ReceivingStation.Other.DoubleBufferedPanel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.lblSelfTestingDate = new MaterialSkin.Controls.MaterialLabel();
            this.lblSelfTestingServerDate = new MaterialSkin.Controls.MaterialLabel();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.doubleBufferedPanel2.SuspendLayout();
            this.doubleBufferedPanel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.doubleBufferedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 745);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(600, 25);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slTime
            // 
            this.slTime.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.slTime.Image = global::ReceivingStation.Properties.Resources.time_icon;
            this.slTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.slTime.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.slTime.Name = "slTime";
            this.slTime.Size = new System.Drawing.Size(583, 20);
            this.slTime.Spring = true;
            this.slTime.Text = "01/01/1668 12:12:01";
            this.slTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.slTime.ToolTipText = "Дата/Время";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.materialDivider1.TabIndex = 27;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.37584F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.62416F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel3.Controls.Add(this.doubleBufferedPanel2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.rtbTestServer, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.doubleBufferedPanel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox1, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 59);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 572F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(600, 686);
            this.tableLayoutPanel3.TabIndex = 46;
            // 
            // doubleBufferedPanel2
            // 
            this.doubleBufferedPanel2.Controls.Add(this.doubleBufferedPanel4);
            this.doubleBufferedPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferedPanel2.Location = new System.Drawing.Point(3, 117);
            this.doubleBufferedPanel2.Name = "doubleBufferedPanel2";
            this.doubleBufferedPanel2.Size = new System.Drawing.Size(265, 566);
            this.doubleBufferedPanel2.TabIndex = 58;
            // 
            // doubleBufferedPanel4
            // 
            this.doubleBufferedPanel4.Controls.Add(this.panel1);
            this.doubleBufferedPanel4.Controls.Add(this.materialRaisedButton1);
            this.doubleBufferedPanel4.Controls.Add(this.materialRaisedButton2);
            this.doubleBufferedPanel4.Controls.Add(this.panel2);
            this.doubleBufferedPanel4.Controls.Add(this.panel3);
            this.doubleBufferedPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferedPanel4.Location = new System.Drawing.Point(0, 0);
            this.doubleBufferedPanel4.Name = "doubleBufferedPanel4";
            this.doubleBufferedPanel4.Size = new System.Drawing.Size(265, 566);
            this.doubleBufferedPanel4.TabIndex = 62;
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(3, 431);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(188, 67);
            this.materialRaisedButton1.TabIndex = 45;
            this.materialRaisedButton1.Text = "Начать  самопроверку сервера";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Location = new System.Drawing.Point(3, 198);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(188, 67);
            this.materialRaisedButton2.TabIndex = 45;
            this.materialRaisedButton2.Text = "Начать самопроверку ";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.rbInterlivingReceiveOff);
            this.panel2.Controls.Add(this.rbInterlivingReceiveOn);
            this.panel2.Controls.Add(this.lblInterliving);
            this.panel2.Location = new System.Drawing.Point(3, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(188, 93);
            this.panel2.TabIndex = 59;
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
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.rbFreq2);
            this.panel3.Controls.Add(this.rbFreq1);
            this.panel3.Controls.Add(this.lblFreq);
            this.panel3.Location = new System.Drawing.Point(3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(188, 93);
            this.panel3.TabIndex = 60;
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
            // rtbTestServer
            // 
            this.rtbTestServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.rtbTestServer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel3.SetColumnSpan(this.rtbTestServer, 2);
            this.rtbTestServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbTestServer.Location = new System.Drawing.Point(277, 117);
            this.rtbTestServer.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.rtbTestServer.Name = "rtbTestServer";
            this.rtbTestServer.Size = new System.Drawing.Size(317, 563);
            this.rtbTestServer.TabIndex = 57;
            this.rtbTestServer.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::ReceivingStation.Properties.Resources.rss_logo;
            this.pictureBox1.Location = new System.Drawing.Point(486, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.rbRandomSending);
            this.panel1.Controls.Add(this.rbSequentialSending);
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Location = new System.Drawing.Point(3, 332);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 93);
            this.panel1.TabIndex = 61;
            // 
            // rbRandomSending
            // 
            this.rbRandomSending.AutoSize = true;
            this.rbRandomSending.Depth = 0;
            this.rbRandomSending.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbRandomSending.Location = new System.Drawing.Point(7, 62);
            this.rbRandomSending.Margin = new System.Windows.Forms.Padding(0);
            this.rbRandomSending.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbRandomSending.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbRandomSending.Name = "rbRandomSending";
            this.rbRandomSending.Ripple = true;
            this.rbRandomSending.Size = new System.Drawing.Size(102, 30);
            this.rbRandomSending.TabIndex = 45;
            this.rbRandomSending.Text = "Случайный";
            this.rbRandomSending.UseVisualStyleBackColor = true;
            // 
            // rbSequentialSending
            // 
            this.rbSequentialSending.AutoSize = true;
            this.rbSequentialSending.Checked = true;
            this.rbSequentialSending.Depth = 0;
            this.rbSequentialSending.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbSequentialSending.Location = new System.Drawing.Point(7, 30);
            this.rbSequentialSending.Margin = new System.Windows.Forms.Padding(0);
            this.rbSequentialSending.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbSequentialSending.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbSequentialSending.Name = "rbSequentialSending";
            this.rbSequentialSending.Ripple = true;
            this.rbSequentialSending.Size = new System.Drawing.Size(157, 30);
            this.rbSequentialSending.TabIndex = 44;
            this.rbSequentialSending.TabStop = true;
            this.rbSequentialSending.Text = "Последовательный";
            this.rbSequentialSending.UseVisualStyleBackColor = true;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(3, 6);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(182, 19);
            this.materialLabel1.TabIndex = 38;
            this.materialLabel1.Text = "Порядок отправки КМС";
            // 
            // doubleBufferedPanel1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.doubleBufferedPanel1, 2);
            this.doubleBufferedPanel1.Controls.Add(this.lblSelfTestingServerDate);
            this.doubleBufferedPanel1.Controls.Add(this.lblSelfTestingDate);
            this.doubleBufferedPanel1.Controls.Add(this.materialLabel3);
            this.doubleBufferedPanel1.Controls.Add(this.materialLabel2);
            this.doubleBufferedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferedPanel1.Location = new System.Drawing.Point(3, 3);
            this.doubleBufferedPanel1.Name = "doubleBufferedPanel1";
            this.doubleBufferedPanel1.Size = new System.Drawing.Size(475, 108);
            this.doubleBufferedPanel1.TabIndex = 59;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(9, 22);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(236, 19);
            this.materialLabel2.TabIndex = 0;
            this.materialLabel2.Text = "Последняя дата самопроверки:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(9, 60);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(297, 19);
            this.materialLabel3.TabIndex = 1;
            this.materialLabel3.Text = "Последняя дата самопроверки сервера:";
            // 
            // lblSelfTestingDate
            // 
            this.lblSelfTestingDate.AutoSize = true;
            this.lblSelfTestingDate.Depth = 0;
            this.lblSelfTestingDate.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblSelfTestingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSelfTestingDate.Location = new System.Drawing.Point(312, 22);
            this.lblSelfTestingDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSelfTestingDate.Name = "lblSelfTestingDate";
            this.lblSelfTestingDate.Size = new System.Drawing.Size(77, 19);
            this.lblSelfTestingDate.TabIndex = 2;
            this.lblSelfTestingDate.Text = "0.0.0 0:0:0";
            // 
            // lblSelfTestingServerDate
            // 
            this.lblSelfTestingServerDate.AutoSize = true;
            this.lblSelfTestingServerDate.Depth = 0;
            this.lblSelfTestingServerDate.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblSelfTestingServerDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSelfTestingServerDate.Location = new System.Drawing.Point(312, 60);
            this.lblSelfTestingServerDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSelfTestingServerDate.Name = "lblSelfTestingServerDate";
            this.lblSelfTestingServerDate.Size = new System.Drawing.Size(77, 19);
            this.lblSelfTestingServerDate.TabIndex = 3;
            this.lblSelfTestingServerDate.Text = "0.0.0 0:0:0";
            // 
            // FormSelfTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 770);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 770);
            this.Name = "FormSelfTest";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Приемная станция: Самопроверка";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSelfTest_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSelfTest_FormClosed);
            this.Load += new System.EventHandler(this.FormSelfTest_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.doubleBufferedPanel2.ResumeLayout(false);
            this.doubleBufferedPanel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.doubleBufferedPanel1.ResumeLayout(false);
            this.doubleBufferedPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slTime;
        private System.Windows.Forms.Timer timer1;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private Other.DisabledRichTextBox rtbTestServer;
        private Other.DoubleBufferedPanel doubleBufferedPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialRadioButton rbFreq2;
        private MaterialSkin.Controls.MaterialRadioButton rbFreq1;
        private MaterialSkin.Controls.MaterialLabel lblFreq;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialRadioButton rbInterlivingReceiveOff;
        private MaterialSkin.Controls.MaterialRadioButton rbInterlivingReceiveOn;
        private MaterialSkin.Controls.MaterialLabel lblInterliving;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
        private Other.DoubleBufferedPanel doubleBufferedPanel4;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialRadioButton rbRandomSending;
        private MaterialSkin.Controls.MaterialRadioButton rbSequentialSending;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Other.DoubleBufferedPanel doubleBufferedPanel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel lblSelfTestingServerDate;
        private MaterialSkin.Controls.MaterialLabel lblSelfTestingDate;
    }
}