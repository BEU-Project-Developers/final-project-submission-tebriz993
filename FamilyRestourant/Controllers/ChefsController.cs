using FamilyRestourant.DAL;
using FamilyRestourant.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyRestourant.Controllers
{
    public class ChefsController : Controller
    {
        private readonly FamilyRestourantDbContext _context;
        public ChefsController(FamilyRestourantDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Chefs> chefs = _context.Chefs
                .Include(c=>c.Professions)
                .ToList();
            return View(chefs);
        }
    }
}
