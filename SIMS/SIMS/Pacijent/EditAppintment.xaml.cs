using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SIMS.Model;

namespace SIMS.Pacijent
{
    /// <summary>
    /// Interaction logic for EditAppintment.xaml
    /// </summary>
    public partial class EditAppintment : Window
    {

        //u ovu kolekciju treba kasnije ucitati doktore iz fajla
        public static ObservableCollection<Model.Doctor> Doctors { get; set; }

        public EditAppintment()
        {
            InitializeComponent();
            this.DataContext = this;

            //Privremeni dumy podaci za listu doktora
            Doctors = new ObservableCollection<Model.Doctor>();

            //Popunjavanje kolekcije dokora
            foreach (Model.Doctor item in DoctorStorage.GetAll())
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
            Model.Doctor doctorTmp = DoctorStorage.GetByUsername(selectedDoctor);

            string dateTime = DatePicker.Text;
            DateTime dateTimeTmp = DateTime.Parse(dateTime);

            //pravim objekat Appointment
            Appointment appointment = new Appointment(dateTimeTmp, 1, room, PatientStorage.GetRegistrated(), doctorTmp);

            //provjeravam da li je odabrani termin zauzet 
            int control = 0;

            for (int i = 0; i < AllAppointments.AppointmentsCollceciton.Count; i++)
            {
                if (appointment.DateAndTime == AllAppointments.AppointmentsCollceciton[i].DateAndTime)
                {
                    control = 1;
                    MessageBox.Show("Termin je zauzet.");
                    break;
                }
            }
            if (control == 0)
            {
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
}
