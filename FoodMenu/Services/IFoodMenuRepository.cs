using FoodMenu.Data.Entitie;

namespace FoodMenu.Services
{
    public interface IFoodMenuRepository
    {
        Task<IEnumerable<Dish>> GetDishesAsync();
        Task<IEnumerable<Dish>> GetDishesAsync(string tagname, bool includeIngredients = false);
        Task<Dish> GetDishAsync(int id);
        Task<IEnumerable<Dish>> FindDishesAsync(string fullOrPartitialName);
        Task<IEnumerable<Tag>> GetTagsAsync();
    }
}