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

        public ActionResult Register()
        {
            return View();
        }
    }
}