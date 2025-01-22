using System.ComponentModel.DataAnnotations;

namespace FamilyRestourant.Entities
{
    public class Home
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength (50)]
        public string Subtitle { get; set; }

    }
}
