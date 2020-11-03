using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Day2_LINQ_Practise
{
    class AllAnyToLookup
    {
        public void Run()
        {
            //return more than one column using 'new' keyword
            var users = User.GetUsers().Where(x => x.ID == 12).Select(x => new { x.Email, x.Password, x.Phone }).ToList();
            foreach (var item in users)
            {
                Console.WriteLine("Email: " + item.Email + " Password: " + item.Password + " Phone: " + item.Phone);
            }
            Console.WriteLine("==================================================================================");
            var list = User.GetUsers().Select(x => x.Address).Distinct().ToList(); //remove duplicated items
            foreach (var item in list)
            {
                Console.WriteLine("Address: " + item);
            }
            Console.WriteLine("==================================================================================");
            var isHigh = User.GetUsers().All(x => x.Salary >= 500); //return true if all items satisfy the condition
            Console.WriteLine(isHigh);
            Console.WriteLine("==================================================================================");
            var isAny = User.GetUsers().Any(x => x.Salary >= 1000); //return true if one item satisfy the condition
            Console.WriteLine(isAny);
            Console.WriteLine("==================================================================================");
            //ToLookup(x => x.Salary >= 1000) return true with items, return false with items
            var listOfUsers = User.GetUsers().ToLookup(x => x.Salary); //categories based on salary
            foreach (var item in listOfUsers)
            {
                Console.WriteLine("Key: " + item.Key);
                foreach (var usersList in item)
                {
                    Console.WriteLine("Email: " + usersList.Email + " Password: " + usersList.Password + " Phone: " + usersList.Phone);
                }
            }
        }
    }
}
