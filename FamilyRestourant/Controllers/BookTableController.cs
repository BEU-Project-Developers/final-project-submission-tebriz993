using Microsoft.AspNetCore.Mvc;

namespace FamilyRestourant.Controllers
{
    public class BookTableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
