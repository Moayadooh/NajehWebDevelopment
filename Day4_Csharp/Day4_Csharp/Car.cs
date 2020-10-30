using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Csharp
{
    class Car : Product
    {
        public string color { get; set; }
        public DateTime ModelNo { get; set; }
        public override Guid Num
        {
            get => Guid.NewGuid();
            set => Num = value;
        }
        public override double getprice(double amount)
        {
            return Price + (Price * amount);
        }
    }
}
