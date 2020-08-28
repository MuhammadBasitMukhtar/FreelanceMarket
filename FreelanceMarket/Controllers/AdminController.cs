using FreelanceMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelanceMarket.Controllers
{
    public class AdminController : Controller
    {
        FreelanceMPEntities db = new FreelanceMPEntities();
        // GET: Admin
        public ActionResult Dashboard()
        {
            ViewBag.FList = db.userdetails.Where(a => a.roleid == 3).Count();
            ViewBag.CList = db.userdetails.Where(a => a.roleid == 2).Count();
            ViewBag.PList = db.projects.Count();
            return View();
        }
        public ActionResult CategoriesList()
        {
            return View(db.categories.ToList());
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        public ActionResult ClientsList()
        {
            var clientdetails = db.userdetails.Where(i => i.roleid == 2).ToList();
            return View(clientdetails);
        }
        public ActionResult FreelancersList()
        {
            var fdetails = db.userdetails.Where(i => i.roleid == 3).ToList();
            return View(fdetails);
        }
        public ActionResult ProjectsList()
        {
            var plist = db.projects.ToList();
            return View(plist);
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}