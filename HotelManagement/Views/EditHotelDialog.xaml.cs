using HotelManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelManagement.Views
{
    /// <summary>
    /// Interaction logic for EditHotelDialog.xaml
    /// </summary>
    public partial class EditHotelDialog : Window
    {
        public HotelVM hotelVM = new HotelVM();
        public EditHotelDialog(Hotel hotel)
        {
            InitializeComponent();
            DataContext = hotel;
            hotelVM.hotel = hotel;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            hotelVM.hotel.HotelName = txtHotelName.Text;
            hotelVM.hotel.HotelLocation = txtLocation.Text;
            hotelVM.hotel.Rating = Convert.ToInt32(txtRating.Text);
            hotelVM.Update(hotelVM.hotel);
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
