using OrderManagementSystem.BusinessLogic.Product;
using OrderManagementSystem.Models.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagementSystem.BusinessLogic.Order
{
    public class SaveCalculation
    {

        public OrderMaster totalPriceCalculation(OrderMaster orderMaster)
        {
            decimal result = 0;

            List<OrderDetails> orderDetails = new List<OrderDetails>();
            orderDetails = orderMaster.orderDetails;

            foreach (var i in orderDetails)
            {
                result = result + price(i);
            }

            orderMaster.totalPrice = result;
            return orderMaster;
        }

        private decimal price(OrderDetails orderDetails)
        {
            decimal productValue = 0;
            GetProductDetails getProductDetails = new GetProductDetails();
            int quantity = orderDetails.quantity;
            decimal? outPutprice = getProductDetails.GetIndividualProductDetail(orderDetails.productid).price;
            decimal price = (decimal)(outPutprice != null ? outPutprice : 0);
            orderDetails.price = price;
            productValue = quantity * price;
            return productValue;

        }
    }
}