using FamilyRestourant.DAL;
using FamilyRestourant.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyRestourant.Controllers
{
    public class ContactController : Controller
    {
        private readonly FamilyRestourantDbContext _context;
        public ContactController(FamilyRestourantDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Contact? contacts = _context.Contacts.OrderBy(c=>c.Id).FirstOrDefault();
            return View(contacts);
        }
    }
}
