namespace FamilyRestourant.Entities
{
    public class LinkedinAddress
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public List<Chefs> Chefs { get; set; }
    }
}
