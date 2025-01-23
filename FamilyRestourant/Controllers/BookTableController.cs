using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using FamilyRestourant.DAL;
using FamilyRestourant.Entities;

namespace FamilyRestourant.Controllers
{
    public class BookTableController : Controller
    {
        private readonly FamilyRestourantDbContext _context;

        public BookTableController(FamilyRestourantDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new ReservationViewModel
            {
                Reservation = new Reservation()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF hücumlarının qarşısını almaq üçün elave etmisem
        public IActionResult Index(ReservationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var reservation = model.Reservation;

                _context.Reservations.Add(reservation);
                _context.SaveChanges(); // Verilənlər bazasına dəyişiklikləri tətbiq et

                TempData["SuccessMessage"] = "Your reservation has been successfully submitted!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Xətaları idarə etmək üçün
                ModelState.AddModelError("", "An error occurred while processing your reservation. Please try again.");
                Console.WriteLine($"Error: {ex.Message}");
            }

            return View(model);
        }
    }
}
