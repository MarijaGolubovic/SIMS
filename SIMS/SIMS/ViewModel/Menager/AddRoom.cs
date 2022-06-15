﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Command;
using SIMS.Model;

namespace SIMS.ViewModel.Menager
{
    class AddRoom : ViewModel
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

        public void Executed_RoomCommand(object obj)
        {
            this.navService.Navigate(
            new Uri("View/AddRoom.xaml", UriKind.Relative));
        }

        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }

        public RelayCommand AddRoomCommand { get; set; }

        public bool CanExecute_RoomCommand(object obj)
        {
            return true;
        }

        public AddRoom(Room room, NavigationService navService, Injector inject,  RelayCommand addRoomCommand)
        {
            this.navService = navService;
            Inject = inject;  
            AddRoomCommand = addRoomCommand;
        }
    }
}
