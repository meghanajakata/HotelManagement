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
        public HotelBusiness()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Data"].ConnectionString;
        }

        public ObservableCollection<Hotel> GetAll()
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

        public void AddHotel()
        {

        }
    }
}
