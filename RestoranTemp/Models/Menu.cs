using System.ComponentModel.DataAnnotations;

namespace RestoranTemp.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public List<MenuOfFoods>? menuOfFoods { get; set; }

        public Menu()
        {
            
        }
    }
}
