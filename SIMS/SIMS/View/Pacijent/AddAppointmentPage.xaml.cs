using SIMS.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SIMS.Model;

namespace SIMS.View.Pacijent
{
    /// <summary>
    /// Interaction logic for AddAppointmentPage.xaml
    /// </summary>
    public partial class AddAppointmentPage : Page, INotifyPropertyChanged
    {
        public static ObservableCollection<Model.Doctor> Doctors { get; set; }
        private readonly DoctorController doctorController = new DoctorController();
        private readonly AppointmentController appointmentController = new AppointmentController();
        private readonly PatientController patientController = new PatientController();
        private static ObservableCollection<String> Time { get; set; }
        public static User logedInUser;
        public AddAppointmentPage(User user)
        {
            InitializeComponent();
            this.DataContext = this;

            Doctors = new ObservableCollection<Model.Doctor>();

            foreach (Model.Doctor item in doctorController.GetAll())
            {
                Doctors.Add(item);
            }

            logedInUser = user;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime formDateTime()
        {
            string date = DatePicker.Text;
            string time = TimeComboBox.Text;
            string dateTime = date + " " + time;
            DateTime dateTime1 = DateTime.Parse(dateTime);

            return dateTime1;
        }

        public bool checkIfFilled()
        {
            bool filled = true;

            if (DoctorComboBox.SelectedItem == null)
            {
                DoctorLabel.Visibility = Visibility.Visible;
                filled = false;
            }
            if (DatePicker.SelectedDate == null)
            {
                DateLabel.Visibility = Visibility.Visible;
                filled = false;
            }
            if (TimeComboBox.SelectedItem == null)
            {
                TimeLabel.Visibility = Visibility.Visible;
                filled = false;
            }
            if (DoctorPriority.IsChecked == false && DatePriority.IsChecked == false)
            {
                PriorityrLabel.Visibility = Visibility.Visible;
                filled = false;
            }

            return filled;
        }

        public void Confirm(object sender, RoutedEventArgs e)
        {
            if (checkIfFilled() && appointmentController.CheckIfDateIsValid(formDateTime()))
            {
                AppointmentForPatientDTO appointmentForPatient = new AppointmentForPatientDTO(DoctorComboBox.SelectedItem as Model.Doctor, formDateTime(), logedInUser, (bool)DoctorPriority.IsChecked);
                if (appointmentController.CheckIfAvailable(appointmentForPatient))
                {
                    Appointment appointment = new Appointment(appointmentForPatient.DateTime, appointmentController.GenerateAppointmentID(), appointmentController.FindRoomForAppointment(appointmentForPatient), patientController.GetOne(appointmentForPatient.User.Person.JMBG), appointmentForPatient.Doctor);
                    _ = appointmentController.Create(appointment, appointmentController.FormRoomOccupacyFromAppointment(appointment));
                    CheckIcon.Visibility = Visibility.Visible;
                }
                else
                {
                    NavigationService.Navigate(new SuggestedAppointments(appointmentController.FindSuggestedAppointments(appointmentForPatient)));
                }
            }
        }

        private void DoctorComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (DoctorComboBox.SelectedItem == null)
            {
                DoctorLabel.Visibility = Visibility.Visible;
            }
            else
            {
                DoctorLabel.Visibility = Visibility.Hidden;
            }
        }

        private void DatePicker_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DatePicker.SelectedDate == null)
            {
                DateLabel.Visibility = Visibility.Visible;
            }
        }

        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (DatePicker.SelectedDate != null)
            {
                if (DateTime.Compare((DateTime)DatePicker.SelectedDate,DateTime.Now) < 0)
                {
                    DateLabel.Text = "Odaberite datum u buducnosti!";
                    DateLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    DateLabel.Text = "Odaberite datum!";
                    DateLabel.Visibility = Visibility.Hidden;
                }
            }
        }

        private void TimeComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (TimeComboBox.SelectedItem == null)
            {
                TimeLabel.Visibility = Visibility.Visible;
            }
            else
            {
                TimeLabel.Visibility = Visibility.Hidden;
            }
        }

        private void DoctorPriority_Checked(object sender, RoutedEventArgs e)
        {
            PriorityrLabel.Visibility = Visibility.Hidden;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Appointments(logedInUser));
        }
    }
}
