using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAPI.Config
{
    public class Function
    {
        public bool  isIdentityNoValid(string ID)
        {
            int stepControl = 0, sumOfOddDigits = 0, sumOfDoubleDigits = 0;
            if (ID.Length == 11) { stepControl = 1; }

            foreach (char chr in ID)
            {
                if (Char.IsNumber(chr)) { stepControl = 2; }
            }
            if (ID.Substring(0, 1) != "0") { stepControl = 3; }

            int[] arrID = System.Text.RegularExpressions.Regex.Replace(ID, "[^0-9]", "").Select(x => (int)char.GetNumericValue(x)).ToArray();

            for (int i = 0; i < ID.Length; i++)
            {
                if (((i + 1) % 2) == 0)
                {
                    if (i + 1 != 10)
                    { sumOfDoubleDigits += Convert.ToInt32(arrID[i]); }
                    else if (i + 1 != 11)
                    { sumOfOddDigits += Convert.ToInt32(arrID[i]); }
                }
            }

            if (Convert.ToInt32(ID.Substring(9, 1)) == (((sumOfOddDigits * 7) - sumOfDoubleDigits) % 10)) { stepControl = 4; }
            if (Convert.ToInt32(ID.Substring(10, 1)) == ((arrID.Sum() - Convert.ToInt32(ID.Substring(10, 1))) % 10)) { stepControl = 5;  }
            if (stepControl == 5) { return true; } else { return false; }
        }
    }
}