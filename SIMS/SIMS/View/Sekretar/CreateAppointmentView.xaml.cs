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
    /// Interaction logic for CreateAppointmentView.xaml
    /// </summary>
    public partial class CreateAppointmentView : Window
    {

        private PatientController patientController;
        private DoctorController doctorController;
        private SpecializationController specializationController;
        private AppointmentController appointmentController;

        public static ObservableCollection<Patient> Patients { get; set; }
        public static ObservableCollection<Appointment> Appointments { get; set; }

        public static ObservableCollection<SIMS.Model.Doctor> Doctors { get; set; }

        public static ObservableCollection<Specialization> SpecializationsS { get; set; }
        public static ObservableCollection<Specialization> SpecializationsO { get; set; }

        public static CreateAppointmentView instance;

        public CreateAppointmentView()
        {

            InitializeComponent();
            this.DataContext = this;
            instance = this;
            patientController = new PatientController();
            appointmentController = new AppointmentController();
            Patients = new ObservableCollection<Patient>();
            Appointments = new ObservableCollection<Appointment>();
            Doctors = new ObservableCollection<Model.Doctor>();
            SpecializationsS = new ObservableCollection<Specialization>();
            SpecializationsO = new ObservableCollection<Specialization>();

            patientController = new PatientController();
            doctorController = new DoctorController();
            specializationController = new SpecializationController();
            foreach (Patient p in patientController.GetAllActiv())
            {
                Patients.Add(p);
            }
            pacijentCombobox.ItemsSource = Patients;
        }



        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            NewPatientView newPatientView = new NewPatientView();
            newPatientView.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Appointments.Clear();
            foreach (Appointment a in appointmentController.findSuggestedAppointmentsSecretary(lekarCombobox.SelectedItem as SIMS.Model.Doctor, pacijentCombobox.SelectedItem as Patient, DateTime.Parse(datum.Text), true, (bool)operacija.IsChecked))
            {
                Appointments.Add(a);
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IZABERI_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = Termini.SelectedItem as Appointment;
            appointmentController.Create(appointment);
            this.Close();
        }

        private void specijalista_Checked(object sender, RoutedEventArgs e)
        {
            if (specijalista.IsChecked == true)
            {

                foreach (Specialization s in specializationController.GetAllSpecialist())
                {
                    SpecializationsS.Add(s);
                }
                specijalistaCombobox.ItemsSource = SpecializationsS;
            }

        }

        private void opstePrakse_Checked(object sender, RoutedEventArgs e)
        {
            if (opstePrakse.IsChecked == true)
            {

                foreach (Specialization s in specializationController.GetAllOpstePrakse())
                {
                    SpecializationsO.Add(s);
                }
                specijalistaCombobox.ItemsSource = SpecializationsO;
                specijalistaCombobox.SelectedValue = SpecializationsO.First().Name;
                specijalistaCombobox.SelectedItem = SpecializationsO.First();


            }
        }



        private void specijalistaCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Specialization specialization = specijalistaCombobox.SelectedItem as Specialization;

            if (specialization == null)
            {
                specialization = new Specialization("Opste prakse");
            }

            Doctors.Clear();
            foreach (SIMS.Model.Doctor d in doctorController.GetBySpecialization(specialization))
            {
                Doctors.Add(d);
            }

            lekarCombobox.ItemsSource = Doctors;
        }



        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Patients.Clear();
            foreach (Patient p in patientController.GetAllActiv())
            {
                Patients.Add(p);
            }
            pacijentCombobox.ItemsSource = Patients;
            pacijentCombobox.Items.Refresh();

        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Patients.Clear();
            foreach (Patient p in patientController.GetAllActiv())
            {
                Patients.Add(p);
            }
            pacijentCombobox.ItemsSource = Patients;

        }
    }
}

