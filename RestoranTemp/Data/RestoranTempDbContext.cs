using Microsoft.EntityFrameworkCore;
using RestoranTemp.Models;

namespace RestoranTemp.Data
{
    public class RestoranTempDbContext:DbContext
    {
        public RestoranTempDbContext(DbContextOptions<RestoranTempDbContext> options) : base(options)
        {

        }
        public DbSet<Home> Home { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Services> Service { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Testimonial> Testimonial { get; set; }
        public DbSet<Foods> Foods { get; set; }


    }


}
