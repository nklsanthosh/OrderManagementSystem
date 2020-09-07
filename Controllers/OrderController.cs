using OMS_Solution.Models;
using OrderManagementSystem.BusinessLogic.Order;
using OrderManagementSystem.Models.OrderDetails;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OMS"].ToString()))
            {
                connection.Open();
                SqlCommand testCMD = new SqlCommand("createorder", connection);
                testCMD.CommandType = CommandType.StoredProcedure;
                //List<SqlParameter> sp = new List<SqlParameter>()
                //    {
                //        new SqlParameter() {ParameterName = "@OrderDate", SqlDbType = SqlDbType.DateTime, 50, Value= orderMaster.orderDate},
                //        new SqlParameter() {ParameterName = "@AddressId", SqlDbType = SqlDbType.Int, 10,Value = orderMaster.addressId},
                //        new SqlParameter() {ParameterName = "@Total_Amount", SqlDbType = SqlDbType.Decimal, Value = orderMaster.totalPrice},
                //        new SqlParameter() {ParameterName = "@OrderMasterId", SqlDbType = SqlDbType.Int, Value = orderMaster.orderId , Direction= ParameterDirection.Output}
                //    };

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
                    //List<SqlParameter> sp1 = new List<SqlParameter>()
                    //{
                    //    new SqlParameter() {ParameterName = "@OrderMasterId", SqlDbType = SqlDbType.NVarChar, Value= orderMaster.orderId},
                    //    new SqlParameter() {ParameterName = "@ProductId", SqlDbType = SqlDbType.NVarChar, Value = i.productid},
                    //    new SqlParameter() {ParameterName = "@Quantity", SqlDbType = SqlDbType.NVarChar, Value = i.quantity},
                    //    new SqlParameter() {ParameterName = "@Price", SqlDbType = SqlDbType.Int, Value = i.quantity }
                    //};

                    testCMD1.Parameters.Add(new SqlParameter("@OrderMasterId", System.Data.SqlDbType.VarChar, 50) { Value = orderMaster.orderId });
                    testCMD1.Parameters.Add(new SqlParameter("@ProductId", System.Data.SqlDbType.VarChar, 50) { Value = i.productid });
                    testCMD1.Parameters.Add(new SqlParameter("@Quantity", System.Data.SqlDbType.VarChar, 50) { Value = i.quantity });
                    testCMD1.Parameters.Add(new SqlParameter("@Price", System.Data.SqlDbType.VarChar, 50) { Value = i.quantity });

                    testCMD1.ExecuteNonQuery();
                }


            }

            SmtpClient client = new SmtpClient();

            MailAddress from = new MailAddress("nklsanthosh143@gmail.com",
               "Jane " + (char)0xD8 + " Clayton",
            System.Text.Encoding.UTF8);
            // Set destinations for the email message.
            MailAddress to = new MailAddress("nklsanthosh143@gmail.com");
            // Specify the message content.
            MailMessage message = new MailMessage(from, to);
            message.Body = "This is a test email message sent by an application. ";
            // Include some non-ASCII characters in body and subject.
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            //message.Body += Environment.NewLine + someArrows;
            //message.BodyEncoding = System.Text.Encoding.UTF8;
            //message.Subject = "test message 1" + someArrows;
            //message.SubjectEncoding = System.Text.Encoding.UTF8;
            //// Set the method that is called back when the send operation ends.
            //client.SendCompleted += new
            //SendCompletedEventHandler(SendCompletedCallback);
            //// The userState can be any object that allows your callback
            //// method to identify this send operation.
            //// For this example, the userToken is a string constant.
            //string userState = "test message1";
            //client.SendAsync(message, userState);
            //Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.");
            //string answer = Console.ReadLine();
            //// If the user canceled the send, and mail hasn't been sent yet,
            //// then cancel the pending operation.
            //if (answer.StartsWith("c") && mailSent == false)
            //{
            //    client.SendAsyncCancel();
            //}
            //// Clean up.
            //message.Dispose();
            //Console.WriteLine("Goodbye.");


            return Ok();
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
