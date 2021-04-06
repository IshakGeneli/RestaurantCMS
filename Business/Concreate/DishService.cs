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

        public Dish Add(Dish dish)
        {
            return _dishDal.Add(dish);
        }

        public Dish GetById(int id)
        {
            return _dishDal.GetById(id);
        }

        public List<Dish> GetAll()
        {
           return _dishDal.GetAll();
        }

        public Dish Update(Dish dish)
        {
            return _dishDal.Update(dish);
        }

        public Dish Delete(int id)
        {
            return _dishDal.Delete(id);
        }
    }
}
