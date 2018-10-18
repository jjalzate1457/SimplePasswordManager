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
        string fPassText { get { return fPass.Text.Trim(); } }

        AppSettings settings;

        AccountList accounts = null;

        Timer t = null;

        int pwordControlsTop = 0;


        public Main()
        {
            InitializeComponent();

            accounts = new AccountList();

            //gridAcct.GotFocus += Fields_GotFocus;
            //fPass.GotFocus += FPass_GotFocus;
            //fName.GotFocus += Fields_GotFocus;
            //fUsername.GotFocus += Fields_GotFocus;
            //fPassword.GotFocus += Fields_GotFocus;

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

            FormClosing += Form_FormClosing;

            pwordControlsTop = lPassword.Top;

            settings = new AppSettings();
            settings.OnSettingsChanged += (o, ee) => { ReflectSettings(); };

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
            UIConfig("lock");

            SetStatus("Saving current records...");

            accounts.Save(Common.EncryptedPassphrase);

            SetStatus("Records saved. Terminating app...");

            SessionLogger.Instance.Dispose();
        }



        #region Passphrase
        private void FPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnValidate.PerformClick();
            }
        }

        private void FPass_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxStatus(sender as TextBox, fPassText == "" ? TextBoxState.Invalid : TextBoxState.Valid);
        }

        private void validatePassphrase_Click(object sender, EventArgs e)
        {
            if (Common.EncryptedPassphrase == "")
            {
                Common.EncryptedPassphrase = Cipher.Encrypt(fPassText, fPassText);

                btnValidate.Text = "Validate";

                SetTextBoxStatus(fPass, TextBoxState.Valid);

                SetStatus("New passphrase saved.", StatusType.Success);

                UIConfig("valid");

                MessageBox.Show(
                    "Please remember your passphrase. Use it everytime you want to access all your accounts. " +
                    "Losing your passphrase means all your accounts are forever encrypted.",
                    "Passphrase is saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                try
                {
                    if (Cipher.Decrypt(Common.EncryptedPassphrase, fPassText) == fPassText)
                    {
                        SetStatus("Passphrase is valid.", StatusType.Success);

                        SetTextBoxStatus(fPass, TextBoxState.Valid);

                        SetStatus("Loading records...");

                        accounts.Load(Common.EncryptedPassphrase);

                        SetStatus("Loaded " + accounts.Count + " accounts.");

                        UIConfig("valid");
                    }
                    else
                    {
                        SetStatus("Passphrase is invalid.", StatusType.Error);
                        SetTextBoxStatus(fPass, TextBoxState.Invalid);

                    }
                }
                catch (Exception)
                {
                    SetStatus("Passphrase is invalid.", StatusType.Error);
                    SetTextBoxStatus(fPass, TextBoxState.Invalid);
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
            OnTextChanged(sender as TextBox);
        }

        private void OnTextChanged(TextBox sender)
        {
            if (sender.Text == "")
                SetTextBoxStatus(sender, TextBoxState.Invalid);
            if (IsDirty(sender))
                SetTextBoxStatus(sender, TextBoxState.Edited);
            else
                SetTextBoxStatus(sender, TextBoxState.Valid);
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
            UIConfig("pinmode");
        }
        #endregion Account Fields



        #region Account Actions
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (fName.Text == "")
                SetStatus("Name is required. Cannot save account.", StatusType.Error, false);
            else if (!fUsePIN.Checked && fName.Text == "")
                SetStatus("Username is required. Cannot save account.", StatusType.Error, false);
            else if (fPassword.Text == "")
                SetStatus(fUsePIN.Checked ? "PIN" : "Password" + " is required. Cannot save account.", StatusType.Error, false);
            else
            {
                if (gridAcct.SelectedIndex == -1)
                {
                    var newRecord = new Account()
                    {
                        AccountType = fUsePIN.Checked ? AccountType.PIN : AccountType.UsernamePassword,
                        Name = fName.Text.ToString(),
                        Username = fUsername.Text.ToString(),
                        Password = fPassword.Text.ToString()
                    };

                    accounts.Add(newRecord);

                    SetStatus("New record added.", StatusType.Success);

                    gridAcct.SelectedIndex = accounts.IndexOf(newRecord);

                    OnTextChanged(fName);
                    OnTextChanged(fUsername);
                    OnTextChanged(fPassword);
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
                if (MessageBox.Show("Are you sure you want to remove this account?",
                    "You are about to delete an account",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    accounts.Remove(gridAcct.SelectedItem as Account);
                    SetStatus("Successfully removed record.", StatusType.Success);
                }
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
            ReflectSettings();

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
            if (Common.PasswordShowMode == "Toggle")
            {
                fPassword.PasswordChar = fPassword.PasswordChar == Common.PasswordChar ? '\0' : Common.PasswordChar;
            }
            else
            {
                if (fPassword.PasswordChar != '\0')
                    fPassword.PasswordChar = '\0';

                t.Interval = Common.PasswordShowModeDuration;

                t.Tick += (o, ee) =>
                {
                    fPassword.PasswordChar = Common.PasswordChar;
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
                    generateFor.PasswordChar = Common.PasswordChar;

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
        /// <summary>
        /// Retrieves settings and reflects them in the application
        /// </summary>
        private void ReflectSettings()
        {
            // password mask
            fPass.PasswordChar = Common.PasswordChar;
            fPassword.PasswordChar = Common.PasswordChar;

            // password show
            if (Common.PasswordShowMode == "Toggle")
                togglePasswordToolStripMenuItem.Text = "Toggle Password";
            else
                togglePasswordToolStripMenuItem.Text = "Show password for " + Common.PasswordShowMode;
        }

        /// <summary>
        /// Sets the text of the status control
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <param name="expires"></param>
        /// <param name="customLog"></param>
        private void SetStatus(string message, StatusType type = StatusType.Info, bool expires = true, string customLog = "")
        {
            statusControl.SetStatus(message, type, expires);

            SessionLogger.Instance.Log((customLog != "") ? customLog : message);
        }

        /// <summary>
        /// Checks whether the current field is dirty
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsDirty(TextBox field)
        {
            if (accounts.Current != null)
            {
                if (field.Name == "fName")
                    return accounts.Current.Name != field.Text;
                else if (field.Name == "fUsername")
                    return accounts.Current.Username != field.Text;
                else if (field.Name == "fPassword")
                    return accounts.Current.Password != field.Text;
            }

            return true;
        }


        /// <summary>
        /// Checks whether the app has a passphrase or not
        /// </summary>
        private void FirstRun()
        {
            UIConfig("firstrun");

            if (Common.EncryptedPassphrase == "")
            {
                SetStatus("Please enter a new passphrase", StatusType.Info, false, "First Run. Waiting for passphrase...");
                btnValidate.Text = "Save";
            }
            else if (fPass.Text.Length == 0)
            {
                SetStatus("Please enter your passphrase", StatusType.Info, false, "Waiting for passphrase...");
            }
        }

        /// <summary>
        /// Resets all data
        /// </summary>
        private void Reset()
        {
            SetStatus("Erasing all data...");

            accounts.Reset();

            Common.Reset();

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
                sv.FileName = Common.FileExportFilename.Split('.')[0];

                if (sv.ShowDialog() == DialogResult.OK)
                    accounts.SaveExport(Common.EncryptedPassphrase, sv.FileName, encrypted);
            }
        }

        private void UIConfig(string state = "firstrun")
        {
            if (state == "pinmode")
            {
                fUsername.Text = "";

                lUsername.Visible = !fUsePIN.Checked;
                fUsername.Visible = !fUsePIN.Checked;
                vUsername.Visible = !fUsePIN.Checked;

                lPassword.Top = fUsePIN.Checked ? lUsername.Top : pwordControlsTop;
                fPassword.Top = fUsePIN.Checked ? fUsername.Top : pwordControlsTop;
                vPassword.Top = fUsePIN.Checked ? vUsername.Top : pwordControlsTop;
            }
            else if (state == "valid")
            {
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

                btnValidate.Enabled = false;

                groupAccountDetails.Enabled = true;
                groupBox1.Enabled = true;

                exportFileToolStripMenuItem.Enabled = true;
                editToolStripMenuItem.Enabled = true;
            }
            else if (state == "lock")
            {
                groupAccountDetails.Enabled = false;
                groupBox1.Enabled = false;
            }
            else
            {
                fPass.Text = "";
                fName.Text = "";
                fUsername.Text = "";
                fPassword.Text = "";

                fPass.Enabled = true;

                fPass.Focus();

                btnValidate.Enabled = true;

                groupAccountDetails.Enabled = false;
                groupBox1.Enabled = false;

                exportFileToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
            }
        }

        private void SetTextBoxStatus(TextBox field, TextBoxState state)
        {
            var controlName = field.Name;
            var validationControl = Controls.Find(controlName.Replace('f', 'v'), true);

            if (validationControl != null && validationControl.Length > 0)
            {
                if (state == TextBoxState.Valid)
                {
                    (validationControl[0] as Label).Text = "✔";
                    (validationControl[0] as Label).ForeColor = Color.Green;
                }
                else if (state == TextBoxState.Edited)
                {
                    (validationControl[0] as Label).Text = "🖉";
                    (validationControl[0] as Label).ForeColor = Color.Orange;
                }
                else if (state == TextBoxState.Invalid)
                {
                    (validationControl[0] as Label).Text = "!";
                    (validationControl[0] as Label).ForeColor = Color.Red;
                }
            }
        }
        #endregion
    }
}
