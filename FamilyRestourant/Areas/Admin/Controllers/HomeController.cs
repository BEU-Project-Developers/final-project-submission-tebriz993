using FamilyRestourant.DAL;
using FamilyRestourant.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyRestourant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly FamilyRestourantDbContext _context;

        public HomeController(FamilyRestourantDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var homes = await _context.Home.ToListAsync();
            return View(homes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Home home)
        {
            if (!ModelState.IsValid) return View(home);

            if (await _context.Home.AnyAsync(p => p.Title.Trim().ToLower() == home.Title.Trim().ToLower()))
            {
                ModelState.AddModelError("Title", "Eyni adda data artıq mövcuddur...");
                return View(home);
            }

            await _context.Home.AddAsync(home);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var home = await _context.Home.FindAsync(id);
            if (home == null) return NotFound();

            return View(home);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Home home)
        {
            if (id != home.Id) return BadRequest();
            if (!ModelState.IsValid) return View(home);

            var existingHome = await _context.Home.FindAsync(id);
            if (existingHome == null) return NotFound();

            if (existingHome.Title != home.Title || existingHome.Subtitle != home.Subtitle)
            {
                existingHome.Title = home.Title;
                existingHome.Subtitle = home.Subtitle;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var home = await _context.Home.FindAsync(id);
            if (home == null) return NotFound();

            _context.Home.Remove(home);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
