using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SIMS.Model;

namespace SIMS.Pacijent
{
    /// <summary>
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {
        public static ObservableCollection<Model.Doctor> Doctors { get; set; }
        public int counter;
        public AddAppointment()
        {
            InitializeComponent();
            this.DataContext = this;

            Doctors = new ObservableCollection<Model.Doctor>();

            //Popunjavanje kolekcije dokora
            foreach(Model.Doctor item in DoctorStorage.GetAll())
            {
                Doctors.Add(item);
            }
            counter++;

        }

        private void NewAppointment(object sender, RoutedEventArgs e)
        {
            //string selectedDoctor = DoctorComboBox.SelectedItem.ToString();

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

            Room room = new Room(counter.ToString(), 5, Model.RoomType.EXAMINATION_ROOM);

            //dobavljanje doktora prema indeksu izabranog item-a iz comboBox-a

            string jmbg = "";

            int index = DoctorComboBox.SelectedIndex;
            if (index == 0)
            {
                jmbg = "2408000103256";
            }
            else if (index == 1)
            {
                jmbg = "2408010103256";
            }
            else if (index == 2)
            {
                jmbg = "2408010103156";
            }
            else if(index == 3)
            {
                jmbg = "2108010103158";
            }

            Model.Doctor doctorTmp = DoctorStorage.GetByID(jmbg);

            string dateTime = DatePicker.Text;
            DateTime dateTimeTmp = DateTime.Parse(dateTime);

            //pravim novi objekat appintment
            Appointment appointment = new Appointment(dateTimeTmp, counter, room, PatientStorage.GetRegistrated(), doctorTmp);

            int control = 0;
            //provjeravam da li je odabrani termin zauzet 
            /*for (int i = 0; i < AllAppointments.AppointmentsCollceciton.Count; i++)
            {
                if (appointment.DateAndTime == AllAppointments.AppointmentsCollceciton[i].DateAndTime)
                {
                    control = 1;
                    MessageBox.Show("Termin je zauzet.");
                    break;
                }
            }*/
            if (control == 0)
            {
                //dodajem ga u kolekciju
                AllAppointments.AppointmentsCollceciton.Add(appointment);
                //AllAppointments.AppointmentsCollceciton2.Add(appointment);

                //pozivam serijalizaciju zbog promijena
                appointmentSerializer.toCSV("appointments.txt", AllAppointments.AppointmentsCollceciton.ToList());

                //zatvaram prozor
                this.Close();

            }

        }
    }
}
