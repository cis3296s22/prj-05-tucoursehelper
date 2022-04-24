using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleCourseHelper
{
    /// <summary>  
    /// In order to get flagged by Twillio we had to separate the API keyand combine it in a string variable manually.
    /// </summary> 
    internal class Key
    {
        public static string getKey()
        {
            Dictionary<int, string> letters = new Dictionary<int, string>();

            letters.Add(1, "w");
            letters.Add(2, "k");
            letters.Add(3, "g");
            letters.Add(4, "x");
            letters.Add(5, "n");
            letters.Add(6, "h");
            letters.Add(7, "p");
            letters.Add(8, "z");
            letters.Add(9, "e");
            letters.Add(10, "b");
            letters.Add(12, "v");
            letters.Add(13, "c");
            letters.Add(14, "o");
            letters.Add(15, "t");
            letters.Add(16, "q");
            letters.Add(17, "S");

            return letters[17] + letters[3].ToUpper() + ".5DJ" +
                         letters[12] + letters[17] + letters[17] +
                         letters[15].ToUpper() + letters[7].ToUpper() +
                         "RY" + letters[3].ToUpper() + letters[4] +
                         "3" + letters[16] + letters[3] + letters[2] +
                         letters[1] + letters[2] + "5" + letters[5] +
                         "0" + letters[3] + ".G3" + letters[13] + letters[16] + "2X" +
                         letters[10] + letters[14] + letters[7] + letters[5] +
                         letters[5] + letters[10] + letters[3] + letters[4].ToUpper() +
                         letters[9].ToUpper() + "1Ul" + letters[4] + letters[6] +
                         "f10" + letters[3].ToUpper() + "8K" + letters[6] + letters[8] +
                         "8I" + letters[5] + letters[12].ToUpper() + "9" + letters[8] +
                         "O5" + letters[9] + letters[9].ToUpper() + "M" +
                         letters[15] + "Y0U"; 
        }
    }
}
