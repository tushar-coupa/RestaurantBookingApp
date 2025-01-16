using System.Linq;
using System.Web.Mvc;
using RestaurantBookingApp.Models;
using RestaurantBookingApp.Data;

namespace RestaurantBookingApp.Controllers
{ 
    public class EditRestaurantController : Controller
    {
        private readonly ApplicationDBContext _context;

        public EditRestaurantController()
        {
            _context = new ApplicationDBContext();
        }

        // GET: ManagerRestaurant/Edit/5
        public ActionResult Edit(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: ManagerRestaurant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                var restaurantInDb = _context.Restaurants.Find(restaurant.Id);
                if (restaurantInDb != null)
                {
                    restaurantInDb.Name = restaurant.Name;
                    restaurantInDb.Address = restaurant.Address;
                    restaurantInDb.OpeningTime = restaurant.OpeningTime;
                    restaurantInDb.ClosingTime = restaurant.ClosingTime;
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(restaurant);
        }
    }
}
