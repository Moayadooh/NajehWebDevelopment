using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class MajorDB : DbContext
    {
        public MajorDB() : base("constr") { }
        public MajorDB(string x) : base("constr")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Major> Majors { get; set; }
    }
}