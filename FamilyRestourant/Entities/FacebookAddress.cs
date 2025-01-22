using System.ComponentModel.DataAnnotations;

namespace FamilyRestourant.Entities
{
    public class FacebookAddress
    {
        [Required]
        public int Id { get; set; }
        public string Link { get; set; }
        public List<Chefs> Chefs { get; set; }
    }
}
