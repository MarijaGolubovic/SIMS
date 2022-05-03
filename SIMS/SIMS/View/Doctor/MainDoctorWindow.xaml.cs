using System.Windows;

namespace SIMS.Doctor
{
    /// <summary>
    /// Interaction logic for MainDoctorWindow.xaml
    /// </summary>
    public partial class MainDoctorWindow : Window
    {
        public MainDoctorWindow()
        {
            InitializeComponent();
        }

        private void AddApointment(object sender, RoutedEventArgs e)
        {
            var addApointmentWindow = new Doctor.Window1();
            addApointmentWindow.Show();
            this.Close();
        }

        private void ShowApointments(object sender, RoutedEventArgs e)
        {
            var allAppointmentsWindow = new AllAppointmentsWindow();
            allAppointmentsWindow.Show();
            this.Close();
        }
    }


}
