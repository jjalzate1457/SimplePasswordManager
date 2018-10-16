using System;
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

        SessionLogger logger = null;

        AccountList accounts = null;

        Timer t = null;

        string pass = "";

        int pwordControlsTop = 0;


        public Main()
        {
            InitializeComponent();

            accounts = new AccountList();

            gridAcct.GotFocus += FirstRun_Focus;
            fPass.GotFocus += FPass_GotFocus;
            fName.GotFocus += FirstRun_Focus;
            fUsername.GotFocus += FirstRun_Focus;
            fPassword.GotFocus += FirstRun_Focus;

            fPass.TextChanged += FPass_TextChanged;
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

            t = new Timer { Interval = 3000 };

            pwordControlsTop = lPassword.Top;

            logger = new SessionLogger();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            fPass.Focus();
            logger.Log("Password manager ready.");
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetStatus("Saving current records...");

            accounts.Save(EncryptedPassphrase);

            SetStatus("Records saved. Terminating app...");

            logger.Dispose();
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
            pass = fPass.Text.Trim();

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
                    if (Cipher.Decrypt(EncryptedPassphrase, pass) == fPass.Text.Trim())
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
                        vPass.ForeColor = Color.Green;
                    }
                }
                catch (Exception ex)
                {
                    SetStatus("Passphrase is invalid.", StatusType.Error);
                    vPass.Text = "!";
                    vPass.ForeColor = Color.Green;
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
                SetStatus("Name is required. Cannot save account.", StatusType.Error, false, false);
            if (!fUsePIN.Checked && fName.Text == "")
                SetStatus("Username is required. Cannot save account.", StatusType.Error, false, false);
            if (fPassword.Text == "")
                SetStatus(fUsePIN.Checked ? "PIN" : "Password" + " is required. Cannot save account.", StatusType.Error, false, false);

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
            fPassword.PasswordChar = fPassword.PasswordChar == '⚫' ? '\0' : '⚫';
        }

        private void suggestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox generateFor = fPass.Focused ? fPass : fPassword.Focused ? fPassword : null;

            if (generateFor != null)
            {
                generateFor.Text = System.Web.Security.Membership.GeneratePassword(10, 2);
                generateFor.PasswordChar = '\0';

                t.Tick += (o, ee) =>
                {
                    generateFor.PasswordChar = '⚫';

                    t.Stop();
                };

                t.Start();
            }
        }


        private void showLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion Menu Items




        #region Other Methods
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

        private void FirstRun_Focus(object sender, EventArgs e)
        {
            FirstRun();
        }

        private void FirstRun(object sender = null)
        {
            if (fPass.Text.Length == 0)
            {
                if (sender != null && ((sender as TextBox) != fPass))
                    fPass.Focus();

                fPass.Enabled = true;

                vPass.Visible = true;

                Activate();

                groupAccountDetails.Enabled = false;
                gridAcct.Enabled = false;

                if (EncryptedPassphrase == "")
                {
                    SetStatus("Please enter a new passphrase", StatusType.Info, false, false);
                    logger.Log("First Run. Waiting for passphrase...");
                    btnValidate.Text = "Save";
                }
                else
                {
                    SetStatus("Please enter your passphrase", StatusType.Info, false, false);
                    logger.Log("Waiting for passphrase...");
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

            FirstRun(fUsername);
        }

        private void SetStatus(string message, StatusType type = StatusType.Info, bool timer = true, bool log = true)
        {
            switch (type)
            {
                case StatusType.Info:
                    lStatus.ForeColor = Color.Blue;
                    break;
                case StatusType.Success:
                    lStatus.ForeColor = Color.Green;
                    break;
                case StatusType.Error:
                    lStatus.ForeColor = Color.Red;
                    break;
            }

            lStatus.Text = message;

            if (log)
                logger.Log(message);

            if (timer)
            {
                t.Tick += (o, e) => { SetStatus("Ready.", StatusType.Info, false, false); };
                t.Start();
            }
            else
                t.Stop();
        }

        private void ExportFile(bool encrypted)
        {
            using (SaveFileDialog sv = new SaveFileDialog())
            {
                sv.DefaultExt = "csv";
                sv.Filter = "Comma Delimited (*.csv)|*.csv";
                sv.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                sv.FileName = Common.Filename.Split('.')[0];
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    accounts.SaveExport(EncryptedPassphrase, sv.FileName, encrypted);
                }
            }
        }
        #endregion
    }

    enum StatusType
    {
        Info,
        Success,
        Error
    }
}
