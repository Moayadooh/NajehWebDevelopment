using System;
using System.Collections.Generic;
using System.Text;

namespace Day2_LINQ_Practise
{
    class Department
    {
        public int DepID { get; set; }
        public string DepName { get; set; }

        public static List<Department> GetDepartments()
        {
            return new List<Department>()
            {
                new Department {DepID = 100 , DepName="HR" },
                new Department {DepID = 101 , DepName="IT" },
                new Department {DepID = 102 , DepName="ENG" },
            };
        }
    }
}
