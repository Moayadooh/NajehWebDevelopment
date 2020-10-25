using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_practise
{
    class StringFormat
    {
        public void Run()
        {
            decimal price = 2500.0m, discount = 0.2m;
            Console.WriteLine($"Original price is {price} OMR");
            Console.WriteLine("Discount is {0}", (discount * 100) + "%");
            Console.WriteLine("Price after discount is " + (price - (price * discount)) + " OMR");
        }
    }
}
