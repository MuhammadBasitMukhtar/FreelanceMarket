using FreelanceMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelanceMarket.Controllers
{
    public class ClientController : Controller
    {
        FreelanceMPEntities db = new FreelanceMPEntities();
        // GET: Client
        public ActionResult Dashboard()
        {
            ViewBag.MPList = db.projects.Where(i => i.clientid == 3).Count();
            ViewBag.OPList = db.projects.Where(i => i.clientid == 3).Count();
            return View();
        }
        public ActionResult AddProject()
        {
            ViewBag.categoryid = new SelectList(db.categories, "catid", "name");
            ViewBag.clientid = new SelectList(db.userdetails, "userid", "name");
            return View();
        }
        [HttpPost]
        public ActionResult AddProject([Bind(Include = "projectid,title,desc,clientid,categoryid,skills,cost,duration,date_of_post,status")] project project)
        {
            if (ModelState.IsValid)
            {
                db.projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }

            ViewBag.categoryid = new SelectList(db.categories, "catid", "name", project.categoryid);
            ViewBag.clientid = new SelectList(db.userdetails, "userid", "name", project.clientid);
            return View(project);
        }
    }
}