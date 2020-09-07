using OrderManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagementSystem.Controllers
{
    public class UserRoleController : ApiController
    {
        [Route("api/UserRole/GetallRoles")]
        [HttpGet]
        public IHttpActionResult GetAllRoles()
        {
            List<UserRoles> userRoles = new List<UserRoles>();
            using (var db = new OMSEF())
            {
                var allRoles = (from a in db.UserRoles select a).ToList();

                foreach (var a in allRoles)
                {
                    UserRoles us = new UserRoles();
                    us.name = a.Name;
                    us.roleId = a.RoleId;
                    userRoles.Add(us);
                }
            }
            return Ok(userRoles);
        }

        [Route("api/UserRole/GetRole")]
        [HttpGet]
        public IHttpActionResult GetRole(int id)
        {
            UserRoles us = new UserRoles();
            using (var db = new OMSEF())
            {
                var userRole = db.UserRoles.Where(s => s.RoleId == id).FirstOrDefault();

                if (userRole != null)
                {
                    us.name = userRole.Name;
                    us.roleId = userRole.RoleId;
                }
            }
            return Ok(us);
        }

        [Authorize(Roles = "Admin")]
        [Route("api/UserRole/AddRole")]
        [HttpPost]
        public IHttpActionResult AddRole([FromBody] UserRoles us)
        {

            using (var db = new OMSEF())
            {
                db.UserRoles.Add(new UserRole
                {
                    Name = us.name
                });
                db.SaveChanges();
            }
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [Route("api/UserRole/DeleteRole")]
        [HttpDelete]
        public IHttpActionResult DeleteRole(int id)
        {
            using (var db = new OMSEF())
            {
                var userRole = db.UserRoles.Where(s => s.RoleId == id).FirstOrDefault();
                if (userRole != null)
                {
                    db.Entry(userRole).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
                return Ok();
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("api/UserRole/UpdateRole")]
        [HttpPut]
        public IHttpActionResult UpdateRole([FromBody] UserRoles us)
        {
            using (var db = new OMSEF())
            {
                var userRole = db.UserRoles.Where(s => s.RoleId == us.roleId).FirstOrDefault();

                if (userRole != null)
                {
                    userRole.Name = us.name;
                }

                db.SaveChanges();
            }
            return Ok();

        }
    }
}
