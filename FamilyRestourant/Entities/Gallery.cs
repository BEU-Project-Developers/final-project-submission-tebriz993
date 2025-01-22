using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyRestourant.Entities
{
    public class Gallery
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
