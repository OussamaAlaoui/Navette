using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Navette.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["user_type"] == null || !Session["user_type"].Equals("admin"))
            {
                return RedirectToAction("index", "home");
            }
            return View();
        }

        public ActionResult VerifyProviders()
        {

            return View();
        }

    }
}