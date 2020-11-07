using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day1_LINQ_Practise
{
    class LinqSelectWhere
    {
        public void Run()
        {
            //LINQ Query
            //var list = (from s in User.GetUsers() select s).ToList();
            //var list = (from s in User.GetUsers() where s.ID == 12 select s).ToList();

            //LINQ Method
            //var list = User.GetUsers();
            //var list = User.GetUsers().Where(s => s.ID == 12).ToList();
            //var list = User.GetUsers().Where(s => s.ID == 12).Select(s => s.Email).ToList();
            var list = User.GetUsers().Where(s => s.ID >= 10 && s.ID <= 12).Select(s => s).ToList();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.ID}\t{item.Email}\t{item.Password}\t{item.Address}\t{item.Phone}");
                //Console.WriteLine(item);
            }
        }
    }
}
