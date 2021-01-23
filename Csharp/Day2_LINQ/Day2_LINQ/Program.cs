using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter page size");
            int pagesize = int.Parse(Console.ReadLine());
            for (int i = 0; i < User.GetUsers().Count; i += pagesize)
            {
                var model = User.GetUsers().Skip(i).Take(pagesize).ToList();
                foreach (var item in model)
                {
                    Console.WriteLine($"{item.ID},{item.Email} , {item.Address} ,{item.Phone}");
                }
                Console.WriteLine("======================================================");
            }
        }
    }
}
