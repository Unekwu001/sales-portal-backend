using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utility
{
    public class Abbreviations
    {
        public static string GetLocationAbbreviation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return string.Empty;

            var words = location.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (words.Length < 2)
                return words[0].Substring(0, 1).ToUpper();

            return $"{words[0][0]}{words[1][0]}".ToUpper();
        }
    }
}
