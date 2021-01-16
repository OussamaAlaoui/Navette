using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Navette.Models;

namespace Navette.Controllers
{
    public class TravellerController : Controller
    {
        // GET: Traveller
        public ActionResult Index()
        {
            string id;
            if (Session["user_type"] == null || (!Session["user_type"].Equals("Traveller") && !Session["user_type"].Equals("admin") && !Session["user_type"].Equals("traveller")))
            {
                return RedirectToAction("index", "home");
            }
            else
            {
                id = Session["user_id"].ToString();
            }




            return View();
        }
        public ActionResult Subscribe(int lineid)
        {
            var sub = new subscription();
            sub.traveller_id = (int)Session["user_id"];
            sub.line_id = lineid;
            sub.price = 20;
            sub.reduction = 0;
            using (NavetteEntities nv = new NavetteEntities())
            {
                nv.subscriptions.Add(sub);
                nv.SaveChanges();
            }
            return View();
        }
        public ActionResult ViewLines()
        {
            using (NavetteEntities nv = new NavetteEntities())
            {
                var lines = nv.lines.ToList();
                if (lines is null)
                {
                    ViewBag.no_lines = "No lines available";
                    return View();
                }
                return View(lines);
            }
        }

        public ActionResult ViewSubs()
        {
            using (NavetteEntities nv = new NavetteEntities())
            {
                var subs = nv.subscriptions.Where(model => model.traveller_id == (int)Session["user_id"]);
                if (subs is null)
                {
                    ViewBag.no_lines = "No subscriptions";
                    return View();
                }
                return View(subs);
            }
        }


        public ActionResult CustomRequest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomRequest(request req)
        {

            if (req.departure_location == null || req.arrival_location == null || req.day == null)
                return View();
            req.departure_time = TimeSpan.Parse(Request.Form["Departure Time"]);
            req.estimated_arrival_time = TimeSpan.Parse(Request.Form["Estimated Arrival Time"]);
            if (Request.Form["weekly"] == "once")
                req.weekly = false;
            else
                req.weekly = true;
            int id = (int)Session["user_id"];
            req.owner_id = id;

            using (var nv = new NavetteEntities())
            {
                nv.requests.Add(req);
                nv.SaveChanges();
            }
            return View();
        }
    }
}