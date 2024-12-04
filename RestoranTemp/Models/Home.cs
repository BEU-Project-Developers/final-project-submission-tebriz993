using System.ComponentModel.DataAnnotations;

namespace RestoranTemp.Models
{
    public class Home
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
    }
}
