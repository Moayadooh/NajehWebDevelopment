using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotographyWebApp.Models
{
    public class DropDown_Branch
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string SubName { get; set; }

        public int DropDown_ServiceID { get; set; } // FK 
        public virtual DropDown_Service DropDown_Service { get; set; } 
    }
}