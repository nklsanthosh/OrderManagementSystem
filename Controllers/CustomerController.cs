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
    public class CustomerController : ApiController
    {

        [Route("api/Customer/GetallCustomers")]
        [HttpGet]
        public IHttpActionResult GetAllCustomers()
        {
            List<CustomerDetails> customerDetails = new List<CustomerDetails>();
            using (var db = new OMSEF())
            {
                var allCustomers = (from a in db.CustomerDetails select a).ToList();
                foreach (var a in allCustomers)
                {
                    CustomerDetails cd = new CustomerDetails();
                    cd.CustomerAge = a.CustomerAge;
                    cd.CustomerEmail = a.CustomerEmail;
                    cd.CustomerGender = a.CustomerGender;
                    cd.CustomerId = a.CustomerId;
                    cd.CustomerName = a.CustomerName;
                    cd.CustomerPhone = a.CustomerPhone;
                    cd.UserRoleId = a.RoleId;
                    customerDetails.Add(cd);
                }
            }
            return Ok(customerDetails);
        }

        [Route("api/Customer/GetCustomer")]
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            if (id != null)
            {
                CustomerDetails cd = new CustomerDetails();
                using (var db = new OMSEF())
                {
                    var customerDetail = db.CustomerDetails.Where(s => s.CustomerId == id).FirstOrDefault();

                    if (customerDetail != null)
                    {
                        cd.CustomerAge = customerDetail.CustomerAge;
                        cd.CustomerEmail = customerDetail.CustomerEmail;
                        cd.CustomerGender = customerDetail.CustomerGender;
                        cd.CustomerId = customerDetail.CustomerId;
                        cd.CustomerName = customerDetail.CustomerName;
                        cd.CustomerPhone = customerDetail.CustomerPhone;
                        cd.UserRoleId = customerDetail.RoleId;
                    }
                }
                return Ok(cd);
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("api/Customer/addCustomer")]
        [HttpPost]
        public IHttpActionResult AddCustomer([FromBody] CustomerDetails cd)
        {

            using (var db = new OMSEF())
            {
                var customer = new CustomerDetail();

                customer.CustomerAge = cd.CustomerAge;
                customer.CustomerEmail = cd.CustomerEmail;
                customer.CustomerGender = cd.CustomerGender;
                customer.CustomerPhone = cd.CustomerPhone;
                customer.Password = cd.Password;
                customer.CustomerName = cd.CustomerName;
                customer.RoleId = cd.UserRoleId;

                db.CustomerDetails.Add(customer);

                db.SaveChanges();
            }

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [Route("api/Customer/deleteCustomer")]
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (id != null)
            {
                using (var db = new OMSEF())
                {
                    var customerDetail = db.CustomerDetails.Where(s => s.CustomerId == id).FirstOrDefault();
                    if (customerDetail != null)
                    {
                        db.Entry(customerDetail).State = System.Data.Entity.EntityState.Deleted;
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
        [Route("api/Customer/UpdateCustomer")]
        [HttpPut]
        public IHttpActionResult UpdateCustomer([FromBody] CustomerDetails cd)
        {
            bool isUpdated = false;
            if (ModelState.IsValid)
            {
                using (var db = new OMSEF())
                {
                    var customerDetail = db.CustomerDetails.Where(s => s.CustomerId == cd.CustomerId).FirstOrDefault();

                    if (customerDetail != null)
                    {
                        customerDetail.CustomerAge = cd.CustomerAge;
                        customerDetail.CustomerEmail = cd.CustomerEmail;
                        customerDetail.CustomerGender = cd.CustomerGender;
                        customerDetail.CustomerPhone = cd.CustomerPhone;
                        customerDetail.Password = cd.Password;
                        customerDetail.CustomerName = cd.CustomerName;
                        customerDetail.RoleId = cd.UserRoleId;

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

