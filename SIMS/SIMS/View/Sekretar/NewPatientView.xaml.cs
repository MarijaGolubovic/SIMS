using SIMS.Controller;
using SIMS.Model;
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
    /// Interaction logic for NewPatientView.xaml
    /// </summary>
    public partial class NewPatientView : Window
    {
        private PatientController patientController;

        public NewPatientView()
        {
            InitializeComponent();
            patientController = new PatientController();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String name = ime.Text;
            String surname = prezime.Text;
            DateTime dateTime = DateTime.Parse(datum.Text);
            String phoneNumber = telefon.Text;
            String jmbgN = jmbg.Text;
            Patient patient = patientController.CreateNewPatient(new NewPatientDTO(name, surname, dateTime, phoneNumber, jmbgN));
            this.Close();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
