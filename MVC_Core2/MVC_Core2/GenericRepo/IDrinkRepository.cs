using MVC_Core2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core2.GenericRepo
{
    public interface IDrinkRepository
    {
        IEnumerable<Drink> AllDrinks { get; }
        IEnumerable<Drink> DrinksOfweek { get; }
        Drink GetDrinkByID(int drinkid);
    }
}
