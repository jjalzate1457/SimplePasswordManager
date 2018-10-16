using System;

namespace SimplePasswordManager
{
    partial class AppSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fPasswordLength = new System.Windows.Forms.ComboBox();
            this.fNonAlpha = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fFilename = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fPasswordMask = new System.Windows.Forms.ComboBox();
            this.fPasswordShowMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBroweDefaultFolder = new System.Windows.Forms.Button();
            this.fDefaultPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusControl1 = new SimplePasswordManager.StatusControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Length:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "No. of Non-Alphanumeric Characters";
            // 
            // fPasswordLength
            // 
            this.fPasswordLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fPasswordLength.FormattingEnabled = true;
            this.fPasswordLength.Location = new System.Drawing.Point(220, 30);
            this.fPasswordLength.Name = "fPasswordLength";
            this.fPasswordLength.Size = new System.Drawing.Size(125, 21);
            this.fPasswordLength.TabIndex = 4;
            // 
            // fNonAlpha
            // 
            this.fNonAlpha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fNonAlpha.FormattingEnabled = true;
            this.fNonAlpha.Location = new System.Drawing.Point(220, 57);
            this.fNonAlpha.Name = "fNonAlpha";
            this.fNonAlpha.Size = new System.Drawing.Size(125, 21);
            this.fNonAlpha.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Filename:";
            // 
            // fFilename
            // 
            this.fFilename.Location = new System.Drawing.Point(116, 29);
            this.fFilename.Name = "fFilename";
            this.fFilename.Size = new System.Drawing.Size(125, 22);
            this.fFilename.TabIndex = 7;
            this.fFilename.TextChanged += new System.EventHandler(this.fFilename_TextChanged);
            this.fFilename.Leave += new System.EventHandler(this.fFilename_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password Mask:";
            // 
            // fPasswordMask
            // 
            this.fPasswordMask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fPasswordMask.FormattingEnabled = true;
            this.fPasswordMask.Location = new System.Drawing.Point(220, 30);
            this.fPasswordMask.Name = "fPasswordMask";
            this.fPasswordMask.Size = new System.Drawing.Size(125, 21);
            this.fPasswordMask.TabIndex = 9;
            this.fPasswordMask.SelectedIndexChanged += new System.EventHandler(this.fPwordMask_SelectedIndexChanged);
            // 
            // fPassShowMode
            // 
            this.fPasswordShowMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fPasswordShowMode.FormattingEnabled = true;
            this.fPasswordShowMode.Location = new System.Drawing.Point(220, 57);
            this.fPasswordShowMode.Name = "fPassShowMode";
            this.fPasswordShowMode.Size = new System.Drawing.Size(125, 21);
            this.fPasswordShowMode.TabIndex = 11;
            this.fPasswordShowMode.SelectedIndexChanged += new System.EventHandler(this.fPasswordShowMode_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Show Password: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.fPasswordLength);
            this.groupBox1.Controls.Add(this.fNonAlpha);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 109);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Suggested Password";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.fPasswordMask);
            this.groupBox2.Controls.Add(this.fPasswordShowMode);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(387, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 109);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Password Settings";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBroweDefaultFolder);
            this.groupBox3.Controls.Add(this.fDefaultPath);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.fFilename);
            this.groupBox3.Location = new System.Drawing.Point(12, 127);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(744, 76);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "File and Exporting";
            // 
            // btnBroweDefaultFolder
            // 
            this.btnBroweDefaultFolder.Location = new System.Drawing.Point(656, 28);
            this.btnBroweDefaultFolder.Name = "btnBroweDefaultFolder";
            this.btnBroweDefaultFolder.Size = new System.Drawing.Size(64, 23);
            this.btnBroweDefaultFolder.TabIndex = 10;
            this.btnBroweDefaultFolder.Text = "Browse";
            this.btnBroweDefaultFolder.UseVisualStyleBackColor = true;
            // 
            // fDefaultPath
            // 
            this.fDefaultPath.Location = new System.Drawing.Point(392, 29);
            this.fDefaultPath.Name = "fDefaultPath";
            this.fDefaultPath.ReadOnly = true;
            this.fDefaultPath.Size = new System.Drawing.Size(258, 22);
            this.fDefaultPath.TabIndex = 9;
            this.fDefaultPath.TextChanged += new System.EventHandler(this.fDefaultPath_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Default Export Path:";
            // 
            // statusControl1
            // 
            this.statusControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.statusControl1.BackColor = System.Drawing.Color.White;
            this.statusControl1.Location = new System.Drawing.Point(12, 209);
            this.statusControl1.Name = "statusControl1";
            this.statusControl1.Size = new System.Drawing.Size(744, 20);
            this.statusControl1.TabIndex = 17;
            // 
            // AppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(771, 236);
            this.Controls.Add(this.statusControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AppSettings";
            this.Text = "Settings ";
            this.Load += new System.EventHandler(this.AppSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox fPasswordLength;
        private System.Windows.Forms.ComboBox fNonAlpha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fFilename;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox fPasswordMask;
        private System.Windows.Forms.ComboBox fPasswordShowMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBroweDefaultFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fDefaultPath;
        private StatusControl statusControl1;
    }
}