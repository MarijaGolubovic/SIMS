using System;
using System.Windows.Controls;
using SIMS.Controller;
using SIMS.Model;

namespace SIMS.View.Doctor
{

    public partial class JoinAppointmentPage : Page
    {

        public static Appointment SelectedItem { get; set; }
        public static MedicalRecord MedicalRecrod { get; set; }

        private readonly AppointmentController appointmentController = new AppointmentController();
        private readonly MedicalRecordController mediicalRecrodController = new MedicalRecordController();
        private readonly DiagnosisController diagnosisController = new DiagnosisController();

        public JoinAppointmentPage()
        {
            InitializeComponent();
            DataContext = this;
            SelectedItem = appointmentController.GetOne(AllAppointmentsPage.SelectedAppointment.appointmentId);
            MedicalRecrod = mediicalRecrodController.GetOne(SelectedItem.Patient.Person.JMBG);
            AllergyComboBox.ItemsSource = MedicalRecrod.Allergies;
            AllergyComboBox.SelectedItem = MedicalRecrod.Allergies[0];
            Therapy_Combobox.ItemsSource = MedicalRecrod.therapies;
            Therapy_Combobox.SelectedItem = MedicalRecrod.therapies[0];
        }

        private void Button_Click_Uput(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Button_Click_Terapija(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.frame.Content = new AddTherapyPage();
        }

        private void Button_Click_Opravdanje(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Button_Click_Zavrsi(object sender, System.Windows.RoutedEventArgs e)
        {
            appointmentController.Delete(SelectedItem.Id);
            Diagnosis d = new Diagnosis(Diagnosis_TextBox.Text, SelectedItem.DateAndTime, SelectedItem.Id, SelectedItem.Room, SelectedItem.Patient, SelectedItem.Doctor);
            diagnosisController.Create(d);
            MainWindow.frame.Content = new AllAppointmentsPage();
        }

        private void Button_Click_Nazad(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.frame.Content = new AllAppointmentsPage();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void setButtonVisibility()
        {
            if (Diagnosis_TextBox.Text != String.Empty)
            {
                Button_Zavrsi.IsEnabled = true;
            }
            else
            {
                Button_Zavrsi.IsEnabled = false;
            }
        }
    }
}
