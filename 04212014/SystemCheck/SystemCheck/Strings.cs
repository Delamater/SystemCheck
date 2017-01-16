using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SystemCheck
{
    public class Strings : Utilities
    {
        //String Constants
        public const string NotLoggedIn = "Unable to complete request. Please successfully log in first.";
        public const string kPhysicalMemoryCouldNotBeDetected = "Phsyical memory could not be detected.";
        
        //Error Codes
        public const string kWin32ProductInvalidClass = 
            "The Win32_Product WMI query may not be possible. Some operating systems require Management "
            + "and Monitoring Tools installed within the Add/Remove Windows Components";
        
        //Routine Messages
        public const string kCheckListDatatableIsEmpty =
            "The checklist data table has not been populated. Please execute the "
            + "checklist queries to get the necessary data for this request.";
        public const string kCompanyNameIsRequired =
            "The company name is required";

        public enum enumCategory { Configuration, Performance, Operation, Patching, All };
        public enum enumCodeType { SQL, Powershell, VbScript };
        public string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        public string CodePath = Path.GetDirectoryName(Application.StartupPath + @"..\..\..\Code\");

        public string MinTsqlCompatibilityVersion = "9.0";
        private static string _strLicenseFileName = @"SystemCheck.ssc";
        private static string _strLicenseFilePath = 
            Path.GetDirectoryName(Application.StartupPath + @"..\..\..\License\");

        public static string LicenseFileFullPath
        {
            get
            {
                return Path.Combine(_strLicenseFilePath, _strLicenseFileName);
            }
        }

        public static string LicenseFileName
        {
            get { return _strLicenseFileName; }
        }
        
        public string configurationSqlCodePath =
            Path.GetDirectoryName(
                Path.GetDirectoryName(Application.ExecutablePath) + @"\Configuration\");
        
        public string operationSqlCodePath =
            Path.GetDirectoryName(
                Path.GetDirectoryName(Application.ExecutablePath) + @"\Operation");
        
        public string performanceSqlCodePath =
            Path.GetDirectoryName(
                Path.GetDirectoryName(Application.ExecutablePath) + @"\Performance");


        public static class ChecklistIDs
        {
            public const int kSystemExperiencedUnexpectedShutdowns = 17;


        }

        public class Utilies
        {
            public object ParseString(string str)
            {
                int intValue;
                double doubleValue;
                char charValue;
                bool boolValue;

                if (int.TryParse(str, out intValue))
                    return intValue;
                else if (double.TryParse(str, out doubleValue))
                    return intValue;
                else if (char.TryParse(str, out charValue))
                    return intValue;
                else if (bool.TryParse(str, out boolValue))
                    return intValue;

                return null;
            }
        }
    }
}
