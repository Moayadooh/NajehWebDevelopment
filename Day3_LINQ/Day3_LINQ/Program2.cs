using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_LINQ
{
    class Program2
    {
        static void Main(string[] args)
        {
            Major mj = new Major();

            var model = mj.GetStudentsByMajorID(10235452556);
            if (model != null)
            {
                foreach (var item in model)
                {
                    
                    foreach (var detials in item)
                    {
                        Console.WriteLine("Email" + detials.Email);
                        Console.WriteLine("First Name" + detials.FirstName);
                    }

                }
            }
            else
            {
                Console.WriteLine("check model");
            }
           
        }
    }
}
