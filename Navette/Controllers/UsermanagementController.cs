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
    public class UsermanagementController : Controller
    {
        private NavetteEntities nv = new NavetteEntities();
        // GET: Usermanagement
        public ActionResult Index()
        {
           /* if (Session["user_type"] == null || !Session["user_type"].Equals("admin"))
            {
                return RedirectToAction("index", "home");
            }*/
            //user's list
            var users = nv.users.ToList();
           if(users is null)
            {
               
                ViewBag.warning= "You have no users.";
                return View();
            }
           else
            return View(users);
        }

        [Route("Usermanagement/Login")]
        public ActionResult Login(user usr2)
        {
            if(Session["user_type"]!=null && Session["user_id"]!=null)
            {
                return RedirectToAction("index", Session["user_type"].ToString());
            }
            if(usr2.password==null)
            {
                return View();
            }
            else
            {
                string str;
                using (var encryption = new SHA512Managed())
                {
                    encryption.ComputeHash(Encoding.UTF8.GetBytes(usr2.password));
                    var encryptedpass = encryption.Hash;
                    string password = string.Join(string.Empty, encryptedpass.Select(x => x.ToString("x2")));
                    var usr = nv.users.Where(n => n.connectionstring == usr2.connectionstring &&
                                         n.password == password).FirstOrDefault();
                    
                        if (usr != null)
                        {
                            Session["user_id"] = usr.user_id;
                            Session["user_type"] = usr.type.ToString();
                            str = usr.type;
                            return RedirectToAction("Index", str);
                        }
                        else
                    {
                         usr = nv.users.Where(n => n.connectionstring == usr2.connectionstring &&
                                        n.password == usr2.password).FirstOrDefault();
                        if(usr != null)
                        {
                            Session["user_id"] = usr.user_id;
                            Session["user_type"] = usr.type.ToString();
                            str = usr.type;
                            return RedirectToAction("Index", str);
                        }
                        else
                            ViewBag.m = "Invalid Identifiers...";
                    }
                            
                    
                }
            }
            
            return View();
            
        }

        // GET: Usermanagement/Details/5
        public ActionResult Details(int id)
        {
            user u = nv.users.Find(id);
            ViewBag.users_details = u; 
         
            return View();
        }
        public ActionResult UserType()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UserType(int i=0)
        {
            String type = Request.Form["users_type"].ToString();
            TempData["user_type"] = type;
                return RedirectToAction("CreateUser");
            
          
        }
      
        
        
        public ActionResult Traveller()
        {
            //ViewBag.id_user = new SelectList(nv.users.ToList(), "id", "name");
            return View();
        }

        // POST: Usermanagement/CreateFormCollection collection
       
        [HttpPost]
        public ActionResult Traveller(traveller t)
        {


            //int nid = Convert.ToInt32(TempData["new_user"].ToString());
            t.topup = 0;
                nv.travellers.Add(t);
            nv.travellers.Find(keyValues: t.user_id).user_id = Convert.ToInt32(TempData["new_user"].ToString());
            nv.SaveChanges();
            

            return View();
        }
        public ActionResult Provider()
        {
            
            //ViewBag.id_user = new SelectList(nv.users.ToList(), "id", "name");
            return View();
        }

        // POST: Usermanagement/CreateFormCollection collection

        [HttpPost]
        public ActionResult Provider(provider p)
        {
           // int nid = Convert.ToInt32(TempData["new_user"].ToString());
          
                nv.providers.Add(p);
                nv.providers.Find(keyValues: p.user_id).user_id = Convert.ToInt32(TempData["new_user"].ToString());
                nv.SaveChanges();
        

            return View();
        }
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(user u)
        {
            using (var encryption = new SHA512Managed())
            {
                encryption.ComputeHash(Encoding.UTF8.GetBytes(u.password));
                var encryptedpassword = encryption.Hash;
                
                u.password = string.Join( string.Empty, encryptedpassword.Select(x => x.ToString("x2")));
            }
            u.approved = false;
            nv.users.Add(u);
            nv.users.Find(keyValues:u.user_id).type = TempData["user_type"].ToString();
               
            nv.SaveChanges();
            TempData["new_user"] = u.user_id;
            return RedirectToAction(TempData["user_type"].ToString());
        }

        // GET: Usermanagement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usermanagement/Edit/5
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

        // GET: Usermanagement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usermanagement/Delete/5
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
