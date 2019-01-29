using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceSite.Models
{
    public class Product
    {
        [Key] //Makes this PK(Primary Key) in DB
        public int ProductID { get; set; }

        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0.0, 1000000.0)]
        public double Price { get; set; }

        [Required]
        public string Category { get; set; }

    }
}
