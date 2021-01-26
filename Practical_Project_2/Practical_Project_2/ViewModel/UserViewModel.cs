using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Practical_Project_2.ViewModel
{
    public class UserViewModel
    {
        [Required]
        [MaxLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"[a-zA-Z0-9_\.+]+@(outlook|icloud|gmail)(\.com|\.om)", ErrorMessage = "Must be outlook, icloud or gmail")]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 3)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Password Confirmation")]
        public string ConfirmPassword { get; set; }
    }
}