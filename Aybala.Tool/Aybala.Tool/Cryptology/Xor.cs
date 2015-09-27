using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aybala.Tool.Cryptology
{
    public class Xor
    {
        private Xor() { }

        public static string GetXor(string input, char key) 
        {
            string output = string.Empty;
            GetXor(input, key, out output);
            return output;
        }

        public static void GetXor(string input, char key, out string output)
        {
            try
            {
                string xorData = string.Empty;
                foreach (char item in input)
                    xorData += ((char)((byte)key ^ (byte)(item))).ToString();
                output = xorData;
            }
            catch (Exception ex)
            {
                throw new Exception("Xor Oluşturulurken Hata Oluştu. Hata : " + ex.Message);
            }
        }

        public static string GetXor(string input, string key)
        {
            string output = string.Empty;
            GetXor(input, key, out output);
            return output;
        }

        public static void GetXor(string input, string key, out string output)
        {
            try
            {
                char xorKey = (char)0x00;
                 foreach (char item in key)
                     xorKey = ((char)((byte)xorKey ^ (byte)(item)));
                string xorData = string.Empty;
                foreach (char item in input)
                    xorData += ((char)((byte)xorKey ^ (byte)(item))).ToString();
                output = xorData;
            }
            catch (Exception ex)
            {
                throw new Exception("Xor Oluşturulurken Hata Oluştu. Hata : " + ex.Message);
            }
        }

    }
}
