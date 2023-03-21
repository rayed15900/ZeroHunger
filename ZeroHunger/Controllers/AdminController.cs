using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Authentication;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    [AdminAccess]
    public class AdminController : Controller
    {
        public ActionResult Dashboard()
        {
            var db = new ZeroHungerDb();
            var restaurants = db.Restaurants.ToList();

            return View(restaurants);
        }
        public ActionResult EmployeeList(int Id)
        {
            TempData["CollectRequest_id"] = Id;
            var db = new ZeroHungerDb();
            var employees = db.Employees.ToList();
            return View(employees);
        }
        public ActionResult AssignEmployee(int Id)
        {
            int CollectRequest_id = (int)TempData["CollectRequest_id"];
            int Employee_id = Id;

            var db = new ZeroHungerDb();
            var collectrequest = (from c in db.CollectRequests
                                  where c.Id == CollectRequest_id
                                  select c).SingleOrDefault();
            collectrequest.Employee_id = Employee_id;
            collectrequest.Status = "Assigned";
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}

