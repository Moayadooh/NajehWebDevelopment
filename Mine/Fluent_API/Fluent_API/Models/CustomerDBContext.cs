using Fluent_API.Models.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluent_API.Models
{
    public class CustomerDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here  

            //modelBuilder.Entity<Customer>()
            //        .Property(c => c.Name)
            //        .IsRequired()
            //        .HasMaxLength(55);

            //modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);
            // Pass any of the entity type configuration class as the parameter of typeof().  
            // EF core will scan the assembly containing that class for finding out the remaining entity configurations
        }
    }
}
