using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Csharp
{
    class Mobile : Product
    {
        public string OS { get; set; }
        public string Cpu { get; set; }
        public double discount { get; set; }
        public override double getprice(double amount)
        {
            return (Price + (Price * amount)) - Price * discount;
        }
        public override Guid Num
        {
            get => Guid.NewGuid();
            set => Num = value;
        }
    }
}
