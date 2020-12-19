using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Payment.Models
{
    public class TVDB : DbContext
    {
        public TVDB() : base("constr") { }

        //public DbSet<ads> ads { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}