using FamilyRestourant.DAL;
using FamilyRestourant.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyRestourant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly FamilyRestourantDbContext _context;
        public DashboardController(FamilyRestourantDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            List<Home> home=_context.Home.ToList();
            return View(home);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Home home)
        {
            if (!ModelState.IsValid) return View();

            ////bool result = await _context.Home.AnyAsync(p => p.Title.Trim().ToLower() == home.Title.Trim().ToLower());

            //if (result)
            //{
            //    ModelState.AddModelError("Title", "Eyni adda data artiq movcuddur...");
            //    return View();
            //}

            await _context.Home.AddAsync(home);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }



        public async Task<IActionResult> UpdateAsync(int Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            Home old = await _context.Home.FirstOrDefaultAsync(o => o.Id == Id);
            if (old == null)
            {
                return NotFound();
            }

            return View(old);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int Id, Home home)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            Home old = await _context.Home.FirstOrDefaultAsync(o => o.Id == Id);

            if (old == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (old.Title == home.Title && old.Subtitle == home.Subtitle)
            {

                return RedirectToAction(nameof(Index));

            }

            old.Title = home.Title;
            old.Subtitle= home.Subtitle;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            Home design = await _context.Home.FirstOrDefaultAsync(o => o.Id == Id);
            if (design == null) NotFound();

            _context.Home.Remove(design);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}
