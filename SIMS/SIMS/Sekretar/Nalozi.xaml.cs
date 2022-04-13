using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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

        public static List<User> users;
        public Nalozi()
        {
            InitializeComponent();
            this.DataContext = this;

            Serialization.Serializer<User> userSerializer = new Serialization.Serializer<User>();
            users = userSerializer.fromCSV("user.txt");

            Serialization.Serializer<Patient> patientSerializer = new Serialization.Serializer<Patient>();
            List<Patient> patientSer = patientSerializer.fromCSV("patients.txt");
            Patients = new ObservableCollection<Patient>();
            PatientsBlock = new ObservableCollection<Patient>();


            if (patientSer.ToList().Any())
            {
                foreach (User item in users)
                {
                    foreach (Patient itemP in patientSer)
                    {
                        if (itemP.JMBGP.Equals(item.Person.JMBG))
                        {
                            if (itemP.ActivatedAccount)
                            {
                                Patients.Add(new Patient(item, new MedicalRecord(), new AccountStatus(false, true)));
                            }
                            else
                            {
                                PatientsBlock.Add(new Patient(item, new MedicalRecord(), new AccountStatus(false, false)));
                            }
                        }
                    }
                }
            }

            Patients = Patients;

            PatientsBlock = PatientsBlock;

            userSerializer.toCSV("user.txt", users);
            patientSerializer.toCSV("patients.txt", Nalozi.Patients.Concat(Nalozi.PatientsBlock).ToList());



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
                PatientsBlock.Add(selectedRow);
                Patients.Remove(selectedRow);
                Serialization.Serializer<Patient> patientSerializer = new Serialization.Serializer<Patient>();
                patientSerializer.toCSV("patients.txt", Nalozi.Patients.Concat(Nalozi.PatientsBlock).ToList());

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
                Patients.Add(selectedRow);
                PatientsBlock.Remove(selectedRow);
                Serialization.Serializer<Patient> patientSerializer = new Serialization.Serializer<Patient>();
                patientSerializer.toCSV("patients.txt", Nalozi.Patients.Concat(Nalozi.PatientsBlock).ToList());

            }

        }
    }
}
