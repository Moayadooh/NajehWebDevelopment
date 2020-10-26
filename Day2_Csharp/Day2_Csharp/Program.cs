using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool checknum = false;
            string result = "";
            Console.WriteLine("Enter number");
            int num = int.Parse(Console.ReadLine());
            //if (num % 2 == 0)
            //{
            //    checknum = true;
            //}
            //else
            //{
            //    checknum = false;
            //}
            //======================================================
            checknum = (num % 2 == 0) ? true : false;
            result = (num % 2 == 0) ? "even" : "odd";
            //======================================================
            Console.WriteLine("The value of " + num + " as even " + checknum);
            Console.WriteLine("The value of " + num + " is " + result);
            Console.WriteLine("The value of " + num + " is " + (result = (num % 2 == 0) ? "even" : "odd"));

        }
    }
}
