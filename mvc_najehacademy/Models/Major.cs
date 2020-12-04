using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_najehacademy.Models
{
    public class Major
    {
        public int ID { get; set; } // PK

        public string Title { get; set; }

        public virtual List<User> Users { get; set; }
    }
}