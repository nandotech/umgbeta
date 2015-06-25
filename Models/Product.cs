using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UmgBeta.Models
{
    public class Product
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; set; }
        public int ProductId { get; set; }
        [Required()]
        [MinLength(4)]
        [MaxLength(12)]
        public string ProductName { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}