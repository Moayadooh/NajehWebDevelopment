using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_LINQ
{
    class Student : Person
    {
        public string  Email { get; set; }
        public string Password { get; set; }

        public  Profile Profile { get; set; }

        public long MajorID { get; set; } // Assign Major ID

        public Major Major { get; set; } // Read Majors

        public List<Junction> Junctions { get; set; }

        public List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student{ ID = 100, FirstName="ammar",LastName="yaser",Email="ammar.net@outlook.com",
               Profile= new Profile { ID=100,Address="amman",Age=37,Image="sdsdf.jpg"}
                , Password="123",MajorID=10235452556},

                new Student{ ID = 101, FirstName="ali",LastName="khaled",Email="khaled.net@outlook.com",
                 Profile= new Profile { ID=101,Address="ali",Age=25,Image="sffff.jpg"}
                , Password="1234",MajorID=10235452556},
                new Student{ ID = 102, FirstName="zaqi",LastName="ahmad",Email="zaqi.net@outlook.com", Password="1234",MajorID=20235458654},
                new Student{ ID = 103, FirstName="saad",LastName="nabeel",Email="saad@outlook.com", Password="1234", MajorID=20235458654},
                new Student{ ID = 104, FirstName="waad",LastName="osama",Email="waad@outlook.com", Password="1234",MajorID=30235457899}
            };

        }

        public Student  Login(string email,string password)
        {
            var model = GetStudents().SingleOrDefault(x => x.Email == email && x.Password == password);
            return model;
        }
    }
}
