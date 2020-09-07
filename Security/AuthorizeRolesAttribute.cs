﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace OrderManagementSystem.Security
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        private bool localAllowed;

        public AuthorizeRolesAttribute(bool allowedParam) 
        {
            localAllowed = allowedParam;

        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if(httpContext.User.Identity.AuthenticationType== "Admin")
            {
                return true;
            }
            else
            {
                return localAllowed;
            }

        }
    }
}