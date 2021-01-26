using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practical_Project_2.ViewModel
{
    public class UserPasswordConfirmation
    {
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