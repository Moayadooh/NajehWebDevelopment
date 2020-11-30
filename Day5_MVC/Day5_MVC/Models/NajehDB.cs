using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Day5_MVC.Models
{
    public class NajehDB : DbContext
    {
        public NajehDB() : base("constr") { }

        public DbSet<User> Users { get; set; }
    }
}