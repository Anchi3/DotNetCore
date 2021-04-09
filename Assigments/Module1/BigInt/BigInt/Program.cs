using System;
using System.IO;
using System.Numerics;

namespace BigInt
{
    class Program
    {
        public static string LargeToWords(int value)
        {
            string[] largeMap = new[]
                { "", "thousand", "million", "billion", "trillion", 
                "quadrillion", "quintillion", "sextillion", "septillion", 
                "octillion", "nonillion", "decillion" };


            return largeMap[value];
        }

        public static string Words(BigInteger number)
        {
            string[] inThrees = number.ToString("N0").Split(",");
            string res = string.Empty;

            for (int i = 0; i < inThrees.Length; i++)
            {
                if (inThrees[i] != "000")
                {
                    res += !string.IsNullOrEmpty(res) ? ", " : "";
                    res += ToWords(inThrees[i]);
                    res += " " + LargeToWords(inThrees.Length - i - 1);
                }
            }
            return res;
        }

        public static string ToWords(string part)
        { 
            part = part.PadLeft(3, '0');
            
            string[] unitsMap = new[] 
                { "", "one", "two", "three", "four", "five", "six",
                "seven", "eight", "nine", "ten", "eleven", "twelve", 
                "thirteen", "fourteen", "fifteen", "sixteen", 
                "seventeen", "eighteen", "nineteen" };

            string[] tensMap = new[]
                { "", "ten", "twenty", "thirty", "forty", "fifty", 
                "sixty", "seventy", "eighty", "ninety" };

           
            int index;
            string result = string.Empty;

            if(part[0] != '0') // transform hundreds
            {
                index = Convert.ToInt32(part[0].ToString());
                result = unitsMap[index] + " hundred";
            }

            string tens = string.Empty;

            if(part[1] == '1') // transform teens 11, 12, 13, 14... 19
            {
                index = Convert.ToInt32(part[1].ToString() + part[2].ToString());
                tens = unitsMap[index];

                result += string.IsNullOrEmpty(result) ? "" : " and ";
                result += tens;

                return result;
            }

            else if(part[1] != '0') // if not 0 or teen; tens
            {
                index = Convert.ToInt32(part[1].ToString());
                tens = tensMap[index];
            }

            string ones = string.Empty;

            if(part[2] != '0') // transform ones
            {
                index = Convert.ToInt32(part[2].ToString());
                ones = unitsMap[index];
            }

            result += !string.IsNullOrEmpty(result) 
                      && !string.IsNullOrEmpty(tens) ? " and " : "";
            result += tens;

            result += !string.IsNullOrEmpty(result)
                      && string.IsNullOrEmpty(tens)
                      && !string.IsNullOrEmpty(ones) ? " and " : "";
          
            result += !string.IsNullOrEmpty(tens)
                      && !string.IsNullOrEmpty(ones) ? "-" : "";
            result += ones;

            return result;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an integer: ");

            BigInteger bi = BigInteger.Parse(Console.ReadLine());

            //BigInteger bi = 18456000000000000000



            string[] inThrees = bi.ToString("N0").Split(","); 

            Console.WriteLine(  "\n=======================================\n" +
                                Words(bi) + "\n=======================================\n\n" + 
                                "Thank you for using the Number To Word Converter. " +
                                "\nHave a great day!!!");
            
        }
    }
}
