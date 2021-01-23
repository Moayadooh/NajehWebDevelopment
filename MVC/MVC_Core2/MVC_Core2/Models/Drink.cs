using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core2.Models
{
    public class Drink
    {
        public int DrinkID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool InStock { get; set; }
        public bool IsDrinkOfWeek { get; set; }
        public string feedback { get; set; }
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
