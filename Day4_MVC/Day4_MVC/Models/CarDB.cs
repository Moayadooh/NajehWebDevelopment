using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Day4_MVC.Models
{
    public class CarDB : DbContext
    {
        public CarDB() : base("constr") { }

        public DbSet<Car> Cars { get; set; }
    }
}