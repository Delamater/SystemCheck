using System;
using System.Text;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace ApplicationLicensing
{
    public class LicenseCheck
    {       
        #region "Declarations"
        
        private const char strDelimiter = '|';
        private const string strEncryptionPassword = "SageSystemCheckByBobDelamater";
        NetworkManager _nic = new NetworkManager();
        
        private string _strPersonRequesting = string.Empty;
        private string _strMACID = string.Empty;
        private DateTime _dtDateRequested;
        private string _strMachineName = string.Empty;
        #endregion

        #region "Properties"

        public char Delimiter
        {
            get { return strDelimiter; }
        }

        public string EncryptionPassword
        {
            get { return strEncryptionPassword; }
        }

        public string UserDomainName
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

        public string MachineName
        {
            get { return _strMachineName; }
            set { _strMachineName = value; }
        }

        public string ApplicationNotLicensedErrorMessage
        {
            get
            {
                return
                    "This application is not licensed or the licensed has expired. "
                    + "Please contact your provider to obtain a new license. "
                    + "A request string has been copied to your clipboard. "
                    + "Email this to your provider to request a new license"
                    + Environment.NewLine
                    + Environment.NewLine
                    + "The application will now close.";
            }
        }

        #endregion


        /// <summary>
        /// Given the path to the license file, this routine will provide a boolean 
        /// response on whether or not your system is licensed properly
        /// </summary>
        /// <param name="strPathToLicenseFile"></param>
        /// <returns>True/False</returns>
        public Boolean IsLicensed(string strPathToLicenseFile)
        {
            try
            {
                FileInfo fi = new FileInfo(strPathToLicenseFile);
                string strLicenseKeyContents = string.Empty;

                strLicenseKeyContents = ReadFileContents(fi);
                SetLicenseParts(strLicenseKeyContents);

                //Enforce date restriction
                if (DateTime.Now > this.DateLicensedUntil)
                {
                    //Your license has expired
                    return false;
                }

                if (this.MachineName != Environment.MachineName)
                {
                    //Your license has expired
                    return false;
                }

                if (this.MacID != _nic.GetMACID())
                {
                    //Your license has expired
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //You are licensed
            return true;
        }

        /// <summary>
        /// Resets properties 
        /// </summary>
        public void Clear()
        {
            this.MachineName = null;
            this.UserDomainName = null;
            this.MacID = null;
        }

        public void SetLicenseParts(string encryptedRequestString)
        {
            string[] strLicenseParts = EncryptionMgr.Decrypt(encryptedRequestString, this.EncryptionPassword).Split(this.Delimiter);

            this.MacID = strLicenseParts[0];
            this.UserDomainName = strLicenseParts[1];
            this.DateLicensedUntil = Convert.ToDateTime(strLicenseParts[2]);
            this.MachineName = strLicenseParts[3];
        }


        private string ReadFileContents(FileInfo fi)
        {

            string strEncryptedLicense = string.Empty;
            StreamReader sr = new StreamReader(fi.FullName);
            strEncryptedLicense = sr.ReadToEnd();

            sr.Close();

            return strEncryptedLicense;
        }

        /// <summary>
        /// This routine is intended to be called by an application requesting a new license
        /// </summary>
        /// <returns></returns>
        public string RequestLicense()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_nic.GetMACID());
            sb.Append(this.Delimiter);

            sb.Append(Environment.UserDomainName + @"\" + Environment.UserName);
            sb.Append(this.Delimiter);

            sb.Append(Environment.MachineName);
            sb.Append(this.Delimiter);

            return EncryptionMgr.Encrypt(sb.ToString(), this.EncryptionPassword);
        }
    }
    
    public class NetworkManager
    {
        public string GetMACID()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            // Only check the first NIC card
            NetworkInterface adapter = nics[0];
            IPInterfaceProperties properties = nics[0].GetIPProperties();

            return adapter.GetPhysicalAddress().ToString();
        }
    }

    public static class EncryptionMgr
    {

        private static readonly byte[] salt = Encoding.ASCII.GetBytes("This is my salt password - delamater - 75");

        public static string Encrypt(string textToEncrypt, string encryptionPassword)
        {
            var algorithm = GetAlgorithm(encryptionPassword);

            byte[] encryptedBytes;
            using (ICryptoTransform encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV))
            {
                byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(textToEncrypt);
                encryptedBytes = InMemoryCrypt(bytesToEncrypt, encryptor);
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string encryptedText, string encryptionPassword)
        {
            var algorithm = GetAlgorithm(encryptionPassword);

            byte[] descryptedBYtes;
            using (ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV))
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                descryptedBYtes = InMemoryCrypt(encryptedBytes, decryptor);
            }

            return Encoding.UTF8.GetString(descryptedBYtes);
        }



        /// <summary>
        /// Performs an in-memory encrypt/decrypt transformation on a byte array
        /// </summary>
        /// <param name="data"></param>
        /// <param name="transform"></param>
        /// <returns></returns>
        private static byte[] InMemoryCrypt(byte[] data, ICryptoTransform transform)
        {
            MemoryStream memory = new MemoryStream();
            using (Stream stream = new CryptoStream(memory, transform, CryptoStreamMode.Write))
            {
                stream.Write(data, 0, data.Length);
            }

            return memory.ToArray();
        }


        /// <summary>
        /// Defines a RijndaelManaged algorithm and sets its key and initialization Vector (IV)
        /// values based on the encryptionPassword received
        /// </summary>
        /// <param name="encryptionPassword"></param>
        /// <returns></returns>
        private static RijndaelManaged GetAlgorithm(string encryptionPassword)
        {
            // Create an encryption key from the encryptionPassword and salt
            var key = new Rfc2898DeriveBytes(encryptionPassword, salt);

            // Declare that we are going to use the Rinjdael algorithim with the key that we've just got
            var algorithm = new RijndaelManaged();
            int bytesForKey = algorithm.KeySize / 8;
            int bytesForIV = algorithm.BlockSize / 8;
            algorithm.Key = key.GetBytes(bytesForKey);
            algorithm.IV = key.GetBytes(bytesForIV);
            return algorithm;
        }

    }
}
