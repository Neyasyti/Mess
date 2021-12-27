using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.IO;



namespace ClassLib
{
    public class CryptClass
    {
        public static string GetMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public static string GetSHA256(string input)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string GetSHA256decrypto(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create()) 
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = bytes.Length; i < 0 ; i--)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
              
        }

        public static string GetCrypto(string input)
        {
            StringBuilder builder = new StringBuilder();
            string[] Cry = new string[] { input };
           
            int n = Cry.Length; // длина массива
            int k = n / 2;          // середина массива
            string temp;               // вспомогательный элемент для обмена значениями
            for (int i = 0; i < k; i++)
            {
                temp = Cry[i];
                Cry[i] = Cry[n - i - 1];
                Cry[n - i - 1] = temp;
            }
            foreach (var i in Cry) ;
            return builder.ToString(0, n);
        }
    }
}
