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
using SIMS.Models;

namespace SIMS.Sekretar
{
    /// <summary>
    /// Interaction logic for Nalozi.xaml
    /// </summary>
    public partial class Nalozi : Window
    {

        public static ObservableCollection<Patient> Patients { get; set; }
        public static ObservableCollection<Patient> PatientsBlock { get; set; }
        public Nalozi()
        {
            InitializeComponent();
            this.DataContext = this;

            City city = new City("Novi Sad");
            Country country = new Country("Srbija");
            Address address = new Address("Strazilovska", "15", city, country);
            Person person = new Person("Dejan", "Gloginjic", "123456789", "065087003", DateTime.Parse("10-10-2000"), "deki555@hotmail.com", address);
            User user = new User("dejan", "dejan123", UserType.patient, person);
            AccountStatus accountStatus = new AccountStatus(false, true);
            List<String> ingredians = new List<string> { "sastojak1", "sastojak2" };
            Medicine medicine = new Medicine("bromazepan", ingredians);
            List<Medicine> medicines = new List<Medicine> { medicine };
            MedicalRecord medicalRecord = new MedicalRecord(1.65, 55, "none", BloodType.abNegative, medicines);
            Patient patient = new Patient(user, medicalRecord, accountStatus);

            City city1 = new City("Mrkonjic Grad");
            Country country1 = new Country("BiH");
            Address address1 = new Address("Sportska", "15", city1, country1);
            Person person1 = new Person("Marija", "Mirkovic", "124567893", "065087003", DateTime.Parse("08-08-2000"), "deki555@hotmail.com", address1);
            User user1 = new User("dejan", "dejan123", UserType.patient, person1);
            AccountStatus accountStatus1 = new AccountStatus(false, true);
            List<String> ingredians1 = new List<string> { "sastojak1", "sastojak2" };
            Medicine medicine1 = new Medicine("bromazepan", ingredians1);
            List<Medicine> medicines1 = new List<Medicine> { medicine1 };
            MedicalRecord medicalRecord1 = new MedicalRecord(1.65, 55, "none", BloodType.abNegative, medicines1);
            Patient patient1 = new Patient(user1, medicalRecord1, accountStatus1);

            City city2 = new City("Mrkonjic Grad");
            Country country2 = new Country("BiH");
            Address address2 = new Address("Sportska", "15", city2, country2);
            Person person2 = new Person("Mirko", "Mirkovic", "321654987", "065087003", DateTime.Parse("24-12-2000"), "deki555@hotmail.com", address2);
            User user2 = new User("dejan", "dejan123", UserType.patient, person2);
            AccountStatus accountStatus2 = new AccountStatus(false, true);
            List<String> ingredians2 = new List<string> { "sastojak1", "sastojak2" };
            Medicine medicine2 = new Medicine("bromazepan", ingredians2);
            List<Medicine> medicines2 = new List<Medicine> { medicine2 };
            MedicalRecord medicalRecord2 = new MedicalRecord(1.65, 55, "none", BloodType.abNegative, medicines2);
            Patient patient2 = new Patient(user2, medicalRecord2, accountStatus2);

            ObservableCollection<Patient> patients = new ObservableCollection<Patient>();
            patients.Add(patient);
            patients.Add(patient1);
            patients.Add(patient2);

            Patients = patients;

            City city3 = new City("Novi Sad");
            Country country3 = new Country("Srbija");
            Address address3 = new Address("Strazilovska", "15", city3, country3);
            Person person3 = new Person("Danijela", "Kralus", "123456781", "065087003", DateTime.Parse("02-05-1995"), "daca@hotmail.com", address3);
            User user3 = new User("daca", "daca123", UserType.patient, person3);
            AccountStatus accountStatus3 = new AccountStatus(false, false);
            List<String> ingredians3 = new List<string> { "sastojak1", "sastojak2" };
            Medicine medicine3 = new Medicine("bromazepan", ingredians3);
            List<Medicine> medicines3 = new List<Medicine> { medicine3 };
            MedicalRecord medicalRecord3 = new MedicalRecord(1.65, 55, "none", BloodType.abNegative, medicines3);
            Patient patient3 = new Patient(user3, medicalRecord3, accountStatus3);
            ObservableCollection<Patient> patientsBlock = new ObservableCollection<Patient>();
            patientsBlock.Add(patient3);
            PatientsBlock = patientsBlock;


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
                selectedRow.accountStatus.activatedAccount = false;
                PatientsBlock.Add(selectedRow);
                Patients.Remove(selectedRow);
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
                selectedRow.accountStatus.activatedAccount = true;
                Patients.Add(selectedRow);
                PatientsBlock.Remove(selectedRow);
            }

        }
    }
}
