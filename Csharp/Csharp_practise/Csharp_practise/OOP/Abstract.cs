using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_practise.OOP
{
    class Abstract
    {
        public void Run()
        {
            int num = 0;
            while (num != 4)
            {
                Console.WriteLine("\nSelect a choise: ");
                Console.WriteLine("1 - Calculate area of the square");
                Console.WriteLine("2 - Calculate area of the triangle");
                Console.WriteLine("3 - Calculate area of the rectangle");
                Console.WriteLine("4 - Exit");
                num = int.Parse(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        Square square = new Square();
                        Console.Write("Enter length of the square: ");
                        square.length = double.Parse(Console.ReadLine());
                        Console.WriteLine("Area of the square: " + square.calcArea(square.length));
                        break;
                    case 2:
                        Triangle triangle = new Triangle();
                        Console.Write("Enter length of the triangle: ");
                        triangle.length = double.Parse(Console.ReadLine());
                        Console.Write("Enter height of the triangle: ");
                        triangle.height = double.Parse(Console.ReadLine());
                        Console.WriteLine("Area of the square: " + triangle.calcArea(triangle.length));
                        break;
                    case 3:
                        Rectangle rectangle = new Rectangle();
                        Console.Write("Enter length of the rectangle: ");
                        rectangle.length = double.Parse(Console.ReadLine());
                        Console.Write("Enter height of the triangle: ");
                        rectangle.height = double.Parse(Console.ReadLine());
                        Console.WriteLine("Area of the square: " + rectangle.calcArea(rectangle.length));
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Please enter a correct number!!");
                        break;
                }
            }
        }
    }
    abstract class Shape
    {
        public double length { get; set; }

        abstract public double calcArea(double length);
    }
    class Square : Shape
    {
        public override double calcArea(double length)
        {
            return length * length;
        }
    }
    class Triangle : Shape
    {
        public double height { get; set; }

        public override double calcArea(double length)
        {
            return .5 * height * length;
        }
    }
    class Rectangle : Shape
    {
        public double height { get; set; }

        public override double calcArea(double length)
        {
            return height * length;
        }
    }
}
