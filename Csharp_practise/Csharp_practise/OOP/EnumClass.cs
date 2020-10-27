using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_practise.OOP
{
    class EnumClass
    {
        public void Run()
        {
            Person person = new Person();
            person.Name = "Moayad";
            person.Dir = Direction.NORTH;
            Console.WriteLine("Person name: " + person.Name);
            string whereHeWent = (person.Dir == Direction.SOUTH) ? "He went to the south" : "I do not no where he went!";
            Console.WriteLine(whereHeWent);
        }
    }

    class Person
    {
        public string Name { get; set; }
        public Direction Dir { get; set; }
    }

    public enum Direction
    {
        WEST, NORTH, SOUTH, EAST
    }
}
