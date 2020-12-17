using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Repository_Pattern.Models
{
    public class SchoolDB : DbContext
    {
        public SchoolDB() : base("constr") { }

        public DbSet<User> Users { get; set; }
    }
}