using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Csharp
{
    class Teacher : IHuman
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

        public void AddTeacher(Teacher tch)
        {
            throw new NotImplementedException();
        }
        public void delTeacher(int id)
        {
            throw new NotImplementedException();
        }
        public void EditTeacher(Teacher tch, int id)
        {
            throw new NotImplementedException();
        }
        public List<Teacher> GetAllTeachers()
        {
            return new List<Teacher>()
            {
                new Teacher { ID= 1, name="aaaaaa" , address="musqat" , phone="33434"},
                new Teacher { ID= 2, name="bbbb" , address="musqat" , phone="3333434"},
            };
        }
        public Teacher Getlogin(string email, string pass)
        {
            if (email == "ammar" && pass == "123")
            {
                return new Teacher { ID = 1, name = "ammar", password = "123", address = "amman", phone = "3455" };
            }
            else
            {
                return null;
            }
        }
        public string getName()
        {
            return "Ammar";
        }
        public int GetNumber()
        {
            return 344;
        }
    }
}
