using System;
using System.ComponentModel;

namespace SimplePasswordManager
{
    public class Common
    {
        static Common _instance;
        public static Common Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Common();

                return _instance;
            }
        }

        /// <summary>
        /// The default filename of the file where all the encrypted accounts data are saved
        /// </summary>
        public string FileExportFilename
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

        public string FileExportDefaultFolder
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


        public string PasswordShowMode
        {
            get
            {
                if (Properties.Settings.Default.PasswordShowMode == 0)
                    Properties.Settings.Default.PasswordShowMode = 3000;

                return
                    Properties.Settings.Default.PasswordShowMode == 0 ?
                    "Toggle" :
                    (Properties.Settings.Default.PasswordShowMode / 1000 + " sec");
            }
            set
            {
                Properties.Settings.Default.PasswordShowMode =
                    (value == "Toggle" ? 0 : Convert.ToInt16(value.Replace("sec", "").Trim())) * 1000;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Display character for password/PIN and passphrase fields
        /// </summary>
        public char PasswordChar
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

        public int PasswordSuggestLength
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

        public int PasswordSuggestNonAlpha
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
    }
}
