using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_LINQ
{
    class Program9
    {
        static void Main(string[] args)
        {
            var num = new List<int>()
            {
                20,48,87,34,12,10,98,01,7,95,60,41,100
            };
            Console.WriteLine("First Element : {0}", num.First());
            Console.WriteLine("Last Element : {0}", num.Last());
            Console.WriteLine("By Element : {0}", num.ElementAt(3));

            var names = new List<string>()
            {

                "Ali" , "zaqi" , "saad" , "waad"
            };
            Console.WriteLine("First Element : {0}", names.First());
            Console.WriteLine("Single Element : {0}", names.Single(x => x == "Ali"));
        }
    }
}
