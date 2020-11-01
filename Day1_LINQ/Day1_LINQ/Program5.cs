using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_LINQ
{
    class Program5
    {
        static void Main(string[] args)
        {
            var model1 = User.GetUsers().Where(x => x.Email.Contains("m")).ToList();
            var model2 = User.GetUsers().Where(x => x.Email.StartsWith("m")).ToList();
            var model3 = User.GetUsers().Where(x => x.Email.EndsWith("s")).ToList();
            var model4 = User.GetUsers().Where(x => x.Address == "xalazaiba").ToList();

            var model5 = User.GetUsers().Where(x => x.Address.Contains("za")).ToList(); Console.WriteLine("ID \t Email \t Address \t Phone \t ");
            Console.WriteLine("--------------------------------------------------------");
            foreach (var item in model5)
            {
                Console.WriteLine($"{item.ID} \t {item.Email} \t {item.Address} \t {item.Phone}");
                Console.WriteLine("--------------------------------------------------------");
            }
        }
    }
}
