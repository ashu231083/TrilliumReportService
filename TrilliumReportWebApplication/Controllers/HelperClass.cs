using System.Security.Cryptography;
using System.Text;

namespace TrilliumReportWebApplication.Controllers
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
                using (XSystem.Security.Cryptography.MD5CryptoServiceProvider mD5CryptoServiceProvider = new XSystem.Security.Cryptography.MD5CryptoServiceProvider())
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
