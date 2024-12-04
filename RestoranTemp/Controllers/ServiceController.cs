using Microsoft.AspNetCore.Mvc;
using RestoranTemp.Data;
using RestoranTemp.Models;

namespace RestoranTemp.Controllers
{
    public class ServiceController : Controller
    {
        private readonly RestoranTempDbContext _context;
        public ServiceController(RestoranTempDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Services> services = _context.Service.ToList();
            return View(services);
        }
    }
}
