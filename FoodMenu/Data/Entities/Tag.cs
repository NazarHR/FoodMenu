namespace FoodMenu.Data.Entitie
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DishTag>? DishTags { get; set; }
    }
}
