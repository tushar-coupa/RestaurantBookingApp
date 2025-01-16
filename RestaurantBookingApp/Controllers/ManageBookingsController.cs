//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using RestaurantBookingApp.Data;
//using RestaurantBookingApp.Models;
//using RestaurantBookingApp.ViewModel;

//namespace RestaurantBookingApp.Controllers
//{
//    public class ManageBookingsController : Controller
//    {
//        private readonly ApplicationDBContext _context;
//        public ManageBookingsController()
//        {
//            _context = new ApplicationDBContext();
//        }

//        // GET: Manager/UpcomingBookings
//        public ActionResult UpcomingBookings(int id)
//        {
//            int restaurantId = id;
//            var bookings = _context.Bookings
//                .Where(b => b.RestuarantId == restaurantId
//                         && b.Status == StatusType.Active
//                         && b.BookingDateTime >= DateTime.Now)
//                .Select(b => new ManagerBookingViewModel
//                {
//                    BookingId = b.Id,
//                    UserId = b.UserId,
//                    UserName = _context.Users
//                                            .Where(u => u.Id == b.UserId)
//                                            .Select(u => u.Name).FirstOrDefault(),
//                    BookingDateTime = b.BookingDateTime,
//                    NumOfGuest = b.NumOfGuest,
//                    TableNumber = _context.Tables
//                                            .Where(t => t.Id == b.TableId)
//                                            .Select(t => t.TableNumber).FirstOrDefault(),
//                    Status = b.Status
//                })
//                .ToList();

//            return View(bookings);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult UpdateBookingStatus(int bookingid, StatusType status)
//        { 
//            var booking = _context.Bookings.Find(bookingid);
//            if (booking == null)
//            {
//                return HttpNotFound();
//            }
//            booking.Status = status;
//            var restaurantID = booking.RestuarantId;
//            _context.SaveChanges();
//            return RedirectToAction("UpcomingBookings", new {id = restaurantID});
//        }

//    }
//}