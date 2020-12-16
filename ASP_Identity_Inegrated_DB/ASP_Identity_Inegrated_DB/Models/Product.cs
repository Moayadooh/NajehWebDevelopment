namespace ASP_Identity_Inegrated_DB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public Guid ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Picture { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public int? Quantity { get; set; }
    }
}
