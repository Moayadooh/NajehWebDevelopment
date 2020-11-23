using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day2_MVC.Models
{
    public class Car
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public static List<Car> GetCars()
        {
            return new List<Car>()
            {
                new Car(){Name="Nissan", Year=2010},
                new Car(){Name="Suzuki", Year=2015},
                new Car(){Name="Corola", Year=2020},
            };
        }
    }
}