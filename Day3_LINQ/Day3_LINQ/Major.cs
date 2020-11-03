using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_LINQ
{
    class Major
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public List<Student> Students { get; set; }

        public List<Major> GetMajors()
        {
            return new List<Major>()
            {
                new Major{ ID = 10235452556 , Title="Information Technology",
                    Students = new List<Student>{
                        new Student{  ID = 102, FirstName="zaqi",LastName="ahmad",Email="zaqi.net@outlook.com", Password="1234",MajorID=10235452556},
                        new Student{ ID = 103, FirstName="saad",LastName="nabeel",Email="saad@outlook.com", Password="1234", MajorID=10235452556}
                    }
                },
                new Major{ ID = 20235458654 , Title="Engineering"},
                new Major{ ID = 30235457899 , Title="Human Resources"}
            };
        }

        public List<List<Student>> GetStudentsByMajorID(long majorid)
        {
            var model = GetMajors().Where(x => x.ID == majorid).Select(x => x.Students).ToList();
            return model;
        }
    }
}
