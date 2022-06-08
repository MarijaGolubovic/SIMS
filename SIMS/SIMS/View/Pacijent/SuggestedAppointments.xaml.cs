using SIMS.Controller;
using SIMS.Model;
using System.Collections.Generic;
using System;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows;

namespace SIMS.View.Pacijent
{
    /// <summary>
    /// Interaction logic for SuggestedAppointments.xaml
    /// </summary>
    public partial class SuggestedAppointments : Page
    {
        public static ObservableCollection<Model.Appointment> Appointments { get; set; }
        private readonly AppointmentController appointmentController = new AppointmentController();
        public static Model.Appointment SelectedItem { get; set; }
        public SuggestedAppointments(List<Appointment> appointments)
        {
            InitializeComponent();
            this.DataContext = this;
            SelectedItem = null;

            Appointments = new ObservableCollection<Appointment>();

            foreach (Appointment a in appointments)
            {
                Appointments.Add(a);
            }
        }

        private void Confirm_Click_1(object sender, RoutedEventArgs e)
        {
            Appointment selectedRow = dataGridSuggestedAppointment.SelectedItem as Appointment;
            appointmentController.Create(selectedRow, appointmentController.FormRoomOccupacyFromAppointment(selectedRow));
        }
    }
}
