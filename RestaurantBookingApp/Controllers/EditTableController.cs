using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantBookingApp.Data;
using RestaurantBookingApp.Models;

namespace RestaurantBookingApp.Controllers
{
    public class EditTableController : Controller
    {
        private readonly ApplicationDBContext _context;

        public EditTableController()
        {
            _context = new ApplicationDBContext();
        }

        // GET: Tables for a specific restaurant
        public ActionResult Index(int restaurantId)
        {
            var tables = _context.Tables.Where(t => t.RestaurantId == restaurantId).ToList();
            ViewBag.RestaurantId = restaurantId;
            return View(tables);
        }

        // GET: Add a new table
        public ActionResult Create(int restaurantId)
        {
            var table = new Table { RestaurantId = restaurantId };
            return View(table);
        }

        // POST: Save a new table
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Table table)
        {
            if (ModelState.IsValid)
            {
                _context.Tables.Add(table);
                _context.SaveChanges();
                return RedirectToAction("Index", new { restaurantId = table.RestaurantId });
            }
            return View(table);
        }

        // GET: Edit table details
        public ActionResult Edit(int id)
        {
            var table = _context.Tables.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        // POST: Save edited table details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Table table)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(table).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index", new { restaurantId = table.RestaurantId });
            }
            return View(table);
        }

        // GET: Delete a table (with confirmation)
        public ActionResult Delete(int id)
        {
            var table = _context.Tables.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        // POST: Confirm deletion of a table
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var table = _context.Tables.Find(id);
            if (table != null)
            {
                _context.Tables.Remove(table);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", new { restaurantId = table.RestaurantId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
