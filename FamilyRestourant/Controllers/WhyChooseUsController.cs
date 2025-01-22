using FamilyRestourant.DAL;
using FamilyRestourant.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyRestourant.Controllers
{
    public class WhyChooseUsController : Controller
    {
        private readonly FamilyRestourantDbContext _context;
        public WhyChooseUsController(FamilyRestourantDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<WhyChooseUs> whyChooseUs= _context.WhyChooseUs.ToList();
            return View(whyChooseUs);
        }
    }
}
