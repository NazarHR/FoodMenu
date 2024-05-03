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

        public async Task<IActionResult> IndexAsync()
        {
            var Tags = await _foodMenuRepository.GetTagsAsync();
            return View(Tags);
        }
    }
}
