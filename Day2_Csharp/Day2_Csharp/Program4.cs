using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Csharp
{
    class Program4
    {
        static void Main(string[] args)
        {
            int? num = null; // nullable
            num = 45;
            double? salary = new double?();
            salary = 45454;
            //====================================================
            string name = Console.ReadLine();
            string pass = Console.ReadLine();
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(pass))
            {
                Console.WriteLine("Hellooooooo" + name);
            }
            else
            {
                Console.WriteLine("Name is Null or empty");
            }
            // T && T = T
            // T && F = F
            // F && F = F
            //==================
            // T || T = T
            // T || F = T
            // F || F = F
        }
    }
}
