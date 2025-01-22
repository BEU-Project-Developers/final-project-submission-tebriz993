using System.ComponentModel.DataAnnotations;

namespace FamilyRestourant.Entities
{
    public class WhyChooseUs
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }

    }
}
