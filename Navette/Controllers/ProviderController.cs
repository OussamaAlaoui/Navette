using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Navette.Models;
using System.Security.Cryptography;
using System.Text;

namespace Navette.Controllers
{
    public class ProviderController : Controller
    {
        private NavetteEntities nv = new NavetteEntities();
        // GET: Provider
        public ActionResult Index()
        {
            var l = nv.lines.ToList();

            if (l is null)
            {


                return View();
            }
            else
                return View(l);
        }

        // GET: Provider/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }
        public ActionResult Requests()
        {

            return View();
        }

        // GET: Provider/Create
        public ActionResult Create()
        {

            var r = nv.requests.ToList();

            if (r is null)
            {


                return View();
            }
            else
                return View(r);
            return View();
        }

        // POST: Provider/Create
        [HttpPost]
        public ActionResult Create(line l)
        {

            l.owner_company = Convert.ToInt32(TempData["user_id"].ToString());
           l.departure_time = TimeSpan.Parse(Request.Form["departure_time"]);
            l.estimated_arrival_time = TimeSpan.Parse(Request.Form["estimated_arrival_time"]);
            
            nv.lines.Add(l);
            nv.SaveChanges();
            return RedirectToAction("Index", "provider");

        }

        public ActionResult logout()
        {
            Session["user_id"] = null;
            Session["user_type"] = null;
            return RedirectToAction("index", "home");
        }
        // GET: Provider/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Provider/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Provider/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Provider/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
