using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_practise
{
    class Structure
    {
        struct Person
        {
            public string name;
            public int age;
        }

        public void Run()
        {
            Person p = new Person();
            p.name = "Eyad";
            p.age = 1;
            //Person p = new Person
            //{
            //    name = "Eyad",
            //    age = 1
            //};
            Console.WriteLine("Person name: {0}", p.name);
            Console.WriteLine($"Person age: {p.age} year");
        }
    }
}
