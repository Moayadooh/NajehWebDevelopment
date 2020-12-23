using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core2.Models
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Drink> Drinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 1, CategoryName = "Soft" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 2, CategoryName = "Hot" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 3, CategoryName = "smoothie" });

            //seed pies
            modelBuilder.Entity<Drink>().HasData(new Drink
            {
                DrinkID = 1,
                Name = "Kara",
                Price = 12.95,
                Description = "karak trea description",
                CategoryID = 1,
                ImageUrl = "Images/karak.jpeg",
                InStock = true,
                IsDrinkOfWeek = true,
            });
            modelBuilder.Entity<Drink>().HasData(new Drink
            {
                DrinkID = 2,
                Name = "Pepsi",
                Price = 12.95,
                Description = "pepsi trea description",
                CategoryID = 1,
                ImageUrl = "Images/pepsi.jpg",
                InStock = true,
                IsDrinkOfWeek = true,
            });
            modelBuilder.Entity<Drink>().HasData(new Drink
            {
                DrinkID = 3,
                Name = "Tea Soluimani",
                Price = 12.95,
                Description = "Tea Description",
                CategoryID = 1,
                ImageUrl = "Images/tea.png",
                InStock = true,
                IsDrinkOfWeek = true,
            });
        }
    }
}
