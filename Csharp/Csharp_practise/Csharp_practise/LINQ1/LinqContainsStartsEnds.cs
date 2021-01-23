using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day1_LINQ_Practise
{
    class LinqContainsStartsEnds
    {
        public void Run()
        {
            var list = User.GetUsers().Where(x => x.Email.ToLower().StartsWith("m")).ToList();
            list = list.Where(x => x.Password.StartsWith("6") || x.Password.EndsWith("6")).ToList();
            list = list.Where(x => x.Address.Contains("s")).ToList();
            User.Display(list);
        }
    }
}
