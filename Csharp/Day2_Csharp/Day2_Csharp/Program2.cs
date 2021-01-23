using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Csharp
{
    class Program2
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter value1");
                var num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter value2");
                var num2 = int.Parse(Console.ReadLine());
                var result = num1 / num2;
                Console.WriteLine("The Result is" + result);
            }
            catch (Exception e)
            {
                Console.WriteLine("The Exception is " + e.InnerException);
            }
            finally
            {
                Console.WriteLine("finally, closed!!");
            }
        }
    }
}
