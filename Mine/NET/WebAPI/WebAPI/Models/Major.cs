using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Major
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public int TotalHours { get; set; }

        public double Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}