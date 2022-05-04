using System.Windows.Controls;
using SIMS.Controller;
using SIMS.Model;
using System.Windows;
using System.Windows.Controls;


namespace SIMS.View.Doctor
{
    /// <summary>
    /// Interaction logic for DetailedAppointment.xaml
    /// </summary>
    public partial class DetailedAppointmentPage : Page
    {

        public static Appointment SelectedItem { get; set; }
        public string date { get; set; }
        public static MedicalRecord MedicalRecrod { get; set; }

        private readonly AppointmentController service = new AppointmentController();
        private readonly MedicalRecordController mediicalRecrodController = new MedicalRecordController();

        public DetailedAppointmentPage()
        {
            InitializeComponent();
            DataContext = this;
            SelectedItem = service.GetOne(AllAppointmentsPage.SelectedItem.appointmentId);
            date = SelectedItem.Patient.Person.DateOfBirth.Date.ToString().Split(' ')[0];
            MedicalRecrod = mediicalRecrodController.GetOne(SelectedItem.Patient.Person.JMBG);
            Allergy_Combobox.ItemsSource = MedicalRecrod.Allergies;
            Therapy_Combobox.ItemsSource = MedicalRecrod.therapies;
            Allergy_Combobox.SelectedItem = MedicalRecrod.Allergies[0];
            Therapy_Combobox.SelectedItem = MedicalRecrod.therapies[0];

        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainWindow.frame.Content = new AllAppointmentsPage();
        }
    }
}
