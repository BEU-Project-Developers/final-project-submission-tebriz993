using System.ComponentModel.DataAnnotations;

namespace RestoranTemp.Models
{
    public class Professions
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Team>? Team { get; set; }
        public List<Testimonial>? Testimonial {  get; set; }

        public Professions()
        {
            
        }
    }
}
