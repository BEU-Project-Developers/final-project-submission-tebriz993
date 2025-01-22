using FamilyRestourant.DAL;
using FamilyRestourant.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyRestourant.Controllers
{
    public class TestimonialsController : Controller
    {
        private readonly FamilyRestourantDbContext _context;
        public TestimonialsController(FamilyRestourantDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Testimonials> testimonials=_context.Testimonials
                .Include(t=>t.Professions)
                .ToList();
            return View(testimonials);
        }
    }
}
