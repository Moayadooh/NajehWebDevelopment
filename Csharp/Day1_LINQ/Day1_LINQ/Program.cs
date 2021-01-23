using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // ADO.net 10  C#  - ASp.net WebForm - Dataset using linq

            // Linq 5  C# - Asp.net MVC 5 .NetFrameWork and asp.net core EntityFramework 
            // Two Syntax
            // - Linq Query -retrieve data as string data type
            // - Linq Method -retrieve data as object list (Access to Microsft SQL Database, ORACL):
            // retrieve - read - select Data
            // Create - insert - Add Data
            // Update - Modify  - Edit Data
            // Delete - Remove Data

            // Linq Query
            var model1 = (from s in User.GetUsers() select s).ToList();

            //Linq Method
            var model2 = User.GetUsers().ToList();
            Console.WriteLine("ID \t Email \t Address \t Phone \t ");
            Console.WriteLine("--------------------------------------------------------");
            foreach (var item in model2)
            {
                Console.WriteLine($"{item.ID} \t {item.Email} \t {item.Address} \t {item.Phone}");
                Console.WriteLine("--------------------------------------------------------");
            }
        }
    }
}
