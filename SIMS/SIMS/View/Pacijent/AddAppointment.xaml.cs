using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using SIMS.Controller;
using SIMS.Model;

namespace SIMS.Pacijent
{
    /// <summary>
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window, INotifyPropertyChanged
    {
        public static ObservableCollection<Model.Doctor> Doctors { get; set; }
        public ObservableCollection<Model.Appointment> AppointmentsCollceciton { get; set; }

        private readonly PatientController patientController = new PatientController();
        private readonly AppointmentController appointmentController = new AppointmentController();
        private List<Appointment> suggestedAppointments = new List<Appointment>();
        private readonly DoctorController doctorController = new DoctorController();
        public User logedInUser;

        public event PropertyChangedEventHandler PropertyChanged;

        public AddAppointment(User user)
        {
            InitializeComponent();
            this.DataContext = this;

            Doctors = new ObservableCollection<Model.Doctor>();
            AppointmentsCollceciton = new ObservableCollection<Appointment>();
            logedInUser = user;

            //Popunjavanje kolekcije dokora

            foreach (Model.Doctor item in doctorController.GetAll())
            {
                Doctors.Add(item);
            }

            //ucitavam podatke u kolekciju
            foreach (Appointment item in suggestedAppointments)
            {
                AppointmentsCollceciton.Add(item);
            }

        }

        private void NewAppointment(object sender, RoutedEventArgs e)
        { 

            //u view mi treba samo ova linija
            //predlozeni termini koje treba prikazati i omoguciti korisniku da neki izabere
            suggestedAppointments = appointmentController.findSuggestedAppointments(doctorTmp, (bool)doctorRadioButton.IsChecked, (bool)appointmentRadioButton.IsChecked, dateTimeTmp,logedInUser);

            //ucitavam podatke u kolekciju
            foreach (Appointment item in suggestedAppointments)
            {
                AppointmentsCollceciton.Add(item);
            }

            //prpovjeravam da li je pronadjen zeljeni termin

            if (suggestedAppointments.Count == 1)
            {
                //termin je vec kreiran u kontroleru
                //this.Close();
            }
            else
            {
                //trebam korisniku da ispisem predlozene termine
            }

            //ucitavam listu termina da zna u sta dodaje novi termin
            //Serialization.Serializer<Appointment> appointmentSerializer = new Serialization.Serializer<Appointment>();
            //List<Appointment> appointments = appointmentSerializer.fromCSV("appointments.txt");

            //inicijalizujem kolekciju
            //AllAppointments.AppointmentsCollceciton = new ObservableCollection<Appointment>();

            //ucitavam podatke u kolekciju
            //foreach (Appointment item in appointments)
            //{
            //   AllAppointments.AppointmentsCollceciton.Add(item);
            //}

            //zatvaram prozor
            //this.Close();
        }

        private void Confim(object sender, RoutedEventArgs e)
        {
            Appointment selectedRow = dataGridSuggestedAppointments.SelectedItem as Appointment;
            if (selectedRow != null)
            {
                appointmentController.Create(selectedRow);
                this.Close();
            }
        }
    }
}
