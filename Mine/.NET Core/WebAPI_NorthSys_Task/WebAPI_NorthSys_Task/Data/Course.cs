using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_NorthSys_Task.Data
{
    public class Course
    {
        public int ID { get; set; }

        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        public DateTime Date { get; set; }

        public static List<Course> Courses;
        public static int i;
        static Course()
        {
            Courses = new List<Course>();
            i = 4;
            Courses.Add(new Course { ID = 1, CourseCode = "CS101", CourseName = "Introduction to Computer Science", Date = DateTime.Parse("2021-03-01 15:00:00") });
            Courses.Add(new Course { ID = 2, CourseCode = "CS102", CourseName = "Algorithm I", Date = DateTime.Parse("2021-03-01 08:00:00") });
            Courses.Add(new Course { ID = 3, CourseCode = "CS201", CourseName = "Introduction To DBMS", Date = DateTime.Parse("2021-03-01 12:30:00") });
        }

        public static List<Course> Read()
        {
            return Courses;
        }

        public static Course GetById(int id)
        {
            return Courses.Single(x => x.ID == id);
        }

        public static void Create(string couseCode, string couseName, string date)
        {
            Courses.Add(new Course { ID = i++, CourseCode = couseCode, CourseName = couseName, Date = DateTime.Parse(date) });
        }

        public static void Edit(int id, string couseCode, string couseName, string date)
        {
            foreach (var item in Courses.Where(x => x.ID == id))
            {
                item.CourseCode = couseCode;
                item.CourseName = couseName;
                item.Date = DateTime.Parse(date);
            }
        }

        public static void Delete(int id)
        {
            Courses.Remove(Courses.Single(x => x.ID == id));
        }
    }
}
