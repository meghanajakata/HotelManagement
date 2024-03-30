using HotelManagement.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Hotel> Hotels { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new HotelVM();
        }
    }
}
