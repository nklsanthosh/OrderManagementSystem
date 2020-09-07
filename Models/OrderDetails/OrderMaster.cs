using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagementSystem.Models.OrderDetails
{
    public class OrderMaster

    {
        public int orderId { get; set; }
        public DateTime orderDate { get; set; }

        public string addressId { get; set; }

        public List<OrderDetails> orderDetails;

        public decimal totalPrice { get; set; }

    }
}