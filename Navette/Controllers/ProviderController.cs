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
            return View();
        }

        // GET: Provider/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Provider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provider/Create
        [HttpPost]
        public ActionResult Create(line l)
        {
            nv.lines.Add(l);
            nv.SaveChanges();
            return View();
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
