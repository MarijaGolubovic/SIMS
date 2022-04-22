using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace SIMS.Doctor
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public static ObservableCollection<Patient> Patients { get; set; }
        public static ObservableCollection<Model.Doctor> Doctors { get; set; }
        public static ObservableCollection<Model.Room> Rooms { get; set; }

        public Window1()
        {
            InitializeComponent();
            this.DataContext = this;

            Patients = new ObservableCollection<Patient>();
            foreach (Patient p in PatientStorage.GetAll()) { 
                Patients.Add(p);
            }

            Doctors = new ObservableCollection<Model.Doctor>();
            foreach (Model.Doctor doc in Model.DoctorStorage.GetAll()) {
                Doctors.Add(doc);
            }

            Rooms = new ObservableCollection<Room>();
            foreach (Room r in RoomStorage.GetAll()) {
                Rooms.Add(r);
            }
        }

        private void AddApointment(object sender, RoutedEventArgs e)
        {
            var addApointmentWindow = new Doctor.Window1();
            addApointmentWindow.Show();
            this.Close();
        }

        

        private void ShowApointments(object sender, RoutedEventArgs e)
        {
            var allAppointmentsWindow = new AllAppointmentsWindow();
            allAppointmentsWindow.Show();
            this.Close();
        }

        private void addAppointment_Click(object sender, RoutedEventArgs e)
        {

            Patient p = patientComboBox.SelectedItem as Patient;
            Model.Doctor d = doctorComboBox.SelectedItem as Model.Doctor;
            DateTime dt = (DateTime)appointmentDate.SelectedDate;
            Room r = roomComboBox.SelectedItem as Room;
            string time = timeComboBox.SelectedItem as string;
            //string[] t = time.Split(':');
            //dt.AddHours(Double.Parse(t[0]));
            //dt.AddMinutes(Double.Parse(t[1]));
            int id = 5;

            Appointment ap = new Appointment(dt, id, r, p, d);
            AppointmentStorage.Create(ap);
        }
    }
}
