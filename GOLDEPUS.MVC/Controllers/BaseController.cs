using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GOLDEPUS.MVC.Controllers
{
    public class GOLDEPUSBaseController : Controller
    {
        private GOLDEPUS.Bll.Facede bll;
        public GOLDEPUS.Bll.Facede Bll
        {
            get
            {
                if (bll == null)
                {
                    if (ServerSide.CacheManager.HasObject("Application"))
                    {
                        bll = (GOLDEPUS.Bll.Facede)ServerSide.CacheManager.GetObject("Application");
                    }
                    else
                    {
                        bll = new GOLDEPUS.Bll.Facede();
                        ServerSide.CacheManager.Add("Application", bll);
                    }
                } 
                return bll;
            }
        }

        public ActionResult Error()
        {
            RouteValueDictionary rd = new RouteValueDictionary();
            rd.Add("controller", "Home");
            rd.Add("action", "Index");
            return new RedirectToRouteResult("Default", rd);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Entity.Monitoring.ExceptionLog exlog = new Entity.Monitoring.ExceptionLog();
            if (Session != null && Session["User"] != null)
                exlog.AccountId = ((Entity.User.Account)Session["User"]).Id;
            exlog.EntityValue = "";
            exlog.Exception = filterContext.Exception.ToString();
            exlog.ExceptionCode = filterContext.Exception.Source;
            exlog.ExceptionMessage = filterContext.Exception.Message;
            exlog.EntityValue = "";
            System.Web.Mvc.Controller _controller = ((System.Web.Mvc.Controller)filterContext.Controller);
            string key = "";
            for (int i = 0; i < _controller.ModelState.Keys.Count; i++)
            {
                key = _controller.ModelState.Keys.ToList()[i];
                exlog.EntityValue += "<" + key + " = ";
                for (int j = 0; j < ((string[])(_controller.ModelState[key].Value.RawValue)).Length; j++)
                {
                    exlog.EntityValue += ((string[])(_controller.ModelState[key].Value.RawValue))[j] + " ; ";
                }
                exlog.EntityValue += ">";
            }
            exlog.ExecuteEntity = filterContext.Controller.GetType().Name;
            this.Bll.Monitoring.CreateExceptionLog(exlog);
            //data sonra değiştirilecek
            RouteValueDictionary rd = new RouteValueDictionary();
            rd.Add("controller", "Home");
            rd.Add("action", "Index");
            new RedirectToRouteResult("Default", rd);
        }
    }
}
