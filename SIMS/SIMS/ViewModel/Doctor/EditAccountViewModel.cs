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
using ToastNotifications.Messages;

namespace SIMS.ViewModel.Doctor
{
    internal class EditAccountViewModel : BindableBase
    {
        public MyICommand CancelCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public User LoggedInUser { get; set; }
        public String NameAndSurname { get; set; }
        public String Date { get; set; }
        public String Address { get; set; }


        public EditAccountViewModel()
        {
            LoggedInUser = MainWindowViewModel.LoggedInUser;
            CancelCommand = new MyICommand(OnCancel);
            EditCommand = new MyICommand(OnEdit);
            NameAndSurname = LoggedInUser.Person.Name + " " + LoggedInUser.Person.Surname;
            Date = LoggedInUser.Person.DateOfBirth.ToString().Split(' ')[0];
            Address = LoggedInUser.Person.Address.City.Name + ", " + LoggedInUser.Person.Address.Street + " " + LoggedInUser.Person.Address.Number;
        }

        private void OnCancel()
        {
            Messenger.Default.Send("AllAppointmentView");
        }

        private void OnEdit()
        {
            LoggedInUser.Validate();
            if (LoggedInUser.IsValid)
            {
                Messenger.Default.Send("AccountView");
                MainWindowViewModel.notifier.ShowSuccess("Uspješno!");
            }
        }
    }
}
