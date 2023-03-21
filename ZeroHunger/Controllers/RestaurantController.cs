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
    [RestaurantLogged]
    public class RestaurantController : Controller
    {
        public ActionResult Dashboard()
        {
            Restaurant restaurant = (Restaurant)Session["Restaurant"];
            ViewBag.Restaurant = restaurant.Name;
            return View();
        }
        [HttpPost]
        public ActionResult Dashboard(CollectRequest c)
        {
            Restaurant restaurant = (Restaurant)Session["Restaurant"];

            var db = new ZeroHungerDb();
            CollectRequest collectrequest = new CollectRequest();
            collectrequest.Name = c.Name;
            collectrequest.Quantity = c.Quantity;
            collectrequest.ExpireAt = c.ExpireAt;
            collectrequest.Restaurant_id = restaurant.Id;
            collectrequest.Employee_id = null;

            db.CollectRequests.Add(collectrequest);
            db.SaveChanges();
            return RedirectToAction("CollectRequests");
        }
        public ActionResult CollectRequests()
        {
            var db = new ZeroHungerDb();
            var restaurants = db.Restaurants.ToList();
            Restaurant restaurant = (Restaurant)Session["Restaurant"];
            ViewBag.Id = restaurant.Id;

            return View(restaurants);
        }
    }
}