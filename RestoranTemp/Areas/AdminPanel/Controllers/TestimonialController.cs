using Microsoft.AspNetCore.Mvc;
using RestoranTemp.Data;
using RestoranTemp.Models;
using Microsoft.EntityFrameworkCore;

namespace RestoranTemp.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class TestimonialController : Controller
    {
        private readonly RestoranTempDbContext _context;
        public readonly IWebHostEnvironment _env;
        public TestimonialController(RestoranTempDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public IActionResult Index()
        {
            List<Testimonial> testimonial= _context.Testimonial.ToList();
            return View(testimonial);
        }

        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Testimonial testimonial)
        {
            if (!ModelState.IsValid) return View();
            if (testimonial == null)
            {
                ModelState.AddModelError("Photo", "Sekil secilmeyib");
                return View();
            }

            if (!testimonial.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Sekil tipi duzgun deyil");
                return View();
            }

            if (testimonial.Photo.Length / 1024 > 200)
            {
                ModelState.AddModelError("Photo", "Sekil olcusu odemir");
                return View();
            }

            var fileName = Guid.NewGuid().ToString() + "" + testimonial.Photo.FileName;

            string path = Path.Combine(_env.WebRootPath, "assets/img", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await testimonial.Photo.CopyToAsync(stream);
            }
            await _context.Testimonial.AddAsync(testimonial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id < 1) return BadRequest();

            Testimonial testimonial = await _context.Testimonial.FirstOrDefaultAsync(s => s.Id == id);

            if (testimonial == null) return NotFound();

            string path = Path.Combine(_env.WebRootPath, "img", testimonial.Image);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.Testimonial.Remove(testimonial);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }

            Testimonial testimonial = await _context.Testimonial.FirstOrDefaultAsync(s => s.Id == id);
            if (testimonial == null)
            {
                return NotFound();
            }

            return View(testimonial);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Testimonial testimonial)
        {
            if (!ModelState.IsValid) return View();

            Testimonial old = await _context.Testimonial.FirstOrDefaultAsync(s => s.Id == testimonial.Id);

            if (old == null) return NotFound();

            if (testimonial.Photo != null)
            {
                if (!testimonial.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "Sekil tipi duzgun deyil");
                    return View();
                }
                if (testimonial.Photo.Length / 1024 > 200)
                {
                    ModelState.AddModelError("Photo", "Olcu uygun deyil");
                    return View();
                }
            }

            string oldpath = Path.Combine(_env.WebRootPath, "assets/img", old.Image);
            if (System.IO.File.Exists(oldpath))
            {
                System.IO.File.Delete(oldpath);
            }
            var fileName = Guid.NewGuid().ToString() + " " + testimonial.Photo.FileName;
            old.Image = fileName;

            string newpath = Path.Combine(_env.WebRootPath, "img", fileName);

            using (FileStream stream = new FileStream(newpath, FileMode.Create))
            {
                await testimonial.Photo.CopyToAsync(stream);
            }

            old.FullName = testimonial.FullName;
            

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
