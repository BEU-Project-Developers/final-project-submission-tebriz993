using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyRestourant.Entities
{
    public class Chefs
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Name { get; set; }

        public int ProfessionsId { get; set; }
        public Professions Professions { get; set; }

        public int InstagramAddressId { get; set; }
        public InstagramAddress InstagramAddress { get; set; }

        public int FacebookAddressId { get; set; }
        public FacebookAddress FacebookAddress { get; set; }

        public int LinkedinAddressId { get; set; }
        public LinkedinAddress LinkedinAddress { get; set; }

        public int TwitterAddressId { get; set; }
        public TwitterAddress TwitterAddress { get; set; }


    }
}
