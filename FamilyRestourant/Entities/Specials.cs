using System.ComponentModel.DataAnnotations;

namespace FamilyRestourant.Entities
{
    public class Specials
    {

        [Required]
        public int Id { get; set; }
        public string Title { get; set; }

        public int SpecialDescriptionId { get; set; }
        public SpecialDescription SpecialDescription { get; set; }

    }
}
