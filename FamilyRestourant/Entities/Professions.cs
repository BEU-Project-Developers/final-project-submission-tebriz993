using System.ComponentModel.DataAnnotations;

namespace FamilyRestourant.Entities
{
    public class Professions
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        List<Testimonials> Testimonials { get; set;}
        List<Chefs> Chefs { get; set; }
    }
}
