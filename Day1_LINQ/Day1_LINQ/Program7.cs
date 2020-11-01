using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_LINQ
{
    class Program7
    {
        static void Main(string[] args)
        {
            List<int> num = new List<int>()
            {
                12,24,65,98,100,50,40,30,67,99,22,10,9,7
            };
            var model1 = num.OrderBy(x => x);

            var model2 = num.OrderByDescending(x => x);

            var model3 = User.GetUsers().OrderByDescending(x => x.ID).ToList();

            var model4 = User.GetUsers().
                OrderBy(x => x.Address).
                ThenBy(x => x.Email).
                ThenBy(x => x.ID).ToList();
            foreach (var item in num)
            {
              //  Console.WriteLine(item);
            }

            List<string> names = new List<string>()
            {
                "ali" , "saad" ,"waad" ,"zaqi"
            };
            //Console.WriteLine("Count users" + names.Count);
            User.Show(model4);
        }
    }
}
