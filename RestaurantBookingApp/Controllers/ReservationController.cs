using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantBookingApp.Data;
using RestaurantBookingApp.Models;
using RestaurantBookingApp.ViewModel;

namespace RestaurantBookingApp.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        private readonly ApplicationDBContext _context;

        public ReservationController()
        {
            _context = new ApplicationDBContext();
        }

        // GET: Reservation/ActiveReservations
        public ActionResult ActiveReservations()
        {
            int currentUserId = 1; 

            var reservations = (from booking in _context.Bookings
                                join restaurant in _context.Restaurants on booking.RestuarantId equals restaurant.Id
                                join table in _context.Tables on booking.TableId equals table.Id
                                where booking.Status == StatusType.Active
                                select new ReservationView
                                {
                                    BookingId = booking.Id,
                                    BookingDateTime = booking.BookingDateTime,
                                    NumOfGuest = booking.NumOfGuest,
                                    RestaurantName = restaurant.Name,
                                    TableNumber = table.TableNumber,
                                    UserId = booking.UserId
                                })
                        .Where(b => b.BookingDateTime >= DateTime.Now && b.UserId == currentUserId)
                        .ToList();

            return View(reservations);
        }
    }
}