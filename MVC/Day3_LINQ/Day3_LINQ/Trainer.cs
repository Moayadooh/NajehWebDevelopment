using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_LINQ
{
    class Trainer : Person
    {
        public string FieldTitle { get; set; }
        public double Salary { get; set; }
        public Profile Profile { get; set; }

        public List<Trainer> GetTrainers()
        {
            return new List<Trainer>
            {
                new Trainer {ID=567987, FieldTitle="Programming",FirstName="Mohammad",LastName="Zaher",Salary=3453},
                new Trainer {ID=5967987, FieldTitle="Graphic Design",FirstName="Muayyad",LastName="Alfalahi",Salary=4453}
            };
        }
    }
}
