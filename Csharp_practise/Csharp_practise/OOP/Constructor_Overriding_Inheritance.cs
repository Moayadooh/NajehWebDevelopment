using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_practise.OOP
{
    class Constructor_Overriding_Inheritance
    {
        public void Run()
        {
            Apple apple = new Apple("iPhone");
            Console.WriteLine("Device type: " + apple.type);
            apple.weight = 0.5;
            Console.WriteLine($"{apple.type} weight: " + apple.weight);
            apple.price = 200.0;
            Console.WriteLine($"{apple.type} price: " + apple.price);
            Console.WriteLine($"{apple.type} price with tax: " + apple.calcPrice(0.1));
        }
    }
    class Device
    {
        public Device()
        {
            Console.WriteLine("Constructor");
        }
        public Device(string type)
        {
            this.type = type;
        }
        public string type;
        private double _Weight;

        //Override Property
        public virtual double weight
        {
            set { _Weight = value; }
            get { return _Weight; }
        }
        public virtual double price { get; set; }

        //Override Function
        public virtual double calcPrice(double tax)
        {
            return tax;
        }

        ~Device()
        {
            Console.WriteLine("Destructor");
        }
    }
    class Apple : Device
    {
        public Apple() : base() { }
        public Apple(string type) : base(type) { }
        
        //public override double weight { get => base.weight; set => base.weight = value; }
        //public override double price { get => base.price; set => base.price = value; }
        public override double calcPrice(double tax)
        {
            return price + price * base.calcPrice(tax);
        }
    }
}
