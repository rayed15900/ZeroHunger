using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;
using ZeroHunger.EF.Models;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult RestaurantRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RestaurantRegister(Restaurant r)
        {
            var db = new ZeroHungerDb();
            db.Restaurants.Add(r);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        public ActionResult EmployeeRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeRegister(Employee e)
        {
            var db = new ZeroHungerDb();
            db.Employees.Add(e);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel l)
        {
            var db = new ZeroHungerDb();


            if (l.Username == "admin" && l.Password == "1234")
            {
                var admin = (from a in db.Admins
                             where a.Username.Equals("admin")
                             select a).SingleOrDefault();
                Session["Admin"] = admin;
                return RedirectToAction("Dashboard", "Admin");
            }

            var restaurants = (from r in db.Restaurants
                               where r.Username.Equals(l.Username)
                               && r.Password.Equals(l.Password)
                               select r).SingleOrDefault();

            var employees = (from e in db.Employees
                             where e.Username.Equals(l.Username)
                             && e.Password.Equals(l.Password)
                             select e).SingleOrDefault();

            if (restaurants != null)
            {
                Session["Restaurant"] = restaurants;
                return RedirectToAction("Dashboard", "Restaurant");
            }
            else if (employees != null)
            {
                Session["Employee"] = employees;
                return RedirectToAction("Dashboard", "Employee");
            }
            else
            {
                ViewBag.Login = "Login Unsuccessful";
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}