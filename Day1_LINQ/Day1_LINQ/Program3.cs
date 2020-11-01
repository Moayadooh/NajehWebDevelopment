using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_LINQ
{
    class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter email");
            var email = Console.ReadLine();
            Console.WriteLine("Enter password");
            var pass = Console.ReadLine();

            var model1 = User.GetUsers().Where(x => x.Email.ToLower() == email.ToLower() && x.Password==pass).ToList();
            
            if (model1.Count > 0)
            {
                Console.WriteLine("ID \t Email \t Address \t Phone \t ");
                Console.WriteLine("--------------------------------------------------------");
                foreach (var item in model1)
                {
                    Console.WriteLine($"{item.ID} \t {item.Email} \t {item.Address} \t {item.Phone}");
                    Console.WriteLine("--------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Try Again!");
            }
        }
    }
}
