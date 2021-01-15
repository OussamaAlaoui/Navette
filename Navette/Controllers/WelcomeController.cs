using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Navette.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: Welcom
        public ActionResult Welcome_page()
        {
            return View();
        }
    }
}