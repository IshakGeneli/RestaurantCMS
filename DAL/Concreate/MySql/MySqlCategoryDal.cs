using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
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
            List<Category> categories = new List<Category>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        string sql = "SELECT * FROM Categories";
                        command.CommandText = sql;

                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {

                            Category category = new Category
                            {
                                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                CategoryName = reader["CategoryName"].ToString(),
                                Color= reader["Color"].ToString()
                            };

                            categories.Add(category);
                        }
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return categories;
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
