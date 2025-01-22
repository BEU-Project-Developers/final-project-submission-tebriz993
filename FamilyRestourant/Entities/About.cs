using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyRestourant.Entities
{
    public class About
    {
        [Required]
        public int Id { get; set; }

        public string? Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        public string Title { get; set; }
        public string Subtitle { get; set; }

        public string Smalltitle1 { get; set; }
        public string Smalltitle2 { get; set; }
        public string Smalltitle3 { get; set; }

        public string Description { get; set; }

    }
}
