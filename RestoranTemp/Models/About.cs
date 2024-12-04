using System.ComponentModel.DataAnnotations;

namespace RestoranTemp.Models
{
    public class About
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int Count { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Subtitle { get; set; }
    }
}
