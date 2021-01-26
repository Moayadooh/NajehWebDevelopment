using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Practical_Project_2.Models
{
    public class User
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Genrerate Guid autotmatically
        public Guid ID { get; set; }

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

        public virtual Profile Profile { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<UserClaim> UserClaims { get; set; }
        public virtual List<UserPurchase> UserPurchases { get; set; }
    }
}