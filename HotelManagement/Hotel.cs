using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement
{
    /// <summary>
    /// Model representing the data 
    /// </summary>
    public class Hotel
    {
        public int HotelID { get; set; }
        public string HotelName { get; set; }
        public string HotelLocation { get; set; }
        public int Rating { get; set; }
        public bool IsSelected { get; set; }
    }
}
