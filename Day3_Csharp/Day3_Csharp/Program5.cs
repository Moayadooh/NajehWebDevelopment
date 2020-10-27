﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Csharp
{
    class Program5
    {
        static void Main(string[] args)
        {
            User user = new User();
            Console.WriteLine("Enter Email or Phone please:");
            var emailorPhone = Console.ReadLine();

            Console.WriteLine("Enter Password please:");
            var pass = Console.ReadLine();

            var emailabletoconvert = int.TryParse(emailorPhone, out int result);
            if (emailabletoconvert == true)
            {
                // should be PHONE NUMBER IF IT'S ABLE TO CONVERT
                if (user.Login(int.Parse(emailorPhone), pass) != false)
                {
                    Console.WriteLine("Login successfully!");
                }
                else
                {
                    Console.WriteLine("Please Try Again!");
                }
            }
            else
            {
                // should be EMAIL
                if (user.Login(emailorPhone, pass) != false)
                {
                    Console.WriteLine("Login successfully!");
                }
                else
                {
                    Console.WriteLine("Please Try Again!");
                }

            }
            #region Tryregion
            //try
            //{
            //    if (user.Login(emailorPhone,pass) != false)
            //    {
            //        Console.WriteLine("Login successfully!");
            //    }
            //    else if(user.Login(int.Parse( emailorPhone), pass) != false)
            //    {
            //        Console.WriteLine("Login successfully!");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Please Try Again!");
            //    }
            //}
            //catch (Exception)
            //{

            //    Console.WriteLine("check your email or phone");
            //}
            #endregion
        }
    }
}
