using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using RestaurantCMS.DAL.Abstract;
using RestaurantCMS.Models;
using System;
using System.Collections.Generic;

namespace RestaurantCMS.DAL.Concreate.MySql
{
    public class MySqlPersonelDal : IPersonelDal
    {
        private readonly string _connectionString;
        public MySqlPersonelDal(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MySqlDbConnection");
        }
        public Personel Add(Personel entity)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        connection.Open();

                        var sql = "INSERT INTO Personels(" +
                            "FirstName," +
                            "LastName," +
                            "Title," +
                            "Image) " +
                            "VALUES(@firstName, @lastName, @title, @image)";

                        command.CommandText = sql;

                        command.Parameters.AddWithValue("@firstName", entity.FirstName);
                        command.Parameters.AddWithValue("@lastName", entity.LastName);
                        command.Parameters.AddWithValue("@title", entity.Title);
                        command.Parameters.AddWithValue("@image", entity.Image);
  

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

        public List<Personel> AddRange(List<Personel> entities)
        {
            throw new NotImplementedException();
        }

        public Personel Delete(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    using (MySqlCommand command = connection.CreateCommand())
                    {

                        connection.Open();

                        command.CommandText = "DELETE FROM Personels WHERE PersonelId = @personelId";

                        command.Parameters.AddWithValue("@personelId", id);

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

        public List<Personel> DeleteRange(List<Personel> entities)
        {
            throw new NotImplementedException();
        }

        public Personel GetById(int id)
        {
            Personel personel = new Personel();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        string sql = "SELECT * FROM Personels WHERE PersonelId = @personelId";
                        command.Parameters.AddWithValue("@personelId", id);
                        command.CommandText = sql;

                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {


                            personel = new Personel
                            {
                                PersonelId = Convert.ToInt32(reader["PersonelId"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Title = reader["Title"].ToString(),
                                Image = reader["Image"].ToString(),
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

            return personel;
        }

        public List<Personel> GetAll()
        {
            List<Personel> personels = new List<Personel>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        string sql = "SELECT * FROM Personels";
                        command.CommandText = sql;

                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            

                            Personel personel = new Personel
                            {
                                PersonelId = Convert.ToInt32(reader["PersonelId"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Title = reader["Title"].ToString(),
                                Image = reader["Image"].ToString()
                            };

                            personels.Add(personel);
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

            return personels;
        }

        public Personel Update(Personel entity)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    using (MySqlCommand command = connection.CreateCommand())
                    {

                        connection.Open();

                        command.CommandText = "UPDATE Personels SET " +
                            "PersonelId = @personelId," +
                            "FirstName = @firstName," +
                            "LastName = @lastName," +
                            "Title = @title" +
                            " WHERE PersonelId = @personelId";

                        command.Parameters.AddWithValue("@personelId", entity.PersonelId);
                        command.Parameters.AddWithValue("@firstName", entity.FirstName);
                        command.Parameters.AddWithValue("@lastName", entity.LastName);
                        command.Parameters.AddWithValue("@title", entity.Title);


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

        public List<Personel> UpdateRange(List<Personel> entities)
        {
            throw new NotImplementedException();
        }
    }
}
