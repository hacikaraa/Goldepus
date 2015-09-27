using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aybala.Tool.Validations
{
    public class CitizenNumber
    {
        private CitizenNumber() { }

        public static bool IsValid(string citizenNumber,Nation nation = Nation.Turkey) 
        {
            switch (nation)
            {
                case Nation.Turkey: return Turkey(citizenNumber);
                default: return false;
            }
        }

        private static bool Turkey(string citizenNumber) 
        {
            TC tc = new TC();
            return
                AString.IsNumeric(citizenNumber) 
                &&
                tc.LastCharacterControl(citizenNumber) 
                &&
                tc.TenthCharacterControl(citizenNumber);
        }

    }

    public enum Nation 
    {
        Turkey = 0
    }

}
