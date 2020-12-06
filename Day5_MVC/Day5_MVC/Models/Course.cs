using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day5_MVC.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Hours { get; set; }

        public List<Junction> Junctions { get; set; } // many to many
    }
}