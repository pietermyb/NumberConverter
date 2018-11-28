using System;

namespace NumberParser
{
    public class GoodEnoughNumberUtilities
    {
        public static bool IsNumeric(string str)
        {
            try
            {
                str = str.Trim();
                var possibleNumber = double.Parse(str);
                return true;
            }
            catch (FormatException)
            {
                // Not a numeric value
                return false;
            }
        }

        public static string ToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + ToWords(Math.Abs(number));

            var words = "";

          

            if ((number / 1000000) > 0)
            {
                words += ToWords(number / 1000000) + " million ";
                number %= 1000000; //Reduce number size
            }

            if ((number / 1000) > 0)
            {
                words += ToWords(number / 1000) + " thousand ";
                number %= 1000; //Reduce number size
            }

            if ((number / 100) > 0)
            {
                words += ToWords(number / 100) + " hundred ";
                number %= 100; //Reduce number size
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var upToTeens = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += upToTeens[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + upToTeens[number % 10];
                }
            }

            return words;
        }
    }
}