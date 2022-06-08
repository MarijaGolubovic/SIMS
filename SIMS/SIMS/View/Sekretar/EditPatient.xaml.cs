using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.View.Sekretar
{
    /// <summary>
    /// Interaction logic for EditPatient.xaml
    /// </summary>
    public partial class EditPatient : Window
    {

        Patient selected;
        private PatientController patientController;
        private UserController userController;
        private static CountryController countryController;
        private static CityController cityController;
        public ObservableCollection<Country> Countries { get; set; }
        public ObservableCollection<City> Cities { get; set; }


        public EditPatient(Patient patient)
        {
            InitializeComponent();
            Countries = new ObservableCollection<Country>();
            Cities = new ObservableCollection<City>();
            countryController = new CountryController();
            cityController = new CityController();

            foreach (Country c in countryController.GetAll())
            {
                Countries.Add(c);
            }
            foreach (City c in cityController.GetAll())
            {
                Cities.Add(c);
            }
            countryComboboxE.ItemsSource = Countries;
            cityComboboxE.ItemsSource = Cities;


            userController = new UserController();
            patientController = new PatientController();
            selected = patient;
            imeE.Text = patient.Person.Name;
            prezimeE.Text = patient.Person.Surname;
            datumE.Text = patient.Person.DateOfBirth.ToString();
            jmbgE.Text = patient.Person.JMBG;
            emailE.Text = patient.Person.EMail;
            telefonE.Text = patient.Person.Telephone;
            cityComboboxE.SelectedValue = patient.Person.Address.City.Name;
            countryComboboxE.SelectedValue = patient.Person.Address.Country.Name;
            ulicaE.Text = patient.Person.Address.Street;
            brojE.Text = patient.Person.Address.Number;
            korisnikE.Text = patient.Username;
            lozinkaE.Text = patient.Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User(korisnikE.Text, lozinkaE.Text, UserType.patient, new Person(imeE.Text, prezimeE.Text, jmbgE.Text, telefonE.Text, DateTime.Parse(datumE.Text), emailE.Text, new Address(ulicaE.Text, brojE.Text, cityComboboxE.SelectedItem as City, countryComboboxE.SelectedItem as Country)));
            Patient newPatient = new Patient(newUser, new MedicalRecord(), selected.AccountStatus);

            if (userController.Update(newUser, selected))
            {
                patientController.UpdateJMBG(selected.Person.JMBG, newUser.Person.JMBG);
                AllPatientView.UpdateView();
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
