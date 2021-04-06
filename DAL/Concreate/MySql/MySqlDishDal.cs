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
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        connection.Open();

                        var sql = "INSERT INTO Dishes(" +
                            "CategoryId," +
                            "DishName," +
                            "Description," +
                            "Image," +
                            "Price," +
                            "Rating," +
                            "Featured) " +
                            "VALUES(@categoryId, @dishName, @description, @image, @price, @rating, @featured)";

                        command.CommandText = sql;

                        command.Parameters.AddWithValue("@categoryId", entity.Category.CategoryId);
                        command.Parameters.AddWithValue("@dishName", entity.DishName);
                        command.Parameters.AddWithValue("@description", entity.Description);
                        command.Parameters.AddWithValue("@image", entity.Image);
                        command.Parameters.AddWithValue("@price", entity.Price);
                        command.Parameters.AddWithValue("@rating", entity.Rating);
                        command.Parameters.AddWithValue("@featured", entity.Featured);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;

            }
            return entity;
        }

        public List<Dish> AddRange(List<Dish> entities)
        {
            throw new NotImplementedException();
        }

        public Dish Delete(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    using (MySqlCommand command = connection.CreateCommand())
                    {

                        connection.Open();

                        command.CommandText = "DELETE FROM Dishes WHERE DishId = @dishId";

                        command.Parameters.AddWithValue("@dishId", id);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch
            {
                throw;
            }
            return GetById(id);
        }

        public List<Dish> DeleteRange(List<Dish> entities)
        {
            throw new NotImplementedException();
        }

        public Dish GetById(int id)
        {
            Dish dish = new Dish();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        string sql = "SELECT C.*,D.* FROM Dishes D JOIN Categories C ON C.CategoryId = D.CategoryId WHERE D.DishId = @dishId";
                        command.Parameters.AddWithValue("@dishId", id);
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

                            dish = new Dish
                            {
                                DishId = Convert.ToInt32(reader["DishId"]),
                                Category = category,
                                DishName = reader["DishName"].ToString(),
                                Description = reader["Description"].ToString(),
                                Image = reader["Image"].ToString(),
                                Price = Convert.ToDouble(reader["Price"]),
                                Rating = Convert.ToInt16(reader["Rating"]),
                                Featured = reader.GetBoolean(reader.GetOrdinal("Featured"))
                            };

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

            return dish;
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
                                DishId = Convert.ToInt32(reader["DishId"]),
                                Category = category,
                                DishName = reader["DishName"].ToString(),
                                Description = reader["Description"].ToString(),
                                Image = reader["Image"].ToString(),
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
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    using (MySqlCommand command = connection.CreateCommand())
                    {

                        connection.Open();

                        command.CommandText = "UPDATE Dishes SET " +
                            "CategoryId = @categoryId," +
                            "DishName = @dishName," +
                            "Description = @description," +       
                            "Price = @price," +
                            "Rating = @rating," +
                            "Featured = @featured WHERE DishId = @dishId";

                        command.Parameters.AddWithValue("@dishId", entity.DishId);
                        command.Parameters.AddWithValue("@categoryId", entity.Category.CategoryId);
                        command.Parameters.AddWithValue("@dishName", entity.DishName);
                        command.Parameters.AddWithValue("@description", entity.Description);
                        command.Parameters.AddWithValue("@price", entity.Price);
                        command.Parameters.AddWithValue("@rating", entity.Rating);
                        command.Parameters.AddWithValue("@featured", entity.Featured);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch
            {
                throw;
            }
            return entity;
        }

        public List<Dish> UpdateRange(List<Dish> entities)
        {
            throw new NotImplementedException();
        }
    }
}
