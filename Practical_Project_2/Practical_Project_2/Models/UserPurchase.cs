using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practical_Project_2.Models
{
    public class UserPurchase
    {
        [Key]
        public int ID { get; set; }

        public Guid UserID { get; set; }

        [Display(Name = "Number of Items")]
        public int NumOfItems { get; set; }

        [Display(Name = "Total Price")]
        public double TotalPrice { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Date and Time")]
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
    }
}