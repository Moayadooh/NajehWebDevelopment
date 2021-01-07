using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotographyWebApp.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
      
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public int InvoiceID { get; set; } //FK
        public virtual Invoice Invoice { get; set; }

        public virtual List<Service> Services { get; set; }

    }
}