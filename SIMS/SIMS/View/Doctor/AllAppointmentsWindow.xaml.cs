
using System.Collections.ObjectModel;
using System.Windows;
using SIMS.Model;


namespace SIMS.Doctor
{
    /// <summary>
    /// Interaction logic for AllAppointmentsWindow.xaml
    /// </summary>

    public partial class AllAppointmentsWindow : Window
    {
        public static ObservableCollection<Model.Appointment> Appointments { get; set; }

        public static Appointment SelectedItem { get; set; }

        public AllAppointmentsWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            /*Appointments = new ObservableCollection<Model.Appointment>();
            foreach (Appointment a in appointmentStorage.GetAll()) { 
                    Appointments.Add(a);
            }*/
        }

        private void OtkaziPregled(object sender, RoutedEventArgs e)
        {
            Appointment selectedRow = dataGridAllAppointments.SelectedItem as Appointment;
            if (selectedRow != null)
            {
                Appointments.Remove(selectedRow);
            }
        }

        private void AddApointment(object sender, RoutedEventArgs e)
        {
            // var addApointmentWindow = new Doctor.Window1();
            //addApointmentWindow.Show();
            this.Close();
        }

        private void ShowApointments(object sender, RoutedEventArgs e)
        {
            var allAppointmentsWindow = new AllAppointmentsWindow();
            allAppointmentsWindow.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            SelectedItem = dataGridAllAppointments.SelectedItem as Appointment;
            if (SelectedItem != null)
            {
                EditAppointmentWindow editAppintment = new EditAppointmentWindow();
                editAppintment.Show();
            }
        }
    }
}
