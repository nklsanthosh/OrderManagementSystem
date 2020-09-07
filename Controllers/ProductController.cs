using OMS_Solution.Models;
using OrderManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagementSystem.Controllers
{
    public class ProductController : ApiController
    {
        [Route("api/product/Getallproducts")]
        [HttpGet]
        public IHttpActionResult GetAllProducts()
        {
            List<ProductDetails> productDetails = new List<ProductDetails>();
            using (var db = new OMSEF())
            {
                var allProducts = (from a in db.ProductDetails select a).ToList();

                foreach (var a in allProducts)
                {
                    ProductDetails pd = new ProductDetails();
                    pd.availableQuantity = a.AvailableQuantity;
                    pd.barCode = a.Barcode;
                    pd.height = a.Height;
                    pd.image = a.Image;
                    pd.name = a.Name;
                    pd.productId = a.ProductId;
                    pd.weight = a.Weight;
                    pd.price = a.Price;
                    pd.SKU = a.SKU;

                    productDetails.Add(pd);
                }
            }
            return Ok(productDetails);
        }

        [Route("api/product/GetProduct/{id}")]
        [HttpGet]
        public IHttpActionResult GetProduct(int id)
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
                return Ok(pd);
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("api/product/addproduct")]
        [HttpPost]
        public IHttpActionResult AddProduct([FromBody] ProductDetails pd)
        {
            if (ModelState.IsValid)
            {
                using (var db = new OMSEF())
                {
                    db.ProductDetails.Add(new ProductDetail
                    {
                        AvailableQuantity = pd.availableQuantity,
                        Barcode = pd.barCode,
                        Height = pd.height,
                        Image = pd.image,
                        Name = pd.name,
                        Price = pd.price,
                        SKU = pd.SKU,
                        Weight = pd.weight
                    });
                    db.SaveChanges();
                }
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("api/product/deleteproduct/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            if (id != null)
            {
                using (var db = new OMSEF())
                {
                    var productdetail = db.ProductDetails.Where(s => s.ProductId == id).FirstOrDefault();
                    if (productdetail != null)
                    {
                        db.Entry(productdetail).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                    }

                    return Ok();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("api/product/Updateproduct")]
        [HttpPut]
        public IHttpActionResult UpdateProduct([FromBody] ProductDetails pd)
        {
            bool isUpdated = false;
            if (ModelState.IsValid)
            {
                using (var db = new OMSEF())
                {
                    var productdetail = db.ProductDetails.Where(s => s.ProductId == pd.productId).FirstOrDefault();

                    if (productdetail != null)
                    {
                        productdetail.AvailableQuantity = pd.availableQuantity;
                        productdetail.Barcode = pd.barCode;
                        productdetail.Height = pd.height;
                        productdetail.Image = pd.image;
                        productdetail.Name = pd.name;
                        productdetail.Price = pd.price;
                        productdetail.SKU = pd.SKU;
                        productdetail.Weight = pd.weight;
                        db.SaveChanges();
                        isUpdated = true;
                    }
                }
                if (isUpdated)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
