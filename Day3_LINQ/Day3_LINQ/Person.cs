using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_LINQ
{
    abstract class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
