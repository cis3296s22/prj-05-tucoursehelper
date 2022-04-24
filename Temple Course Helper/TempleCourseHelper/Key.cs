using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleCourseHelper
{
    internal class Key
    {
        public static string getKey()
        {
            Dictionary<int, string> letters = new Dictionary<int, string>();

            letters.Add(1, "n");
            letters.Add(2, "k");
            letters.Add(3, "m");
            letters.Add(4, "a");
            letters.Add(5, "v");
            letters.Add(6, "y");
            letters.Add(7, "c");
            letters.Add(8, "j");
            letters.Add(9, "w");
            letters.Add(10, "z");
            letters.Add(12, "e");
            letters.Add(13, "u");
            letters.Add(14, "d");
            letters.Add(15, "g");
            letters.Add(16, "p");
            letters.Add(17, "i");

            return "S" + letters[15].ToUpper() + "." + letters[7] +
                   "RD6" + letters[2] + letters[16] + letters[17] +
                   letters[5].ToUpper() + "Qz" + letters[15].ToUpper() +
                   "G6" + letters[14] + letters[13].ToUpper() + "_" +
                   letters[7].ToUpper() + "On" + letters[2].ToUpper() +
                   "SA." + letters[14] + "_" + letters[5].ToUpper() + "VF" +
                   letters[4] + letters[14].ToUpper() + "QJ" +
                   letters[13] + letters[4] + letters[12] + "eC" + letters[4] +
                   letters[8].ToUpper() + "7d" + letters[14] + letters[2] +
                   letters[7] + "ByU" + letters[13] + "7W" + letters[9] +
                   letters[6] + letters[4].ToUpper() + "QF4S" + letters[5] +
                   letters[3] + letters[8] + letters[14].ToUpper() + "s" +
                   letters[15] + letters[10] + "ss";
        }
    }
}
