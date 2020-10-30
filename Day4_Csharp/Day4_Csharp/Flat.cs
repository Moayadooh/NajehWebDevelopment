using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Csharp
{
    class Flat : Product
    {
        public double area { get; set; }
        public int Rooms { get; set; }
        public override Guid Num
        {
            get => Guid.NewGuid();
            set => Num = value;
        }

        public override double getprice(double amount)
        {
            return area * amount;
        }
    }
}
