using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aybala.Tool.Validations
{
    class TC
    {
        public bool TenthCharacterControl(string IdentityNumber)
        {
            int odds = 0, evens = 0;
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 1)
                    odds += (Convert.ToInt32(IdentityNumber[i]) - 48);
                else
                    evens += (Convert.ToInt32(IdentityNumber[i]) - 48);
            }
            if ((((odds * 7) - evens) % 10) != (Convert.ToInt32(IdentityNumber[10]) - 48))
                return false;
            return true;
        }

        public bool LastCharacterControl(string IdentityNumber)
        {
            int firstTenCharacter = 0;
            for (int i = 0; i < 10; i++)
                firstTenCharacter += (Convert.ToInt32(IdentityNumber[i]) - 48);
            if ((firstTenCharacter % 10) != (Convert.ToInt32(IdentityNumber[10])) - 48)
                return false;
            return true;
        }
    }
}
