using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practical_Project_2.Models
{
    public class Item
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Category is not selected")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Item Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Image file is required")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Item Price is required")]
        public double Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        public virtual Category Category { get; set; }
    }
}