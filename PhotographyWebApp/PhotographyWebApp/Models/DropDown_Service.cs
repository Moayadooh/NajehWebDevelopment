using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotographyWebApp.Models
{
    public class DropDown_Service
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual List<DropDown_Branch> DropDown_Branchs { get; set; }

    }
}