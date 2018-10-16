using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePasswordManager
{
    public partial class StatusControl : UserControl
    {
        Timer t;

        public StatusControl()
        {
            InitializeComponent();

            t = new Timer { Interval = 3000 };
        }

        public  void SetStatus(string message, StatusType type = StatusType.Info, bool expires = true)
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

            if (expires)
            {
                t.Tick += (o, e) =>
                {
                    SetStatus("Ready.", StatusType.Info, false);
                    t.Stop();
                };
                t.Start();
            }

        }
    }

    public enum StatusType
    {
        Info,
        Success,
        Error
    }
}
