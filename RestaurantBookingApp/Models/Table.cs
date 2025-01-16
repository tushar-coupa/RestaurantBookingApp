using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantBookingApp.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int RestaurantId { get; set; }
        public int Capacity { get; set; }
        public int ReservationDuration { get; set; }
    }
}