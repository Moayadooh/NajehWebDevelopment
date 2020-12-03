using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Day5_MVC.Models
{
    public class Account
    {
        [Key][ForeignKey("User")] // User is a property name
        public int ID { get; set; }

        [Required]
        public string FullNmae { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Birth { get; set; }

        public string Image { get; set; }

        public virtual User User { get; set; } // one to one
    }
}