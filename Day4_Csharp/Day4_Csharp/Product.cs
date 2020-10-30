using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Csharp
{
    public abstract class Product
    {
        public double Price { get; set; }
        public string owner { get; set; }
        
        //abstract property
        public abstract Guid Num { get; set; }

        //abstract method
        public abstract double getprice(double amount);


        
    }

}
