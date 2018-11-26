using System;

namespace NumberConvertor
{
    public static class BetterNumberUtilities
    {
        #region Strings

        private static readonly string[] ones = {
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
            "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen",
            "eighteen", "nineteen"
        };

        private static readonly string[] tens = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        private static readonly string[] thousands = { "hundred", "thousand", "million", "billion", "trillion", "quadrillion" };

        #endregion Strings

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

            double intPortion = (double)number;
            int decPortion = 0;
            if(stringNumber.Contains(","))
            {
                var regex = new System.Text.RegularExpressions.Regex("(?<=[\\,])[0-9]+");
                string decimal_places = regex.Match(stringNumber).Value;
                decPortion = Convert.ToInt32(decimal_places);
            }
            
            return string.Format($"{ToWords(intPortion)} rand and {ToWords(decPortion)} cents");
        }
        #endregion Public Methods

        #region Private Methods

        private static string ToWords(double number, string appendScale = "")
        {
            string numString = "";

            if (number < 100)
            {
                if (number < 20)
                {
                    //Dont add the word zero if its led by a scale
                    if (!string.IsNullOrEmpty(appendScale) || (int)number != 0)
                    { numString = ones[(int)number]; }
                    else
                    { numString = "zero"; }
                }
                else
                {
                    numString = tens[(int)number / 10];
                    if ((number % 10) > 0)
                    {
                        if (!string.IsNullOrEmpty(appendScale) || (int)number % 10 != 0)
                        { numString += "-" + ones[(int)number % 10]; }
                    }
                }
            }
            else
            {
                double pow = 0;
                string powStr = "";

                if (number < 1000) // number is between 100 and 1000
                {
                    pow = 100;
                    powStr = thousands[0];
                }
                else // find the scale of the number
                {
                    int log = (int)Math.Log(number, 1000);//Potential future issue here if value grows lager than ints max
                    pow = Math.Pow(1000, log);
                    powStr = thousands[log];
                }

                numString = $"{ToWords(number / pow, powStr)} {ToWords(number % pow)}".Trim();
            }

            return $"{numString} {appendScale}".Trim();
        }

        #endregion Private Methods
    }
}