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
            if (Nalozi.Patients.Any(p=> p.Person.JMBG==jmbg.Text))
            {
                string messageBoxText = "Korisnik sa ovim JMBG već postoji";
                string caption = "Greška";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

            } else
            {
            Patient patient = new Patient(new User (korisnik.Text, lozinka.Text, UserType.patient, new Person(ime.Text,prezime.Text,jmbg.Text, telefon.Text, DateTime.Parse(datum.Text),email.Text,new Address(ulica.Text, broj.Text, new City(grad.Text),new Country(drzava.Text)))),new MedicalRecord(), new AccountStatus(false, true));
                Nalozi.Patients.Add(patient);
                this.Close();
            }
         
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
