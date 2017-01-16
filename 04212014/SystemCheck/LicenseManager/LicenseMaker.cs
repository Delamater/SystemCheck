using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.IO;

namespace LicenseManager
{
    class LicenseMaker : ApplicationLicensing.LicenseCheck
    {
        #region "Declarations"
        ApplicationLicensing.LicenseCheck _alm = new ApplicationLicensing.LicenseCheck();

        //private override const char strDelimiter = '|';
        //private override const string strEncryptionPassword = "SageSystemCheckByBobDelamater1975$%!";
        ApplicationLicensing.NetworkManager _nic = new ApplicationLicensing.NetworkManager();
        

        //private override string _strPersonRequesting = string.Empty;
        //private override string _strMACID = string.Empty;
        //private DateTime _dtDateRequested;
        private string _strMachineName = string.Empty;
        #endregion


        ///// <summary>
        ///// Make a license file given certain requirements
        ///// </summary>
        ///// <param name="strPathToLicenseFile"></param>
        ///// <param name="PersonRequesting"></param>
        ///// <param name="LicensedUntil"></param>
        ///// <param name="MachineName"></param>
        ///// <returns>The path to the file</returns>
        //public void MakeLicenseKey(string strPathToLicenseFile, string PersonRequesting, DateTime LicensedUntil, string MachineName)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    //sb.Length = 256;
        //    //sb.EnsureCapacity(256);
        //    sb.Append(_nic.GetMACID());
        //    sb.Append(this.Delimiter);

        //    sb.Append(PersonRequesting);
        //    sb.Append(this.Delimiter);

        //    sb.Append(LicensedUntil);
        //    sb.Append(this.Delimiter);

        //    sb.Append(MachineName);
        //    sb.Append(this.Delimiter);

        //    //Write the file to disk, encrypted
        //    StreamWriter sw = new StreamWriter(strPathToLicenseFile, false);
        //    sw.Write(ApplicationLicensing.EncryptionMgr.Encrypt(sb.ToString(), this.EncryptionPassword));
        //    sw.Flush();
        //    sw.Close();
        //}

        /// <summary>
        /// Make a license file given certain requirements
        /// </summary>
        /// <param name="strPathToLicenseFile"></param>
        /// <param name="encryptedRequestString"></param>
        /// <param name="LicensedUntil"></param>
        public void MakeLicenseKey(string strPathToLicenseFile, string encryptedRequestString, DateTime LicensedUntil)
        {
            //First decrypt the string
            string[] strDecryptedRequestString = 
                ApplicationLicensing.EncryptionMgr.Decrypt(
                    encryptedRequestString, this.EncryptionPassword).Split(this.Delimiter);
            
            //Make a stringbuilder to build a license file
            StringBuilder sb = new StringBuilder();

            //MAC Address 
            sb.Append(strDecryptedRequestString[0]);
            sb.Append(this.Delimiter);

            //User Name
            sb.Append(strDecryptedRequestString[1]);
            sb.Append(this.Delimiter);

            sb.Append(LicensedUntil);
            sb.Append(this.Delimiter);

            //Machine Name
            sb.Append(strDecryptedRequestString[2]); 
            sb.Append(this.Delimiter);

            //Write the file to disk, encrypted
            StreamWriter sw = new StreamWriter(strPathToLicenseFile, false);
            sw.Write(ApplicationLicensing.EncryptionMgr.Encrypt(sb.ToString(), this.EncryptionPassword));
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
    }
}
