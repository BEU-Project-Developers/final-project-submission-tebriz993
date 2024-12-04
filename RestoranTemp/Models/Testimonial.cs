using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestoranTemp.Models
{
    public class Testimonial
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        public string FullName { get; set; }


        public Professions Profession { get; set; }
        public int ProfessionId { get; set; }
        
        public Testimonial()
        {

        }

    }
}
