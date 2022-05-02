using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        }
    }
}
