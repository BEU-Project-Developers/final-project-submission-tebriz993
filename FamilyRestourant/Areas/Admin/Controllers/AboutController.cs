using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FamilyRestourant.DAL;
using FamilyRestourant.Entities;


namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly FamilyRestourantDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutController(FamilyRestourantDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public IActionResult Index()
        {
            List<About> about = _context.About.ToList();
            return View(about);
        }
        public IActionResult Create()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(About about)
        {

            if (!ModelState.IsValid) return View();

            if (about == null)

            {
                ModelState.AddModelError("Photo", "Sekil Secilmeyib");
                return View();


            }

            if (!about.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Tipi sehvdir");
                return View();

            }


            if (about.Photo.Length / 1024 > 200)
            {
                ModelState.AddModelError("Photo", "Olcu Odemir");
                return View();
            }

            var filename = Guid.NewGuid().ToString() + "_" + about.Photo.FileName;

            about.Image = filename;

            string path = Path.Combine(_env.WebRootPath, "assets/img", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await about.Photo.CopyToAsync(stream);
            }

            await _context.About.AddAsync(about);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();

            }
            About news = await _context.About.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }





        [HttpPost]
        public async Task<IActionResult> Update(About about)
        {
            if (!ModelState.IsValid) return View();

            About old = await _context.About.FirstOrDefaultAsync(o => o.Id == about.Id);
            if (old == null)
            {
                return NotFound();
            }


            if (about.Photo != null)
            {
                if (!about.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "Sekil tipi duzgun deyil");
                    return View();
                }
                if (about.Photo.Length / 1024 > 200)
                {
                    ModelState.AddModelError("Photo", "Olcu duzgun deyil");
                    return View();
                }


            }


            string path = Path.Combine(_env.WebRootPath + "img" + old.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            var fileName = Guid.NewGuid().ToString() + "" + about.Photo.FileName;
            old.Image = fileName;

            string newpath = Path.Combine(_env.WebRootPath, "assets/img", fileName);
            using (FileStream stream = new FileStream(newpath, FileMode.Create))
            {
                await about.Photo.CopyToAsync(stream);
            }
            
            old.Title = about.Title;
            old.Subtitle = about.Subtitle;
            old.Smalltitle1 = about.Smalltitle1;
            old.Smalltitle2 = about.Smalltitle2;
            old.Smalltitle3 = about.Smalltitle3;
            old.Description = about.Description;


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            About news = await _context.About.FirstOrDefaultAsync(n => n.Id == id);
            if (news == null)
            {
                return NotFound("About entry not found.");
            }

            string imagePath = Path.Combine(_env.WebRootPath, "img", news.Image);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _context.About.Remove(news);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}




