using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_LINQ
{
    class Program9
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>()
            {
                10,32,65,87,23,87,2,33,67,12
            };

            List<int> Excludenums = new List<int>()
            {
                10,12
            };
            var model1 = nums.Where(x => x > 40 && x < 80 && (x != 65));

            var model2 = nums.Where(x => !Excludenums.Contains(x));

            foreach (var item in model1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("==============================================");
            foreach (var item in model2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
