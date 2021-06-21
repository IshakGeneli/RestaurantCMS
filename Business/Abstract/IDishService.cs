using RestaurantCMS.Models;
using System.Collections.Generic;

namespace RestaurantCMS.Business.Abstract
{
    public interface IDishService : IRepositoryService<Dish>
    {
        List<Dish> GetByCategoryId(int categoryId);
        List<Dish> GetByFeaturedItem();

    }
}
