using System;
using System.Text.RegularExpressions;

namespace Module1
{
    class Program
    {

        public static void PrintIsMatch(string input, string pattern)
        {
            Regex reg = new Regex($@"^{pattern}$");
            Console.WriteLine($"{input} matches ^{pattern}? {reg.IsMatch(input)}");
        }
        

        public static void Main(string[] args)
        {

            Console.WriteLine("The default regular expression checks for at least one digit.");

            ConsoleKeyInfo cki = Console.ReadKey();

            while (cki.Key != ConsoleKey.Escape)
            {
                string pattern = "\\d+$";
                Console.WriteLine("Enter a regular expression (or press ENTER to use the default):");
                cki = Console.ReadKey();

                if (cki.Key != ConsoleKey.Enter)
                {
                    pattern = Console.ReadLine(); 
                }

                Console.WriteLine("Enter some input: ");
                string input = Console.ReadLine();

                PrintIsMatch(input, pattern);

                Console.WriteLine("Press ESC to end or any key to try again. ");
                cki = Console.ReadKey();
            }
            
            Console.WriteLine("\nHave a great day!!!");
          
        }
    }
}
