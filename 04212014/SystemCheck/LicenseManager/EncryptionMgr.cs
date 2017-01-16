using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace LicenseManager
{
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
