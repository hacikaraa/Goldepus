using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace GOLDEPUS.MVC.Authorize
{
    public class NonSessionAuthorization : AuthorizeAttribute
    {
        private string sessionName = "User";
        public string SessionName { get { return this.sessionName; } set { this.sessionName = value; } }
        
        public string RouteController { get; set; }

        private string routeAction = "Index";
        public string RouteAction { get { return this.routeAction; } set { this.routeAction = value; } }

        private string routeName = "Default";
        public string RouteName { get { return this.routeName; } set { this.routeName = value; } }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.Result == null)
            {
                if (filterContext.HttpContext.Session != null && filterContext.HttpContext.Session[SessionName] != null)
                {
                    RouteValueDictionary rd = new RouteValueDictionary();
                    rd.Add("controller", RouteController);
                    rd.Add("action", RouteAction);
                    filterContext.Result = new RedirectToRouteResult(RouteName, rd);
                }
            }
        }
    }
}
