using System;
using System.ComponentModel.DataAnnotations;

namespace FamilyRestourant.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Reservation date and time is required")]
        public DateTime ReservationDateTime { get; set; }

        [Required(ErrorMessage = "Number of people is required")]
        [Range(1, 30, ErrorMessage = "Number of people must be between 1 and 30")]
        public int People { get; set; }

        public string Message { get; set; }
        public List<ReservationFoods> ReservationFoods { get; set; }
    }
}
