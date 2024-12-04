using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestoranTemp.Data;
using RestoranTemp.Models;

namespace RestoranTemp.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly RestoranTempDbContext _context;
        public TestimonialController(RestoranTempDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           List<Testimonial> testimonial = _context.Testimonial.Include(p=>p.Profession).ToList();
           return View(testimonial);
        }
    }
}
            