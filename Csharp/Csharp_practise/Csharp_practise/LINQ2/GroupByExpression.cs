using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day2_LINQ_Practise
{
    class GroupByExpression
    {
        public void Run()
        {
            //var users = User.GetUsers().GroupBy(x => x.Address).ToList();
            var users = User.GetUsers().GroupBy(x => x.getSalaryGroup()).ToList();
            foreach (var groupedItem in users)
            {
                Console.WriteLine("Address: " + groupedItem.Key);
                foreach (var usersItem in groupedItem)
                {
                    Console.WriteLine("ID: " + usersItem.ID + " Email: " + usersItem.Email + " Salary: " + usersItem.Salary);
                }
            }
        }
    }
}
