namespace FamilyRestourant.Entities
{
    public class MenusFoods
    {
        public int Id { get; set; }
        public int MenusId { get; set; }
        public Menus Menus { get; set; }

        public int FoodsId { get; set; }
        public Foods Foods { get; set; }
    }
}
