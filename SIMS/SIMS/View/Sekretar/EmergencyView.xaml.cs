using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.View.Sekretar
{
    /// <summary>
    /// Interaction logic for EmergencyView.xaml
    /// </summary>
    public partial class EmergencyView : Window
    {
        private PatientController patientController;
        private DoctorController doctorController;
        private SpecializationController specializationController;
        private AppointmentController appointmentController;

        public static ObservableCollection<Patient> Patients { get; set; }
        public static ObservableCollection<EmergencyAppointmentsDTO> Appointments { get; set; }

        public static ObservableCollection<Specialization> SpecializationsS { get; set; }

        public EmergencyView()
        {
            InitializeComponent();
            this.DataContext = this;
            appointmentController = new AppointmentController();
            Patients = new ObservableCollection<Patient>();
            Appointments = new ObservableCollection<EmergencyAppointmentsDTO>();
            SpecializationsS = new ObservableCollection<Specialization>();
            patientController = new PatientController();
            doctorController = new DoctorController();
            specializationController = new SpecializationController();
            foreach (Patient p in patientController.GetAllActiv())
            {
                Patients.Add(p);
            }
            pacijentCombobox.ItemsSource = Patients;

            foreach (Specialization s in specializationController.GetAllSpecialist())
            {
                SpecializationsS.Add(s);
            }
            specijalistaCombobox.ItemsSource = SpecializationsS;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<EmergencyAppointmentsDTO> emergencyAppointmentsDTOs = appointmentController.GetEmergencyAppointments(pacijentCombobox.SelectedItem as Patient, specijalistaCombobox.SelectedItem as Specialization);
            if (emergencyAppointmentsDTOs == null)
            {
                string messageBoxText = "Termin za pacijenta " + (pacijentCombobox.SelectedItem as Patient).Username + " je zakazan";
                string caption = "Termin je zakazan";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                this.Close();
            }
            else
            {
                foreach (EmergencyAppointmentsDTO a in emergencyAppointmentsDTOs)
                {
                    Appointments.Add(a);
                }
            }



        }
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            NewPatientView newPatientView = new NewPatientView();
            newPatientView.Show();
        }
        private void IZABERI_Click(object sender, RoutedEventArgs e)
        {
            EmergencyAppointmentsDTO rescheduledAppointment = Termini.SelectedItem as EmergencyAppointmentsDTO;
            appointmentController.ReschedulingAppointments(pacijentCombobox.SelectedItem as Patient, rescheduledAppointment);
            this.Close();
        }
    }
}
