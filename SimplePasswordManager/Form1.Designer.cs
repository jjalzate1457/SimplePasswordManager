namespace SimplePasswordManager
{
    partial class Form1
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
            this.gridAcct = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fName = new System.Windows.Forms.TextBox();
            this.fUsername = new System.Windows.Forms.TextBox();
            this.lUsername = new System.Windows.Forms.Label();
            this.fPassword = new System.Windows.Forms.TextBox();
            this.lPassword = new System.Windows.Forms.Label();
            this.fPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.vPass = new System.Windows.Forms.Label();
            this.vName = new System.Windows.Forms.Label();
            this.vUsername = new System.Windows.Forms.Label();
            this.vPassword = new System.Windows.Forms.Label();
            this.btnValidate = new System.Windows.Forms.Button();
            this.lStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupAccountDetails = new System.Windows.Forms.GroupBox();
            this.fUsePIN = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decryptedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.togglePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupAccountDetails.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridAcct
            // 
            this.gridAcct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAcct.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridAcct.FormattingEnabled = true;
            this.gridAcct.ItemHeight = 17;
            this.gridAcct.Location = new System.Drawing.Point(3, 22);
            this.gridAcct.Name = "gridAcct";
            this.gridAcct.Size = new System.Drawing.Size(161, 225);
            this.gridAcct.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.Location = new System.Drawing.Point(234, 125);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 28);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account Name:";
            // 
            // fName
            // 
            this.fName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fName.Location = new System.Drawing.Point(113, 25);
            this.fName.Name = "fName";
            this.fName.Size = new System.Drawing.Size(219, 25);
            this.fName.TabIndex = 2;
            // 
            // fUsername
            // 
            this.fUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fUsername.Location = new System.Drawing.Point(113, 53);
            this.fUsername.Name = "fUsername";
            this.fUsername.Size = new System.Drawing.Size(219, 25);
            this.fUsername.TabIndex = 3;
            // 
            // lUsername
            // 
            this.lUsername.AutoSize = true;
            this.lUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUsername.Location = new System.Drawing.Point(6, 56);
            this.lUsername.Name = "lUsername";
            this.lUsername.Size = new System.Drawing.Size(72, 17);
            this.lUsername.TabIndex = 4;
            this.lUsername.Text = "Username:";
            // 
            // fPassword
            // 
            this.fPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fPassword.Location = new System.Drawing.Point(113, 81);
            this.fPassword.Name = "fPassword";
            this.fPassword.PasswordChar = '⚫';
            this.fPassword.Size = new System.Drawing.Size(219, 25);
            this.fPassword.TabIndex = 4;
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPassword.Location = new System.Drawing.Point(6, 84);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(69, 17);
            this.lPassword.TabIndex = 6;
            this.lPassword.Text = "Password:";
            // 
            // fPass
            // 
            this.fPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fPass.Location = new System.Drawing.Point(91, 19);
            this.fPass.Name = "fPass";
            this.fPass.PasswordChar = '⚫';
            this.fPass.Size = new System.Drawing.Size(170, 25);
            this.fPass.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Passphrase:";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDelete.Location = new System.Drawing.Point(298, 125);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(61, 28);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNew.Location = new System.Drawing.Point(169, 125);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(61, 28);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // vPass
            // 
            this.vPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vPass.AutoSize = true;
            this.vPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vPass.ForeColor = System.Drawing.Color.Red;
            this.vPass.Location = new System.Drawing.Point(267, 23);
            this.vPass.Name = "vPass";
            this.vPass.Size = new System.Drawing.Size(12, 17);
            this.vPass.TabIndex = 9;
            this.vPass.Text = "!";
            // 
            // vName
            // 
            this.vName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vName.ForeColor = System.Drawing.Color.Red;
            this.vName.Location = new System.Drawing.Point(337, 28);
            this.vName.Name = "vName";
            this.vName.Size = new System.Drawing.Size(22, 17);
            this.vName.TabIndex = 10;
            this.vName.Text = "!";
            this.vName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vUsername
            // 
            this.vUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vUsername.ForeColor = System.Drawing.Color.Red;
            this.vUsername.Location = new System.Drawing.Point(337, 56);
            this.vUsername.Name = "vUsername";
            this.vUsername.Size = new System.Drawing.Size(22, 17);
            this.vUsername.TabIndex = 11;
            this.vUsername.Text = "!";
            this.vUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vPassword
            // 
            this.vPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vPassword.ForeColor = System.Drawing.Color.Red;
            this.vPassword.Location = new System.Drawing.Point(337, 84);
            this.vPassword.Name = "vPassword";
            this.vPassword.Size = new System.Drawing.Size(22, 17);
            this.vPassword.TabIndex = 12;
            this.vPassword.Text = "!";
            this.vPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnValidate
            // 
            this.btnValidate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnValidate.Location = new System.Drawing.Point(285, 17);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(74, 28);
            this.btnValidate.TabIndex = 13;
            this.btnValidate.Text = "&Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.validate_Click);
            // 
            // lStatus
            // 
            this.lStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStatus.ForeColor = System.Drawing.Color.Blue;
            this.lStatus.Location = new System.Drawing.Point(6, 9);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(358, 22);
            this.lStatus.TabIndex = 14;
            this.lStatus.Text = "Ready";
            this.lStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lStatus.DoubleClick += new System.EventHandler(this.lStatus_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.gridAcct);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 259);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Accounts";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnValidate);
            this.groupBox2.Controls.Add(this.vPass);
            this.groupBox2.Controls.Add(this.fPass);
            this.groupBox2.Location = new System.Drawing.Point(188, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 60);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // groupAccountDetails
            // 
            this.groupAccountDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAccountDetails.Controls.Add(this.fUsePIN);
            this.groupAccountDetails.Controls.Add(this.label1);
            this.groupAccountDetails.Controls.Add(this.btnSave);
            this.groupAccountDetails.Controls.Add(this.lUsername);
            this.groupAccountDetails.Controls.Add(this.vPassword);
            this.groupAccountDetails.Controls.Add(this.vUsername);
            this.groupAccountDetails.Controls.Add(this.lPassword);
            this.groupAccountDetails.Controls.Add(this.vName);
            this.groupAccountDetails.Controls.Add(this.btnNew);
            this.groupAccountDetails.Controls.Add(this.btnDelete);
            this.groupAccountDetails.Controls.Add(this.fName);
            this.groupAccountDetails.Controls.Add(this.fUsername);
            this.groupAccountDetails.Controls.Add(this.fPassword);
            this.groupAccountDetails.Location = new System.Drawing.Point(188, 97);
            this.groupAccountDetails.Name = "groupAccountDetails";
            this.groupAccountDetails.Size = new System.Drawing.Size(365, 159);
            this.groupAccountDetails.TabIndex = 17;
            this.groupAccountDetails.TabStop = false;
            this.groupAccountDetails.Text = "Account";
            // 
            // fUsePIN
            // 
            this.fUsePIN.AutoSize = true;
            this.fUsePIN.Location = new System.Drawing.Point(9, 133);
            this.fUsePIN.Name = "fUsePIN";
            this.fUsePIN.Size = new System.Drawing.Size(103, 17);
            this.fUsePIN.TabIndex = 13;
            this.fUsePIN.Text = "Use PIN instead";
            this.fUsePIN.UseVisualStyleBackColor = true;
            this.fUsePIN.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lStatus);
            this.groupBox3.Location = new System.Drawing.Point(188, 255);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(365, 34);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(565, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportFileToolStripMenuItem,
            this.toolStripSeparator1,
            this.resetToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportFileToolStripMenuItem
            // 
            this.exportFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encryptedToolStripMenuItem,
            this.decryptedToolStripMenuItem});
            this.exportFileToolStripMenuItem.Name = "exportFileToolStripMenuItem";
            this.exportFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportFileToolStripMenuItem.Text = "Export File";
            // 
            // encryptedToolStripMenuItem
            // 
            this.encryptedToolStripMenuItem.Name = "encryptedToolStripMenuItem";
            this.encryptedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.encryptedToolStripMenuItem.Text = "Encrypted";
            this.encryptedToolStripMenuItem.Click += new System.EventHandler(this.encryptedToolStripMenuItem_Click);
            // 
            // decryptedToolStripMenuItem
            // 
            this.decryptedToolStripMenuItem.Name = "decryptedToolStripMenuItem";
            this.decryptedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.decryptedToolStripMenuItem.Text = "Decrypted";
            this.decryptedToolStripMenuItem.Click += new System.EventHandler(this.decryptedToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.togglePasswordToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // togglePasswordToolStripMenuItem
            // 
            this.togglePasswordToolStripMenuItem.Name = "togglePasswordToolStripMenuItem";
            this.togglePasswordToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.togglePasswordToolStripMenuItem.Text = "Toggle Password";
            this.togglePasswordToolStripMenuItem.Click += new System.EventHandler(this.togglePasswordToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLogsToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // showLogsToolStripMenuItem
            // 
            this.showLogsToolStripMenuItem.Name = "showLogsToolStripMenuItem";
            this.showLogsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.showLogsToolStripMenuItem.Text = "Show Logs";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(128, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(565, 301);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupAccountDetails);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Password Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupAccountDetails.ResumeLayout(false);
            this.groupAccountDetails.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox gridAcct;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fName;
        private System.Windows.Forms.TextBox fUsername;
        private System.Windows.Forms.Label lUsername;
        private System.Windows.Forms.TextBox fPassword;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.TextBox fPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label vPass;
        private System.Windows.Forms.Label vName;
        private System.Windows.Forms.Label vUsername;
        private System.Windows.Forms.Label vPassword;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupAccountDetails;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox fUsePIN;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encryptedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decryptedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem togglePasswordToolStripMenuItem;
    }
}

