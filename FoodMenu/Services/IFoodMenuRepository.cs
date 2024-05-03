using FoodMenu.Data.Entitie;

namespace FoodMenu.Services
{
    public interface IFoodMenuRepository
    {
        Task<IEnumerable<Dish>> GetDishesAsync();
        Task<IEnumerable<Dish>> GetDishesAsync(string fullOrPartitialName);
        Task<IEnumerable<Tag>> GetTagsAsync();
    }
}