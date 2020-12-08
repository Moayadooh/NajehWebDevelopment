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

        public NajehDB(string x) : base("constr")
        {
            this.Configuration.LazyLoadingEnabled = false; // this statement to turn api on
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Junction> Junctions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<News> News { get; set; }
    }
}