using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_LINQ
{
    class Program8
    {

        static void Main(string[] args)
        {
            List<string> names = new List<string>()
            {
                // 0        1     2      3      4
                "ahmad","mousa","ali","loay","muayyad",
                //  5         6       7        8      9      10       11
                "mohammad","shaher","khaled","wael","osama","ammar","qasem"
            };
            
            var model1 = names.Skip(7).Take(5).ToList();
            foreach (var item in model1)
            {
                Console.WriteLine(item);
            }
        }
    }
}
