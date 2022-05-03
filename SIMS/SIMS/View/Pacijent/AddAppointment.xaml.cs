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

        public event PropertyChangedEventHandler PropertyChanged;

        public AddAppointment()
        {
            InitializeComponent();
            this.DataContext = this;

            Doctors = new ObservableCollection<Model.Doctor>();
            AppointmentsCollceciton = new ObservableCollection<Appointment>();

            //Popunjavanje kolekcije dokora
            foreach (Model.Doctor item in DoctorController.GetAll())
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

            //preuzimanje podataka sa interface-a 
            string dateTime = DatePicker.Text;
            DateTime dateTimeTmp = DateTime.Parse(dateTime);

            //u view mi treba samo ova linija
            //predlozeni termini koje treba prikazati i omoguciti korisniku da neki izabere
            suggestedAppointments = appointmentController.findSuggestedAppointments(doctorTmp, (bool)doctorRadioButton.IsChecked, (bool)appointmentRadioButton.IsChecked, dateTimeTmp);

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
