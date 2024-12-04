using Microsoft.AspNetCore.Mvc;
using RestoranTemp.Data;
using RestoranTemp.Models;

namespace RestoranTemp.Controllers
{
    public class AboutController : Controller
    {
        private readonly RestoranTempDbContext _context;
        public AboutController(RestoranTempDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<About> about=_context.About.ToList();
            return View(about);
        }
    }
}
