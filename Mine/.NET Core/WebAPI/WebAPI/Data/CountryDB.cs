using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public class CountryDB : DbContext
    {
        public CountryDB(DbContextOptions<CountryDB> options) : base(options)
        {
            //Disable "Lazy Loading"
            //ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Country> Countries { get; set; }
    }
}
