using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using RestaurantCMS.DAL.Abstract;
using RestaurantCMS.Models;
using System;
using System.Collections.Generic;

namespace RestaurantCMS.DAL.Concreate.MySql
{
    public class MySqlReservationDal : IReservationDal
    {
        private readonly string _connectionString;
        public MySqlReservationDal(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MySqlDbConnection");
        }
        public Reservation Add(Reservation entity)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        connection.Open();

                        var sql = "INSERT INTO Reservations(" +
                            "FullName," +
                            "PhoneNumber," +
                            "Date," +
                            "NumPerson) " +
                            "VALUES(@fullName, @phoneNumber, @date, @numPerson)";

                        command.CommandText = sql;

                        command.Parameters.AddWithValue("@fullName", entity.FullName);
                        command.Parameters.AddWithValue("@phoneNumber", entity.PhoneNumber);
                        command.Parameters.AddWithValue("@date", entity.Date);
                        command.Parameters.AddWithValue("@numPerson", entity.NumPerson);

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

        public List<Reservation> AddRange(List<Reservation> entities)
        {
            throw new NotImplementedException();
        }

        public Reservation Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> DeleteRange(List<Reservation> entities)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAll()
        {
            List<Reservation> reservations = new List<Reservation>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        string sql = "SELECT * FROM Reservations";
                        command.CommandText = sql;

                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {                         
                            Reservation reservation = new Reservation
                            {
                                ReservationId = Convert.ToInt32(reader["ReservationId"]),
                                FullName = reader["FullName"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Date = Convert.ToDateTime(reader["Date"]),
                                NumPerson = Convert.ToInt32(reader["NumPerson"])
                            };

                            reservations.Add(reservation);
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

            return reservations;
        }

        public Reservation GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetNotExpired()
        {
            List<Reservation> reservations = new List<Reservation>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        string sql = "SELECT * FROM Reservations WHERE Date > now()";
                        command.CommandText = sql;

                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Reservation reservation = new Reservation
                            {
                                ReservationId = Convert.ToInt32(reader["ReservationId"]),
                                FullName = reader["FullName"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Date = Convert.ToDateTime(reader["Date"]),
                                NumPerson = Convert.ToInt32(reader["NumPerson"])
                            };

                            reservations.Add(reservation);
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

            return reservations;
        }

        public Reservation Update(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> UpdateRange(List<Reservation> entities)
        {
            throw new NotImplementedException();
        }
    }
}
