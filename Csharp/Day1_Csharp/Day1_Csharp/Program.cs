using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Csharp
{
    class Program
    {
        int sal = 344; // Public 
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World"); // output

            int number = 3; //integer
            string name = "Ammar";
            //String name = "Ammar"; 

            bool Activate = false;
            DateTime birth = new DateTime(); // create new object
            var b = birth.Date;
            DateTime PersonBirth = DateTime.Now; // assign

            double salary = 355.55;
            decimal tax = 456.545M;
            float area = 345.54F;

            short rang = 22267;

            char letter = 'a';
            Console.WriteLine("Number is " + number); // concatination
            Console.WriteLine("Name is {0} {1}", name, PersonBirth.ToShortDateString()); // string format
            Console.WriteLine("Salary =" + salary);
            Console.WriteLine("Tax =" + tax);
            Console.WriteLine("area =" + area);
            Console.WriteLine($"rang {rang}");
            Console.WriteLine($"letter {letter}");
        }
    }
}
