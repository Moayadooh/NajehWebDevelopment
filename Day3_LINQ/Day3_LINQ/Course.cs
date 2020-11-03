using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_LINQ
{
    class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double price { get; set; }
        public int Hours { get; set; }
        public List<Junction> Junctions { get; set; }

        public List<Course> GetCourses()
        {
            return new List<Course>()
            {
                new Course { ID=10,Name="Backend", Hours=90,price=300},
                new Course { ID=11,Name="Frontend", Hours=50,price=200},
                new Course { ID=12,Name="SqlDeveloper", Hours=100,price=400},
                new Course { ID=13,Name="Graphic Design", Hours=120,price=250},
                new Course { ID=14,Name="Adobe Animate", Hours=40,price=200}
            };
        }
    }
}
