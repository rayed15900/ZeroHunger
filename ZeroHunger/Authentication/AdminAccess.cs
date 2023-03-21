using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF.Models;

namespace ZeroHunger.Authentication
{
    public class AdminAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var admin = (Admin)httpContext.Session["Admin"];
            if (admin != null && admin.Username.Equals("admin"))
            {
                return true;
            }
            return false;
        }
    }
}