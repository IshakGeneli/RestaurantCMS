using RestaurantCMS.Models;
using System.Collections.Generic;

namespace RestaurantCMS.Business.Abstract
{
    public interface IDishService
    {
        List<Dish> GetDishes();
    }
}
