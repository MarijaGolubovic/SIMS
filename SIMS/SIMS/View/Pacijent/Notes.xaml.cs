using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.View.Pacijent
{
    /// <summary>
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : Page
    {

        public ObservableCollection<Model.Notificatoin> Notifications { get; set; }
        private readonly NotificationController notificationController = new NotificationController();
        public User logedInUser;
        public Notes(User user)
        {
            InitializeComponent();
            this.DataContext = this;
            logedInUser = user;

            Notifications = new ObservableCollection<Notificatoin>();
            List<Model.Notificatoin> notificationsList = notificationController.GetAllForPatient(logedInUser.Person.JMBG);
            foreach (Notificatoin n in notificationsList)
            {
                Notifications.Add(n);
            }
        }

        private void AddNote(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddNote(logedInUser));
        }
    }
}
