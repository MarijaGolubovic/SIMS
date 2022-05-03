using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using SIMS.Controller;
using SIMS.Model;


namespace SIMS.Sekretar
{
    /// <summary>
    /// Interaction logic for Nalozi.xaml
    /// </summary>
    public partial class Nalozi : Window
    {

        public static ObservableCollection<Patient> Patients { get; set; }
        public static ObservableCollection<Patient> PatientsBlock { get; set; }
        private static PatientController patientController;
        private static UserController userController;
        public static List<User> users;
        public Nalozi()
        {
            InitializeComponent();
            this.DataContext = this;

            Patients = new ObservableCollection<Patient>();
            PatientsBlock = new ObservableCollection<Patient>();
            userController = new UserController();
            patientController = new PatientController();
            UpdateView();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreatePatient createPatient = new CreatePatient();
            createPatient.Show();
        }

        private void IZMENI_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedRow = AktivniNalazi.SelectedItem as Patient;
            EditPatient editPatient = new EditPatient(selectedRow);
            editPatient.Show();
        }

        private void DEAKTIVIRAJ_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedRow = AktivniNalazi.SelectedItem as Patient;
            if (selectedRow != null)
            {
                selectedRow.AccountStatus.activatedAccount = false;
                patientController.Update(selectedRow);
                UpdateView();
            }
        }

        private void VIDI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void IZMENI_Click_1(object sender, RoutedEventArgs e)
        {
            Patient selectedRow = BlokiraniNalozi.SelectedItem as Patient;
            EditPatient editPatient = new EditPatient(selectedRow);
            editPatient.Show();
        }

        private void AKTIVIRAJ_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedRow = BlokiraniNalozi.SelectedItem as Patient;
            if (selectedRow != null)
            {
                selectedRow.AccountStatus.activatedAccount = true;
                patientController.Update(selectedRow);
                UpdateView();
            }

        }

        public static void UpdateView ()
        {
            Patients.Clear();
            PatientsBlock.Clear();
            foreach (Patient p in patientController.GetAllActiv())
            {
                Patients.Add(p);
            }

            foreach (Patient p in patientController.GetAllBlock())
            {
                PatientsBlock.Add(p);
            }
        }
    }
}
