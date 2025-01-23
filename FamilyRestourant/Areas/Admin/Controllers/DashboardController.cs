using FamilyRestourant.DAL;
using FamilyRestourant.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyRestourant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
      
        public IActionResult Index()
        {
            
            return View();
        }


        


    }
}
