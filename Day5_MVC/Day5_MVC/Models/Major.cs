using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day5_MVC.Models
{
    public class Major
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public virtual List<User> Users { get; set; }
    }
}