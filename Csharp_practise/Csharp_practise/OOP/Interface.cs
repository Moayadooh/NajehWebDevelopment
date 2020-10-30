using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Csharp_practise.OOP
{
    class Interface
    {
        public void Run()
        {
            User user = new User();
            user.SignUp("Moayad", "123");
            user.SignUp("Mohanned", "123");
            user.SignUp("Moahammed", "123");


            user.Login("Moayad", "123");
            //user.Logout();

            Admin admin = new Admin();
            admin.Login("admin", "admin");
            admin.DeleteUser("Moahammed");
            //admin.Logout();

            user.Login("Mohanned", "123");

        }
    }
    interface Account
    {
        public void Login(string username, string password);
        public void Logout();
    }
    class User : Account
    {
        public static DB db;
        public User()
        {
            db = new DB();
        }
        public void SignUp(string username, string password)
        {
            db.AddNewAccount(username, password);
        }
        public void Login(string username, string password)
        {
            bool isExist = false;
            foreach (var item in User.db.accounts)
            {
                if (item.username == username && item.password==password)
                {
                    Console.WriteLine("Welcome {0}. You are now logged in!", username);
                    isExist = true;
                    break;
                }
            }
            if(!isExist)
                Console.WriteLine("Wrong username or password!");
        }

        public void Logout()
        {
            Console.WriteLine("You are now logged out!");
        }

    }
    class Admin : Account
    {
        public void Login(string username, string password)
        {
            if (username=="admin" && password=="admin")
                Console.WriteLine("Welcome {0}. You are now logged in!", username);
            else
                Console.WriteLine("Wrong username or password!");
        }

        public void Logout()
        {
            Console.WriteLine("You are now logged out!");
        }
        public void DeleteUser(string username)
        {
            bool isFound = false;
            foreach (var item in User.db.accounts)
            {
                if (item.username == username)
                {
                    User.db.accounts.Remove(item);
                    Console.WriteLine($"{username}'s account deleted successfuly!");
                    isFound = true;
                    break;
                }
            }
            if(!isFound)
                Console.WriteLine($"{username}'s account is not found!");
        }
    }
    class AccountData
    {
        private string _Username;
        private string _Password;
        public string username
        { get { return _Username; } set { _Username = value; } }
        public string password
        { get { return _Password; } set { _Password = value; } }
    }
    class DB
    {
        public List<AccountData> accounts;
        public DB()
        {
            accounts = new List<AccountData>();
        }
        public void AddNewAccount(string username, string password)
        {
            //accounts.Add(new AccountData() { username = username, password = password });
            accounts.Add(new AccountData { username = username, password = password });
        }
    }
}
