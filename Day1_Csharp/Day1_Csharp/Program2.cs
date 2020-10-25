using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Csharp
{
    class Program2
    {
        static void Main(string[] args)
        {
            int a = 10;

           // a++;// increment in memory

            Console.WriteLine("a value is " + a++); // print out on screen
            Console.WriteLine("a value is " + a); // print out on screen

            int b = 5;
            b--; // decrement in memory
            Console.WriteLine("b value is " + b--); // print out on screen
            Console.WriteLine("b value is " + b); // print out on screen
            //=================================================================

            int c = 100;
            ++c; // print out increment by one 
            Console.WriteLine("c value is " + c); // increment in memory
            //=====================================================================
            Console.WriteLine("======================================================");
            int salary = 1000;
            salary++;  // in memory 1001
            Console.WriteLine("salary is in first line " + salary); // 1001
            Console.WriteLine("salary is in second line " + salary++); // 1002 in memory // on screen 1001
            Console.WriteLine("salary is in third line " + salary); // 1002 on screen
            ++salary;
            Console.WriteLine("salary is in fourth line " + salary); // memory and screen 1003
            Console.WriteLine("salary is in fifth line " + ++salary); // memory and screen 1004
            Console.WriteLine("salary is in sixth line " + ++salary); // 1005 on screen
            Console.WriteLine("salary is in seventh line " + salary); // 1005 from memory
        }
    }
}
