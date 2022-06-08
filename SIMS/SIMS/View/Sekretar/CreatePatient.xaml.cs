using SIMS.Controller;
using SIMS.Model;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System;

namespace SIMS.View.Sekretar
{
    /// <summary>
    /// Interaction logic for CreatePatient.xaml
    /// </summary>
    public partial class CreatePatient : Window, INotifyPropertyChanged
    {
        private PatientController patientController;
        private UserController userController;
        private static CountryController countryController;
        private static CityController cityController;
        public static ObservableCollection<Country> Countries { get; set; }
        public static ObservableCollection<City> Cities { get; set; }




        public event PropertyChangedEventHandler PropertyChanged;



        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public CreatePatient()
        {
            InitializeComponent();
            this.DataContext = this;
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
                AllPatientView.UpdateView();
                this.Close();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }

        private string _dateTime;
        public string DateTimeP
        {
            get { return _dateTime; }
            set
            {
                _dateTime = value;
                OnPropertyChanged("DateTimeP");
            }
        }

        private string _jmbg;
        public string JMBG
        {
            get { return _jmbg; }
            set
            {
                _jmbg = value;
                OnPropertyChanged("JMBG");
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _street;
        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged("Street");
            }
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        private string _passsword;
        public string Password
        {
            get { return _passsword; }
            set
            {
                _passsword = value;
                OnPropertyChanged("Password");
            }
        }
    }
}
