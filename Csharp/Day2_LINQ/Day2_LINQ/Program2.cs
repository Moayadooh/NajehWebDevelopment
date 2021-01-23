using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_LINQ
{
    class Program2
    {
        static void Main(string[] args)
        {
            var groupaddress = User.GetUsers().GroupBy(x => x.Address);
            foreach (var itemAddress in groupaddress)
            {
                Console.WriteLine("Address {0}", itemAddress.Key);
                foreach (var itemUser in itemAddress)
                {
                    Console.WriteLine("ID :{0} , Email {1} , phone : {2}", itemUser.ID, itemUser.Email, itemUser.Phone);
                }
                Console.WriteLine("===============================================");
            }
        }
    }
}
