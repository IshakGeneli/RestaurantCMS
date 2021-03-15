using RestaurantCMS.DAL.Abstract;
using RestaurantCMS.Models;
using System;
using System.Collections.Generic;

namespace RestaurantCMS.DAL.Concreate.MockData
{
    public class MockDishDal : IDishDal
    {
        private List<Dish> _dishes;

        public MockDishDal()
        {
            _dishes = new List<Dish>
            {
                new Dish{
                    DishId=1,
                    CategoryId=1,
                    DishName="Test Dish",
                    Description="Test Description",
                    Price=15.5,
                    Featured=true,
                    Image="images/test.jpg",
                    Rating=8
                },
                new Dish{
                    DishId=2,
                    CategoryId=1,
                    DishName="Test Dish 2",
                    Description="Test Description 2",
                    Price=15.2,
                    Featured=false,
                    Image="images/test2.jpg",
                    Rating=4
                },
                new Dish{
                    DishId=3,
                    CategoryId=1,
                    DishName="Test Dish 3",
                    Description="Test Description 3",
                    Price=15.3,
                    Featured=false,
                    Image="images/test3.jpg",
                    Rating=6
                },

            };
        }
        public Dish Add(Dish entity)
        {
            throw new NotImplementedException();
        }

        public List<Dish> AddRange(List<Dish> entities)
        {
            throw new NotImplementedException();
        }

        public Dish Delete(Dish entity)
        {
            throw new NotImplementedException();
        }

        public List<Dish> DeleteRange(List<Dish> entities)
        {
            throw new NotImplementedException();
        }

        public Dish Get(Dish entity)
        {
            throw new NotImplementedException();
        }

        public List<Dish> GetAll()
        {
            throw new NotImplementedException();
        }

        public Dish Update(Dish entity)
        {
            throw new NotImplementedException();
        }

        public List<Dish> UpdateRange(List<Dish> entities)
        {
            throw new NotImplementedException();
        }
    }
}
