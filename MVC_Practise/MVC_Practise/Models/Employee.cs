using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Practise.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
    }
}