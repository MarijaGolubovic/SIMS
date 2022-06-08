using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace SIMS.View.Pacijent
{
    /// <summary>
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Page
    {
        public static ObservableCollection<Model.Appointment> AppointmentHistory { get; set; }
        public static ObservableCollection<Model.Appointment> AppointmentFuture { get; set; }
        public static ObservableCollection<Model.Appointment> AppointmentCollection { get; set; }
        public static ObservableCollection<Patient> Patients { get; set; }

        private readonly PatientController patientController = new PatientController();
        public static Appointment SelectedItem { get; set; }

        public User logedInUser;
        public Appointments(User user)
        {
            InitializeComponent();
            this.DataContext = this;
            SelectedItem = null;
            logedInUser = user;


            Serialization.Serializer<Appointment> appointmentSerializer = new Serialization.Serializer<Appointment>();
            Serialization.Serializer<Patient> patientSerializer = new Serialization.Serializer<Patient>();

            //ucitavam termine iz fajla
            List<Appointment> appointments = appointmentSerializer.fromCSV("appointments.txt");
            List<Patient> patients = patientSerializer.fromCSV("patients.txt");

            //inicijalizujem kolekciju
            AppointmentHistory = new ObservableCollection<Appointment>();
            AppointmentFuture = new ObservableCollection<Appointment>();
            AppointmentCollection = new ObservableCollection<Appointment>();
            Patients = new ObservableCollection<Patient>();

            //ucitavam podatke u kolekciju
            foreach (var item in appointments)
            {
                if (item.Patient.JMBGP.Equals(logedInUser.Person.JMBG))
                {
                    DateTime date = DateTime.UtcNow;
                    if (DateTime.Compare(date, item.DateAndTime) < 0)
                    {
                        //termin u buducnosti
                        AppointmentFuture.Add(item);
                    }
                    else
                    {
                        AppointmentHistory.Add(item);
                    }
                }
            }

            //ucitavam podatke u kolekciju
            foreach (Appointment item in appointments)
            {
                AppointmentCollection.Add(item);
            }

            foreach (Patient item in patients)
            {
                Patients.Add(item);
            }
        }

        private void AddAppointment(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAppointmentPage(logedInUser));
        }

        private void CancelAppointment(object sender, RoutedEventArgs e)
        {
            Appointment selectedRow = dataGridAppointmentFuture.SelectedItem as Appointment;
            if (selectedRow != null)
            {
                AppointmentFuture.Remove(selectedRow);
                AppointmentCollection.Remove(selectedRow);
                Serialization.Serializer<Appointment> appointmentSerializer = new Serialization.Serializer<Appointment>();
                appointmentSerializer.toCSV("appointments.txt", Appointments.AppointmentCollection.ToList());

                Patient patient = patientController.GetOne(logedInUser.Person.JMBG);

                foreach (Patient item in Patients)
                {
                    if (item.JMBGP.Equals(logedInUser.Person.JMBG))
                    {
                        item.OffenceCounter += 1;
                        if (item.OffenceCounter >= 5)
                        {
                            patientController.UpdatePatient(item);

                            //ovo ne ugasi prozor
                            //System.Net.Mime.MediaTypeNames.Application.Exit();
                        }
                    }
                }

                Serialization.Serializer<Patient> patientSerializer = new Serialization.Serializer<Patient>();
                patientSerializer.toCSV("patients.txt", Patients.ToList());
            }

        }

        private void EditAppointment(object sender, RoutedEventArgs e)
        {
            SelectedItem = dataGridAppointmentFuture.SelectedItem as Appointment;
            if (SelectedItem != null)
            {
                NavigationService.Navigate(new EditAppointmentPage(SelectedItem));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedItem = dataGridAppointmentHistory.SelectedItem as Appointment;
            if (SelectedItem != null)
            {
                NavigationService.Navigate(new DetailsAppointmentPage(SelectedItem));
            }
        }
    }
}
