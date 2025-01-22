using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyRestourant.Entities
{
    public class SpecialDescription
    {
        [Required]
        public int Id { get; set; }
        public string Subtitle1 { get; set; }
        public string Subtitle2 { get; set; }
        public string Subtitle3 { get; set; }

        public string? Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        public List<Specials> Specials { get; set; }
    }
}
