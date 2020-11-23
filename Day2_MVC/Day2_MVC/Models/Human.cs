using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day2_MVC.Models
{
    public class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public static List<Human> GetHumen()
        {
            return new List<Human>()
            {
                new Human(){Name="Moayad", Age=23},
                new Human(){Name="Mohanned", Age=21},
                new Human(){Name="Mohammed", Age=19},
            };
        }
    }
}