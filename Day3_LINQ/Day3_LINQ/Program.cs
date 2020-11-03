using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Email");
            var email = Console.ReadLine();
            Console.WriteLine("Enter Password");
            var password = Console.ReadLine();

            Student st = new Student();
            var recordStudent = st.Login(email, password);
            if (recordStudent != null)
            {
                Console.WriteLine("Hello," + recordStudent.Email);
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Person Information :");
                Console.WriteLine("========================================================");
                Console.WriteLine($" First Name {recordStudent.FirstName }");
                Console.WriteLine($" Last Name {recordStudent.LastName }");
                Console.WriteLine($" Full Name {recordStudent.FullName() }");
                Console.WriteLine($"  {recordStudent.FullName() }");
                Console.WriteLine("Profile Information :");
                Console.WriteLine("========================================================");
                Console.WriteLine($" Address {recordStudent.Profile.Address }");
                Console.WriteLine($" Image {recordStudent.Profile.Image }");
                Console.WriteLine($" Age {recordStudent.Profile.Age }");
            }
            else
            {
                Console.WriteLine("Please verify Email or Password!");
            }
        }
    }
}
