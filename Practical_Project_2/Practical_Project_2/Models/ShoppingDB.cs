using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practical_Project_2.Models
{
    public class ShoppingDB : DbContext
    {
        public ShoppingDB() : base("constr") { }
        public ShoppingDB(string x) : base("constr") 
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserPurchase> UserPurchases { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}