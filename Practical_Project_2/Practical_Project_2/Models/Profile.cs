using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Practical_Project_2.Models
{
    public class Profile
    {
        [Key][ForeignKey("User")]
        public Guid UserID { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public virtual User User { get; set; }
    }
}