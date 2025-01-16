using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace RestaurantBookingApp.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public  TimeSpan ClosingTime { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
    }
}