using HotelManagement.Bussiness;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelManagement.ViewModel
{
    public class HotelVM : INotifyPropertyChanged
    { 
        public ObservableCollection<Hotel> Hotels = new ObservableCollection<Hotel>();
        HotelBusiness _hotelBusiness;
        public HotelVM()
        {
            Hotels.Add(new Hotel() { HotelName = "Mehfil", HotelLocation = "Hyderabad", Rating = 4 });
        }
        private RelayCommand _addCommand;
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;

        public void LoadData()
        {
            Hotels = _hotelBusiness.GetAll();
        }
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(
                        param => this.AddHotel(),
                        param => true
                        );
                }
                return _addCommand;
            }
        }

        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new RelayCommand(
                        param => this.EditHotel(),
                        param => true
                        );
                }
                return _editCommand;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(
                        param => this.DeleteHotel(),
                        param => true
                        );
                }
                return _deleteCommand;
            }
        }

        

        private void AddHotel()
        {

        }

        private void DeleteHotel()
        {

        }

        private void EditHotel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
