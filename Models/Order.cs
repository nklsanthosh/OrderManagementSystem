using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS_Solution.Models
{
   
    public class Order
    {
        public int orderId { get; set; }

        public DateTime orderDate { get; set; }

        public int AddressId { get; set; }

        public decimal Total_Amount { get; set; }

        public string OrderStatus { get; set; }
    }
}