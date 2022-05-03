using SIMS.Model;
using System;
using System.Linq;
using System.Windows;
using SIMS.Controller;
using SIMS.Model;


namespace SIMS.Sekretar
{
    /// <summary>
    /// Interaction logic for EditPatient.xaml
    /// </summary>
    public partial class EditPatient : Window
    {

        Patient selected;
        private PatientController patientController;
        private UserController userController;

        public EditPatient(Patient patient)
        {
            userController = new UserController();
            patientController = new PatientController();
            selected = patient;
            InitializeComponent();
            imeE.Text = patient.Person.Name;
            prezimeE.Text = patient.Person.Surname;
            datumE.Text = patient.Person.DateOfBirth.ToString();
            jmbgE.Text = patient.Person.JMBG;
            emailE.Text = patient.Person.EMail;
            telefonE.Text = patient.Person.Telephone;
            gradE.Text = patient.Person.Address.City.Name;
            drzavaE.Text = patient.Person.Address.Country.Name;
            ulicaE.Text = patient.Person.Address.Street;
            brojE.Text = patient.Person.Address.Number;
            korisnikE.Text = patient.Username;
            lozinkaE.Text = patient.Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           User newUser = new User(korisnikE.Text, lozinkaE.Text, UserType.patient, new Person(imeE.Text, prezimeE.Text, jmbgE.Text, telefonE.Text, DateTime.Parse(datumE.Text), emailE.Text, new Address(ulicaE.Text, brojE.Text, new City(gradE.Text), new Country(drzavaE.Text))));
           Patient newPatient = new Patient(newUser, new MedicalRecord(), selected.AccountStatus);

            if (userController.Update(newUser, selected)) {
                //if (jmbgE.Text == selected.Person.JMBG || !Nalozi.Patients.Any(p => p.Person.JMBG == jmbgE.Text))
                //{
                //    if (selected.AccountStatus.activatedAccount)
                //    {
                //        Nalozi.Patients.Remove(selected);
                //        Nalozi.users.Remove(Nalozi.users.Find(u => u.Person.JMBG.Equals(selected.Person.JMBG)));
                //        User user = new User(korisnikE.Text, lozinkaE.Text, UserType.patient, new Person(imeE.Text, prezimeE.Text, jmbgE.Text, telefonE.Text, DateTime.Parse(datumE.Text), emailE.Text, new Address(ulicaE.Text, brojE.Text, new City(gradE.Text), new Country(drzavaE.Text))));
                //        Patient patient = new Patient(user, new MedicalRecord(), selected.AccountStatus);
                //        Nalozi.Patients.Add(patient);
                //        Nalozi.users.Add(user);
                //    }
                //    else
                //    {
                //        Nalozi.PatientsBlock.Remove(selected);
                //        Nalozi.users.Remove(Nalozi.users.Find(u => u.Person.JMBG.Equals(selected.Person.JMBG)));
                //        User user = new User(korisnikE.Text, lozinkaE.Text, UserType.patient, new Person(imeE.Text, prezimeE.Text, jmbgE.Text, telefonE.Text, DateTime.Parse(datumE.Text), emailE.Text, new Address(ulicaE.Text, brojE.Text, new City(gradE.Text), new Country(drzavaE.Text))));
                //        Patient patient = new Patient(user, new MedicalRecord(), selected.AccountStatus);
                //        Nalozi.PatientsBlock.Add(patient);
                //        Nalozi.users.Add(user);
                //    }
                //    Serialization.Serializer<User> userSerializer = new Serialization.Serializer<User>();
                //    userSerializer.toCSV("user.txt", Nalozi.users);
                //    Serialization.Serializer<Patient> patientSerializer = new Serialization.Serializer<Patient>();
                //    patientSerializer.toCSV("patients.txt", Nalozi.Patients.Concat(Nalozi.PatientsBlock).ToList());
                patientController.UpdateJMBG(selected.Person.JMBG, newUser.Person.JMBG);
                Nalozi.UpdateView();
                this.Close();
            }
            else
            {
                string messageBoxText = "Korisnik sa ovim JMBG već postoji";
                string caption = "Greška";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
