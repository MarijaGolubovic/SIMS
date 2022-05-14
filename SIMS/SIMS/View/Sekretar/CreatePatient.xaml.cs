using System;
using System.Collections.ObjectModel;
using System.Windows;
using SIMS.Controller;
using SIMS.Model;

namespace SIMS.Sekretar
{
    /// <summary>
    /// Interaction logic for CreatePatient.xaml
    /// </summary>
    public partial class CreatePatient : Window
    {
        private PatientController patientController;
        private UserController userController;
        private static CountryController countryController;
        private static CityController cityController;
        public static ObservableCollection<Country> Countries { get; set; }
        public static ObservableCollection<City> Cities { get; set; }

        public CreatePatient()
        {
            InitializeComponent();
            userController = new UserController();
            patientController = new PatientController();
            countryController = new CountryController();
            cityController = new CityController();
            Countries = new ObservableCollection<Country>();
            Cities = new ObservableCollection<City>();
            foreach (Country c in countryController.GetAll())
            {
                Countries.Add(c);
            }
            foreach (City c in cityController.GetAll())
            {
                Cities.Add(c);
            }
            countryCombobox.ItemsSource = Countries;
            cityCombobox.ItemsSource = Cities;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            User user = new User(korisnik.Text, lozinka.Text, UserType.patient, new Person(ime.Text, prezime.Text, jmbg.Text, telefon.Text, DateTime.Parse(datum.Text), email.Text, new Address(ulica.Text, broj.Text, cityCombobox.SelectedItem as City, countryCombobox.SelectedItem as Country)));
            Patient patient = new Patient(user, new MedicalRecord(), new AccountStatus(false, true));

            if (!userController.Create(user))
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
                patientController.Create(patient);
                Nalozi.UpdateView();
                this.Close();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
