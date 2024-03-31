using HotelManagement.Bussiness;
using HotelManagement.Views;
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
        public ObservableCollection<Hotel> Hotels { get; set; } = new ObservableCollection<Hotel>();
        public Hotel hotel = new Hotel();
        HotelBusiness _hotelBusiness;
        public HotelVM()
        {
            _hotelBusiness = new HotelBusiness();
            LoadData();
        }
        private RelayCommand _addCommand;
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;

        /// <summary>
        /// Loads the data to the UI
        /// </summary>
        public void LoadData()
        {
            Hotels.Clear();
            foreach(Hotel item in _hotelBusiness.GetAll())
            {
                Hotels.Add(item);
            }
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
                        param => CanEdit()
                        );
                }
                return _editCommand;
            }
        }

        private Hotel selectedHotel;
        public Hotel SelectedHotel
        {
            get { return selectedHotel; }
            set
            {
                if (selectedHotel != value)
                {
                    selectedHotel = value;
                    OnPropertyChanged(nameof(SelectedHotel));
                }
            }
        }

        public bool CanEdit()
        {
            return SelectedHotel != null;
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(
                        param => this.DeleteHotel(),
                        param => CanDelete()
                        );
                }
                return _deleteCommand;
            }
        }

        public bool CanDelete()
        {
            return SelectedHotel != null;
        }

        private void AddHotel()
        {
            AddHotelDialog dialog = new AddHotelDialog();

            bool? result = dialog.ShowDialog();

            if (result == true)
            {

            }
            LoadData();
        }

        private void DeleteHotel()
        {
            _hotelBusiness.DeleteHotel(selectedHotel);
            LoadData();
        }

        private void EditHotel()
        {
            EditHotelDialog dialog = new EditHotelDialog(selectedHotel);

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                LoadData();
            }
        }

        public void Save(Hotel hotel)
        {
            _hotelBusiness.AddHotel(hotel);
        }

        public void Update(Hotel hotel)
        {
            _hotelBusiness.UpdateHotel(hotel);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
