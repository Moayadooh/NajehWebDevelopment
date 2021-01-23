using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_LINQ
{
    class Program6
    {
        static void Main(string[] args)
        {
            // FILTER
            var all = User.GetUsers(); // 16  First Stage 
            
            Console.WriteLine("Enter email");
           
            var email = Console.ReadLine();
            

            Console.WriteLine("Enter address");
            
            var address = Console.ReadLine();
            
            Console.WriteLine("Enter Phone");

            var phone = Console.ReadLine();
            if (!string.IsNullOrEmpty(email.Trim()))
            {
                all = all.Where(b => b.Email.Contains(email)).ToList(); // e.g 8 persons
                  // Second Stage  
            }
            if (!string.IsNullOrEmpty(address.Trim()))
            {
                all = all.Where(x => x.Address == address).ToList(); // e.g 8 persons
                //third stage
            }

            if (!string.IsNullOrEmpty(phone.Trim()))
            {
                all = all.Where(y => y.Phone.ToString().StartsWith(phone)).ToList(); // e.g 8 persons
                // final stage
            }
            User.Show(all);
            // result Stage
        }
    }
}
