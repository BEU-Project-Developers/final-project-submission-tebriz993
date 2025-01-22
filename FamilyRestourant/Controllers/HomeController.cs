using FamilyRestourant.DAL;
using FamilyRestourant.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyRestourant.Controllers
{
    public class HomeController : Controller
    {
        private readonly FamilyRestourantDbContext _context;
        public HomeController(FamilyRestourantDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            Home? home= _context.Home.OrderBy(h=>h.Id).FirstOrDefault();
            return View(home);
        }
    }
}
