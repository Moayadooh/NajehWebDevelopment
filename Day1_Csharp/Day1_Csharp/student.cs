using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Csharp
{
    class student
    {
        public int ID;
        public string Name;
        public string Lastname;
        public string Address;

        public void FullName()
        {
            Console.WriteLine(Name + " " + Lastname);
        }

        public string getFullName()
        {
            return Name + " " + Lastname;
        }
    }
}
