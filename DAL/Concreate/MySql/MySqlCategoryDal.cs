using Microsoft.Extensions.Configuration;
using RestaurantCMS.DAL.Abstract;
using RestaurantCMS.Models;
using System;
using System.Collections.Generic;

namespace RestaurantCMS.DAL.Concreate.MySql
{
    public class MySqlCategoryDal : ICategoryDal
    {
        private readonly string _connectionString;
        public MySqlCategoryDal(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MySqlDbConnection");
        }
        public Category Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public List<Category> AddRange(List<Category> entities)
        {
            throw new NotImplementedException();
        }

        public Category Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> DeleteRange(List<Category> entities)
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public List<Category> UpdateRange(List<Category> entities)
        {
            throw new NotImplementedException();
        }
    }
}
