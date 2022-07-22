using GalaSoft.MvvmLight.Command;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace SIMS.ViewModel.Menager
{
    class DistributeEquipment:ViewModel
    {
        private NavigationService navService;
        private Room room;
        private string idRoom;
        private Equpment equpments;
        private string name;
        private int quntity;

        public Injector Inject { get; set; }

        public Model.Room Room

        {
            get { return room; }
            set
            {
                room = value;
                OnPropertyChanged();
            }
        }

        public Model.Equpment Equpment

        {
            get { return equpments; }
            set
            {
                equpments = value;
                OnPropertyChanged();
            }
        }
        public string IdRoom
        {
            get { return idRoom; }
            set
            {
                idRoom = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public int Quantity
        {
            get { return quntity; }
            set
            {
                quntity = value;
                OnPropertyChanged();
            }
        }
        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }
        public void Executed_RoomCommand(object obj)
        {
            this.navService.Navigate(
            new Uri("View/DistributEquipment.xaml", UriKind.Relative));

        }
        public RelayCommand DistribuuteRoomCommand { get; set; }

        public bool CanExecuteRoomCommand(object obj)
        {
            return true;
        }
        private ObservableCollection<Room> rooms;
        private ObservableCollection<Equpment>equipments;
        public ObservableCollection<Room> Rooms
        {
            get { return rooms; }
            set
            {
                rooms = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Equpment> Equipment
        {
            get { return equipments; }
            set
            {
                equipments = value;
                OnPropertyChanged();
            }
        }

        public DistributeEquipment(NavigationService navService, Injector inject, Room room, Equpment equpment, string idRoom, string name, int quantity, RelayCommand distribuuteRoomCommand, ObservableCollection<Room> rooms, ObservableCollection<Equpment> equipment)
        {
            this.navService = navService;
            Inject = inject;
            Room = room;
            Equpment = equpment;
            IdRoom = idRoom;
            Name = name;
            Quantity = quantity;
            DistribuuteRoomCommand = distribuuteRoomCommand;
            Rooms = rooms;
            Equipment = equipment;
        }
    }
}
