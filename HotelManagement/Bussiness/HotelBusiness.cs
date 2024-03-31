using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace HotelManagement.Bussiness
{
    public class HotelBusiness
    {
        private string _connectionString;

        /// <summary>
        /// Connection string of the database
        /// </summary>
        public HotelBusiness()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Data"].ConnectionString;
        }

        /// <summary>
        /// Represents the data of Hotels
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Hotel> GetAll()
        {
            try
            {
                string query = "SELECT * FROM Hotels";
                ObservableCollection<Hotel> Hotels = new ObservableCollection<Hotel>();

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Hotel hotel = new Hotel
                        {
                            HotelID = (int)reader["HotelID"],
                            HotelName = (string)reader["HotelName"],
                            HotelLocation = (string)reader["HotelLocation"],
                            Rating = (int)reader["Rating"]
                        };
                        Hotels.Add(hotel);
                    }
                }

                return Hotels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Adds the Hotel data to the database
        /// </summary>
        /// <param name="hotel"></param>
        public void AddHotel(Hotel hotel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO Hotels (HotelName, HotelLocation, Rating) VALUES (@HotelName, @HotelLocation, @Rating)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@HotelName", hotel.HotelName);
                        command.Parameters.AddWithValue("@HotelLocation", hotel.HotelLocation);
                        command.Parameters.AddWithValue("@Rating", hotel.Rating);

                        int rowsAffected = command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Updates the data to the database
        /// </summary>
        /// <param name="hotel"></param>
        public void UpdateHotel(Hotel hotel)
        {
            string query = "UPDATE Hotels SET HotelName = @HotelName, HotelLocation = @HotelLocation, Rating = @Rating WHERE HotelID = @HotelId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@HotelId", hotel.HotelID);
                    command.Parameters.AddWithValue("@HotelName", hotel.HotelName);
                    command.Parameters.AddWithValue("@HotelLocation", hotel.HotelLocation);
                    command.Parameters.AddWithValue("@Rating", hotel.Rating);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Hotel data updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Hotel data update failed.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error updating hotel data: " + ex.Message);
                    }
                }
            }
        }


        /// <summary>
        /// Deletes the hotel data from the database
        /// </summary>
        /// <param name="hotel"></param>
        public void DeleteHotel(Hotel hotel)
        {
            string query = "DELETE FROM Hotels WHERE HotelID = @HotelId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@HotelId", hotel.HotelID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Hotel data deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Hotel data deletion failed. No rows were affected.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error deleting hotel data: " + ex.Message);
                    }
                }
            }
        }
    }
}
