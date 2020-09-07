using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OMS_Solution.Models
{
    public class ProductDetails
    {

        public int productId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public decimal weight { get; set; }
        [Required]
        public decimal height { get; set; }
        public byte[] image { get; set; }
        [Required]
        public string SKU { get; set; }
        public string barCode { get; set; }
        [Required]
        public int availableQuantity { get; set; }
        [Required]
        public decimal price { get; set; }
    }
}