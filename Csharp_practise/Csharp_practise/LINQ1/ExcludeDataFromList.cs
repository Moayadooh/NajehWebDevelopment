using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day1_LINQ_Practise
{
    class ExcludeDataFromList
    {
        public void Run()
        {
            var num = new List<int>()
            {
                1,2,3,4,5,6
            };
            var numToExclude = new List<int>()
            {
                1,6
            };
            num = num.Where(x => !numToExclude.Contains(x)).ToList();
            User.Display(num);
        }
    }
}
