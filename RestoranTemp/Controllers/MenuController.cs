using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestoranTemp.Data;
using RestoranTemp.Models;

namespace RestoranTemp.Controllers
{
    public class MenuController : Controller
    {

        private readonly RestoranTempDbContext _context;
        public MenuController(RestoranTempDbContext context)
        {
            _context = context;
        }
        
            public async Task<IActionResult> Index()
            {
                List<Menu> menus = await _context.Menu.Include(m=>m.menuOfFoods).ThenInclude(f=>f.Foods).ToListAsync();
                return View(menus);
            }
        
    }
}