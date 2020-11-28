using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Practise.Models
{
    public class CollegeDB : DbContext
    {
        public CollegeDB() : base("constr") { }
        public DbSet<Student> Students { get; set; }
    }
}