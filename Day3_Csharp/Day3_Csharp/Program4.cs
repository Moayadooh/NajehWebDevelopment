using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Csharp
{
    class Program4
    {
        static void Main(string[] args)
        {
            Calc cls = new Calc() ;
            Console.WriteLine("Sum : " +  cls.Sum());
            Console.WriteLine("Sum by 2 numbers: " + cls.Sum(3,5));
            Console.WriteLine("Sum by 1 number and 1 String: " + cls.Sum(3, "100"));
            Console.WriteLine("Sum by 1 string and 1 number: " + cls.Sum("300", 5));
            Console.WriteLine("Concat 2 strings : " + cls.Sum("Ammar", "Yaser"));
        }
    }
}
