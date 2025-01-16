using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantBookingApp.Models;
using RestaurantBookingApp.Data;

namespace RestaurantBookingApp.Controllers
{
    public class RestaurantDetailsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public RestaurantDetailsController()
        {
            _context = new ApplicationDBContext();
        }
        // GET: RestaurantDetails
        public ActionResult Details(int id)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == id); ;
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }
    }
}