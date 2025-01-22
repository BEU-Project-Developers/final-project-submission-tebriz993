namespace FamilyRestourant.Entities
{
    public class InstagramAddress
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public List<Chefs> Chefs { get; set; }
    }
}
