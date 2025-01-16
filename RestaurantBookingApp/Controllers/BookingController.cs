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
    public class BookingController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly BookingValidationService _validationService;

        public BookingController()
        {
            _context = new ApplicationDBContext();
            _validationService = new BookingValidationService(_context);
        }

        // GET: Booking
        public ActionResult Book(int id)
        {
            ViewBag.Tables = _context.Tables.Where(t => t.RestaurantId == id).ToList();
            var booking = new Booking
            {
                RestuarantId = id,
                UserId = 1
            };
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book(Booking booking)
        {
            if (!_validationService.IsSlotAvailable(booking.RestuarantId, booking.Id, booking.BookingDateTime))
            {
                ModelState.AddModelError("", "This table is not available during the selected time. Please select other table or other time slot.");
                return View(booking);
            }

            if (ModelState.IsValid)
            {
                booking.Status = StatusType.Active;
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return RedirectToAction("BookingConfirmed");
            }

            return View(booking);
        }

        public ActionResult BookingConfirmed()
        {
            return View();
        }
    }
}