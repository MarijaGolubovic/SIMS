using GalaSoft.MvvmLight.Messaging;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.View.Pacijent
{
    /// <summary>
    /// Interaction logic for EditAppointmentPage.xaml
    /// </summary>
    public partial class EditAppointmentPage : Page
    {
        private Model.Appointment appointment1;
        public static ObservableCollection<Model.Doctor> Doctors { get; set; }
        private readonly DoctorController doctorController = new DoctorController();
        private readonly AppointmentController appointmentController = new AppointmentController();
        private readonly PatientController patientController = new PatientController();
        public static System.Collections.ObjectModel.ObservableCollection<Patient> Patients { get; set; }
        public EditAppointmentPage(Model.Appointment appointment)
        {
            InitializeComponent();
            this.DataContext = this;

            appointment1 = appointment;
            DoctorComboBox.SelectedItem = appointment1.Doctor.Username.ToString();

            Doctors = new ObservableCollection<Model.Doctor>();
            Patients = new ObservableCollection<Model.Patient>();

            Serialization.Serializer<Patient> patientSerializer = new Serialization.Serializer<Patient>();
            List<Patient> patients = patientSerializer.fromCSV("patients.txt");

            foreach (Model.Doctor item in doctorController.GetAll())
            {
                Doctors.Add(item);
            }


            foreach (Patient item in patients)
            {
                Patients.Add(item);
            }

        }

        public DateTime formDateTime()
        {
            string date = DatePicker.Text;
            string time = TimeComboBox.Text;
            string dateTime = date + " " + time;
            DateTime dateTime1 = DateTime.Parse(dateTime);

            return dateTime1;
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            if (appointmentController.CheckIfDateIsValidForEdit(appointment1.DateAndTime, formDateTime()))
            {
                AppointmentForPatientDTO appointmentForPatient = new AppointmentForPatientDTO(DoctorComboBox.SelectedItem as Model.Doctor, formDateTime(), appointment1.Patient, (bool)DoctorPriority.IsChecked);
                if (appointmentController.CheckIfAvailable(appointmentForPatient))
                {
                    Appointment appointment = new Appointment(appointmentForPatient.DateTime, appointmentController.GenerateAppointmentID(), appointmentController.FindRoomForAppointment(appointmentForPatient), patientController.GetOne(appointmentForPatient.User.Person.JMBG), appointmentForPatient.Doctor);
                    _ = appointmentController.Create(appointment, appointmentController.FormRoomOccupacyFromAppointment(appointment));
                    appointmentController.Delete(appointment1.Id, appointmentController.FormRoomOccupacyFromAppointment(appointment1));
                }
                else
                {
                    appointmentController.Delete(appointment1.Id, appointmentController.FormRoomOccupacyFromAppointment(appointment1));
                    NavigationService.Navigate(new SuggestedAppointments(appointmentController.FindSuggestedAppointments(appointmentForPatient)));
                }
                Patient patient = patientController.GetOne(appointment1.Patient.JMBGP);

                foreach (Patient item in Patients)
                {
                    if (item.JMBGP.Equals(appointment1.Patient.JMBGP))
                    {
                        item.OffenceCounter += 1;
                    }
                }

                Serialization.Serializer<Patient> patientSerializer = new Serialization.Serializer<Patient>();
                patientSerializer.toCSV("patients.txt", Patients.ToList());
            }
        }
    }
}
