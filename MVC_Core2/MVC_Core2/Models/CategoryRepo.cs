using MVC_Core2.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core2.Models
{
    public class CategoryRepo : ICategoryRepository
    {
        private ShopDbContext _db;
        public CategoryRepo(ShopDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Category> AllCategories => _db.Categories;
    }
}
