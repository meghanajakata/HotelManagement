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
    /// Interaction logic for AddHotelDialog.xaml
    /// </summary>
    public partial class AddHotelDialog : Window
    {
        public HotelVM hotelVM= new HotelVM();
        public AddHotelDialog()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            hotelVM.hotel.HotelName = txtHotelName.Text;
            hotelVM.hotel.HotelLocation = txtLocation.Text;
            hotelVM.hotel.Rating = Convert.ToInt32(txtRating.Text);
            hotelVM.Save(hotelVM.hotel);
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
