using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Csharp
{
    class Calc
    {
        public double Sum()
        {
            return 0.0;
        }
        public double Sum(int no1,int no2)
        {
            return no1+no2;
        }
        public string Sum(string firstname, string lastname)
        {
            return firstname + " " + lastname;
        }
        public int Sum (int no1 , string no2)
        {
            return no1 + int.Parse(no2);
        }
        public int Sum(string x, int y)
        {
            return int.Parse(x) + y;
        }
    }
}
