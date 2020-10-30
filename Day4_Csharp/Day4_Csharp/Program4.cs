using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Csharp
{
    class Program4
    {
        static void Main(string[] args)
        {
            Teacher tch = new Teacher();
            Console.WriteLine($"Teacher Name { tch.getName()}");

            Console.WriteLine($"Teacher Number { tch.GetNumber()}");

            var x = tch.Getlogin("ammar", "123");
            Console.WriteLine("Hello," + x.name);
        }
    }
}
