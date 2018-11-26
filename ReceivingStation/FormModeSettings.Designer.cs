namespace ReceivingStation
{
    partial class FormModeSettings
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
            this.btnChangeLocalMode = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnServerSettings = new MaterialSkin.Controls.MaterialFlatButton();
            this.lblConnection = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // btnChangeLocalMode
            // 
            this.btnChangeLocalMode.Depth = 0;
            this.btnChangeLocalMode.Location = new System.Drawing.Point(211, 120);
            this.btnChangeLocalMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnChangeLocalMode.Name = "btnChangeLocalMode";
            this.btnChangeLocalMode.Primary = true;
            this.btnChangeLocalMode.Size = new System.Drawing.Size(124, 36);
            this.btnChangeLocalMode.TabIndex = 0;
            this.btnChangeLocalMode.Text = "Перейти в режим МУ";
            this.btnChangeLocalMode.UseVisualStyleBackColor = true;
            this.btnChangeLocalMode.Click += new System.EventHandler(this.btnChangeLocalMode_Click);
            // 
            // btnServerSettings
            // 
            this.btnServerSettings.AutoSize = true;
            this.btnServerSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnServerSettings.Depth = 0;
            this.btnServerSettings.Location = new System.Drawing.Point(13, 120);
            this.btnServerSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnServerSettings.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnServerSettings.Name = "btnServerSettings";
            this.btnServerSettings.Primary = false;
            this.btnServerSettings.Size = new System.Drawing.Size(158, 36);
            this.btnServerSettings.TabIndex = 1;
            this.btnServerSettings.Text = "Настройки сервера";
            this.btnServerSettings.UseVisualStyleBackColor = true;
            this.btnServerSettings.Click += new System.EventHandler(this.btnServerSettings_Click);
            // 
            // lblConnection
            // 
            this.lblConnection.BackColor = System.Drawing.SystemColors.Window;
            this.lblConnection.Depth = 0;
            this.lblConnection.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConnection.Location = new System.Drawing.Point(12, 74);
            this.lblConnection.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(324, 31);
            this.lblConnection.TabIndex = 2;
            this.lblConnection.Text = "Режим: Местное управление";
            this.lblConnection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormModeSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 176);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.btnServerSettings);
            this.Controls.Add(this.btnChangeLocalMode);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(442, 235);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(342, 135);
            this.Name = "FormModeSettings";
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btnChangeLocalMode;
        private MaterialSkin.Controls.MaterialFlatButton btnServerSettings;
        private MaterialSkin.Controls.MaterialLabel lblConnection;
    }
}