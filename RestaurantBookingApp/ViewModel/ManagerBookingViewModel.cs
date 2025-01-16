using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantBookingApp.Models;

namespace RestaurantBookingApp.ViewModel
{
    public class ManagerBookingViewModel
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime BookingDateTime { get; set; }
        public int TableNumber { get; set; }
        public int NumOfGuest { get; set; }
        public StatusType Status { get; set; }
    }
}