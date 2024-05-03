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
            return await _dbContext.Tags.Include(dt=>dt.DishTags).ThenInclude(d=>d.Dish)
                .ToListAsync();
        }
        public async Task<Dish> GetDishAsync(int id)
        {
            return await _dbContext.Dishes
                .Include(di=>di.DishIngredients)
                .ThenInclude(i => i.Ingredient)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task<IEnumerable<Dish>> GetDishesAsync()
        {
            return await _dbContext.Dishes.ToListAsync();
        }
        public async Task<IEnumerable<Dish>> GetDishesAsync(string tagname, bool includeIngredients = false)
        {
            var dishes = _dbContext.DishTags
                .Include(dt => dt.Tag)
                .Where(dt => dt.Tag.Name == tagname)
                .Include(dt => dt.Dish)
                .Select(dt => dt.Dish);
            //var dishes = _dbContext.Dishes;
            //if(includeIngredients )
            //{
            //    dishes.Include(d => d.DishIngredients).ThenInclude(d => d.Ingredient);
            //}
            return await dishes.ToListAsync();
        }
        public async Task<IEnumerable<Dish>> FindDishesAsync(string fullOrPartitialName)
        {
            return await _dbContext.Dishes.Where(d => d.Name.Contains(fullOrPartitialName)).ToListAsync();
        }
    }
}
