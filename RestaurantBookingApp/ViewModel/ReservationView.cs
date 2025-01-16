using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantBookingApp.ViewModel
{
    public class ReservationView
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public DateTime BookingDateTime { get; set; }
        public int TableNumber { get; set; }
        public int NumOfGuest { get; set; }
        public string RestaurantName { get; set; }
        public int RestaurantId { get; set; }
    }
}