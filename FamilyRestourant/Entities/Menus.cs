using System.ComponentModel.DataAnnotations;

namespace FamilyRestourant.Entities
{
    public class Menus
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }
        public List<MenusFoods> MenusFoods { get; set; }
    }
}
