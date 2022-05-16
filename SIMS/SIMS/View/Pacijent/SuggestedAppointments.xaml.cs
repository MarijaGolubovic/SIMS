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
            appointmentController.Create(selectedRow,appointmentController.FormRoomOccupacyFromAppointment(selectedRow));
        }
    }
}
