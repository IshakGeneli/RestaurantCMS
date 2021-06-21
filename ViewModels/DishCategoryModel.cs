using RestaurantCMS.Models;
using System.Collections.Generic;

namespace RestaurantCMS.ViewModels
{
    public class DishCategoryModel
    {
        public Category Category { get; set; }
        public Dish Dish { get; set; }
        public List<Dish> Dishes { get; set; }
        public List<Category> Categories { get; set; }
    }
}
