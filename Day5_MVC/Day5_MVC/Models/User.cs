using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Day5_MVC.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"[a-zA-Z0-9_\.+]+@(live|hotmail|gmail)(\.com|\.om)",
            ErrorMessage = "Must be live, hotmail or gmail")]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20,MinimumLength = 3)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")] // refer to the Password field
        public string Confirm { get; set; }
    }
}