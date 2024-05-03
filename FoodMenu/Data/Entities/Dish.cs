namespace FoodMenu.Data.Entitie
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public double Price {  get; set; }
        public List<DishTag> DishTags { get; set; }
        public List<DishIngredient> DishIngredients { get; set;}

    }
}
