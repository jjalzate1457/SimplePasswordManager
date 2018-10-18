using System;
using System.ComponentModel;

namespace SimplePasswordManager
{
    public class Common
    {
        public static string IV
        {
            get { return Properties.Settings.Default.iv; }
            set
            {
                Properties.Settings.Default.iv = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string EncryptedPassphrase
        {
            get { return Properties.Settings.Default.pass; }
            set
            {
                Properties.Settings.Default.pass = value;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// The default filename of the file where all the encrypted accounts data are saved
        /// </summary>
        public static string FileExportFilename
        {
            get
            {
                if (Properties.Settings.Default.FileExportFilename == "")
                    Properties.Settings.Default.FileExportFilename = "accts.spm";

                return Properties.Settings.Default.FileExportFilename;
            }
            set
            {
                Properties.Settings.Default.FileExportFilename = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string FileExportDefaultFolder
        {
            get
            {
                if (Properties.Settings.Default.FileExportDefaultFolder == "")
                    Properties.Settings.Default.FileExportDefaultFolder =
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                return Properties.Settings.Default.FileExportDefaultFolder;
            }
            set
            {
                Properties.Settings.Default.FileExportDefaultFolder = value;
                Properties.Settings.Default.Save();
            }
        }


        public static string PasswordShowMode
        {
            get
            {
                return
                    Properties.Settings.Default.PasswordShowMode == 0 ?
                    "Toggle" :
                    (Properties.Settings.Default.PasswordShowMode / 1000 + " secs");
            }
            set
            {
                Properties.Settings.Default.PasswordShowMode =
                    (value == "Toggle" ? 0 : Convert.ToInt16(value.Replace("secs", "").Trim())) * 1000;
                Properties.Settings.Default.Save();
            }
        }

        public static int PasswordShowModeDuration
        {
            get { return Properties.Settings.Default.PasswordShowMode; }
        }

        /// <summary>
        /// Display character for password/PIN and passphrase fields
        /// </summary>
        public static char PasswordChar
        {
            get
            {
                if (Properties.Settings.Default.PasswordMask == '\0')
                    Properties.Settings.Default.PasswordMask = '⚫';

                return Properties.Settings.Default.PasswordMask;
            }
            set
            {
                Properties.Settings.Default.PasswordMask = value;
                Properties.Settings.Default.Save();
            }
        }

        public static int PasswordSuggestLength
        {
            get
            {
                if (Properties.Settings.Default.PasswordSuggestLength == 0)
                    Properties.Settings.Default.PasswordSuggestLength = 8;

                return Properties.Settings.Default.PasswordSuggestLength;
            }
            set
            {
                Properties.Settings.Default.PasswordSuggestLength = value;
                Properties.Settings.Default.Save();
            }
        }

        public static int PasswordSuggestNonAlpha
        {
            get
            {
                if (Properties.Settings.Default.PasswordSuggestNonAlpha == 0)
                    Properties.Settings.Default.PasswordSuggestNonAlpha = 8;

                return Properties.Settings.Default.PasswordSuggestNonAlpha;
            }
            set
            {
                Properties.Settings.Default.PasswordSuggestNonAlpha = value;
                Properties.Settings.Default.Save();
            }
        }

        public static void Reset()
        {
            IV = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16);
            EncryptedPassphrase = "";

            PasswordChar = '⚫';
            PasswordShowMode = "3 secs";
            PasswordSuggestLength = 8;
            PasswordSuggestNonAlpha = 2;
        }
    }
}
