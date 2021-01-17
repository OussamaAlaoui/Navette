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
        public ActionResult Edit(string id)
        {
            vehicule v = nv.vehicules.Find(id);
            if (v is null)
            {
                return HttpNotFound();
            }
            else
                return View(v);
        }

        // POST: Vehicule/Edit/5
        [HttpPost]
        public ActionResult Edit(vehicule v)
        {
                nv.Entry(v).State = System.Data.Entity.EntityState.Modified;
                nv.SaveChanges();
                return RedirectToAction("Index","Vehicule");
       
           

       
            
        }

  
        public ActionResult Delete(string id)
        {

            vehicule v = nv.vehicules.SingleOrDefault(x => x.registration_number.Equals(id));
            if (v is null)
                return HttpNotFound();
            else
            {
            nv.vehicules.Remove(v);
            nv.SaveChanges();
            return RedirectToAction("Index", "Vehicule");
            }

        }
    }
}
