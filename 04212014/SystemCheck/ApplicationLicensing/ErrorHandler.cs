using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ApplicationLicensing
{
    class ErrorHandler
    {
        EventLog evl;

        public void ShowError(Exception ex, MessageBoxButtons msgBtns, MessageBoxIcon icon)
        {
            MessageBox.Show(ex.Message, Application.ProductName, msgBtns, icon);
            WriteToErrorLog(ex);
        }

        private void WriteToErrorLog(Exception ex)
        {
            StringBuilder sbErrorPrefix = new StringBuilder();
            sbErrorPrefix.Append("Application: " + Application.ProductName + Environment.NewLine);
            sbErrorPrefix.Append("Application Version: " + Application.ProductVersion + Environment.NewLine);
            sbErrorPrefix.Insert(0, "*", 8);
            sbErrorPrefix.Append(Environment.NewLine);
            sbErrorPrefix.Append("Application ");
            sbErrorPrefix.Insert(0, "*", 8);
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
