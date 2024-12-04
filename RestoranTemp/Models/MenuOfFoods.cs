using System.ComponentModel.DataAnnotations;

namespace RestoranTemp.Models
{
    public class MenuOfFoods
    {
        [Key]
        public int Id { get; set; }

        public Menu Menu { get; set; }
        public int MenuId { get; set; }

        public Foods Foods { get; set; }
        public int FoodId { get; set; }
    }
}
