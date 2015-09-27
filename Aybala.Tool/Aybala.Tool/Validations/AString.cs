using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aybala.Tool.Validations
{
    public class AString
    {
        private AString() { }

        public static bool IsNotEmpty(params string[] input)
        {
            bool result = true;
            foreach (var item in input)
            {
                if (String.IsNullOrEmpty(item))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static bool IsNullOrWhiteSpace(params string[] input)
        {
            bool result = true;
            foreach (var item in input)
            {
                if (String.IsNullOrWhiteSpace(item))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static bool IsNumeric(string input)
        {
            bool result = true;
            foreach (char chr in input)
            {
                if (!Char.IsNumber(chr))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static bool IsNumeric(params string[] input)
        {
            bool result = true;
            foreach (var item in input)
            {
                if (IsNumeric(item)) 
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}
