using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeYapisi.Models
{
    public class UserAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.Session["MemberID"] != null)
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/Account/Login");
                return false;
            }

        }
    }
}