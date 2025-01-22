using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyRestourant.Entities
{
    public class Testimonials
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        public string PersonName { get; set; }

        public int ProfessionsId { get; set; }
        public Professions Professions { get; set; }
    }
}
