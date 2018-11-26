using System;

namespace NumberConvertor
{
    public static class BetterNumberUtilities
    {
        #region Strings 

        private static readonly string[] ones = {
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
            "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen",
        };

        private static readonly string[] tens = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        private static readonly string[] thousands = { "hundred", "thousand", "million", "billion", "trillion", "quadrillion" };

        #endregion

        #region Public Methods

        public static bool IsNumericFromTryParse(string str)
        {
            return double.TryParse(str, System.Globalization.NumberStyles.Float,
                    System.Globalization.NumberFormatInfo.CurrentInfo, out double result);
        }

        public static string ToWords(this string stringNumber)
        {
            var number = Convert.ToDecimal(stringNumber);

            if (number < 0)
            { return "negative " + ToWords(Math.Abs(number).ToString()); }

            int intPortion = (int)number;
            int decPortion = (int)((number - intPortion) * (decimal)100);

            return string.Format($"{ToWords(intPortion)} rand and {ToWords(decPortion)} cents");
        } 

        #endregion

        #region Private Methods

        private static string ToWords(int number, string appendScale = "")
        {
            string numString = "";
            if (number < 100)
            {
                if (number < 20)
                {
                    numString = ones[number];
                }
                else
                {
                    numString = tens[number / 10];
                    if ((number % 10) > 0)
                        numString += "-" + ones[number % 10];
                }
            }
            else
            {
                int pow = 0;
                string powStr = "";

                if (number < 1000) // number is between 100 and 1000
                {
                    pow = 100;
                    powStr = thousands[0];
                }
                else // find the scale of the number
                {
                    int log = (int)Math.Log(number, 1000);
                    pow = (int)Math.Pow(1000, log);
                    powStr = thousands[log];
                }

                numString = $"{ToWords(number / pow, powStr)} {ToWords(number % pow)}".Trim();
            }

            return $"{numString} {appendScale}".Trim();
        } 
        #endregion
    }
}