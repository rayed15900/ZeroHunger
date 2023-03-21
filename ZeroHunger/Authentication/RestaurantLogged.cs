using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZeroHunger.Authentication
{
    public class RestaurantLogged : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["Restaurant"] != null)
            {
                return true;
            }
            return false;
        }
    }
}