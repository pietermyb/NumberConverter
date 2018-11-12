using System;

namespace NumberConvertor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Good Enough Method");
            Console.WriteLine("------------------");
            Console.WriteLine("Please enter a number:");

            var stringNumber = Console.ReadLine();

            while (GoodEnoughNumberUtilities.IsNumeric(stringNumber))
            {
                var englishWords = GoodEnoughNumberUtilities.NumberToWords(Convert.ToInt32(stringNumber));
                Console.WriteLine(englishWords);
                Console.WriteLine("Please enter another number:");
                stringNumber = Console.ReadLine();
            }

            Console.WriteLine("------------------");
            Console.WriteLine("Better Method");
            Console.WriteLine("------------------");
            Console.WriteLine("Please enter a number:");

            stringNumber = Console.ReadLine();
            
            while (BetterNumberUtilities.IsNumericFromTryParse(stringNumber))
            {
                Console.WriteLine(stringNumber.ToWords());
                Console.WriteLine("Please enter another number:");
                stringNumber = Console.ReadLine();
            }

            Console.WriteLine("Done. Press Enter key to exit");
            Console.ReadLine();
        }
    }
}
