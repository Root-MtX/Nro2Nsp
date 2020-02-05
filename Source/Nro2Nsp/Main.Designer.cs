namespace MtX.Nro2Nsp
{
    partial class Nro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nro));
            this.compile_button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.sdmc_select = new System.Windows.Forms.RadioButton();
            this.romfs_select = new System.Windows.Forms.RadioButton();
            this.name_box = new System.Windows.Forms.TextBox();
            this.id_box = new System.Windows.Forms.TextBox();
            this.author_box = new System.Windows.Forms.TextBox();
            this.version_box = new System.Windows.Forms.TextBox();
            this.sdmc_path = new System.Windows.Forms.TextBox();
            this.romfs_path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.Icon_Button = new System.Windows.Forms.Button();
            this.Randomize = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // compile_button
            // 
            this.compile_button.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compile_button.Location = new System.Drawing.Point(108, 316);
            this.compile_button.Name = "compile_button";
            this.compile_button.Size = new System.Drawing.Size(93, 25);
            this.compile_button.TabIndex = 0;
            this.compile_button.Text = "Compile";
            this.compile_button.UseVisualStyleBackColor = true;
            this.compile_button.Click += new System.EventHandler(this.Compile_button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // sdmc_select
            // 
            this.sdmc_select.AutoSize = true;
            this.sdmc_select.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sdmc_select.Location = new System.Drawing.Point(19, 223);
            this.sdmc_select.Name = "sdmc_select";
            this.sdmc_select.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sdmc_select.Size = new System.Drawing.Size(83, 21);
            this.sdmc_select.TabIndex = 2;
            this.sdmc_select.TabStop = true;
            this.sdmc_select.Text = ": Sdmc    ";
            this.sdmc_select.UseVisualStyleBackColor = true;
            this.sdmc_select.CheckedChanged += new System.EventHandler(this.RadioButton_Checked);
            // 
            // romfs_select
            // 
            this.romfs_select.AutoSize = true;
            this.romfs_select.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.romfs_select.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.romfs_select.Location = new System.Drawing.Point(13, 272);
            this.romfs_select.Name = "romfs_select";
            this.romfs_select.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.romfs_select.Size = new System.Drawing.Size(89, 21);
            this.romfs_select.TabIndex = 3;
            this.romfs_select.TabStop = true;
            this.romfs_select.Text = ": Romfs    ";
            this.romfs_select.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.romfs_select.UseVisualStyleBackColor = true;
            this.romfs_select.CheckedChanged += new System.EventHandler(this.RadioButton_Checked);
            // 
            // name_box
            // 
            this.name_box.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_box.Location = new System.Drawing.Point(108, 12);
            this.name_box.Name = "name_box";
            this.name_box.Size = new System.Drawing.Size(132, 25);
            this.name_box.TabIndex = 4;
            this.name_box.Text = "App Name";
            this.name_box.Enter += new System.EventHandler(this.on_textClick_namebox);
            this.name_box.Leave += new System.EventHandler(this.leave_textClick_namebox);
            // 
            // id_box
            // 
            this.id_box.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_box.Location = new System.Drawing.Point(108, 58);
            this.id_box.Name = "id_box";
            this.id_box.Size = new System.Drawing.Size(132, 25);
            this.id_box.TabIndex = 5;
            this.id_box.Text = "05000A0000000000";
            this.id_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Input_restrict);
            // 
            // author_box
            // 
            this.author_box.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.author_box.Location = new System.Drawing.Point(108, 101);
            this.author_box.Name = "author_box";
            this.author_box.Size = new System.Drawing.Size(132, 25);
            this.author_box.TabIndex = 6;
            this.author_box.Text = "Author";
            this.author_box.Enter += new System.EventHandler(this.on_authorTextClick);
            this.author_box.Leave += new System.EventHandler(this.leave_authorTextClick);
            // 
            // version_box
            // 
            this.version_box.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version_box.Location = new System.Drawing.Point(108, 144);
            this.version_box.Name = "version_box";
            this.version_box.Size = new System.Drawing.Size(132, 25);
            this.version_box.TabIndex = 7;
            this.version_box.Text = " 1.0.0";
            // 
            // sdmc_path
            // 
            this.sdmc_path.Enabled = false;
            this.sdmc_path.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sdmc_path.Location = new System.Drawing.Point(108, 223);
            this.sdmc_path.Name = "sdmc_path";
            this.sdmc_path.Size = new System.Drawing.Size(230, 25);
            this.sdmc_path.TabIndex = 8;
            this.sdmc_path.Text = "/switch/application/application.nro";
            // 
            // romfs_path
            // 
            this.romfs_path.Enabled = false;
            this.romfs_path.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.romfs_path.Location = new System.Drawing.Point(108, 272);
            this.romfs_path.Name = "romfs_path";
            this.romfs_path.Size = new System.Drawing.Size(230, 25);
            this.romfs_path.TabIndex = 9;
            this.romfs_path.Text = "/application.nro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "App Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Title Id:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Author:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Version:";
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SettingsButton.BackgroundImage")));
            this.SettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SettingsButton.Location = new System.Drawing.Point(421, 315);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(28, 26);
            this.SettingsButton.TabIndex = 14;
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // Icon_Button
            // 
            this.Icon_Button.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon_Button.BackgroundImage = global::MtX.Nro2Nsp.Properties.Resources._default;
            this.Icon_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Icon_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Icon_Button.FlatAppearance.BorderSize = 2;
            this.Icon_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.Icon_Button.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon_Button.Location = new System.Drawing.Point(292, 12);
            this.Icon_Button.Name = "Icon_Button";
            this.Icon_Button.Size = new System.Drawing.Size(157, 157);
            this.Icon_Button.TabIndex = 9;
            this.Icon_Button.UseVisualStyleBackColor = false;
            this.Icon_Button.Click += new System.EventHandler(this.Import_Pictures);
            // 
            // Randomize
            // 
            this.Randomize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Randomize.BackgroundImage")));
            this.Randomize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Randomize.Location = new System.Drawing.Point(241, 58);
            this.Randomize.Name = "Randomize";
            this.Randomize.Size = new System.Drawing.Size(29, 25);
            this.Randomize.TabIndex = 15;
            this.Randomize.UseVisualStyleBackColor = true;
            this.Randomize.Click += new System.EventHandler(this.Randomize_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.Location = new System.Drawing.Point(241, 316);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(93, 25);
            this.btn_exit.TabIndex = 16;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.Btn_exit_Click);
            // 
            // Nro
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(469, 364);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.Randomize);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.romfs_path);
            this.Controls.Add(this.sdmc_path);
            this.Controls.Add(this.version_box);
            this.Controls.Add(this.author_box);
            this.Controls.Add(this.id_box);
            this.Controls.Add(this.name_box);
            this.Controls.Add(this.romfs_select);
            this.Controls.Add(this.sdmc_select);
            this.Controls.Add(this.Icon_Button);
            this.Controls.Add(this.compile_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Nro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nro2Nsp Version 3.2.2 -- MtX ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button compile_button;
        private System.Windows.Forms.Button Icon_Button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton sdmc_select;
        private System.Windows.Forms.RadioButton romfs_select;
        private System.Windows.Forms.TextBox name_box;
        private System.Windows.Forms.TextBox id_box;
        private System.Windows.Forms.TextBox author_box;
        private System.Windows.Forms.TextBox version_box;
        private System.Windows.Forms.TextBox sdmc_path;
        private System.Windows.Forms.TextBox romfs_path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button Randomize;
        private System.Windows.Forms.Button btn_exit;
    }
}

