using OMS_Solution.Models;
using OrderManagementSystem.BusinessLogic.Order;
using OrderManagementSystem.Models.OrderDetails;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Web.Http;

namespace OrderManagementSystem.Controllers
{
    public class OrderController : ApiController
    {
        //private readonly AuthorizeRolesAttribute _authorizeRolesAttribute;


        [Route("api/Order/GetallOrders")]
        [Authorize]
        [HttpGet]
        public IHttpActionResult GetAllOrders()
        {
            // System.Security.Principal.IIdentity principal 
            // string abc = User.Identity.AuthenticationType

            return Ok();
        }

        [Route("api/Order/GetOrder")]
        [Authorize]
        [HttpGet]
        public IHttpActionResult GetOrder()
        {

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [Route("api/Order/addOrder")]
        [HttpPost]
        public IHttpActionResult AddOrder([FromBody] OrderMaster orderMaster)
        {
            SaveCalculation saveCalculation = new SaveCalculation();
            saveCalculation.totalPriceCalculation(orderMaster);
            orderMaster.orderDate = DateTime.Now;
            bool orderCreated = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMS"].ToString()))
            {
                connection.Open();
                SqlCommand testCMD = new SqlCommand("createorder", connection);
                testCMD.CommandType = CommandType.StoredProcedure;


                testCMD.Parameters.Add(new SqlParameter("@OrderDate", System.Data.SqlDbType.VarChar, 50) { Value = orderMaster.orderDate });
                testCMD.Parameters.Add(new SqlParameter("@AddressId", System.Data.SqlDbType.VarChar, 50) { Value = orderMaster.addressId });
                testCMD.Parameters.Add(new SqlParameter("@Total_Amount", System.Data.SqlDbType.VarChar, 50) { Value = orderMaster.totalPrice });
                testCMD.Parameters.Add(new SqlParameter("@OrderMasterId", System.Data.SqlDbType.VarChar, 50) { Value = orderMaster.orderId });
                testCMD.Parameters["@OrderMasterId"].Direction = ParameterDirection.Output;

                testCMD.ExecuteNonQuery(); // read output value from @NewId 
                orderMaster.orderId = Convert.ToInt32(testCMD.Parameters["@OrderMasterId"].Value);

                List<OrderDetails> orderDetails = new List<OrderDetails>();
                orderDetails = orderMaster.orderDetails;
                foreach (var i in orderDetails)
                {
                    SqlCommand testCMD1 = new SqlCommand("createorderdetail", connection);
                    testCMD1.CommandType = CommandType.StoredProcedure;


                    testCMD1.Parameters.Add(new SqlParameter("@OrderMasterId", System.Data.SqlDbType.VarChar, 50) { Value = orderMaster.orderId });
                    testCMD1.Parameters.Add(new SqlParameter("@ProductId", System.Data.SqlDbType.VarChar, 50) { Value = i.productid });
                    testCMD1.Parameters.Add(new SqlParameter("@Quantity", System.Data.SqlDbType.VarChar, 50) { Value = i.quantity });
                    testCMD1.Parameters.Add(new SqlParameter("@Price", System.Data.SqlDbType.VarChar, 50) { Value = i.quantity });

                    testCMD1.ExecuteNonQuery();
                }

                orderCreated = SendMail("Order Number :" + orderMaster.orderId + " is Created on " + DateTime.Now);
            }

            if (orderCreated)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        private static bool SendMail(string body)
        {
            bool mailSent = false;
            string message = DateTime.Now + " In SendMail\n";

            using (MailMessage mm = new MailMessage())
            {
                mm.From = new MailAddress(Convert.ToString(ConfigurationManager.AppSettings["From"]));
                string[] _toAddress = Convert.ToString(ConfigurationManager.AppSettings["To"]).Split(';');
                foreach (string address in _toAddress)
                {
                    mm.To.Add(address);
                }
                mm.Subject = ConfigurationManager.AppSettings["Subject"];
                mm.Body = body;
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["Username"],
                    ConfigurationManager.AppSettings["Password"]);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);

                message = DateTime.Now + " Sending Mail\n";
                smtp.Send(mm);
                message = DateTime.Now + " Mail Sent\n";

                System.Threading.Thread.Sleep(3000);
                mailSent = true;
            }
            return mailSent;
        }

        [Route("api/Order/deleteOrder")]
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IHttpActionResult DeleteOrder(int id)
        {
            return Ok();
        }

        //[AuthorizeEnum(Role.Admin)]
        // [Authorize(User.Identity.AuthenticationType = "Admin")]
        // [AuthorizeRolesAttribute(false)]
        [Authorize(Roles = "Admin")]
        [Route("api/Order/UpdateOrder")]
        [HttpPut]
        public IHttpActionResult UpdateOrder(int id)
        {
            return Ok();
        }
    }
}
