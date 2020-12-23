using MVC_Core2.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core2.Models
{
    public class DemoDrink : IDrinkRepository
    {
        private ICategoryRepository _catrepo = new DemoCategory(); // fill from demo data to header property directly
        public IEnumerable<Drink> AllDrinks =>
            new List<Drink>
            {
                new Drink { DrinkID= 1,Name="Tea",Price=100,InStock=true,
                            Description="Hot Drink with cardamom",IsDrinkOfWeek=true,
                       ImageUrl="/Images/Tea.png",Category=_catrepo.AllCategories.ToList()[1] },

                new Drink { DrinkID= 2,Name="Pepsi",Price=150,InStock=true,
                            Description="Soft Drink with soda",IsDrinkOfWeek=false,
                       ImageUrl="/Images/pepsi.jpg",Category=_catrepo.AllCategories.ToList()[0] },

                new Drink { DrinkID= 3,Name="Karak",Price=200,InStock=true,
                            Description="Hot Drink with cardamom and milk",IsDrinkOfWeek=true,
                       ImageUrl="/Images/Karak.jpeg",Category=_catrepo.AllCategories.ToList()[1] }
            };

        public IEnumerable<Drink> DrinksOfweek { get; }
        public Drink GetDrinkByID(int drinkid)
        {
            return AllDrinks.FirstOrDefault(x => x.DrinkID == drinkid);
        }
    }
}
