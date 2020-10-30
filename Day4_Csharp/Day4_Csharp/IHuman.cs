using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Csharp
{
    interface IHuman
    {
        string getName();
        int GetNumber();

        List<Teacher> GetAllTeachers();

        Teacher Getlogin(string email, string pass);

        void AddTeacher(Teacher tch);
        void EditTeacher(Teacher tch, int id);
        void delTeacher(int id);
    }
}
