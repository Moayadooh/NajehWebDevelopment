using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day1_LINQ_Practise
{
    class SkipTakeOrderThen
    {
        public void Run()
        {
            var users = User.GetUsers().OrderBy(x => x.Email).ThenBy(x => x.ID).Skip(0).Take(3).ToList();
            User.Display(users);
        }
    }
}
