using GalaSoft.MvvmLight.Command;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace SIMS.ViewModel.Menager
{
    class RoomList:ViewModel
    {

        private Room room;
        private NavigationService navService;

        public Injector Inject { get; set; }

        public Room Room
        {
            get { return room; }
            set
            {
                room = value;
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
            new Uri("View/RoomList.xaml", UriKind.Relative));

        }
        public RelayCommand RoomListCommand { get; set; }

        public bool CanExecute_RoomListCommand(object obj)
        {
            return true;
        }

        public RoomList(NavigationService navService, Injector inject, Room room, RelayCommand roomListCommand)
        {
            this.navService = navService;
            Inject = inject;
            Room = room;
            RoomListCommand = roomListCommand;
        }
    }
}
