using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Aybala.Tool.Cryptology
{
    public class MD5
    {
        private MD5() { }

        public static string MD5Create(string input)
        {
            string md5Data = string.Empty;
            using (System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create())
            {
                byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                    sBuilder.Append(data[i].ToString("x2"));
                md5Data = sBuilder.ToString();
            }
            return md5Data;
        }

    }
}
