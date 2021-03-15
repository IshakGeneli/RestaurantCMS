using RestaurantCMS.Business.Abstract;
using RestaurantCMS.DAL.Abstract;
using RestaurantCMS.Models;
using System.Collections.Generic;

namespace RestaurantCMS.Business.Concreate
{
    public class DishService : IDishService
    {
        private IDishDal _dishDal;
        public DishService(IDishDal dishDal)
        {
            _dishDal = dishDal;
        }
        
        public List<Dish> GetDishes()
        {
           return _dishDal.GetAll();
        }
    }
}
