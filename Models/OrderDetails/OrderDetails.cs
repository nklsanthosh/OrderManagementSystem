using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagementSystem.Models.OrderDetails
{
    public class OrderDetails
    {
        public int productid { get; set; }

        public int quantity { get; set; }

        public decimal price { get; set; }

    }
}