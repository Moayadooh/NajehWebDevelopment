using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Csharp
{
    public class Academy
    {
        public List<Course> GetCourses() 
        {
            return new List<Course>()
            {
                new Course { CourseID = 10,CourseName="Asp.net",CoursePrice=655,CourseStatus=status.Active },
                new Course { CourseID = 11,CourseName="frontend",CoursePrice=155,CourseStatus=status.NonActive },
                new Course { CourseID = 12,CourseName="SQl server",CoursePrice=1655,CourseStatus=status.Active },
                new Course { CourseID = 13,CourseName="Azure",CoursePrice=2655,CourseStatus=status.Active },
            };
        }

        public Course GetOneCourse()
        {
            return new Course() { CourseID= 14, CourseName = "SQlAdmin", CoursePrice=455,CourseStatus=status.Active};
        }

        //private enum status1
        //{
        //    Active, NonActive
        //}

    }

   public struct Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public double CoursePrice { get; set; }
        public status CourseStatus { get; set; }
    }
    public enum status
    {
        Active, NonActive
    }
}
