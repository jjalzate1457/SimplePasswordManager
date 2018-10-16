using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimplePasswordManager
{
    public partial class SessionLog : Form
    {
        public SessionLog()
        {
            InitializeComponent();

            FormClosing += SessionLog_FormClosing;
        }

        private void SessionLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        public void AddLog(string log)
        {
            textBox1.AppendText(log + Environment.NewLine);
        }
    }

    public class SessionLogger : IDisposable
    {
        List<string> logs;

        SessionLog w;

        public SessionLogger()
        {
            logs = new List<string>();

            w = new SessionLog();

            Log("New Session started.");
        }

        public void Show()
        {
            w.Show();
        }

        public void Log(string log)
        {
            string formattedLog = DateTime.Now.ToString("hh:mm:ss >>> ") + log;

            logs.Add(formattedLog);

            w.AddLog(formattedLog);
        }

        public void Dispose()
        {
            logs.Clear();
            logs = null;
        }
    }
}
