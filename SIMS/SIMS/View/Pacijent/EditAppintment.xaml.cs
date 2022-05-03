using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SIMS.Controller;
using SIMS.Model;
using Tulpep.NotificationWindow;

namespace SIMS.Pacijent
{
    /// <summary>
    /// Interaction logic for EditAppintment.xaml
    /// </summary>
    public partial class EditAppintment : Window
    {

        
        public static ObservableCollection<Model.Doctor> Doctors { get; set; }

        private readonly PatientController patientController = new PatientController();

        public EditAppintment()
        {
            InitializeComponent();
            this.DataContext = this;
            
            Doctors = new ObservableCollection<Model.Doctor>();

            //Popunjavanje kolekcije dokora iz fajla
            foreach (Model.Doctor item in DoctorController.GetAll())
            {
                Doctors.Add(item);
            }

            //inicijalizujem vrijednosti u formi
            DoctorComboBox.SelectedItem = AllAppointments.SelectedItem.Doctor.Username;
            DatePicker.SelectedDate = AllAppointments.SelectedItem.DateAndTime;
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            string selectedDoctor = DoctorComboBox.SelectedItem.ToString();

            //Dumy podaci
            Room room = new Room("1", 5, Model.RoomType.EXAMINATION_ROOM);

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
            else if (index == 3)
            {
                jmbg = "2108010103158";
            }

            Model.Doctor doctorTmp = DoctorController.GetByID(jmbg);

            //poredim stari datum sa novim zeljenim datumom
            DateTime dateTimeOld = AllAppointments.SelectedItem.DateAndTime;  //stari datum
            string dateTime = DatePicker.Text;                                //novi datum
            DateTime dateTimeNew = DateTime.Parse(dateTime);

            double dateDiference = (dateTimeNew - dateTimeOld).TotalDays;

            if (dateDiference < 10)
            {
                //pravim objekat Appointment
                Appointment appointment = new Appointment(dateTimeNew, 1, room, patientController.GetOne("2408010222156"), doctorTmp); ;

                //brisem stari i ubacujem novi termin u kolekciju
                AllAppointments.AppointmentsCollceciton.Add(appointment);
                AllAppointments.AppointmentsCollceciton.Remove(AllAppointments.SelectedItem);

                //pozivam serijalizaciju zbog promijena
                Serialization.Serializer<Appointment> appointmentSerializer = new Serialization.Serializer<Appointment>();
                appointmentSerializer.toCSV("appointments.txt", AllAppointments.AppointmentsCollceciton.ToList());

                //zatvaram prozor

                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Obavestenje!";
                popup.Popup();
                this.Close();
            }

        }
    }
}
