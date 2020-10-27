using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student(); // Create an object;

            st.ID = int.Parse(Console.ReadLine()); // set
            st.Name = Console.ReadLine(); //set
            Guid gg = Guid.NewGuid(); // generate Guid 
            st.SetCode(gg); //set 
            //================================================
            Console.WriteLine("Student ID : " + st.ID); // get
            Console.WriteLine("Student Name : " + st.Name); // get
            Console.WriteLine("Student Code : " + st.GetCode()); // get
        }
    }
}
