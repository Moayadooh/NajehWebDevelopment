using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Csharp
{
    class Program5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter UserName:");
            string username = Console.ReadLine(); // input

            Console.WriteLine("Please Enter Password:");
            string userpass = Console.ReadLine(); // input

            if (username == "ammar" && userpass=="12$4@")
            {
                Console.WriteLine("Enter your role:");
                string Role = Console.ReadLine();
                if (Role == "Admin")
                {
                    Console.WriteLine("Hello, {0} and your Role is {1}", username, Role);
                }
                else
                {
                    Console.WriteLine("You don't have an athorization");
                }
            }
            else
            {
                Console.WriteLine("Please Try Again");
            }
        }
    }
}
