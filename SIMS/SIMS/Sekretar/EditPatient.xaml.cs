using System;
using System.Collections.Generic;
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

namespace SIMS.Sekretar
{
    /// <summary>
    /// Interaction logic for EditPatient.xaml
    /// </summary>
    public partial class EditPatient : Window
    {

        Patient selected;

        public EditPatient(Patient patient)
        {
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
            if (jmbgE.Text==selected.Person.JMBG || !Nalozi.Patients.Any(p => p.Person.JMBG == jmbgE.Text))
            {
                if (selected.AccountStatus.activatedAccount)
                {
                Nalozi.Patients.Remove(selected);
                Patient patient = new Patient(new User(korisnikE.Text, lozinkaE.Text, UserType.patient, new Person(imeE.Text, prezimeE.Text, jmbgE.Text, telefonE.Text, DateTime.Parse(datumE.Text), emailE.Text, new Address(ulicaE.Text, brojE.Text, new City(gradE.Text), new Country(drzavaE.Text)))), new MedicalRecord(), selected.AccountStatus);
                Nalozi.Patients.Add(patient);
                } else
                {
                    Nalozi.PatientsBlock.Remove(selected);
                    Patient patient = new Patient(new User(korisnikE.Text, lozinkaE.Text, UserType.patient, new Person(imeE.Text, prezimeE.Text, jmbgE.Text, telefonE.Text, DateTime.Parse(datumE.Text), emailE.Text, new Address(ulicaE.Text, brojE.Text, new City(gradE.Text), new Country(drzavaE.Text)))), new MedicalRecord(), selected.AccountStatus);
                    Nalozi.PatientsBlock.Add(patient);
                }
                
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
