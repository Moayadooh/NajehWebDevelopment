using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practical_Project_2.Models
{
    public class UserRole
    {
        [Key]
        public int ID { get; set; }

        public Guid UserID { get; set; }

        public int RoleID { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}