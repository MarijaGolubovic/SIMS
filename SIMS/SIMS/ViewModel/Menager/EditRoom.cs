using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Command;
using SIMS.Model;

namespace SIMS.ViewModel.Menager
{
    class EditRoom:ViewModel
    {
        private NavigationService navService;
        private Room room;
        private string idRoom;
        private double size;
        private RoomType type;
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

        public string IdRoom
        {
            get { return idRoom; }
            set
            {
                idRoom = value;
                OnPropertyChanged();
            }
        }
        public double Size
        {
            get { return size; }
            set
            {
                size = value;
                OnPropertyChanged();
            }
        }

        public RoomType Type
        {
            get { return type; }
            set
            {
                type= value;
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
            new Uri("View/EditRoom.xaml", UriKind.Relative));

        }
        private ObservableCollection<Room> rooms;
        public RelayCommand EditRoomCommand { get; set; }

        public bool CanExecuteRoomCommand(object obj)
        {
            return true;
        }
        public ObservableCollection<Room> Rooms
        {
            get { return rooms; }
            set
            {
                rooms = value;
                OnPropertyChanged();
            }
        }

        public EditRoom(NavigationService navService, Injector inject, Room room, string idRoom, double size, RoomType type, RelayCommand deleteRoomCommand, ObservableCollection<Room> rooms)
        {
            this.navService = navService;
            Inject = inject;
            Room = room;
            IdRoom = idRoom;
            Size = size;
            Type = type;
            EditRoomCommand = deleteRoomCommand;
            Rooms = rooms;
        }
    }
}
