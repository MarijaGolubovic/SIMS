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
    
    public partial class AddAppointmentPage : Page
    {
        private readonly PatientController patientController = new PatientController();
        private readonly DoctorController doctorController = new DoctorController();
        private List<PatientForAddAppointmentDTO> Patients;
        private List<DoctorForAddAppointmentDTO> Doctors;
        public AddAppointmentPage()
        {
            InitializeComponent();
            this.DataContext = this;

            Patients = patientController.GetPatientForAddAppointment();
            Doctors = doctorController.GetDoctorForAddAppointment();
            addAppointmentsPatientDataGrid.ItemsSource = Patients;
            addAppointmentsDoctorDataGrid.ItemsSource = Doctors;
        }

        private void PatientNameAndSurname_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            addAppointmentsPatientDataGrid.ItemsSource = patientController.filterPatients(PatientNameAndSurname_TextBox.Text, Patients);
        }
    }
}
