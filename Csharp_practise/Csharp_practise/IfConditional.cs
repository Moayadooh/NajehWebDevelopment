using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_practise
{
    class IfConditional
    {
        public void Run()
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            string result = (num > 100) ? "Number is big" : "Number is small";
            Console.WriteLine(result);
        }
    }
}
