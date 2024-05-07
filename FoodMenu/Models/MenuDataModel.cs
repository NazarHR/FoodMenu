using FoodMenu.Data.Entitie;

namespace FoodMenu.Models
{
    public class MenuDataModel
    {
        public List<TagDto> Tags { get; set; }
        public List<DishWitoutIngredientsDto> Dishes { get; set; }
    }
}
