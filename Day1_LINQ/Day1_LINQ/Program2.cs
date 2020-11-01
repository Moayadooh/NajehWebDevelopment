using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_LINQ
{
    class Program2
    {
        static void Main(string[] args)
        {
            // linq query
            var model1 = from s in User.GetUsers()
                         where s.ID == 10
                         select s;

            // linq Query
            var model2 = from s in User.GetUsers()
                         where s.ID == 10
                         select s.Email;

            // linq Method
            var model3 = User.GetUsers().
                         Where(s => s.ID == 10).
                         Select(x => x.Email);

            //linq Method
            Console.WriteLine("Enter Search name");
            var search = Console.ReadLine();
            var model4 = User.GetUsers().Where(x => x.Email.ToLower() == search.ToLower());

            Console.WriteLine("ID \t Email \t Address \t Phone \t ");
            Console.WriteLine("--------------------------------------------------------");
            foreach (var item in model4)
            {
                Console.WriteLine($"{item.ID} \t {item.Email} \t {item.Address} \t {item.Phone}");
                Console.WriteLine("--------------------------------------------------------");
            }
            Console.WriteLine("\n\n\n");
            //=====================================================================
            Console.WriteLine("ID \t Email \t Address \t Phone \t ");
            Console.WriteLine("--------------------------------------------------------");
            foreach (var item in model1)
            {
                Console.WriteLine($"{item.ID} \t {item.Email} \t {item.Address} \t {item.Phone}");
                Console.WriteLine("--------------------------------------------------------");
            }
            //=============================================================
            Console.WriteLine("Email ");
            Console.WriteLine("--------------------------------------------------------");
            foreach (var item in model3)
            {
                Console.WriteLine($"{item}");
                Console.WriteLine("--------------------------------------------------------");
            }
        }
    }
}
