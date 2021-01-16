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
    public class VehiculeController : Controller
    {
        private NavetteEntities nv = new NavetteEntities();
        // GET: Vehicule
        public ActionResult Index()
           
        {
            var v = nv.vehicules.ToList();

            if (v is null)
            {

                return View();

            }
            else
                return View(v);

          
        }

        // GET: Vehicule/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vehicule/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicule/Create
        [HttpPost]
        public ActionResult Create(vehicule v)
        {
            v.provider_id = Convert.ToInt32(TempData["user_id"].ToString());
           

            nv.vehicules.Add(v);
            nv.SaveChanges();
            return RedirectToAction("Index","Vehicule");
           
        }

        // GET: Vehicule/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vehicule/Edit/5
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

        // GET: Vehicule/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vehicule/Delete/5
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
