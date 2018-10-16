using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePasswordManager
{
    public partial class AppSettings : Form
    {
        Common Common { get; set; }

        List<char> passwordCharItems;
        List<string> passwordShowModeItems;

        public AppSettings()
        {
            InitializeComponent();
            Common = Common.Instance;
        }

        private void AppSettings_Load(object sender, EventArgs e)
        {

            fPasswordLength.Items.Clear();
            fNonAlpha.Items.Clear();

            for (var a = 1; a <= 16; a++)
            {
                fPasswordLength.Items.Add(a);
                fNonAlpha.Items.Add(a);
            }

            fPasswordLength.SelectedIndex = Common.PasswordSuggestLength - 1;
            fNonAlpha.SelectedIndex = Common.PasswordSuggestNonAlpha - 1;

            fPasswordLength.SelectedIndexChanged += new EventHandler(fPasswordLength_SelectedIndexChanged);
            fNonAlpha.SelectedIndexChanged += new EventHandler(fNonAlpha_SelectedIndexChanged);

            passwordShowModeItems = new List<string> {"3 sec", "5 sec", "Toggle" };
            fPasswordShowMode.DataSource = passwordShowModeItems;
            fPasswordShowMode.SelectedItem = passwordShowModeItems.Find(i => i == Common.PasswordShowMode);

            passwordCharItems = new List<char> { '●', '*', '-', '#' };
            fPasswordMask.DataSource = passwordCharItems;
            fPasswordMask.SelectedItem = passwordCharItems.Find(i => i == Common.PasswordChar);
        }

        private void SetStatus(string message, StatusType type = StatusType.Info, bool expires = true, string customLog = "")
        {
            statusControl1.SetStatus(message, type, expires);

            if (customLog != "")
                SessionLogger.Instance.Log(customLog);
        }

        private void fPasswordLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fNonAlpha.SelectedIndex + 1 > fPasswordLength.SelectedIndex + 1)
            {
                fNonAlpha.Items.Clear();

                for (var a = 1; a <= fPasswordLength.Items.Count; a++)
                {
                    fNonAlpha.Items.Add(a);
                }

                fNonAlpha.SelectedIndex = fPasswordLength.SelectedIndex;
            }

            Common.PasswordSuggestLength = fPasswordLength.SelectedIndex + 1;
        }

        private void fNonAlpha_SelectedIndexChanged(object sender, EventArgs e)
        {
            Common.PasswordSuggestNonAlpha = fNonAlpha.SelectedIndex + 1;
        }

        private void fPwordMask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fPasswordMask.SelectedIndex != -1)
                Common.PasswordChar = passwordCharItems[fPasswordMask.SelectedIndex];
        }

        private void fPasswordShowMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fPasswordShowMode.SelectedIndex != -1)
                Common.PasswordShowMode = passwordShowModeItems[fPasswordShowMode.SelectedIndex];
        }

        private void fFilename_TextChanged(object sender, EventArgs e)
        {

        }

        private void fFilename_Leave(object sender, EventArgs e)
        {

        }

        private void fDefaultPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
