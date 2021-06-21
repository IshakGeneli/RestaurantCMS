using RestaurantCMS.Business.Abstract;
using RestaurantCMS.DAL.Abstract;
using RestaurantCMS.Models;
using System;
using System.Collections.Generic;

namespace RestaurantCMS.Business.Concreate
{
    public class CategoryService : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
           return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category dish)
        {
            throw new NotImplementedException();
        }
    }
}
