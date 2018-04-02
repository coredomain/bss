using System;
using bss.infrastructure;

namespace NumberToNounConsole
{
    class Program
    {
        private readonly NumberToNoun numberToNoun;
        private string numbers = "";
        public Program()
        {
            numberToNoun = new NumberToNoun();
        }
        static void Main(string[] args)
        {
            var start = new Program();
            Console.Write("Enter Numeric Value:  ");
            
            do
            {
                var info = Console.ReadKey();
                start.numbers += info.KeyChar;
                var numericValue = start.numbers;
                if (info.Key == ConsoleKey.Enter)
                {
                    var response = start.Ini(double.Parse(numericValue));
                    Console.WriteLine("");
                    Console.WriteLine(response);
                    Console.WriteLine();
                    Console.WriteLine(" -- Value Entered: --" + numericValue);
                    Console.WriteLine();
                    Console.Beep();
                    start.numbers = string.Empty;
                }

                
            } while (true);

        }
        private string Ini(double number)
        {
            var response = numberToNoun.Convert(number);
            return response;
        }
    }
}
