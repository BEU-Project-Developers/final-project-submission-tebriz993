using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestoranTemp.Models
{
    public class Team
    {
        [Key]
        public int İd { get; set; }


        public string İmage { get; set; }
        


        public string FullName { get; set; }

        public Professions Profession { get; set; }
        public int ProfessionId { get; set; }

        public Team()
        {
            
        }
    }
}
