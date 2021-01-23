using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WCF_Ajax.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
    public class CarDb : DbContext
    {
        public CarDb() : base("constr") { }

        public DbSet<Car> Cars { get; set; }
    }
}