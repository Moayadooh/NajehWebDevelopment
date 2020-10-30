using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Employee emp = new Employee();
            //Console.WriteLine(emp.getconnection());

            Developer developer = new Developer();
            Console.WriteLine("Enter Developer ID:");
            developer.DevID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Developer Name:");
            developer.DevName = Console.ReadLine();
            Console.WriteLine("Enter Developer Hours:");
            developer.hours = int.Parse(Console.ReadLine());
            Console.WriteLine("Developer ID " + developer.DevID);
            Console.WriteLine("Developer Name " + developer.DevName);
            Console.WriteLine("Developer hours " + developer.hours);
            Console.WriteLine("Developer Salary " + developer.Getsalary(1000) + " OMR");
            Console.WriteLine("Developer Code " + developer.empcode);

            Designer designer = new Designer();
            Console.WriteLine("Enter Designer ID:");
            designer.DesID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Designer Name:");
            designer.DesName = Console.ReadLine();
            Console.WriteLine("Enter Designer comission:");
            designer.commision = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Designer Sales:");
            designer.Sale = double.Parse(Console.ReadLine());
            Console.WriteLine("Designer ID " + designer.DesID);
            Console.WriteLine("Designer Name " + designer.DesName);
            Console.WriteLine("Designer Salary " + designer.Getsalary(2000) + " OMR");
            Console.WriteLine("Designer  Code " + designer.empcode);

        } // end of statements
    }
}
