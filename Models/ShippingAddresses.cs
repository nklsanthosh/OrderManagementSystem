using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderManagementSystem.Models
{
    public class ShippingAddresses
    {
        public int AddressID { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public int? PinCode { get; set; }
        [Required]
        public int CustomerId { get; set; }

    }
}