using FamilyRestourant.DAL;
using FamilyRestourant.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyRestourant.Controllers
{
    public class SpecialsController : Controller
    {
        private readonly FamilyRestourantDbContext _context;
        public SpecialsController(FamilyRestourantDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Specials> specials=_context.Specials
                .Include(s=>s.SpecialDescription)
                .ToList();
            return View(specials);
        }
    }
}
