using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyRestourant.Entities
{
    public class Events
    {
        [Required]
        public int Id { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        public string Title1 { get; set; }
        public double Price { get; set; }
        public string Title2 { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Title3 { get; set; }
    }
}
