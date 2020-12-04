using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvc_najehacademy.Models
{
    public class NajehDB : DbContext
    {
        public NajehDB() : base("constr") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Major> Majors { get; set; }
    }
}