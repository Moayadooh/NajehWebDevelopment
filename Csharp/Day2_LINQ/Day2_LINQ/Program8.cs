using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_LINQ
{
    class Program8
    {
        static void Main(string[] args)
        {
            var num = new List<int>()
            {
                20,48,87,34,12,10,98,01,7,95,60,41,100
            };

            var maxNumbers = num.Max();
            var minNumbers = num.Min();
            var avgNumbers = num.Average();
            var sumNumbers = num.Sum();
            Console.WriteLine("Max is " + maxNumbers);
            Console.WriteLine("Min is " + minNumbers);
            Console.WriteLine("avg is " + avgNumbers);
            Console.WriteLine("sum is " + sumNumbers);
            Console.WriteLine("count is " + num.Count);
            Console.WriteLine("count even number is " + num.Count(x => x % 2 == 0));
            Console.WriteLine("count odd number is " + num.Count(x => x % 2 == 1));
            Console.WriteLine("========================================================");
            var model1 = User.GetUsers().Count();
            Console.WriteLine("User Count {0}", model1);

            var model2 = User.GetUsers().Count(x => x.Email == "Mohammad");
            Console.WriteLine("User Exist {0}", model2);
            Console.WriteLine("Employee Salary Max is " + User.GetUsers().Max(x => x.Salary));
            Console.WriteLine("Employee Salary Min is " + User.GetUsers().Min(x => x.Salary));
            Console.WriteLine("Employee Salary avg is " + User.GetUsers().Average(x => x.Salary));
            Console.WriteLine("Employee Salay sum is " + User.GetUsers().Sum(x => x.Salary));
            var countsalary = User.GetUsers().Count(x =>
            {
                if (x.Salary >= 7000)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
            Console.WriteLine("Count salary greater than 7000 is " + countsalary);
        }
    }
}
