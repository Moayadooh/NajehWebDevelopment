using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Csharp
{
    class Program6
    {
        static void Main(string[] args)
        {
            int[] nums = new int[10] { 34,76,98,100,54,8,59,12,11,23 } ;
            string[] names = new string[5] { "Amani", "Balqees", "Iman", "Fatema", "hajar" };
            char[] name = new char[4] { 'n', 'o', 'u', 'f' };
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine("ammar " + nums[i]  );
            }
            Console.WriteLine("====================================================");
            foreach (var item in names)
            {
                Console.WriteLine("Name is :" + item);
            }
            Console.WriteLine("====================================================");
            Console.Write("The name is ");
            foreach (var item2 in name)
            {
                Console.Write(item2);
            }
            Console.WriteLine("");
        }
    }
}
