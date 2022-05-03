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

        public static Appointment SelectedItem { get; set; }
        public string date { get; set; }
        public MedicalRecord medicalRecrod { get; set; }

        private readonly AppointmentController service = new AppointmentController();
        private readonly MedicalRecordController mediicalRecrodController = new MedicalRecordController();

        public DetailedAppointmentPage()
        {
            InitializeComponent();
            DataContext = this;
            SelectedItem = service.GetOne(AllAppointmentsPage.SelectedItem.appointmentId);
            date = SelectedItem.Patient.Person.DateOfBirth.Date.ToString().Split(' ')[0];
            medicalRecrod = mediicalRecrodController.GetOne(SelectedItem.Patient.Person.JMBG);
        }
    }
}
