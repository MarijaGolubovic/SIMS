using System.Windows;
using System.Windows.Controls;
using SIMS.Controller;
using SIMS.Model;


namespace SIMS.View.Doctor
{
    /// <summary>
    /// Interaction logic for DetailedAppointment.xaml
    /// </summary>
    public partial class DetailedAppointmentPage : Page
    {

        public static Appointment SelectedAppointment { get; set; }
        public string date { get; set; }
        public static MedicalRecord MedicalRecord { get; set; }

        private readonly AppointmentController service = new AppointmentController();
        private readonly MedicalRecordController mediicalRecrodController = new MedicalRecordController();

        public DetailedAppointmentPage()
        {
            InitializeComponent();
            DataContext = this;
            SelectedAppointment = service.GetOne(AllAppointmentsPage.SelectedAppointment.appointmentId);
            date = SelectedAppointment.Patient.Person.DateOfBirth.Date.ToString().Split(' ')[0];
            MedicalRecord = mediicalRecrodController.GetOne(SelectedAppointment.Patient.Person.JMBG);
            Allergy_Combobox.ItemsSource = MedicalRecord.Allergies;
            Therapy_Combobox.ItemsSource = MedicalRecord.therapies;
            Allergy_Combobox.SelectedItem = MedicalRecord.Allergies[0];
            Therapy_Combobox.SelectedItem = MedicalRecord.therapies[0];

        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainWindow.frame.Content = new AllAppointmentsPage();
        }
    }
}
