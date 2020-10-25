using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Csharp
{
    class Program4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a value");
            int mark = int.Parse( Console.ReadLine());

            switch (mark)
            {
                case 10:
                    Console.WriteLine("10");
                    break;

                case 20:
                    Console.WriteLine("20");
                    break;

                case 30:
                    Console.WriteLine("30");
                    break;


                default:
                    Console.WriteLine("Not Found");
                    break;
            }
        }
    }
}
