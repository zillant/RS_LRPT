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
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblRemoteMode = new MaterialSkin.Controls.MaterialLabel();
            this.lblSetParameters = new MaterialSkin.Controls.MaterialLabel();
            this.lblStartReceive = new MaterialSkin.Controls.MaterialLabel();
            this.lblStopReceive = new MaterialSkin.Controls.MaterialLabel();
            this.lblLocalMode = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 770);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(1556, 25);
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
            this.slTime.Size = new System.Drawing.Size(1539, 20);
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
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel3.Controls.Add(this.panel6, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 59);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1556, 114);
            this.tableLayoutPanel3.TabIndex = 46;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Window;
            this.panel6.Controls.Add(this.tableLayoutPanel5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(858, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(695, 108);
            this.panel6.TabIndex = 44;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.45324F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.54676F));
            this.tableLayoutPanel5.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(695, 108);
            this.tableLayoutPanel5.TabIndex = 45;
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
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(39, 201);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(159, 57);
            this.materialRaisedButton1.TabIndex = 45;
            this.materialRaisedButton1.Text = "Начать локальный тест сервера";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // lblRemoteMode
            // 
            this.lblRemoteMode.AutoSize = true;
            this.lblRemoteMode.BackColor = System.Drawing.SystemColors.Window;
            this.lblRemoteMode.Depth = 0;
            this.lblRemoteMode.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblRemoteMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRemoteMode.Location = new System.Drawing.Point(337, 278);
            this.lblRemoteMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRemoteMode.Name = "lblRemoteMode";
            this.lblRemoteMode.Size = new System.Drawing.Size(108, 19);
            this.lblRemoteMode.TabIndex = 47;
            this.lblRemoteMode.Text = "materialLabel1";
            // 
            // lblSetParameters
            // 
            this.lblSetParameters.AutoSize = true;
            this.lblSetParameters.BackColor = System.Drawing.SystemColors.Window;
            this.lblSetParameters.Depth = 0;
            this.lblSetParameters.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblSetParameters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSetParameters.Location = new System.Drawing.Point(337, 312);
            this.lblSetParameters.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSetParameters.Name = "lblSetParameters";
            this.lblSetParameters.Size = new System.Drawing.Size(108, 19);
            this.lblSetParameters.TabIndex = 48;
            this.lblSetParameters.Text = "materialLabel2";
            // 
            // lblStartReceive
            // 
            this.lblStartReceive.AutoSize = true;
            this.lblStartReceive.BackColor = System.Drawing.SystemColors.Window;
            this.lblStartReceive.Depth = 0;
            this.lblStartReceive.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblStartReceive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStartReceive.Location = new System.Drawing.Point(337, 346);
            this.lblStartReceive.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStartReceive.Name = "lblStartReceive";
            this.lblStartReceive.Size = new System.Drawing.Size(108, 19);
            this.lblStartReceive.TabIndex = 49;
            this.lblStartReceive.Text = "materialLabel3";
            // 
            // lblStopReceive
            // 
            this.lblStopReceive.AutoSize = true;
            this.lblStopReceive.BackColor = System.Drawing.SystemColors.Window;
            this.lblStopReceive.Depth = 0;
            this.lblStopReceive.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblStopReceive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStopReceive.Location = new System.Drawing.Point(337, 380);
            this.lblStopReceive.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStopReceive.Name = "lblStopReceive";
            this.lblStopReceive.Size = new System.Drawing.Size(108, 19);
            this.lblStopReceive.TabIndex = 50;
            this.lblStopReceive.Text = "materialLabel4";
            // 
            // lblLocalMode
            // 
            this.lblLocalMode.AutoSize = true;
            this.lblLocalMode.BackColor = System.Drawing.SystemColors.Window;
            this.lblLocalMode.Depth = 0;
            this.lblLocalMode.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblLocalMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblLocalMode.Location = new System.Drawing.Point(337, 415);
            this.lblLocalMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblLocalMode.Name = "lblLocalMode";
            this.lblLocalMode.Size = new System.Drawing.Size(108, 19);
            this.lblLocalMode.TabIndex = 51;
            this.lblLocalMode.Text = "materialLabel1";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(41, 415);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(238, 19);
            this.materialLabel1.TabIndex = 56;
            this.materialLabel1.Text = "Переход в местное управление:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(41, 380);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(146, 19);
            this.materialLabel2.TabIndex = 55;
            this.materialLabel2.Text = "Остановить прием:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(41, 346);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(112, 19);
            this.materialLabel3.TabIndex = 54;
            this.materialLabel3.Text = "Начать прием:";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(41, 312);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(210, 19);
            this.materialLabel4.TabIndex = 53;
            this.materialLabel4.Text = "Установленные параметры:";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(41, 278);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(290, 19);
            this.materialLabel5.TabIndex = 52;
            this.materialLabel5.Text = "Переход в дистанционное управление:";
            // 
            // FormSelfTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 795);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.lblLocalMode);
            this.Controls.Add(this.lblStopReceive);
            this.Controls.Add(this.lblStartReceive);
            this.Controls.Add(this.lblSetParameters);
            this.Controls.Add(this.lblRemoteMode);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1556, 795);
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
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slTime;
        private System.Windows.Forms.Timer timer1;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialLabel lblRemoteMode;
        private MaterialSkin.Controls.MaterialLabel lblSetParameters;
        private MaterialSkin.Controls.MaterialLabel lblStartReceive;
        private MaterialSkin.Controls.MaterialLabel lblStopReceive;
        private MaterialSkin.Controls.MaterialLabel lblLocalMode;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
    }
}