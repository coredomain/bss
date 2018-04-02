using bss.Data;
using System;

namespace bss.infrastructure
{
    public class NumberToNoun
    {
        private readonly NounUnitData nounUnit;
        /// <summary>
        /// Biggest number 32 bit 2147483648 {0.0.0.0} array of 4
        /// Representation of The 32nd bit that remains in 4 byte of given number
        /// </summary>
        /// ///

        public NumberToNoun()
        {
            nounUnit = new NounUnitData();
        }
        /// <summary>
        /// Recursion 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string Convert(int number){
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + Convert(Math.Abs(number));

            string noun = "";
            //divide a wholenumber by power of 10 add on 0's to find bigger numbers
            //Whole number, separate as many decimal digits as there are 0 in the power
            if ((number / 1000000) > 0){
                noun += Convert(number / 1000000) + " " + nounUnit.FatUni[3] + " ";
                //Computes the remainder of  
                number %= 1000000;
            }

            if ((number / 1000) > 0){
                noun += Convert(number / 1000) + " " + nounUnit.FatUni[2] + " ";
                //Computes the remainder of 
                number %= 1000;
            }

            if ((number / 100) > 0){
                noun += Convert(number / 100) + " " + nounUnit.HundredUnit[0] + " ";
                //Computes the remainder of
                number %= 100;
            }
            if (number > 0){
                if (noun != "")
                    noun += "and ";

                if (number < 20)
                    noun += nounUnit.Unit[number];
                else{
                    noun += nounUnit.TensUnit[number / 10];
                    if ((number % 10) > 0)
                        noun += " " + nounUnit.Unit[number % 10];
                }
            }

            return noun;
        }
        private string Convert(string number)
        {

            var Count = 0;
            var noun = "";
            //if number lenght not grater than 3
            if (number.Length <= 3)
            {
                return Convert(int.Parse(number));
            }
            //Last 3 Digit iteration 
            while (number.Length > 0)
            {
                string lastDigits = number.Length < 3 ? number : number.Substring(number.Length - 3);
                number = number.Length < 3 ? "" : number.Remove(number.Length - 3);
                var numbers = int.Parse(lastDigits);
                lastDigits = Convert(numbers);
                lastDigits += " "+ nounUnit.FatUni[Count] + " ";
                noun = lastDigits + noun;
                Count++;
            }
            return noun;
        }
        public string Convert(double number)
        {
            var wholeNumber = "";
            if (ValidateIntegerIsWhole(number))
            {
                wholeNumber = Convert(number.ToString());
                return wholeNumber;
            }
            else
            {
                ///Decimal Round precision 2
                string[] ret = Math.Round(number, 2).ToString().Split('.');
                return this.Convert(int.Parse(ret[0])) + " " + ret[1] + "/100";
            }            
        }
        private static bool ValidateIntegerIsWhole(double Value)
        {
            return Math.Abs(Value % 1) < double.Epsilon;
        }
    }

}
