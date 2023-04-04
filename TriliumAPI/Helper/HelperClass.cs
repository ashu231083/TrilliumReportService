using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TriliumAgent.Helper
{
    public class HelperClass
    {
        public string EncryptString(string text, string password, Encoding encoding)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                return text;
            }
            return Convert.ToBase64String(this.Encrypt(encoding.GetBytes(text), encoding.GetBytes(password)));
        }
        public byte[] Encrypt(byte[] data, byte[] password)
        {
            byte[] result;
            using (TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider())
            {
                using (System.Security.Cryptography.MD5CryptoServiceProvider mD5CryptoServiceProvider = new System.Security.Cryptography.MD5CryptoServiceProvider())
                {
                    byte[] array = mD5CryptoServiceProvider.ComputeHash(password);
                    byte[] array2 = new byte[24];
                    Buffer.BlockCopy(array, 0, array2, 0, array.Length);
                    Buffer.BlockCopy(array, 0, array2, array.Length, 8);
                    tripleDESCryptoServiceProvider.Key = array2;
                    tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
                    result = tripleDESCryptoServiceProvider.CreateEncryptor().TransformFinalBlock(data, 0, data.Length);
                }
            }
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            return result;
        }
    }
}
