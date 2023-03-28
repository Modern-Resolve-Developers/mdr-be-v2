using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Collections.Generic;
using System;

namespace danj_backend.Authentication
{
    public class DataAuth
    {
        public string Encrypt(string cleanText)
        {
            string EncryptionKey = "WTWKEYAPI1234567890";
            byte[] clearBytes = Encoding.Unicode.GetBytes(cleanText);
            using(Aes ecryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[8]);
                ecryptor.Key = pdb.GetBytes(32);
                ecryptor.IV = pdb.GetBytes(16);
                using(MemoryStream ms = new MemoryStream())
                {
                    using(CryptoStream cs = new CryptoStream(ms, ecryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    cleanText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return cleanText;
        }
        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "WTWKEYAPI1234567890";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using(Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[8]);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using(MemoryStream ms = new MemoryStream())
                {
                    using(CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
