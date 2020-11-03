using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day2_LINQ_Practise
{
    class LambdaFunctions
    {
        public void Run()
        {
            var nums = new List<int>()
            {
                45, 3, 9, 78, 145, 20, 5, 33, 7, 81
            };
            Console.WriteLine("Max: " + nums.Max());
            Console.WriteLine("Min: " + nums.Min());
            Console.WriteLine("Average: " + nums.Average());
            Console.WriteLine("Sum: " + nums.Sum());
            Console.WriteLine("Count: " + nums.Count());
            Console.WriteLine("==================================================================================");
            Console.WriteLine("Number of trainee: " + User.GetUsers().Count());
            Console.WriteLine("Number of trainee who's address contains 'l': " + User.GetUsers().Count(x => x.Address.Contains("l")));
            Console.WriteLine("Even numbers: " + nums.Count(x => x % 2 == 0));
            Console.WriteLine("Odd numbers: " + nums.Count(x => x % 2 == 1));
            var salaries = User.GetUsers().Count(x =>
            {
                if (x.Salary > 7000)
                    return true;
                else
                    return false;
            });
            Console.WriteLine("Salaries more than 7000: " + salaries);
            Console.WriteLine("==================================================================================");
            var names = new List<string>()
            {
                "Moayad", "Mohanned", "Mohammed", "Eyad"
            };
            Console.WriteLine("First name in the list: " + names.First());
            Console.WriteLine("Selected name: " + names.Single(x => x == "Eyad"));
        }
    }
}
