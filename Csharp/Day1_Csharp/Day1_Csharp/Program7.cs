using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Csharp
{
    class Program7
    {
        static void Main(string[] args)
        {
            student std = new student(); // Create an object form student classsssss;
            Console.WriteLine("Enter an ID");
            std.ID = int.Parse( Console.ReadLine());

            Console.WriteLine("Enter Student Name");
            std.Name = Console.ReadLine();

            Console.WriteLine("Enter Student LastName");
            std.Lastname = Console.ReadLine();

            Console.WriteLine("Enter Student Address");
            std.Address = Console.ReadLine();

            Console.WriteLine("Student ID {0}", std.ID);
            Console.WriteLine("Student Name {0}", std.Name);
            Console.WriteLine("Student Address {0}", std.Address);
            Console.WriteLine("Student Full Name is {0}", std.getFullName());
            std.FullName();
       }
    }
}
