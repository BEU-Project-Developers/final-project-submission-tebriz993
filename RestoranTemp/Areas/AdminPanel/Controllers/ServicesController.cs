using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using RestoranTemp.Data;
using RestoranTemp.Models;

namespace RestoranTemp.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ServicesController : Controller
    {
        private readonly RestoranTempDbContext _context;
        public ServicesController(RestoranTempDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Services> services = _context.Service.ToList();
            return View(services);
        }




       
        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Services services)
        {
            if (!ModelState.IsValid) return View();

            bool result = await _context.Service.AnyAsync(p => p.Title.Trim().ToLower() == services.Title.Trim().ToLower());
            if (result)
            {
                ModelState.AddModelError("Title", "Bu adda data artiq movcuddur.");
                return View();
            }

            await _context.Service.AddAsync(services);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id < 1) return BadRequest();

            Services old=await _context.Service.FirstOrDefaultAsync(p => p.Id == id);

            if(old == null) return NotFound();

            return View(old);

        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Services service)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }

            Services old = await _context.Service.FirstOrDefaultAsync(o => o.Id == id);

            if (old == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (old.Title == service.Title)
            {
                return RedirectToAction(nameof(Index));
            }
            bool result = await _context.Service.AnyAsync(p => p.Title.Trim().ToLower() == service.Title.Trim().ToLower() && p.Id != old.Id);
            if (result)
            {
                ModelState.AddModelError("Title", "Bu adda title artiq var");
                return View(old);
            }
            old.Title = service.Title;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            Services service = await _context.Service.FirstOrDefaultAsync(o => o.Id == id);
            if (service == null) NotFound();

            _context.Service.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }



    }
}
