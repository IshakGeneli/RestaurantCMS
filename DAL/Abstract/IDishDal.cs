using RestaurantCMS.Models;
using System.Collections.Generic;

namespace RestaurantCMS.DAL.Abstract
{
    public interface IDishDal : IRepository<Dish>
    {
        List<Dish> GetByCategoryId(int categoryId);
        List<Dish> GetByFeaturedItem();
    }
}
