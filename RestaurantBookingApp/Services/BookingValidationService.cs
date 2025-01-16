using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantBookingApp.Models;
using RestaurantBookingApp.Data;

namespace RestaurantBookingApp.Services
{
    public class BookingValidationService
    {
        private readonly ApplicationDBContext _context;

        public BookingValidationService(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool IsSlotAvailable(int restaurantId, int tableId, DateTime bookingDateTime)
        {
            var minTime = bookingDateTime.AddMinutes(-_context.Tables
                .Where(t => t.Id == tableId)
                .Select(t => t.ReservationDuration)
                .FirstOrDefault());

            var maxTime = bookingDateTime.AddMinutes(_context.Tables
                .Where(t => t.Id == tableId)
                .Select(t => t.ReservationDuration)
                .FirstOrDefault());

            return !_context.Bookings
                .Any(b => b.RestuarantId == restaurantId
                          && b.TableId == tableId
                          && b.BookingDateTime >= minTime
                          && b.BookingDateTime <= maxTime);
        }
    }
}