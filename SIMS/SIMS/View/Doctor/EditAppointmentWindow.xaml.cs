
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using SIMS.Controller;
using SIMS.Model;


namespace SIMS.Doctor
{
    /// <summary>
    /// Interaction logic for EditAppointmentWindow.xaml
    /// </summary>
    public partial class EditAppointmentWindow : Window
    {

        public static ObservableCollection<Patient> Patients { get; set; }
        public static ObservableCollection<Model.Doctor> Doctors { get; set; }
        public static ObservableCollection<Model.Room> Rooms { get; set; }

        private readonly PatientController patientController;
        public static Controller.RoomController roomController = new Controller.RoomController();
        private readonly DoctorController doctorController = new DoctorController();
        public EditAppointmentWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            //dami podaci

            Patients = new ObservableCollection<Patient>();
            foreach (Patient p in patientController.GetAll())
            {
                Patients.Add(p);
            }

            Doctors = new ObservableCollection<Model.Doctor>();
            foreach (Model.Doctor doc in doctorController.GetAll())
            {
                Doctors.Add(doc);
            }

            Rooms = new ObservableCollection<Room>();
            foreach (Room r in roomController.GetAll())
            {
                Rooms.Add(r);
            }

            patientComboBox.SelectedItem = AllAppointmentsWindow.SelectedItem.Patient;
            doctorComboBox.SelectedItem = AllAppointmentsWindow.SelectedItem.Doctor;
            appointmentDate.SelectedDate = AllAppointmentsWindow.SelectedItem.DateAndTime;

        }

        private void AddApointment(object sender, RoutedEventArgs e)
        {
            //var addApointmentWindow = new Doctor.Window1();
            //addApointmentWindow.Show();
            this.Close();
        }

        private void ShowApointments(object sender, RoutedEventArgs e)
        {
            var allAppointmentsWindow = new AllAppointmentsWindow();
            allAppointmentsWindow.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
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

            AllAppointmentsWindow.Appointments.Add(ap);
            AllAppointmentsWindow.Appointments.Remove(AllAppointmentsWindow.SelectedItem);

            Serialization.Serializer<Appointment> appointmentSerializer = new Serialization.Serializer<Appointment>();
            appointmentSerializer.toCSV("appointments.txt", AllAppointmentsWindow.Appointments.ToList());

            this.Close();
        }
    }
}
