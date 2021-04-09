using System;
using System.Numerics;

namespace Big_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "18456000000000000000";

            BigInteger bi = BigInteger.Parse(userInput);

            Console.WriteLine(bi.ToString("N0"));
        }
    }
}
