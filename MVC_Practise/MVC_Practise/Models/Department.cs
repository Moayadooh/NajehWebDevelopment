using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Practise.Models
{
    public class Department
    {
        [Key][ForeignKey("Employees")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}