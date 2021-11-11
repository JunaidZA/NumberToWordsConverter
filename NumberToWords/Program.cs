using System;

namespace NumberToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a value: ");
            var input = Console.ReadLine();

            if (long.TryParse(input, out var number))
            {
                try
                {
                    Console.WriteLine(NumberToWords(number));
                }
                catch
                {
                    Console.WriteLine("There was an error generating the text for the number entered.");
                }
            }
            else
            {
                Console.WriteLine("Invalid number entered.");
            }
        }

        /// <summary>
        /// Original taken from StackOverflow: https://stackoverflow.com/questions/2729752/converting-numbers-in-to-words-c-sharp
        /// Converts numbers into words
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string NumberToWords(long number)
        {
            if (number == 0)
            {
                return "zero";
            }

            if (number < 0)
            {
                return "minus " + NumberToWords(Math.Abs(number));
            }

            string words = "";

            if ((number / 1000000000000) > 0)
            {
                words += NumberToWords(number / 1000000000000) + " trillion ";
                number %= 1000000000000;
            }

            if ((number / 1000000000) > 0)
            {
                words += NumberToWords(number / 1000000000) + " billion ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                {
                    words += "and ";
                }

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                {
                    words += unitsMap[number];
                }
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }

            return words;
        }
    }
}
