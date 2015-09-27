using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace GOLDEPUS.MVC.Authorize
{
    public class SessionAuthorization : AuthorizeAttribute
    {
        private string sessionName = "User";
        public string SessionName { get { return this.sessionName; } set { this.sessionName = value; } }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.Result == null)
            {
                if (!(filterContext.HttpContext.Session != null && filterContext.HttpContext.Session[SessionName] != null))
                {
                    RouteValueDictionary rd = new RouteValueDictionary();
                    rd.Add("controller", "Home");
                    rd.Add("action", "Index");
                    filterContext.Result = new RedirectToRouteResult("Default", rd);
                }
            }
        }
    }
}
