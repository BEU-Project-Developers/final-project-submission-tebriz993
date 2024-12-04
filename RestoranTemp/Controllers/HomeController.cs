using Microsoft.AspNetCore.Mvc;
using RestoranTemp.Data;
using RestoranTemp.Models;

namespace RestoranTemp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly RestoranTempDbContext _context;
        //public HomeController(RestoranTempDbContext context)
        //{
        //    _context = context;
        //}
        public IActionResult Index()
        {
            //Home? home = _context.Home.FirstOrDefault(); 
            return View();
        }
    }
}
