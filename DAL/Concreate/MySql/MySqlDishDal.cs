using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using RestaurantCMS.DAL.Abstract;
using RestaurantCMS.Models;
using System;
using System.Collections.Generic;

namespace RestaurantCMS.DAL.Concreate.MySql
{
    public class MySqlDishDal : IDishDal
    {
        private readonly string _connectionString;
        public MySqlDishDal(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MySqlDbConnection");
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
            List<Dish> dishes = new List<Dish>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    

                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        string sql = "SELECT C.*,D.* FROM Dishes D JOIN Categories C ON C.CategoryId = D.CategoryId";
                        command.CommandText = sql;

                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Category category = new Category
                            {
                                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                CategoryName = reader["CategoryName"].ToString(),
                                Color = reader["Color"].ToString()
                            };

                            Dish dish = new Dish
                            {
                               DishId =Convert.ToInt32(reader["DishId"]),
                               Category = category,
                               DishName = reader["DishName"].ToString(),
                               Description = reader["Description"].ToString(),
                               Image = reader["DishName"].ToString(),
                               Price = Convert.ToDouble(reader["Price"]),
                               Rating = Convert.ToInt16(reader["Rating"]),
                               Featured = reader.GetBoolean(reader.GetOrdinal("Featured"))
                        };

                            dishes.Add(dish);
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
           
            return dishes;
                       
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
