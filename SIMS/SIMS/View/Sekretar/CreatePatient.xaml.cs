using System;
using System.Linq;
using System.Windows;
using SIMS.Model;

namespace SIMS.Sekretar
{
    /// <summary>
    /// Interaction logic for CreatePatient.xaml
    /// </summary>
    public partial class CreatePatient : Window
    {
        public CreatePatient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Nalozi.Patients.Any(p => p.Person.JMBG == jmbg.Text))
            {
                string messageBoxText = "Korisnik sa ovim JMBG već postoji";
                string caption = "Greška";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

            }
            else
            {
                User user = new User(korisnik.Text, lozinka.Text, UserType.patient, new Person(ime.Text, prezime.Text, jmbg.Text, telefon.Text, DateTime.Parse(datum.Text), email.Text, new Address(ulica.Text, broj.Text, new City(grad.Text), new Country(drzava.Text))));
                Patient patient = new Patient(user, new MedicalRecord(), new AccountStatus(false, true));
                Nalozi.Patients.Add(patient);
                Nalozi.users.Add(user);
                Serialization.Serializer<User> userSerializer = new Serialization.Serializer<User>();
                userSerializer.toCSV("user.txt", Nalozi.users);
                Serialization.Serializer<Patient> patientSerializer = new Serialization.Serializer<Patient>();
                patientSerializer.toCSV("patients.txt", Nalozi.Patients.Concat(Nalozi.PatientsBlock).ToList());

                this.Close();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
