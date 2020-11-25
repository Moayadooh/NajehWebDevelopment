using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Day3_MVC.Models
{
    public class CompanyDB : DbContext
    {
        //Create Database
        public CompanyDB() : base("constr") { }

        //Create Tables
        public DbSet<Employee> Employees { get; set; }
    }
}