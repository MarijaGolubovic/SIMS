using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Command;
using SIMS.Model;

namespace SIMS.ViewModel.Menager
{
    class DeleteRoom : ViewModel
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
            new Uri("Views/DeleteRoom.xaml", UriKind.Relative));
            //NavigationCommands.BrowseBack.Execute;
        }
        public RelayCommand DeleteRoomCommand { get; set; }

        public bool CanExecute_RoomCommand(object obj)
        {
            return true;
        }

        public DeleteRoom(NavigationService navService, Injector inject, Room room, RelayCommand deleteRoomCommand)
        {
            this.navService = navService;
            Inject = inject;
            Room = room;
            DeleteRoomCommand = deleteRoomCommand;
        }
    }
}
