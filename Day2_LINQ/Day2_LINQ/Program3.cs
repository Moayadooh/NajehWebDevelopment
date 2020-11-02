using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_LINQ
{
    class Program3
    {
        static void Main(string[] args)
        {
            var groupsalary = User.GetUsers().GroupBy(x => x.getSalaryGroup());
            foreach (var itemSalary in groupsalary)
            {
                Console.WriteLine("Salary Category {0}", itemSalary.Key);
                foreach (var itemUser in itemSalary)
                {
                    Console.WriteLine("ID :{0} , Email {1} , phone : {2}, Salary : {3}", itemUser.ID, itemUser.Email, itemUser.Phone , itemUser.Salary);
                }
            }
        }
    }
}
