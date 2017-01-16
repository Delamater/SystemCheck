using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace LicenseManager
{
    class ApplicationLicenseManager
    {
        public string LicensePath = Path.GetDirectoryName(Application.StartupPath + @"..\..\..\License\");
        private const string strLicenseFileName = "SystemCheck.ssc";
        private const char strDelimiter = '|';
        private const string strEncryptionPassword = "SageSystemCheckByBobDelamater";
        NetworkManager _nic = new NetworkManager();
        ErrorHandler _err = new ErrorHandler();
        
        #region "Declarations"
        private string _strPersonRequesting = string.Empty;
        private string _strMACID = string.Empty;
        private DateTime _dtDateRequested;
        #endregion

        #region "Properties"
        public string PersonRequesting
        {
            get { return _strPersonRequesting; }
            set { _strPersonRequesting = value; }
        }

        public string MacID
        {
            get { return _strMACID; }
            set { _strMACID = value; }
        }

        public DateTime DateLicensedUntil
        {
            get { return _dtDateRequested; }
            set { _dtDateRequested = value; }
        }

        public string ApplicationNotLicensedErrorMessage
        {
            get
            {
                return "This application is not licensed or the licensed has expired. Please contact your provider to obtain a new license";
            }
        }
        #endregion


        public Boolean IsLicensed()
        {
            try
            {
                FileInfo fi = GetLicenseKey();
                string strLicenseKeyContents = string.Empty;

                strLicenseKeyContents = ReadFileContents(fi);
                string[] strLicenseParts = EncryptionMgr.Decrypt(strLicenseKeyContents, strEncryptionPassword).Split(strDelimiter);

                this.MacID = strLicenseParts[0];
                this.PersonRequesting = strLicenseParts[1];
                this.DateLicensedUntil = Convert.ToDateTime(strLicenseParts[2]);

                //Enforce date restriction
                if (DateTime.Now > this.DateLicensedUntil)
                {
                    //Your license has expired
                    return false;
                }
            }
            catch (Exception ex)
            {
                _err.ShowError(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }

            //You are licensed
            return true;
        }

        private string ReadFileContents(FileInfo fi)
        {
      
            string strEncryptedLicense = string.Empty;
            StreamReader sr = new StreamReader(fi.FullName);
            strEncryptedLicense = sr.ReadToEnd();

            sr.Close();
            
            return strEncryptedLicense;
        }

        public FileInfo MakeLicenseKey(string PersonRequesting, DateTime LicensedUntil)
        {
            StringBuilder sb = new StringBuilder();
            //sb.Length = 256;
            //sb.EnsureCapacity(256);
            sb.Append(_nic.GetMACID());
            sb.Append(strDelimiter);

            sb.Append(PersonRequesting);
            sb.Append(strDelimiter);

            sb.Append(LicensedUntil);
            sb.Append(strDelimiter);

            string fileName = System.IO.Path.Combine(LicensePath,strLicenseFileName);
            StreamWriter sw = new StreamWriter(fileName, false);
            sw.Write(EncryptionMgr.Encrypt(sb.ToString(),strEncryptionPassword));
            sw.Flush();
            sw.Close();

            return new FileInfo(fileName);
            
        }
        
        private FileInfo GetLicenseKey()
        {
            string[] strFile = Directory.GetFiles(LicensePath, strLicenseFileName, SearchOption.AllDirectories);
            FileInfo fi = new FileInfo(strFile[0]);
            return fi;
        }


        public void StoreLicense()
        {
            throw new NotImplementedException();
        }

        public dsLicenseInfo.KeyHistoryDataTable GetLicenseHistory()
        {
            throw new NotImplementedException();
        }

        
    }
}
