using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exam_70_486.Models
{
    public class MyDB : DbContext
    {
        public MyDB() : base("constr") { }

        public DbSet<LogModel> LogModels { get; set; }
    }
}