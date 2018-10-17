﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePasswordManager
{
    public partial class Main : Form
    {
        string EncryptedPassphrase
        {
            get { return Properties.Settings.Default.pass; }
            set
            {
                Properties.Settings.Default.pass = value;
                Properties.Settings.Default.Save();
            }
        }
        string pass { get { return fPass.Text.Trim(); } }

        AppSettings settings;

        AccountList accounts = null;

        Timer t = null;

        int pwordControlsTop = 0;


        public Main()
        {
            InitializeComponent();

            accounts = new AccountList();

            //gridAcct.GotFocus += Fields_GotFocus;
            fPass.GotFocus += FPass_GotFocus;
            fName.GotFocus += Fields_GotFocus;
            fUsername.GotFocus += Fields_GotFocus;
            fPassword.GotFocus += Fields_GotFocus;

            //fPass.TextChanged += FPass_TextChanged;
            fName.TextChanged += Field_TextChanged;
            fUsername.TextChanged += Field_TextChanged;
            fPassword.TextChanged += Field_TextChanged;

            fPass.KeyDown += FPass_KeyDown;
            fName.KeyDown += FName_KeyDown;
            fUsername.KeyDown += FUsername_KeyDown;
            fPassword.KeyDown += FPassword_KeyDown;

            gridAcct.SelectedIndexChanged += GridAcct_SelectedIndexChanged;
            gridAcct.DataSource = accounts;
            gridAcct.DisplayMember = "Name";

            exportFileToolStripMenuItem.Enabled = false;
            editToolStripMenuItem.Enabled = false;

            FormClosing += Form_FormClosing;

            pwordControlsTop = lPassword.Top;

            t = new Timer();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            FirstRun();
            fPass.Focus();
            SessionLogger.Instance.Log("Password manager ready.");
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetStatus("Saving current records...");

            accounts.Save(EncryptedPassphrase);

            SetStatus("Records saved. Terminating app...");

            SessionLogger.Instance.Dispose();
        }



        #region Passphrase 
        private void FPass_GotFocus(object sender, EventArgs e)
        {

        }

        private void FPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnValidate.PerformClick();
            }
        }

        private void FPass_TextChanged(object sender, EventArgs e)
        {
            if (fPass.Text.Length == 0)
            {
                vPass.Text = "!";
                vPass.ForeColor = Color.Red;
            }
        }

        private void validatePassphrase_Click(object sender, EventArgs e)
        {
            if (EncryptedPassphrase == "")
            {
                EncryptedPassphrase = Cipher.Encrypt(pass, pass);

                Properties.Settings.Default.Save();

                btnValidate.Text = "Validate";
                btnValidate.Enabled = false;

                fPass.Enabled = false;

                fName.Focus();

                vPass.Text = "✔";
                vPass.ForeColor = Color.Green;

                SetStatus("New passphrase saved.", StatusType.Success);

                groupAccountDetails.Enabled = true;
                gridAcct.Enabled = true;

                MessageBox.Show(
                    "Please remember your passphrase. Use it everytime you want to access all your accounts ",
                    "Passphrase is saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                exportFileToolStripMenuItem.Enabled = true;
                editToolStripMenuItem.Enabled = true;

            }
            else
            {
                try
                {
                    if (Cipher.Decrypt(EncryptedPassphrase, pass) == pass)
                    {
                        SetStatus("Passphrase is valid.", StatusType.Success);
                        vPass.Text = "✔";
                        vPass.ForeColor = Color.Green;

                        groupAccountDetails.Enabled = true;
                        gridAcct.Enabled = true;

                        btnValidate.Enabled = false;

                        fPass.Enabled = false;

                        if (gridAcct.Items.Count > 0)
                        {
                            gridAcct.SelectedIndex = 0;
                            gridAcct.SelectedItem = accounts[0];
                            gridAcct.Focus();
                        }
                        else
                        {
                            fName.Focus();
                        }

                        SetStatus("Loading records...");

                        accounts.Load(EncryptedPassphrase);

                        SetStatus("Loaded " + accounts.Count + " accounts.");

                        exportFileToolStripMenuItem.Enabled = true;
                        editToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        SetStatus("Passphrase is invalid.", StatusType.Error);
                        vPass.Text = "!";
                        vPass.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    SetStatus("Passphrase is invalid.", StatusType.Error);
                    vPass.Text = "!";
                    vPass.ForeColor = Color.Red;
                }
            }
        }
        #endregion Passphrase 



        #region Accounts Grid
        private void GridAcct_SelectedIndexChanged(object sender, EventArgs e)
        {
            accounts.Current = gridAcct.SelectedItem as Account;

            if (accounts.Current != null)
            {
                fUsePIN.Checked = false;
                fUsePIN.Checked = accounts.Current.AccountType == AccountType.PIN;

                fName.Text = accounts.Current.Name;
                fUsername.Text = accounts.Current.Username;
                fPassword.Text = accounts.Current.Password;
            }
        }
        #endregion Accounts Grid



        #region Account Fields
        private void Fields_GotFocus(object sender, EventArgs e)
        {

        }

        private void Field_TextChanged(object sender, EventArgs e)
        {
            var control = sender as TextBox;
            var controlName = (sender as Control).Name;
            var validationControl = Controls.Find(controlName.Replace('f', 'v'), true);

            if (validationControl != null && validationControl.Length > 0)
            {
                if ((sender as TextBox).Text.Length != 0)
                {
                    if (CheckFieldValue(controlName, control.Text))
                    {
                        (validationControl[0] as Label).Text = "✔";
                        (validationControl[0] as Label).ForeColor = Color.Green;
                    }
                    else
                    {
                        (validationControl[0] as Label).Text = "🖉";
                        (validationControl[0] as Label).ForeColor = Color.Orange;
                    }
                }
                else
                {
                    (validationControl[0] as Label).Text = "!";
                    (validationControl[0] as Label).ForeColor = Color.Red;
                }
            }
        }

        private void FName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                fUsername.Focus();
            }
        }

        private void FUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                fPassword.Focus();
            }
        }

        private void FPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
            }
        }

        private void fUsePIN_CheckChanged(object sender, EventArgs e)
        {
            lUsername.Visible = !fUsePIN.Checked;
            fUsername.Visible = !fUsePIN.Checked;
            vUsername.Visible = !fUsePIN.Checked;

            lPassword.Top = fUsePIN.Checked ? lUsername.Top : pwordControlsTop;
            fPassword.Top = fUsePIN.Checked ? fUsername.Top : pwordControlsTop;
            vPassword.Top = fUsePIN.Checked ? vUsername.Top : pwordControlsTop;
        }
        #endregion Account Fields



        #region Account Actions
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (fName.Text == "")
                SetStatus("Name is required. Cannot save account.", StatusType.Error, false);
            if (!fUsePIN.Checked && fName.Text == "")
                SetStatus("Username is required. Cannot save account.", StatusType.Error, false);
            if (fPassword.Text == "")
                SetStatus(fUsePIN.Checked ? "PIN" : "Password" + " is required. Cannot save account.", StatusType.Error, false);

            if (gridAcct.SelectedIndex == -1)
            {
                accounts.Add(new Account()
                {
                    AccountType = fUsePIN.Checked ? AccountType.PIN : AccountType.UsernamePassword,
                    Name = fName.Text.ToString(),
                    Username = fUsername.Text.ToString(),
                    Password = fPassword.Text.ToString()
                });

                SetStatus("New record added.", StatusType.Success);
            }
            else
            {
                var selected = gridAcct.SelectedItem as Account;

                accounts.Update(new Account
                {
                    Id = selected.Id,
                    AccountType = fUsePIN.Checked ? AccountType.PIN : AccountType.UsernamePassword,
                    Name = fName.Text.ToString(),
                    Username = fUsername.Text.ToString(),
                    Password = fPassword.Text.ToString(),
                });

                SetStatus("Record updated", StatusType.Success);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            gridAcct.SelectedIndex = -1;

            fName.Text = "";
            fUsername.Text = "";
            fPassword.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridAcct.SelectedIndex == -1)
            {
                SetStatus("Cannot Delete. There is no selected record.", StatusType.Error);
            }
            else
            {
                accounts.Remove(gridAcct.SelectedItem as Account);
                SetStatus("Successfully removed record.", StatusType.Success);
            }
        }
        #endregion Account Actions



        #region Menu Items
        private void encryptedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile(true);
        }

        private void decryptedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile(false);
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (settings == null)
            {
                settings = new AppSettings();
                settings.OnSettingsChanged += (o, ee) =>
                {
                    if (o is ComboBox)
                    {
                        if ((o as ComboBox).Name.ToLower().Contains("mask"))
                        {
                            var a = (o as ComboBox).SelectedItem;

                            fPass.PasswordChar = (char)a;
                            fPassword.PasswordChar = (char)a;
                        }
                        if ((o as ComboBox).Name.ToLower().Contains("showmode"))
                        {
                            var a = (o as ComboBox).SelectedItem.ToString();

                            if (a == "Toggle")
                                togglePasswordToolStripMenuItem.Text = "Toggle Password";
                            else
                                togglePasswordToolStripMenuItem.Text = "Show password for " + a;
                        }
                    }
                };
            }

            settings.Show();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all data?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Reset();
            }
        }


        private void togglePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Common.Instance.PasswordShowMode == "Toggle")
            {
                fPassword.PasswordChar = fPassword.PasswordChar == Common.Instance.PasswordChar ? '\0' : Common.Instance.PasswordChar;
            }
            else
            {
                if (fPassword.PasswordChar != '\0')
                    fPassword.PasswordChar = '\0';

                t.Interval = Common.Instance.PasswordShowModeDuration;

                t.Tick += (o, ee) =>
                {
                    fPassword.PasswordChar = Common.Instance.PasswordChar;
                    t.Stop();
                };

                t.Start();
            }
        }

        private void suggestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox generateFor = fPass.Focused ? fPass : fPassword.Focused ? fPassword : null;

            if (generateFor != null)
            {
                generateFor.Text = System.Web.Security.Membership.GeneratePassword(
                    fUsePIN.Checked ? 4 : 10,
                     fUsePIN.Checked ? 0 : 2
                );

                generateFor.PasswordChar = '\0';

                t.Interval = 3000;

                t.Tick += (o, ee) =>
                {
                    generateFor.PasswordChar = Common.Instance.PasswordChar;

                    t.Stop();
                };

                t.Start();
            }
        }


        private void showLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionLogger.Instance.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion Menu Items



        #region Other Methods
        private void SetStatus(string message, StatusType type = StatusType.Info, bool expires = true, string customLog = "")
        {
            statusControl1.SetStatus(message, type, expires);

            if (customLog != "")
                SessionLogger.Instance.Log(message);
        }

        private bool CheckFieldValue(string field, string value)
        {
            Account current = accounts.Current;

            if (current != null)
            {
                if (field == "fName")
                    return current.Name == value;
                else if (field == "fUsername")
                    return current.Username == value;
                else if (field == "fPassword")
                    return current.Password == value;
            }

            return true;
        }

        private void FirstRun()
        {
            if (fPass.Text.Length == 0)
            {
                fPass.Focus();

                fPass.Enabled = true;

                groupAccountDetails.Enabled = false;
                gridAcct.Enabled = false;

                if (EncryptedPassphrase == "")
                {
                    SetStatus("Please enter a new passphrase", StatusType.Info, false, "First Run. Waiting for passphrase...");
                    btnValidate.Text = "Save";
                }
                else
                {
                    SetStatus("Please enter your passphrase", StatusType.Info, false, "Waiting for passphrase...");
                }
            }
        }

        private void Reset()
        {
            SetStatus("Erasing all data...");

            accounts.Reset();
            EncryptedPassphrase = "";
            Properties.Settings.Default.iv = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16);

            fPass.Text = "";
            fName.Text = "";
            fUsername.Text = "";
            fPassword.Text = "";

            SetStatus("Data has been reset.");

            FirstRun();
        }

        private void ExportFile(bool encrypted)
        {
            using (SaveFileDialog sv = new SaveFileDialog())
            {
                sv.DefaultExt = "spm";
                sv.Filter = "Simple Password Manager File (*.spm)|*.spm";
                sv.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                sv.FileName = Common.Instance.FileExportFilename.Split('.')[0];
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    accounts.SaveExport(EncryptedPassphrase, sv.FileName, encrypted);
                }
            }
        }
        #endregion


    }
}
