using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SystemCheck
{
    class ErrorHandler
    {
        EventLog evl;

        public void ShowError(Exception ex, MessageBoxButtons msgBtns, MessageBoxIcon icon)
        {
            MessageBox.Show(ex.Message, Application.ProductName, msgBtns, icon);
            WriteToErrorLog(ex);
        }

        public void ShowMessage(string Message, MessageBoxButtons msgBtns, MessageBoxIcon icon)
        {
            MessageBox.Show(Message, Application.ProductName, msgBtns, icon);
        }

        public void WriteToErrorLog(Exception ex)
        {
            StringBuilder sbErrorPrefix = new StringBuilder();
            sbErrorPrefix.Append("Application: " + Application.ProductName + Environment.NewLine);
            sbErrorPrefix.Append("Application Version: " + Application.ProductVersion + Environment.NewLine);
            sbErrorPrefix.Insert(0,"*", 8);
            sbErrorPrefix.Append(Environment.NewLine);
            sbErrorPrefix.Append("Application ");
            sbErrorPrefix.Insert(0,"*",8);
            sbErrorPrefix.Append("has encountered the following error" + Environment.NewLine);
            sbErrorPrefix.Append(Environment.NewLine);
            sbErrorPrefix.Append(ex.Message);
            sbErrorPrefix.Append(Environment.NewLine);
            sbErrorPrefix.Append(ex.StackTrace);

            evl = new EventLog();
            evl.Source = "Application";
            evl.WriteEntry(sbErrorPrefix.ToString(), EventLogEntryType.Error, 9999);

        }
    }
}
