using OrderManagementSystem.Models;
using OrderManagementSystem.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace OrderManagementSystem.Scripts
{
    public class Authentication : DelegatingHandler
    {

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            IEnumerable<string> userHeader = request.Headers.GetValues("username");
            var userName = userHeader.FirstOrDefault();

            IEnumerable<string> passwordHeader = request.Headers.GetValues("password");
            var passWord = passwordHeader.FirstOrDefault();

            string[] roleDB = new string[1];
            string[] role = new string[1];
            using (var db = new OMSEF())
            {
                var roleid = (from d in db.CustomerDetails
                              where d.CustomerEmail == userName && d.Password == passWord
                              select d.RoleId).FirstOrDefault();

                if (roleid != 0)
                {
                    roleDB = (from r in db.UserRoles
                            where r.RoleId == roleid
                            select r.Name).ToArray();

                    foreach (var r in roleDB)
                    {
                        // role[0] = r.Replace(' ', '');
                        role[0] = r.Trim();
                    }

                    var identity = new GenericIdentity(userName);
                    SetPrincipal(new GenericPrincipal(identity, role));
                }
            }
            //string role1 = "Admin";
            //string[] role = new string[] { "Admin" };
            return base.SendAsync(request, cancellationToken);
        }
        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;

            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;

            }
        }
    }
}