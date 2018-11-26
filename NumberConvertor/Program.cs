using System;

namespace NumberConvertor
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Good Enough Method");
            Console.WriteLine("------------------");
            Console.WriteLine("Please enter a number:");

            var stringNumber = Console.ReadLine();

            try
            {
                while (GoodEnoughNumberUtilities.IsNumeric(stringNumber))
                {
                    var englishWords = GoodEnoughNumberUtilities.ToWords(Convert.ToInt32(stringNumber));
                    Console.WriteLine(englishWords);
                    Console.WriteLine("Please enter another number:");
                    stringNumber = Console.ReadLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Oh no. That number is not good enough. Lets try something better.");
            }

            Console.WriteLine("------------------");
            Console.WriteLine("Better Method");
            Console.WriteLine("------------------");
            Console.WriteLine("Please enter a number:");

            stringNumber = Console.ReadLine();

            try
            {
                while (BetterNumberUtilities.IsNumericFromTryParse(stringNumber))
                {
                    Console.WriteLine(stringNumber.ToWords());
                    Console.WriteLine("Please enter another number:");
                    stringNumber = Console.ReadLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Oh no. That number is not even handled by the better method. Shame.");
            }

            Console.WriteLine("Done. Press Enter key to exit");
            Console.ReadLine();
        }
    }
}