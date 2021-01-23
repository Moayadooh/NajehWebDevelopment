using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceNewsOM
{
    public class NewsDB : DbContext
    {
        public NewsDB() : base("constr2") { }
        public DbSet<News> News { get; set; }
    }
}
