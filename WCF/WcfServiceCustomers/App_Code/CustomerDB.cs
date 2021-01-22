using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class CustomerDB : DbContext
{
    public CustomerDB() : base("constr") { }

    public DbSet<Customer> Customers { get; set; }

}