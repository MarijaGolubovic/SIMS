using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using SIMS.Model;

namespace SIMS.Pacijent
{
    /// <summary>
    /// Interaction logic for EditAppintment.xaml
    /// </summary>
    public partial class EditAppintment : Window { 

    //u ovu kolekciju treba kasnije ucitati doktore iz fajla
    public static ObservableCollection<Model.Doctor> Doctors { get; set; }
    
        public EditAppintment()
        {
            InitializeComponent();
            this.DataContext = this;

            //Privremeni dumy podaci za listu doktora
            Doctors = new ObservableCollection<Doctor>();

            //Popunjavanje kolekcije dokora
            foreach (Doctor item in DoctorStorage.GetAll())
            {
                Doctors.Add(item);
            }

            DoctorComboBox.SelectedItem = AllAppointments.SelectedItem.Doctor.Username;
            DatePicker.SelectedDate = AllAppointments.SelectedItem.DateAndTime;
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            string selectedDoctor = DoctorComboBox.SelectedItem.ToString();

            //Dumy podaci
            Room room = new Room("1", 5, Model.RoomType.EXAMINATION_ROOM);
            Doctor doctorTmp = DoctorStorage.GetByUsername(selectedDoctor);

            string dateTime = DatePicker.Text;
            DateTime dateTimeTmp = DateTime.Parse(dateTime);

            //pravim objekat Appointment
            Appointment appointment = new Appointment(dateTimeTmp, 1, room, PatientStorage.GetOne("123456789"), doctorTmp);

            //brisem stari i ubacujem novi termin u kolekciju
            AllAppointments.AppointmentsCollceciton.Add(appointment);
            AllAppointments.AppointmentsCollceciton.Remove(AllAppointments.SelectedItem);

            //pozivam serijalizaciju zbog promijena
            Serialization.Serializer<Appointment> appointmentSerializer = new Serialization.Serializer<Appointment>();
            appointmentSerializer.toCSV("appointments.txt", AllAppointments.AppointmentsCollceciton.ToList());

            //zatvaram prozor
            this.Close();

        }
    }
}
