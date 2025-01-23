using System.Collections.Generic;

namespace FamilyRestourant.Entities
{
    public class ReservationViewModel
    {
        public Reservation Reservation { get; set; }
        public List<Foods> Foods { get; set; }
        public List<int> SelectedFoodIds { get; set; }
    }
}
