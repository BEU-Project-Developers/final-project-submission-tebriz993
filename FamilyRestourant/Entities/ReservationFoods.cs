using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyRestourant.Entities
{
    public class ReservationFoods
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        [ForeignKey(nameof(ReservationId))]
        public Reservation Reservation { get; set; }

        public int FoodId { get; set; }
        [ForeignKey(nameof(FoodId))]
        public Foods Foods { get; set; }
    }
}
