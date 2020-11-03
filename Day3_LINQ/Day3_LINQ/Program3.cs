using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_LINQ
{
    class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter new Course");
            var name = Console.ReadLine();

            Course crs = new Course();
            var newlist = crs.GetCourses();
            var model = crs.GetCourses().Where(x => x.Name == name);
            if (model.Count() == 0)
            {
                newlist.Add(new Course { ID = 105, Name = name, price = 660, Hours = 60 });
                foreach (var item in newlist)
                {
                    Console.WriteLine("Course ID" + item.ID);
                    Console.WriteLine("Course Name" + item.Name);
                    Console.WriteLine("Course Price" + item.price);
                    Console.WriteLine("Course Hour" + item.Hours);
                }
            }
            else
            {
                Console.WriteLine(name + " already found!");
            }
        }
    }
}
