using SIMS.Model;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace SIMS.ViewModel.Doctor
{
    internal class AccountViewModel : BindableBase
    {
        public MyICommand CancelCommand { get; set; }
        public User LoggedInUser { get; set; }
        public String NameAndSurname { get; set; }
        public String Date { get; set; }
        public String Address { get; set; }

        public AccountViewModel()
        {
            LoggedInUser = MainWindowViewModel.LoggedInUser;
            CancelCommand = new MyICommand(OnCancel);
            NameAndSurname = LoggedInUser.Person.Name + " " + LoggedInUser.Person.Surname;
            Date = LoggedInUser.Person.DateOfBirth.ToString().Split(' ')[0];
            Address = LoggedInUser.Person.Address.City.Name + ", " + LoggedInUser.Person.Address.Street + " " + LoggedInUser.Person.Address.Number;
        }

        private void OnCancel()
        {
            Messenger.Default.Send("AllAppointmentView");
        }
    }
}
