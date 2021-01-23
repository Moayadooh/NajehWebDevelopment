using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_LINQ
{
    class Program7
    {
        static void Main(string[] args)
        {
            var model1 = User.GetUsers().All(x => x.Salary >= 1000 && x.Salary <= 60000);

            var model2 = User.GetUsers().Any(x => x.Salary <= 60000 && x.Salary >= 1900);

            var model3 = User.GetUsers().ToLookup(x => x.Salary);

            foreach (var item in model3)
            {
                Console.WriteLine("Salary Cat {0} :" ,item.Key);
                foreach (var item2 in item)
                {
                    Console.WriteLine("User Employee : {0}", item2.Email);
                }
            }
            Console.WriteLine("Result is :" + model1);
            Console.WriteLine("Result is :" + model2);
        }
    }
}
