using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using RestaurantBookingApp.Models;

namespace RestaurantBookingApp.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(): base("DefaultConnection")
        {
        }

        public static ApplicationDBContext Create()
        {
            return new ApplicationDBContext();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Table> Tables { get; set; }
    }
}