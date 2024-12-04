using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestoranTemp.Data;
using RestoranTemp.Models;

namespace RestoranTemp.Controllers
{
    public class TeamController : Controller
    {
        private readonly RestoranTempDbContext _context;
        public TeamController(RestoranTempDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Team> team = _context.Team.Include(p=>p.Profession).ToList();
            return View(team);
        }
    }
}
