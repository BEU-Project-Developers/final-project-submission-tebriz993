using FamilyRestourant.DAL;
using FamilyRestourant.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyRestourant.Controllers
{
    public class GalleryController : Controller
    {
        private readonly FamilyRestourantDbContext _context;
        public GalleryController(FamilyRestourantDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Gallery> gallery=_context.Gallerys.ToList();
            return View(gallery);
        }
    }
}
