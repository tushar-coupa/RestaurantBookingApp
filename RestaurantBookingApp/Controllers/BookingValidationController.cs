using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantBookingApp.Models;
using RestaurantBookingApp.Data;
using RestaurantBookingApp.Services;

namespace RestaurantBookingApp.Controllers
{
    public class BookingValidationController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly BookingValidationService _validationService;

        public BookingValidationController()
        {
            _context = new ApplicationDBContext();
            _validationService = new BookingValidationService(_context);
        }

        [HttpGet]
        public JsonResult IsSlotAvailable(int restaurantId, int tableId, DateTime bookingDateTime)
        {
            var isAvailable = _validationService.IsSlotAvailable(restaurantId, tableId, bookingDateTime);
            return Json(isAvailable, JsonRequestBehavior.AllowGet);
        }
    }
}