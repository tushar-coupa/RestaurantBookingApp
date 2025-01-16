using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantBookingApp.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TableId { get; set; }
        public int RestuarantId { get; set; }
        public DateTime BookingDateTime { get; set; }
        public int NumOfGuest { get; set; }

        public StatusType Status { get; set; }
    }
}