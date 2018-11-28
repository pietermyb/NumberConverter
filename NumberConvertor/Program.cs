using System;
using System.IO;
using NumberParser;

namespace NumberConvertorApp
{
    internal class Program
    {
        private static string _stringNumber = "";
        private static bool _keepRunning = true;

        private static void Main(string[] args)
        {
            var runMethod = "";

            Console.WriteLine("Choose a run method");
            Console.WriteLine("1: Good Enough");
            Console.WriteLine("2: Better");
            Console.WriteLine("3: From File");
            Console.WriteLine("exit: Exits app");

            runMethod = Console.ReadLine();

            while (runMethod != "exit" && _keepRunning)
            {
                switch (runMethod)
                {
                    case "1":
                        RunGoodEnough();
                        break;
                    case "2":
                        RunBetter();
                        break;
                    case "3":
                        RunFileInput();
                        break;
                }
            }

            Console.WriteLine("Done. Press Enter key to exit");
            Console.ReadLine();
        }

        private static void RunGoodEnough()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Good Enough Method");
            Console.WriteLine("------------------");
            Console.WriteLine("Please enter a number:");

            _stringNumber = Console.ReadLine();

            try
            {
                while (GoodEnoughNumberUtilities.IsNumeric(_stringNumber))
                {
                    var englishWords = GoodEnoughNumberUtilities.ToWords(Convert.ToInt32(_stringNumber));
                    Console.WriteLine(englishWords);
                    Console.WriteLine("Please enter another number:");
                    _stringNumber = Console.ReadLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Oh no. That number is not good enough. Lets try something better.");
            }

            _keepRunning = false;
        }

        private static void RunBetter()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Better Method");
            Console.WriteLine("------------------");
            Console.WriteLine("Please enter a number:");

            _stringNumber = Console.ReadLine();

            try
            {
                while (BetterNumberUtilities.IsNumericFromTryParse(_stringNumber))
                {
                    Console.WriteLine(_stringNumber.ToWords());
                    Console.WriteLine("Please enter another number:");
                    _stringNumber = Console.ReadLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Oh no. That number is not even handled by the better method. Shame.");
            }

            _keepRunning = false;
        }

        private static void RunFileInput()
        {
            const string numbersFile = "C:\\numbers.txt";
            var numbers = "";

            using (var sr = new StreamReader(numbersFile))
            {
                numbers = sr.ReadToEnd();
            }

            try
            {
                var lines = numbers.Split(Environment.NewLine);
                foreach (var line in lines)
                {
                    if (BetterNumberUtilities.IsNumericFromTryParse(line))
                    {
                        Console.WriteLine($"In: {line}");
                        Console.WriteLine($"Out: {line.ToWords()}");
                    }
                    else
                    {
                        Console.WriteLine($"{line} is not a number");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Oh no. That number is not even handled by the better method. Shame.");
                
            }

            _keepRunning = false;
        }
    }
}