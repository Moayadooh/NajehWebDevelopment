using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_practise
{
    class Nullable
    {
        public void Run()
        {
            //int num = null; //error
            int? num = null; //nullable
            double? tax = new double?();
            tax = null;

            Console.Write("Enter a value: ");
            string value = Console.ReadLine();
            if (string.IsNullOrEmpty(value))
                Console.WriteLine("Value is null or empty!!");
            else
                Console.WriteLine("You are ok to go.");
        }
    }
}
