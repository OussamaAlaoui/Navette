using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Navette.Controllers
{
    public class TravellerController : Controller
    {
        // GET: Traveller
        public ActionResult Index()
        {
            string id;
                if( Session["user_type"]==null || (!Session["user_type"].Equals("Traveller") && !Session["user_type"].Equals("admin") && !Session["user_type"].Equals("traveller")) )
                {
                    return RedirectToAction("index", "home");
                }
                else
                {
                    id = Session["user_id"].ToString();
                }
            
            
            
            
            return View();
        }

        public ActionResult ViewLines()
        {
            return View();
        }
        public ActionResult CustomRequest()
        {

            return View();
        }
    }
}