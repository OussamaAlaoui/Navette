using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Navette.Controllers
{
    public class ProviderController : Controller
    {
        // GET: Provider
        public ActionResult Index()
        {
            if (Session["user_type"] == null || (!Session["user_type"].Equals("provider") && !Session["user_type"].Equals("admin")))
            {
                return RedirectToAction("index", "home");
            }
            return View();
        }
    }
}