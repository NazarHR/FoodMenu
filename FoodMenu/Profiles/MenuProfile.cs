using AutoMapper;
using FoodMenu.Data.Entitie;
using FoodMenu.Models;

namespace FoodMenu.Profiles
{
    public class MenuProfile:Profile
    {
        public MenuProfile() 
        {
            CreateMap<Tag,TagDto>();
            CreateMap<Dish, DishWitoutIngredientsDto>();
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<Dish,DishDetailsDto>()
                .ForMember(dest=>dest.Ingredients, opt=>
                opt.MapFrom(src=>src.DishIngredients.Select(di=>di.Ingredient).ToList()));
        }

    }
}
