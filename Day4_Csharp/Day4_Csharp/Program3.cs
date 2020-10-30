using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Csharp
{
    class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Shape Number:");
            int no = int.Parse(Console.ReadLine());
            if (no == 1)
            {
                Square sq = new Square();
                Console.WriteLine("Enter Square length:");
                sq.length = double.Parse(Console.ReadLine());
                Console.WriteLine(" Square Area:" + sq.getArea(sq.length));
            }
            else if (no == 2)
            {
                Traingle tr = new Traingle();
                Console.WriteLine("Enter Traingle length:");
                tr.length = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Traingle height:");
                tr.height = double.Parse(Console.ReadLine());
                Console.WriteLine(" Traingle Area:" + tr.getArea(tr.length));
            }
            else if (no == 3)
            {
                Rect rc = new Rect();
                Console.WriteLine("Enter Rect length:");
                rc.length = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Traingle height:");
                rc.height = double.Parse(Console.ReadLine());
                Console.WriteLine(" Traingle Area:" + rc.getArea(rc.length));
            }
            else
            {
                Console.WriteLine("Not Found , please ener 1,2 or 3");
            }
        }
    }
}
