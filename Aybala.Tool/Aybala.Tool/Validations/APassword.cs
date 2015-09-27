using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aybala.Tool.Validations
{
    public class APassword
    {
        private APassword() { }

        public static string PasswordControl(string input)
        {
            return PasswordControlProcess(input, 6, 16, false, false, false);
        }

        public static bool PasswordControlToBoolean(string input)
        {
            if (PasswordControlProcess(input, 6, 16, false, false, false) == "True")
                return true;
            return false;
        }

        public static string PasswordControl(string input,int minLenght,int maxLenght)
        {
            return PasswordControlProcess(input, minLenght, maxLenght, false, false, false);
        }

        public static bool PasswordControlToBoolean(string input, int minLenght, int maxLenght)
        {
            if (PasswordControlProcess(input, minLenght, maxLenght, false, false, false) == "True")
                return true;
            return false;
        }

        public static string PasswordControl(string input, int minLenght, int maxLenght,params char[] blokeCharackers)
        {
            return PasswordControlProcess(input, minLenght, maxLenght, false, false, false, blokeCharackers);
        }

        public static bool PasswordControlToBoolean(string input, int minLenght, int maxLenght, params char[] blokeCharackers)
        {
            if (PasswordControlProcess(input, minLenght, maxLenght, false, false, false, blokeCharackers) == "True")
                return true;
            return false;
        }

        public static string PasswordControl(string input, int minLenght, int maxLenght, bool isHaveBigCharacker, bool isHaveSmallCharacker, bool isHaveNumberCharacker, params char[] blokeCharackers)
        {
            return PasswordControlProcess(input, minLenght, maxLenght, isHaveBigCharacker, isHaveSmallCharacker, isHaveNumberCharacker, blokeCharackers);
        }

        public static bool PasswordControlToBoolean(string input, int minLenght, int maxLenght, bool isHaveBigCharacker, bool isHaveSmallCharacker, bool isHaveNumberCharacker, params char[] blokeCharackers)
        {
            if (PasswordControlProcess(input, minLenght, maxLenght, isHaveBigCharacker, isHaveSmallCharacker, isHaveNumberCharacker, blokeCharackers) == "True")
                return true;
            return false;
        }


        private static string PasswordControlProcess(string password, int minLenght, int maxLenght, bool isHaveBigCharacker, bool isHaveSmallCharacker, bool isHaveNumberCharacker, params char[] blokeCharackers)
        {
            try
            {
                if (password.Length < minLenght)
                    return "Parola Uzunluğu En Az " + minLenght + " Olmalıdır";

                if (password.Length > maxLenght)
                    return "Parola Uzunluğu En Fazla " + maxLenght + " Olmalıdır";

                if (blokeCharackers.Length > 0)
                {
                    foreach (char item in password)
                    {
                        foreach (char c in blokeCharackers)
                        {
                            if (item == c)
                                return "Parolanızda " + blokeCharackers.ToString() + " Karakterlerini Kullanamazsınız";
                        }
                    }
                }
                

                if (isHaveBigCharacker)
                {
                    int bigCharackerCount = 0;
                    foreach (var item in password)
                    {
                        if ((byte)item > 64 && (byte)item < 91)
                            bigCharackerCount++;
                    }
                    if (bigCharackerCount < 1)
                        return "Parolanızda En Az Bir Büyük Karakter Olmak Zorunda";
                }

                if (isHaveSmallCharacker)
                {
                    int smallCharackerCount = 0;
                    foreach (var item in password)
                    {
                        if ((byte)item > 96 && (byte)item < 123)
                            smallCharackerCount++;
                    }
                    if (smallCharackerCount < 1)
                        return "Parolanızda En Az Bir Küçük Karakter Olmak Zorunda";
                }

                if (isHaveNumberCharacker)
                {
                    int numberCharackerCount = 0;
                    foreach (var item in password)
                    {
                        if ((byte)item > 47 && (byte)item < 58)
                            numberCharackerCount++;
                    }
                    if (numberCharackerCount < 1)
                        return "Parolanızda En Az Bir Rakam Olmak Zorunda";
                }
                
                return "True";
            }
            catch (Exception)
            { return "False"; }
        }
    }
}
