namespace MtX.Nro2Nsp
{
    partial class SettingsMenu
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
            this.CustomDevClick = new System.Windows.Forms.CheckBox();
            this.CustomAuthorClick = new System.Windows.Forms.CheckBox();
            this.RollingIdClick = new System.Windows.Forms.CheckBox();
            this.PerserveDataClick = new System.Windows.Forms.CheckBox();
            this.CustomDevkitBox = new System.Windows.Forms.TextBox();
            this.CustomAuthorBox = new System.Windows.Forms.TextBox();
            this.RollingIdBox = new System.Windows.Forms.TextBox();
            this.PerserveDataBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SettingSaveButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.OldKeyBox = new System.Windows.Forms.TextBox();
            this.OldKeyCheck = new System.Windows.Forms.CheckBox();
            this.SettingCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CustomDevClick
            // 
            this.CustomDevClick.AutoSize = true;
            this.CustomDevClick.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
            this.CustomDevClick.Location = new System.Drawing.Point(179, 17);
            this.CustomDevClick.Name = "CustomDevClick";
            this.CustomDevClick.Size = new System.Drawing.Size(15, 14);
            this.CustomDevClick.TabIndex = 0;
            this.CustomDevClick.UseVisualStyleBackColor = true;
            this.CustomDevClick.CheckedChanged += new System.EventHandler(this.CustomDevClick_CheckedChanged);
            this.CustomDevClick.Click += new System.EventHandler(this.CustomDevkitClick);
            // 
            // CustomAuthorClick
            // 
            this.CustomAuthorClick.AutoSize = true;
            this.CustomAuthorClick.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
            this.CustomAuthorClick.Location = new System.Drawing.Point(179, 61);
            this.CustomAuthorClick.Name = "CustomAuthorClick";
            this.CustomAuthorClick.Size = new System.Drawing.Size(15, 14);
            this.CustomAuthorClick.TabIndex = 1;
            this.CustomAuthorClick.UseVisualStyleBackColor = true;
            this.CustomAuthorClick.CheckedChanged += new System.EventHandler(this.CustomAuthorClick_CheckedChanged);
            // 
            // RollingIdClick
            // 
            this.RollingIdClick.AutoSize = true;
            this.RollingIdClick.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
            this.RollingIdClick.Location = new System.Drawing.Point(179, 106);
            this.RollingIdClick.Name = "RollingIdClick";
            this.RollingIdClick.Size = new System.Drawing.Size(15, 14);
            this.RollingIdClick.TabIndex = 2;
            this.RollingIdClick.UseVisualStyleBackColor = true;
            this.RollingIdClick.CheckedChanged += new System.EventHandler(this.RollingIdClick_CheckedChanged);
            // 
            // PerserveDataClick
            // 
            this.PerserveDataClick.AutoSize = true;
            this.PerserveDataClick.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
            this.PerserveDataClick.Location = new System.Drawing.Point(179, 152);
            this.PerserveDataClick.Name = "PerserveDataClick";
            this.PerserveDataClick.Size = new System.Drawing.Size(15, 14);
            this.PerserveDataClick.TabIndex = 3;
            this.PerserveDataClick.UseVisualStyleBackColor = true;
            this.PerserveDataClick.CheckedChanged += new System.EventHandler(this.PerserveDataClick_CheckedChanged);
            // 
            // CustomDevkitBox
            // 
            this.CustomDevkitBox.Enabled = false;
            this.CustomDevkitBox.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Italic);
            this.CustomDevkitBox.Location = new System.Drawing.Point(211, 12);
            this.CustomDevkitBox.Name = "CustomDevkitBox";
            this.CustomDevkitBox.Size = new System.Drawing.Size(255, 25);
            this.CustomDevkitBox.TabIndex = 4;
            this.CustomDevkitBox.Text = "Set Custom DevkitPro Location";
            this.CustomDevkitBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CustomAuthorBox
            // 
            this.CustomAuthorBox.Enabled = false;
            this.CustomAuthorBox.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Italic);
            this.CustomAuthorBox.Location = new System.Drawing.Point(211, 55);
            this.CustomAuthorBox.Name = "CustomAuthorBox";
            this.CustomAuthorBox.Size = new System.Drawing.Size(255, 25);
            this.CustomAuthorBox.TabIndex = 5;
            this.CustomAuthorBox.Text = "Set Default Author to Speed Things Up";
            this.CustomAuthorBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RollingIdBox
            // 
            this.RollingIdBox.Enabled = false;
            this.RollingIdBox.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Italic);
            this.RollingIdBox.Location = new System.Drawing.Point(211, 101);
            this.RollingIdBox.Name = "RollingIdBox";
            this.RollingIdBox.ShortcutsEnabled = false;
            this.RollingIdBox.Size = new System.Drawing.Size(255, 25);
            this.RollingIdBox.TabIndex = 6;
            this.RollingIdBox.Text = "Set Base Title Id, Will Auto Increment";
            this.RollingIdBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RollingIdBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Input_Restrict);
            // 
            // PerserveDataBox
            // 
            this.PerserveDataBox.Enabled = false;
            this.PerserveDataBox.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Italic);
            this.PerserveDataBox.Location = new System.Drawing.Point(211, 146);
            this.PerserveDataBox.Name = "PerserveDataBox";
            this.PerserveDataBox.Size = new System.Drawing.Size(255, 25);
            this.PerserveDataBox.TabIndex = 7;
            this.PerserveDataBox.Text = "Saves Nca, Exefs, and Control Data";
            this.PerserveDataBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Custom Devkitpro Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(70, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Preset Author";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(65, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Rolling Title Id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(69, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Perserve Data";
            // 
            // SettingSaveButton
            // 
            this.SettingSaveButton.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SettingSaveButton.ForeColor = System.Drawing.Color.Black;
            this.SettingSaveButton.Location = new System.Drawing.Point(145, 230);
            this.SettingSaveButton.Name = "SettingSaveButton";
            this.SettingSaveButton.Size = new System.Drawing.Size(75, 27);
            this.SettingSaveButton.TabIndex = 12;
            this.SettingSaveButton.Text = "Save";
            this.SettingSaveButton.UseVisualStyleBackColor = true;
            this.SettingSaveButton.Click += new System.EventHandler(this.SettingSaveButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(46, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Old T-Key Format";
            // 
            // OldKeyBox
            // 
            this.OldKeyBox.Enabled = false;
            this.OldKeyBox.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Italic);
            this.OldKeyBox.Location = new System.Drawing.Point(211, 189);
            this.OldKeyBox.Name = "OldKeyBox";
            this.OldKeyBox.Size = new System.Drawing.Size(255, 25);
            this.OldKeyBox.TabIndex = 14;
            this.OldKeyBox.Text = "Old Style T-Key 05XXXXXXXXXXXXXXXX";
            this.OldKeyBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OldKeyCheck
            // 
            this.OldKeyCheck.AutoSize = true;
            this.OldKeyCheck.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
            this.OldKeyCheck.Location = new System.Drawing.Point(179, 195);
            this.OldKeyCheck.Name = "OldKeyCheck";
            this.OldKeyCheck.Size = new System.Drawing.Size(15, 14);
            this.OldKeyCheck.TabIndex = 13;
            this.OldKeyCheck.UseVisualStyleBackColor = true;
            this.OldKeyCheck.CheckedChanged += new System.EventHandler(this.OldKeyClick_Checked);
            // 
            // SettingCancelButton
            // 
            this.SettingCancelButton.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SettingCancelButton.ForeColor = System.Drawing.Color.Black;
            this.SettingCancelButton.Location = new System.Drawing.Point(226, 230);
            this.SettingCancelButton.Name = "SettingCancelButton";
            this.SettingCancelButton.Size = new System.Drawing.Size(75, 27);
            this.SettingCancelButton.TabIndex = 16;
            this.SettingCancelButton.Text = "Cancel";
            this.SettingCancelButton.UseVisualStyleBackColor = true;
            this.SettingCancelButton.Click += new System.EventHandler(this.SettingCancelButton_Click);
            // 
            // SettingsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(495, 269);
            this.Controls.Add(this.SettingCancelButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OldKeyBox);
            this.Controls.Add(this.OldKeyCheck);
            this.Controls.Add(this.SettingSaveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PerserveDataBox);
            this.Controls.Add(this.RollingIdBox);
            this.Controls.Add(this.CustomAuthorBox);
            this.Controls.Add(this.CustomDevkitBox);
            this.Controls.Add(this.PerserveDataClick);
            this.Controls.Add(this.RollingIdClick);
            this.Controls.Add(this.CustomAuthorClick);
            this.Controls.Add(this.CustomDevClick);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsMenu";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CustomDevClick;
        private System.Windows.Forms.CheckBox CustomAuthorClick;
        private System.Windows.Forms.CheckBox RollingIdClick;
        private System.Windows.Forms.CheckBox PerserveDataClick;
        private System.Windows.Forms.TextBox CustomDevkitBox;
        private System.Windows.Forms.TextBox CustomAuthorBox;
        private System.Windows.Forms.TextBox RollingIdBox;
        private System.Windows.Forms.TextBox PerserveDataBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SettingSaveButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox OldKeyBox;
        private System.Windows.Forms.CheckBox OldKeyCheck;
        private System.Windows.Forms.Button SettingCancelButton;
    }
}