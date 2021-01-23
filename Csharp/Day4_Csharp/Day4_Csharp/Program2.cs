using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Csharp
{
    class Program2
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.color = "red";
            car.ModelNo = DateTime.Now;
            car.owner = "ammar";
            car.Price = 1000;
            Console.WriteLine("Car Color " + car.color);
            Console.WriteLine("Car ModelNo " + car.ModelNo);
            Console.WriteLine("Car Owner " + car.owner);
            Console.WriteLine("Car Price " + car.Price + " OMR");
            Console.WriteLine("Car Nett Price " + car.getprice(0.12) + " OMR");
            Console.WriteLine("Car Code " + car.Num);
            Console.WriteLine("=============================================================");

            Flat flt = new Flat();
            flt.area = 200;
            flt.Price = 300;
            flt.Rooms = 2;
            flt.owner = "ali";
            Console.WriteLine("Flat area " + flt.area);
            Console.WriteLine("Flat Owner " + flt.owner);
            Console.WriteLine("Flat Price " + flt.Price + " OMR");
            Console.WriteLine("Flat Nett Price " + flt.getprice(23) + " OMR");
            Console.WriteLine("Flat Code " + flt.Num);
            Console.WriteLine("=============================================================");

            Mobile mobile = new Mobile();
            mobile.Cpu = "1.7";
            mobile.Price = 300;
            mobile.OS = "android";
            mobile.owner = "ali";
            mobile.discount = 0.2;
            Console.WriteLine("mobile area " + mobile.Cpu);
            Console.WriteLine("mobile OS " + mobile.OS);
            Console.WriteLine("mobile Owner " + mobile.owner);
            Console.WriteLine("mobile Price " + mobile.Price + " OMR");
            Console.WriteLine("mobile Nett Price " + mobile.getprice(.12) + " OMR");
            Console.WriteLine("mobile Code " + mobile.Num);
        }
    }
}
