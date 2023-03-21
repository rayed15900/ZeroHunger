using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Authentication;
using ZeroHunger.EF;
using ZeroHunger.EF.Models;

namespace ZeroHunger.Controllers
{
    [EmployeeLogged]
    public class EmployeeController : Controller
    {
        public ActionResult Dashboard()
        {
            var db = new ZeroHungerDb();
            var restaurants = db.Restaurants.ToList();

            Employee employee = (Employee)Session["Employee"];
            ViewBag.Employee = employee;

            return View(restaurants);
        }
        public ActionResult Collect(int Id)
        {
            var db = new ZeroHungerDb();
            var collectrequest = (from c in db.CollectRequests
                                  where c.Id == Id
                                  select c).SingleOrDefault();
            collectrequest.Status = "Delivering";
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        public ActionResult Distribute(int Id)
        {
            var db = new ZeroHungerDb();
            var collectrequest = (from c in db.CollectRequests
                                  where c.Id == Id
                                  select c).SingleOrDefault();
            collectrequest.Status = "Completed";
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}