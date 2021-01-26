using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Practical_Project_2.ViewModel
{
    public class UserIntegrationLogin
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"[a-zA-Z0-9_\.+]+@(outlook|icloud|gmail)(\.com|\.om)", ErrorMessage = "Must be outlook, icloud or gmail")]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}