using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_LINQ
{
    class Program4
    {
        static void Main(string[] Args)
        {
            List<string> nums = new List<string>()
            {
                "One" , "Two" , "Three" , "four" , "Five"
            };

            var nums2 = new List<string>()
            {
                "Seven" , "Ten" , "Two" ,"Three"

            };

            var joinnums = nums.Join(nums2, n => n, n2 => n2, (n, n2) => n);
            foreach (var item in joinnums)
            {
                Console.WriteLine("Nums: {0}" , item);
            }

            var model1 = User.GetUsers().Select(x => x.Address); // one column
            var model2 = User.GetUsers().Select(x => new { x.ID,x.Phone,x.Email }); // three columns 
            var model3 = User.GetUsers().ToList(); // All Columns
            foreach (var item in model1)
            {
                Console.WriteLine(item); // One Column
            }
            Console.WriteLine("===========================================");
            foreach (var item in model2)
            {
                Console.WriteLine($"{item.ID} , {item.Phone} , {item.Email}");
            }
            Console.WriteLine("===========================================");
            foreach (var item in model3)
            {
                Console.WriteLine($"{item.ID} , {item.Phone} , {item.Email}");
            }
        }
    }
}
