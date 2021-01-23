using MVC_Core2.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core2.Models
{
    public class DemoCategory : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category> {
            new Category {CategoryID=100,CategoryName="SoftDrink" },
            new Category {CategoryID=101,CategoryName="HotDrink" }
            };
    }
}
