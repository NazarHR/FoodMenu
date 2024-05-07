using AutoMapper;
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
        private readonly IMapper _mapper;

        public MenuController(IFoodMenuRepository foodMenuRepository, IMapper mapper)
        {
            _foodMenuRepository = foodMenuRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexAsync(string? tag)
        {
            var tags = (List<Tag>)await _foodMenuRepository.GetTagsAsync();
            var tagsDto = tags.Select(t=>_mapper.Map<TagDto>(t)).ToList();
            if (tag == null)
            {
                tag = tagsDto[0].Name;
            }
            var dishes = (List<Dish>)await _foodMenuRepository.GetDishesAsync(tag);
            var dishesDto = dishes.Select(d=>_mapper.Map<DishWitoutIngredientsDto>(d)).ToList();
            var menuData = new MenuDataModel
            {
                Tags = tagsDto,
                Dishes = dishesDto
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
            var dishDto = _mapper.Map<DishDetailsDto>(dish);
            return View(dishDto);
        }
    }
}
