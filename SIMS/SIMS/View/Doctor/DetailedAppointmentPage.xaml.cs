using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
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
