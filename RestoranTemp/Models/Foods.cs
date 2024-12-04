using System.ComponentModel.DataAnnotations;

namespace RestoranTemp.Models
{
    public class Foods
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        [MaxLength(100)]
        public string FoodName { get; set; }
        
        public int Price { get; set; }
        [MaxLength(100)]
        public string Subtitle { get; set; }


        public List<MenuOfFoods>? menuOfFoods { get; set; }

        public Foods()
        {
            
        }
    }
}
