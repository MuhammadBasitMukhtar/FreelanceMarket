using FreelanceMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelanceMarket.Controllers
{
    public class HomeController : Controller
    {
        FreelanceMPEntities db = new FreelanceMPEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.roleid = new SelectList(db.roles, "roleid", "rolename");
            return View();
        }
        [HttpPost]
        public ActionResult Register([Bind(Include = "userid,name,email,address,date_of_joining,contact,pass,roleid,isverified")] userdetail userdetail)
        {
            if (ModelState.IsValid)
            {
                db.userdetails.Add(userdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.roleid = new SelectList(db.roles, "roleid", "rolename", userdetail.roleid);
            return View(userdetail);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(logindetail lg)
        {
            if(lg.email == "admin@admin.com" && lg.pass == "123")
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            else if(lg.email == "basit@email.com" && lg.pass == "123")
            {
                return RedirectToAction("Dashboard", "Client");
            }
            return View();
        }
    }
}