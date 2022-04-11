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
using System.Linq;

namespace SIMS.Pacijent
{
    /// <summary>
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {
        public static ObservableCollection<Model.Doctor> Doctors { get; set; }
        public AddAppointment()
        {
            InitializeComponent();
            this.DataContext = this;

            Doctors = new ObservableCollection<Doctor>();

            //Popunjavanje kolekcije dokora
            foreach(Doctor item in DoctorStorage.GetAll())
            {
                Doctors.Add(item);
            }
            
        }

        private void NewAppointment(object sender, RoutedEventArgs e)
        {
            string selectedDoctor = DoctorComboBox.SelectedItem.ToString();

            //ucitavam listu termina da zna u sta dodaje novi termin
            Serialization.Serializer<Appointment> appointmentSerializer = new Serialization.Serializer<Appointment>();
            List<Appointment> appointments = appointmentSerializer.fromCSV("appointments.txt");

            //inicijalizujem kolekciju
            AllAppointments.AppointmentsCollceciton = new ObservableCollection<Appointment>();

            //ucitavam podatke u kolekciju
            foreach (Appointment item in appointments)
            {
                AllAppointments.AppointmentsCollceciton.Add(item);
            }

            //Dumy podaci 
            //trebaju mi da mogu da napravim objekat Appointment
            //kasnije  cu traziti doktora po jmbg

            Room room = new Room(1, Model.RoomType.EXAMINATION_ROOM, 5);
            Doctor doctorTmp = DoctorStorage.GetByUsername(selectedDoctor);

            string dateTime = DatePicker.Text;
            DateTime dateTimeTmp = DateTime.Parse(dateTime);

            //pravim novi objekat appintment
            Appointment appointment = new Appointment(dateTimeTmp, 1, room, PatientStorage.GetOne("12345"),doctorTmp);

            //dodajem ga u kolekciju
            AllAppointments.AppointmentsCollceciton.Add(appointment);
            
            //pozivam serijalizaciju zbog promijena
            appointmentSerializer.toCSV("appointments.txt",AllAppointments.AppointmentsCollceciton.ToList());

            //zatvaram prozor
            this.Close();
        }
    }
}
