using System.Windows;
using System.Windows.Controls;
using SIMS.Controller;
using SIMS.Model;

namespace SIMS.View.Doctor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame frame { get; set; }
        public static User LoggedInUser { get; set; }
        public static Model.Doctor Doctor { get; set; }

        private readonly DoctorController doctorController = new DoctorController();
        public MainWindow()
        {
            InitializeComponent();
            Doctor = doctorController.GetByID(LoggedInUser.Person.JMBG);
            View.Doctor.AllAppointmentsPage allAppointmentsPage = new View.Doctor.AllAppointmentsPage();
            frame = MainFrame;
            frame.Content = allAppointmentsPage;

        }

        private void MenuItem_Click_Zakazi(object sender, RoutedEventArgs e)
        {
            MainWindow.frame.Content = new AddAppointmentPage();
        }

    }
}
