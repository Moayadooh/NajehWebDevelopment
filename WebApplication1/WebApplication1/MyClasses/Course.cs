using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.MyClasses
{
    public class Course
    {
        public int ID { get; set; }

        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        public DateTime Date { get; set; }

        List<Course> Courses;
        int i;
        public bool isInitialized;
        public Course()
        {
            Courses = new List<Course>();
            i = 4;
            isInitialized = false;
            //Courses = new List<Course>
            //{
            //    new Course { ID = 1, CouseCode = "CS101", CouseName = "Introduction to Computer Science", Date = DateTime.Parse("2021-03-01 15:00:00")},
            //    new Course { ID = 2, CouseCode = "CS102", CouseName = "Algorithm I", Date = DateTime.Parse("2021-03-01 08:00:00")},
            //    new Course { ID = 3, CouseCode = "CS201", CouseName = "Introduction To DBMS", Date = DateTime.Parse("2021-03-01 12:30:00")}
            //};
        }

        public void Initial()
        {
            Courses.Add(new Course { ID = 1, CourseCode = "CS101", CourseName = "Introduction to Computer Science", Date = DateTime.Parse("2021-03-01 15:00:00") });
            Courses.Add(new Course { ID = 2, CourseCode = "CS102", CourseName = "Algorithm I", Date = DateTime.Parse("2021-03-01 08:00:00") });
            Courses.Add(new Course { ID = 3, CourseCode = "CS201", CourseName = "Introduction To DBMS", Date = DateTime.Parse("2021-03-01 12:30:00") });
        }

        public List<Course> Read()
        {
            return Courses;
        }

        public Course GetById(int id)
        {
            return Courses.SingleOrDefault(x => x.ID == id);
        }

        public void Create(string couseCode, string couseName, string date)
        {
            Courses.Add(new Course { ID = i++, CourseCode = couseCode, CourseName = couseName, Date = DateTime.Parse(date) });
        }

        public void Edit(int id, string couseCode, string couseName, string date)
        {
            Courses.Remove(Courses.Single(x => x.ID == id));
            Courses.Add(new Course { ID = id, CourseCode = couseCode, CourseName = couseName, Date = DateTime.Parse(date) });
        }

        public void Delete(int id)
        {
            Courses.Remove(Courses.Single(x => x.ID == id));
        }
    }
}
