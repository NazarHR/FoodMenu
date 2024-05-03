using FoodMenu.Data;
using FoodMenu.Data.Entitie;
using Microsoft.EntityFrameworkCore;

namespace FoodMenu.Services
{
    public class FoodMenuRepository : IFoodMenuRepository
    {
        private readonly FoodMenuDBContext _dbContext;

        public FoodMenuRepository(FoodMenuDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            return await _dbContext.Tags.ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetDishesAsync()
        {
            return await _dbContext.Dishes.ToListAsync();
        }
        public async Task<IEnumerable<Dish>> GetDishesAsync(string fullOrPartitialName)
        {
            return await _dbContext.Dishes.Where(d => d.Name.Contains(fullOrPartitialName)).ToListAsync();
        }
    }
}
