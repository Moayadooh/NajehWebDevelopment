using Microsoft.EntityFrameworkCore;
using MVC_Core2.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core2.Models
{
    public class DrinkRepo : IDrinkRepository
    {
        private ShopDbContext _db;
        public DrinkRepo(ShopDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Drink> AllDrinks
        {
            get
            {
                return _db.Drinks.Include(x => x.Category); // Call real data drink from Database
            }
        }
        public IEnumerable<Drink> DrinksOfweek
        {
            get
            {
                return _db.Drinks.Where(x => x.IsDrinkOfWeek == true);
            }
        }
        public Drink GetDrinkByID(int drinkid)
        {
            return _db.Drinks.Find(drinkid);
        }
    }
}
