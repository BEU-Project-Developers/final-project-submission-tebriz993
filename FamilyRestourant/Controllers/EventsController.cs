using FamilyRestourant.DAL;
using FamilyRestourant.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyRestourant.Controllers
{
    public class EventsController : Controller
    {
        private readonly FamilyRestourantDbContext _context;
        public EventsController(FamilyRestourantDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Events> events=_context.Events.ToList();
            return View(events);
        }
    }
}
