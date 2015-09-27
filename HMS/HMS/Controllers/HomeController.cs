using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Models;
using GOLDEPUS.MVC.Authorize;

namespace HMS.Controllers
{
    [NonSessionAuthorization(SessionName ="User",RouteController ="Panel")]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View("~/Views/Shared/Visitor/SignIn.cshtml");
        }

        public ActionResult Login(string username, string password)
        {
            JsonResult json = new JsonResult();
            GOLDEPUS.Bll.ResultObject<GOLDEPUS.Entity.User.Account> result = base.Bll.User.Login(username, password);
            if (result.Result)
            {
                Session.Add("User", result.Value);
            }
            return Json(result);
        }

        public ActionResult SignUp()
        {
            return View("~/Views/Shared/Visitor/SignUp.cshtml");
        }

    }
}