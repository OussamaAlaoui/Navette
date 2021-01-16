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
            using (NavetteEntities nv = new NavetteEntities())
            {
                if (Session["user_type"] == null || (!Session["user_type"].Equals("Traveller") && !Session["user_type"].Equals("admin") && !Session["user_type"].Equals("traveller")))
                {
                    return RedirectToAction("index", "home");
                }
                else
                {
                    int id = (int)Session["user_id"];
                    var city = nv.travellers.Find(id);
                    var lines = nv.lines.Where(m => m.departure_location.ToUpper().Contains(city.city.ToUpper()) || m.arrival_location.ToUpper().Contains(city.city.ToUpper())).ToList();
                    if (lines is null)
                    {
                        ViewBag.no_lines = "No lines available";
                        return View();
                    }
                    return View(lines);
                }
            }
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
                if (Session["user_type"] == null || (!Session["user_type"].Equals("Traveller") && !Session["user_type"].Equals("admin") && !Session["user_type"].Equals("traveller")))
                {
                    return RedirectToAction("index", "home");
                }
                else
                {
                    int id = (int)Session["user_id"];
                    var city = nv.travellers.Find(id);
                    var lines = nv.lines.Where(m => m.departure_location.ToUpper().Contains(city.city.ToUpper()) || m.arrival_location.ToUpper().Contains(city.city.ToUpper())).ToList();
                    if (lines is null)
                    {
                        ViewBag.no_lines = "No lines available";
                        return View();
                    }
                    return View(lines);
                } 
            }
        }
        public ActionResult logout()
        {
            Session["user_id"] = null;
            Session["user_type"] = null; 
            return RedirectToAction("index", "home");
        }

        public ActionResult ViewSubs()
        {
            if (Session["user_type"] == null || (!Session["user_type"].Equals("Traveller") && !Session["user_type"].Equals("admin") && !Session["user_type"].Equals("traveller")))
            {
                return RedirectToAction("index", "home");
            }
            else
            {
                using (NavetteEntities nv = new NavetteEntities())
                {
                    int user_id = (int)Session["user_id"];
                    var subs = nv.subscriptions.Where(model => model.traveller_id == user_id).ToList();
                    if (subs is null)
                    {
                        ViewBag.no_lines = "No subscriptions";
                        return View();
                    }
                    return View(subs);
                }
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