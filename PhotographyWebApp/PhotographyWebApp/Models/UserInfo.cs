using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhotographyWebApp.Models
{
    public class UserInfo
    {
        [Key]
        public String ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Index(IsUnique =true)]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(20)]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Length should be between 6 and 20", MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [StringLength(100, ErrorMessage = "Length should be between 6 and 20", MinimumLength = 6)]
        public string Confirm { get; set; }

        //-------------------------------------------------------------

        public virtual List<Invoice> Invoices { get; set; }
    }
}