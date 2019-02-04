using System;
using System.Security.Cryptography;
using System.Text;

namespace MainApp.AES
{
    class SimpleAES
    {
        AesCryptoServiceProvider cryptoServiceProvider;
        public SimpleAES()
        {   
            string key = "86B342D09EE161F05F1EFE72DA749C0F";
            string iv =  "25EFE2076D6B0C89";
            cryptoServiceProvider = new AesCryptoServiceProvider
            {
                BlockSize = 128,
                KeySize = 128,
                Key = Encoding.ASCII.GetBytes(key),
                IV = Encoding.ASCII.GetBytes(iv),
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };
        }

        public string Encrypt(string clearText)
        {
            ICryptoTransform transform = cryptoServiceProvider.CreateEncryptor();
            byte[] encryptedBytes = transform.TransformFinalBlock(Encoding.ASCII.GetBytes(clearText), 0, clearText.Length);
            return Convert.ToBase64String(encryptedBytes);
        }

        public string Decrpyt(string encryptedText)
        {
            ICryptoTransform transform = cryptoServiceProvider.CreateDecryptor();
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            byte[] decryptedBytes = transform.TransformFinalBlock(encryptedBytes, 0 , encryptedBytes.Length);
            return Encoding.ASCII.GetString(decryptedBytes);
        }
    }
}
