using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Csharp
{
    class Program3
    {
        static void Main(string[] args)
        {
            var result = "";
            for (int i = 0; i < 5; i++)
            {
                var num = int.Parse(Console.ReadLine());
                result = (num > 0) ? "positive" : "negative";
                Console.WriteLine("corona virus test is " + result);
            }
        }
    }
}
