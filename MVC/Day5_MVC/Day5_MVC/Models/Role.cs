using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day5_MVC.Models
{
    public class Role
    {
        [Key]
        public Guid RoleID { get; set; }

        [Required]
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; } // ICollection same as List
    }
}