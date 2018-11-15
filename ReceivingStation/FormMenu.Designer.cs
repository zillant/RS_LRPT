namespace ReceivingStation
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelfTest = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnReceive = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnDecode = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnSelfTest, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnReceive, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDecode, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 59);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(311, 451);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnSelfTest
            // 
            this.btnSelfTest.AutoSize = true;
            this.btnSelfTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSelfTest.Depth = 0;
            this.btnSelfTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelfTest.Location = new System.Drawing.Point(4, 6);
            this.btnSelfTest.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSelfTest.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSelfTest.Name = "btnSelfTest";
            this.btnSelfTest.Primary = false;
            this.btnSelfTest.Size = new System.Drawing.Size(303, 138);
            this.btnSelfTest.TabIndex = 0;
            this.btnSelfTest.Text = "Самопроверка";
            this.btnSelfTest.UseVisualStyleBackColor = true;
            // 
            // btnReceive
            // 
            this.btnReceive.AutoSize = true;
            this.btnReceive.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReceive.Depth = 0;
            this.btnReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReceive.Location = new System.Drawing.Point(4, 156);
            this.btnReceive.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReceive.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Primary = false;
            this.btnReceive.Size = new System.Drawing.Size(303, 138);
            this.btnReceive.TabIndex = 1;
            this.btnReceive.Text = "Прием";
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.AutoSize = true;
            this.btnDecode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDecode.Depth = 0;
            this.btnDecode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDecode.Location = new System.Drawing.Point(4, 306);
            this.btnDecode.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDecode.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Primary = false;
            this.btnDecode.Size = new System.Drawing.Size(303, 139);
            this.btnDecode.TabIndex = 2;
            this.btnDecode.Text = "Декодирование";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
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
            this.materialDivider1.TabIndex = 1;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.ClientSize = new System.Drawing.Size(311, 510);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.materialDivider1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Приемная станция";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialFlatButton btnSelfTest;
        private MaterialSkin.Controls.MaterialFlatButton btnReceive;
        private MaterialSkin.Controls.MaterialFlatButton btnDecode;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
    }
}