using MVC_Core2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core2.ViewModels
{
    public class DrinkViewModel
    {
        public IEnumerable<Drink> GetDrinks { get; set; } // Empty list
        public string CategoryName { get; set; } // Empty string
    }
}
