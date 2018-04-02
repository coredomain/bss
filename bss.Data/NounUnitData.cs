using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bss.Data
{
    public class NounUnitData
    {
        private string[] tenUnit = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private string[] fatUnit = { "", " Thousand ", " Million ", " Billion " };
        private string[] hundredUnit = { "Hundred" };
        private string[] unit = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

        public string[] Unit { get { return unit; } set { unit = value; } }
        public string[] TensUnit { get { return tenUnit; } set { tenUnit = value; } }
        public string[] FatUni { get { return fatUnit; } set { fatUnit = value; } }
        public string[] HundredUnit { get { return hundredUnit; } set { hundredUnit = value; } }

    }
    
}
