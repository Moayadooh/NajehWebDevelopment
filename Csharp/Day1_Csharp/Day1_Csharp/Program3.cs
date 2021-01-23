using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Csharp
{
    class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a double Price please:"); // info for end user

            //Int32 x = 5;
            //int y = 5;

            double Price = double.Parse(Console.ReadLine()); // input
            double tax = Price * 0.16; // process
            double result = Price + tax; // process
            Console.WriteLine("The Tax is " + tax); // output
            Console.WriteLine("The Result is " + result); // output
            // == !=   >=  <=  > < 
            if (result >= 4000)
            {
                Console.WriteLine("Too much");
            }
            else if(result >= 3000)
            {
                Console.WriteLine("Good");
            }
            else
            {
                Console.WriteLine("not bad");
            }
        }
    }
}
