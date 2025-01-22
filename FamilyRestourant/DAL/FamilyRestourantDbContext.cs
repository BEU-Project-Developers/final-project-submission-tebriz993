using FamilyRestourant.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamilyRestourant.DAL
{
    public class FamilyRestourantDbContext:DbContext
    {
        public FamilyRestourantDbContext(DbContextOptions<FamilyRestourantDbContext> options):base(options)
        {
            
        }


        public DbSet<About> About { get; set; }
        public DbSet<Chefs> Chefs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<FacebookAddress> FacebookAddresses { get; set; }
        public DbSet<Foods> Foods { get; set; }
        public DbSet<Gallery> Gallerys { get; set; }
        public DbSet<Home> Home { get; set; }
        public DbSet<InstagramAddress> InstagramAddresses { get; set; }
        public DbSet<LinkedinAddress> LinkedinAddresses { get; set; }
        public DbSet<Menus> Menus { get; set; }
        public DbSet<MenusFoods> MenusFoods { get; set;}
        public DbSet<Professions> Professions { get; set;}
        public DbSet<SpecialDescription> SpecialDescriptions { get; set; }
        public DbSet<Specials> Specials { get; set; }
        public DbSet<Testimonials> Testimonials { get; set;}
        public DbSet<TwitterAddress> TwitterAddresses { get; set; }
        public DbSet<WhyChooseUs> WhyChooseUs { get; set; }


    }
}
