using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Employees;

namespace Day2_Csharp
{
    class Program6
    {
        static void Main(string[] args)
        {
           Teacher.Printput();
        }
    }
    
}

namespace Academy
{

    namespace Employees
    {
        public class Teacher
        {
            public static void Printput()
            {
                Console.WriteLine("Print out - Ammar");
            }
        }
    }
}
