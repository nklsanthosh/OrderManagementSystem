using OMS_Solution.Models;
using OrderManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OrderManagementSystem.BusinessLogic.Product
{
    public class GetProductDetails
    {
        public ProductDetails GetIndividualProductDetail(int id)
        {
            if (id != null)
            {
                ProductDetails pd = new ProductDetails();
                using (var db = new OMSEF())
                {
                    var productdetail = db.ProductDetails.Where(s => s.ProductId == id).FirstOrDefault();

                    if (productdetail != null)
                    {
                        pd.availableQuantity = productdetail.AvailableQuantity;
                        pd.barCode = productdetail.Barcode;
                        pd.height = productdetail.Height;
                        pd.image = productdetail.Image;
                        pd.name = productdetail.Name;
                        pd.productId = productdetail.ProductId;
                        pd.weight = productdetail.Weight;
                        pd.price = productdetail.Price;
                        pd.SKU = productdetail.SKU;
                    }
                }
                return pd;
            }
            else
            {
                return null;
            }
        }
    }
}
