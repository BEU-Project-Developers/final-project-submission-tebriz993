using FamilyRestourant.DAL;
using FamilyRestourant.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyRestourant.Controllers
{
    public class AboutController : Controller
    {
        private readonly FamilyRestourantDbContext _context;
        public AboutController(FamilyRestourantDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            About? about = _context.About.OrderBy(a=>a.Id).FirstOrDefault();
            return View(about);

        }
    }
}
