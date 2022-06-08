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
    /// Interaction logic for AddNote.xaml
    /// </summary>
    public partial class AddNote : Page
    {
        public User logedInUser { get; set; }
        private readonly PatientController patientController = new PatientController();
        private readonly NotificationController notificationController = new NotificationController();
        public AddNote(Model.User logedInUser)
        {
            InitializeComponent();
            this.logedInUser = logedInUser;
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            String text = Text.Text;
            String date = DatePicker.ToString();
            String time = TimePicker.Value.ToString();
            string dateTime = date.Split(' ')[0] + " " + time.Split(' ')[1];
            DateTime dateTime1 = DateTime.Parse(dateTime);

            Notificatoin notificatoin = new Notificatoin(dateTime1, text, patientController.GetOne(logedInUser.Person.JMBG));
            notificationController.Create(notificatoin);

        }
    }
}
