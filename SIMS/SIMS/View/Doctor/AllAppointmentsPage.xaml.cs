using SIMS.Controller;
using SIMS.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.View.Doctor
{
    public partial class AllAppointmentsPage : Page
    {
        public List<AppointmentsForDoctorDTO> Appointments { get; set; }
        private AppointmentController appointmentController { get; set; }
        public static AppointmentsForDoctorDTO SelectedItem { get; set; }

        public AllAppointmentsPage()
        {
            InitializeComponent();
            this.DataContext = this;

            appointmentController = new AppointmentController();
            Appointments = appointmentController.GetAppointmentsForDoctor();
        }

        private void Button_Click_Detaljnije(object sender, RoutedEventArgs e)
        {
            if (allAppointmentsDataGrid.SelectedItem as AppointmentsForDoctorDTO == null)
            {
                return;
            }
            SelectedItem = allAppointmentsDataGrid.SelectedItem as AppointmentsForDoctorDTO;
            MainWindow.frame.Content = new DetailedAppointmentPage();
        }

        private void Button_Click_Pristupi(object sender, RoutedEventArgs e)
        {
            if (allAppointmentsDataGrid.SelectedItem as AppointmentsForDoctorDTO == null)
            {
                return;
            }
            SelectedItem = allAppointmentsDataGrid.SelectedItem as AppointmentsForDoctorDTO;
            MainWindow.frame.Content = new JoinAppointmentPage();
        }
    }
}
