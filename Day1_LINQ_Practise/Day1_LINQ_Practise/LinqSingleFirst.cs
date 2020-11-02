using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Day1_LINQ_Practise
{
    class LinqSingleFirst
    {
        public void Run()
        {
            //throw an exception if the record is not exist
            //var user = User.GetUsers().First(x => x.ID == 12);
            //var user = User.GetUsers().Single(x => x.ID == 12);

            //return null if the record is not exist
            var user = User.GetUsers().FirstOrDefault(x => x.Password == "7233"); //return first record that satisfies the condition
            //var user = User.GetUsers().SingleOrDefault(x => x.Password == "7233"); //throw an exception if there are more than records satisfies the condition
            if (user!=null)
                Console.WriteLine($"{user.ID}\t{user.Email}\t{user.Password}\t{user.Address}\t{user.Phone}");
            else
                Console.WriteLine("Record is not found!!");
        }
    }
}
