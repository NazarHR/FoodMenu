using Azure.Core;
using FoodMenu.Data.Entitie;
using FoodMenu.Models;
using FoodMenu.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodMenu.Controllers
{
    public class MenuController : Controller
    {
        private readonly IFoodMenuRepository _foodMenuRepository;

        public MenuController(IFoodMenuRepository foodMenuRepository)
        {
            _foodMenuRepository = foodMenuRepository;
        }
        public async Task<IActionResult> IndexAsync(string? tag)
        {
            List<Tag> tags = (List<Tag>)await _foodMenuRepository.GetTagsAsync();
            
            if (tag == null)
            {
                tag = tags[0].Name;
            }
            List<Dish> dishes = (List<Dish>)await _foodMenuRepository.GetDishesAsync(tag);
            var menuData = new MenuDataModel
            {
                Tags = tags,
                Dishes = (List<Dish>)dishes
            };
            return View(menuData);
        }

        public async Task<IActionResult> Details(int dishId)
        {
            var dish = await _foodMenuRepository.GetDishAsync(dishId);
            if(dish == null)
            {
                return NotFound();
            }
            return View(dish);
        }
    }
}
