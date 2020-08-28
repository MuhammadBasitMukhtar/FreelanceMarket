using FreelanceMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace FreelanceMarket.Controllers
{
    public class HomeController : Controller
    {
        private FreelanceMPEntities db = new FreelanceMPEntities();
        // GET: Home
        public ActionResult Index()
        {
            var projects = db.projects.Include(p => p.category).Include(p => p.userdetail);
            return View(projects.ToList());
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
            var id = db.userdetails.Where(i => i.email == lg.email && i.pass == lg.pass).FirstOrDefault();
            if(id.roleid == 1)
            {
                Session["UName"] = id.name;
                return RedirectToAction("Dashboard", "Admin");
            }
            else if(id.roleid == 2)
            {
                Session["UName"] = id.name;
                return RedirectToAction("Dashboard", "Client");
            }
            else if(id.roleid == 3)
            {
                Session["UName"] = id.name;
                return RedirectToAction("Dashboard", "Freelancer");
            }
            else
            {
                Session["UName"] = id.name;
                ViewBag.Error = "Wrong Crediantials Entered!";
            }
            return View();
        }
    }
}