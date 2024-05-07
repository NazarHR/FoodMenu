namespace FoodMenu.Models
{
    public class DishDetailsDto
    {
        public string Name { get; set; }
        public string ImageURL { get; set; }

        public List<IngredientDto> Ingredients { get; set;}
    }
}
