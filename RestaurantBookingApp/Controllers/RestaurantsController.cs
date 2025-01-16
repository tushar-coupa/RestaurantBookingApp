using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;
using RestaurantBookingApp.Models;
using RestaurantBookingApp.Data;

namespace RestaurantBookingApp.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly ApplicationDBContext _context;
    
        public RestaurantsController()
        {
            _context = new ApplicationDBContext();
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            var restaurants = _context.Restaurants.ToList();  // Fetch all restaurants
            return View(restaurants);
        }
    }
}