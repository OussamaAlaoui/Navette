using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Navette.Models;

namespace Navette.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {
            if (Session["user_type"] != null && Session["user_id"] != null)
            {
                return RedirectToAction("index", Session["user_type"].ToString());
            }
            ViewBag.m = "hello this is a test for our navette application";
            return View();
        }
      
      
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}