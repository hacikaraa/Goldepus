using ProjeYapisi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeYapisi.Controllers
{
    [UserAuthorize]
    public class NoteController : BaseController
    {
        //
        // GET: /Note/

        public ActionResult Index()
        {
            return View();
        }

    }
}
