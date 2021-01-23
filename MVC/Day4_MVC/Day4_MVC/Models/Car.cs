using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day4_MVC.Models
{
    public class Car
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please fill out brand textbox")]
        [MaxLength(20)]
        public string Brand { get; set; }

        [StringLength(30,ErrorMessage = "Should be between 4 and 30 letters",MinimumLength = 4)]
        [Required]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please pick date release"),DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Date Release")]
        public DateTime DateRelease { get; set; }

        public string Color { get; set; }
    }
}