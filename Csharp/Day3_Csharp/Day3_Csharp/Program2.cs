using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Csharp
{
    class Program2
    {
        static void Main(string[] args)
        {
            Course crs = new Course();
            crs.CourseID = 12;
            crs.CourseName = "asp.net";
            crs.CoursePrice = 344.4;
            crs.CourseStatus = status.Active;
            Console.WriteLine("Course ID {0}", crs.CourseID);
            Console.WriteLine("Course Name {0}", crs.CourseName);
            Console.WriteLine("Course Price {0}", crs.CoursePrice);
            Console.WriteLine("Course Status {0}", crs.CourseStatus);
            Console.WriteLine("==============================================================================");
            //==============================================================================

            Academy academy = new Academy();
            var obj = academy.GetOneCourse();
            Console.WriteLine("Course ID {0}", obj.CourseID);
            Console.WriteLine("Course Name {0}", obj.CourseName);
            Console.WriteLine("Course Price {0}", obj.CoursePrice);
            Console.WriteLine("Course Status {0}", obj.CourseStatus);
            //===============================================================================
            Console.WriteLine("==============================================================================");
            Console.WriteLine("ID \t|  Name \t| Price \t| Status");
            foreach (var item in academy.GetCourses())
            {
                Console.Write(item.CourseID + "\t|");
                Console.Write(item.CourseName + "\t|");
                Console.Write(item.CoursePrice + "\t\t|");
                Console.Write(item.CourseStatus + "\t \n");
            }
        }
    }
}
