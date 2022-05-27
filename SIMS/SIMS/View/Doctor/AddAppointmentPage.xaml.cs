using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using SIMS.Controller;
using SIMS.Model;

namespace SIMS.View.Doctor
{

    public partial class AddAppointmentPage : Page
    {
        private readonly PatientController patientController = new PatientController();
        private readonly DoctorController doctorController = new DoctorController();
        private List<PatientForAddAppointmentDTO> Patients;
        private List<DoctorForAddAppointmentDTO> Doctors;
        public static Appointment appointment { get; set; }
        public AddAppointmentPage()
        {
            InitializeComponent();
            this.DataContext = this;

            Patients = patientController.GetPatientForAddAppointment();
            Doctors = doctorController.GetDoctorForAddAppointment();
            addAppointmentsPatientDataGrid.ItemsSource = Patients;
            addAppointmentsDoctorDataGrid.ItemsSource = Doctors;

            appointment = new Appointment();
        }

        private void PatientNameAndSurname_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            addAppointmentsPatientDataGrid.ItemsSource = patientController.filterPatients(PatientNameAndSurname_TextBox.Text, Patients);
        }

        private void Button_PotvrdiPacijenta_Click(object sender, RoutedEventArgs e)
        {
            PatientForAddAppointmentDTO pat = addAppointmentsPatientDataGrid.SelectedItem as PatientForAddAppointmentDTO;

            appointment.Patient = patientController.GetOne(pat.PatientId);
        }

        private void Button_PotvrdiDoktora_Click(object sender, RoutedEventArgs e)
        {
            DoctorForAddAppointmentDTO doc = addAppointmentsDoctorDataGrid.SelectedItem as DoctorForAddAppointmentDTO;
            appointment.Doctor = doctorController.GetByID(doc.Id);
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.frame.Content = new AllAppointmentsPage();
        }

        private void Button_Nastavi_Click(object sender, RoutedEventArgs e)
        {
            appointment.DateAndTime = (DateTime)dateOfAppointment.SelectedDate;
            if ((bool)doctorRadioButton.IsChecked)
            {
                //MainWindow.frame.Content = new SelectTimeOfAppointmentPriorityDoctorPage();
            }
            else if ((bool)terminRadioButton.IsChecked)
            { }
        }
    }
}
