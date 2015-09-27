using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOLDEPUS.MVC.Authorize;
using HMS.Models;
using System.Web.Routing;

namespace HMS.Controllers
{
    [SessionAuthorization(SessionName = "User")]
    public class PanelController : BaseController
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            MenuModel Data = new MenuModel();
            return PartialView("~/Views/Shared/Master/Menu.cshtml", Data);
        }

        public ActionResult Header()
        {
            HeaderModel Data = new HeaderModel();
            return PartialView("~/Views/Shared/Master/Header.cshtml", Data);
        }

        public ActionResult HomeMembers()
        {


            return View(new Models.HomeMembersModel());
        }

        public ActionResult Lists()
        {
            return View();
        }

        public ActionResult Finance()
        {
            return View();
        }

        public ActionResult HomeMovements()
        {
            return View();
        }

        public ActionResult Profil()
        {
            return View();
        }

        public ActionResult MemberMovements()
        {
            return View();
        }

        public ActionResult UpdateAccount()
        {
            return View();
        }

        public ActionResult UpdatePassword()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("/Home");
        }

    }
}