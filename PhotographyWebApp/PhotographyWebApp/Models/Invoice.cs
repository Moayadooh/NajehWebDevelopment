using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotographyWebApp.Models
{
    public class Invoice
    {
        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; } //FK
        public virtual UserInfo User { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}