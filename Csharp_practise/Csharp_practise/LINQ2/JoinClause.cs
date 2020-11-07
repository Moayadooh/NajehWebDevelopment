using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day2_LINQ_Practise
{
    class JoinClause
    {
        public void Run()
        {
            var num1 = new List<string>()
            {
                "one", "two", "three", "four", "five"
            };
            var num2 = new List<string>()
            {
                "one", "three", "six", "seven"
            };

            var nums = num1.Join(num2, n1 => n1, n2 => n2, (n1, n2) => n1);
            foreach (var item in nums)
            {
                Console.WriteLine("Number: " + item);
            }
            Console.WriteLine("==================================================================================");
            var users = User.GetUsers().
                Join(Department.GetDepartments(), 
                u => u.DepID, 
                d => d.DepID, 
                (u, d) => new { email = u.Email, department = d.DepName }); // 'd' is possible than call column 'item.department.DepName'
            foreach (var item in users)
            {
                Console.WriteLine("Email: " + item.email + ", Department: " + item.department);
            }
            Console.WriteLine("==================================================================================");
            var departments = Department.GetDepartments().
                GroupJoin(User.GetUsers(),
                d => d.DepID,
                u => u.DepID,
                (d, u) => new { department = d.DepName, user = u }); //user = u.Email --> not allowed in 'GroupJoin'
            foreach (var item in departments)
            {
                Console.WriteLine("Department: " + item.department);
                foreach (var data in item.user)
                {
                    Console.WriteLine("Email: " + data.Email + " Password: " + data.Password + " Phone: " + data.Phone);
                }
            }
        }
    }
}
