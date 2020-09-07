using OrderManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagementSystem.Controllers
{
    public class ShippingAddressController : ApiController
    {
        [Route("api/ShippingAddress/GetallAddresses")]
        [HttpGet]
        public IHttpActionResult GetallAddresses()
        {
            List<ShippingAddresses> shippingAddresses = new List<ShippingAddresses>();
            using (var db = new OMSEF())
            {
                var allAddresses = (from a in db.ShippingAddresses select a).ToList();

                foreach (var a in allAddresses)
                {
                    ShippingAddresses sa = new ShippingAddresses();
                    sa.Address1 = a.Address1;
                    sa.Address2 = a.Address2;
                    sa.AddressID = a.AddressID;
                    sa.City = a.City;
                    sa.PinCode = a.PinCode;
                    sa.State = a.State;

                    shippingAddresses.Add(sa);
                }
            }
            return Ok(shippingAddresses);
        }

        [Route("api/ShippingAddress/GetAddress")]
        [HttpGet]
        public IHttpActionResult GetAddress(int id)
        {
            ShippingAddresses sa = new ShippingAddresses();
            using (var db = new OMSEF())
            {
                var userRole = db.ShippingAddresses.Where(s => s.AddressID == id).FirstOrDefault();

                if (userRole != null)
                {
                    sa.Address1 = userRole.Address1;
                    sa.Address2 = userRole.Address2;
                    sa.AddressID = userRole.AddressID;
                    sa.City = userRole.City;
                    sa.PinCode = userRole.PinCode;
                    sa.State = userRole.State;
                }
            }
            return Ok(sa);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/ShippingAddress/AddAddress")]
        [HttpPost]
        public IHttpActionResult AddAddress([FromBody] ShippingAddresses sa)
        {

            using (var db = new OMSEF())
            {
                db.ShippingAddresses.Add(new ShippingAddress
                {
                    Address1 = sa.Address1,
                    Address2 = sa.Address2,
                    City = sa.City,
                    PinCode = sa.PinCode,
                    State = sa.State
                });
                db.SaveChanges();
            }
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [Route("api/ShippingAddress/DeleteAddress")]
        [HttpDelete]
        public IHttpActionResult DeleteAddress(int id)
        {
            using (var db = new OMSEF())
            {
                var shippingAddress = db.ShippingAddresses.Where(s => s.AddressID == id).FirstOrDefault();
                if (shippingAddress != null)
                {
                    db.Entry(shippingAddress).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
                return Ok();
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("api/ShippingAddress/UpdateAddress")]
        [HttpPut]
        public IHttpActionResult UpdateAddress([FromBody] ShippingAddresses sa)
        {
            using (var db = new OMSEF())
            {
                var shippingAddress = db.ShippingAddresses.Where(s => s.AddressID == sa.AddressID).FirstOrDefault();

                if (shippingAddress != null)
                {
                    shippingAddress.Address1 = sa.Address1;
                    shippingAddress.Address2 = sa.Address2;
                    shippingAddress.City = sa.City;
                    shippingAddress.PinCode = sa.PinCode;
                    shippingAddress.State = sa.State;
                }
                db.SaveChanges();
            }
            return Ok();

        }
    }
}
