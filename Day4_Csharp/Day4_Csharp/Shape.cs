using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Csharp
{
    abstract class Shape
    {
        public double length { get; set; }
        public abstract double getArea(double length);
    }
    class Square : Shape
    {
        public override double getArea(double length)
        {
            return length * length;
        }
    }
    class Traingle : Shape
    {
        public double height { get; set; }
        public override double getArea(double length)
        {
            return 0.5 * length * height;
        }
    }
    class Rect : Shape
    {
        public double height { get; set; }
        public override double getArea(double length)
        {
            return length * height;
        }
    }
}
