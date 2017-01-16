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

        public string MachineName
        {
            get { return _strMachineName; }
            set { _strMachineName = value; }
        }

        public string ApplicationNotLicensedErrorMessage
        {
            get
            {
                return "This application is not licensed or the licensed has expired. Please contact your provider to obtain a new license";
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
                throw ex;
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

        /// <summary>
        /// Make a license file given certain requirements
        /// </summary>
        /// <param name="strPathToLicenseFile"></param>
        /// <param name="PersonRequesting"></param>
        /// <param name="LicensedUntil"></param>
        /// <param name="MachineName"></param>
        /// <returns>The path to the file</returns>
        public void MakeLicenseKey(string strPathToLicenseFile, string PersonRequesting, DateTime LicensedUntil, string MachineName)
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

            sb.Append(MachineName);
            sb.Append(strDelimiter);

            //Write the file to disk, encrypted
            StreamWriter sw = new StreamWriter(strPathToLicenseFile, false);
            sw.Write(EncryptionMgr.Encrypt(sb.ToString(), strEncryptionPassword));
            sw.Flush();
            sw.Close();
        }
    }
    
    class NetworkManager
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
