using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_LINQ
{
    class Program4
    {
        static void Main(string[] args)
        {
            #region single
            //try
            //            {

            //                Console.WriteLine("Enter Email");
            //                var email = Console.ReadLine();

            //                Console.WriteLine("Enter pass");
            //                var pass = Console.ReadLine();

            //                var model1 = User.GetUsers().Single(x => x.Email.ToLower() == email.ToLower() && x.Password == pass);
            //                var model1 = User.GetUsers().First(x => x.Email.ToLower() == email.ToLower() && x.Password == pass);

            //                Console.WriteLine("Name:" + model1.Email);
            //                Console.WriteLine("ID:" + model1.ID);
            //                Console.WriteLine("Password:" + model1.Password);
            //                Console.WriteLine("Address:" + model1.Address);
            //                Console.WriteLine("Phone:" + model1.Phone);
            //            }
            //            catch (Exception e)
            //            {

            //                Console.WriteLine("Check Email or password!");
            //            }
            #endregion
            #region singleordefault
            Console.WriteLine("Enter Email");
            var email = Console.ReadLine();

            Console.WriteLine("Enter pass");
            var pass = Console.ReadLine();

            //var model1 = User.GetUsers().SingleOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == pass);
            var model1 = User.GetUsers().FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == pass);

            if (model1== null)
            {
                Console.WriteLine("check email or password");
            }
            else
            {
                Console.WriteLine("Name:" + model1.Email);
                Console.WriteLine("ID:" + model1.ID);
                Console.WriteLine("Password:" + model1.Password);
                Console.WriteLine("Address:" + model1.Address);
                Console.WriteLine("Phone:" + model1.Phone);
            }
            #endregion
        }
    }
}
