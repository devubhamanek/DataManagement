using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataMangement.Encryption
{
    public static class CryptoEngine
    {
        private readonly static string key = "_mt";

        public static string Encrypt(string input)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(input);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
        public static string Decrypt(string input)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(input);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }
    }
}
