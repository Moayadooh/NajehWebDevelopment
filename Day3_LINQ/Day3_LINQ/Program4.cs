using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_LINQ
{
    class Program4
    {
        static void Main(string[] args)
        {
            Course crs = new Course();
            Student st = new Student();

            var modelcourses = crs.GetCourses().Where(x => x.Junctions.Any(y => y.StudentID == 100)).ToList();

            var modelstudent = st.GetStudents().Where(x => x.Junctions.Any(j => j.CourseID == 10)).ToList();
        }
    }
}
