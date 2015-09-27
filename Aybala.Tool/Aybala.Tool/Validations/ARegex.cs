using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Aybala.Tool.Validations
{
    public class ARegex
    {
        private ARegex() { }

        public static bool IsMailFormat(string input) 
        {
            bool result = true;
            Regex regex = new Regex(@"^[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9_\-\.]+\.[a-zA-Z]{2,}$");
            if (!regex.IsMatch(input))
                result = false;
            return result;
        }

    }
}
