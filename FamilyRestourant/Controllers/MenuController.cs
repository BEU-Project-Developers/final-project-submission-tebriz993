using FamilyRestourant.DAL;
using FamilyRestourant.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyRestourant.Controllers
{
    public class MenuController : Controller
    {
        private readonly FamilyRestourantDbContext _context;
        public MenuController(FamilyRestourantDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Menus> menus=_context.Menus
                .Include(m=>m.MenusFoods)
                .ThenInclude(f=>f.Foods)
                .ToList();

            return View(menus);
        }
    }
}
