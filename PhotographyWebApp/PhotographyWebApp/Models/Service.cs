using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotographyWebApp.Models
{
    public class Service
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public int OrderID { get; set; } // FK 
        public virtual Order Order { get; set; } // Connect relationship as 1 to many

    }
}