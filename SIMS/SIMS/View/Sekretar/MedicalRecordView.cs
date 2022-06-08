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
    /// Interaction logic for MedicalRecord.xaml
    /// </summary>
    public partial class MedicalRecordView : Window
    {
        Patient selected;
        private static AllergyController allergyController;
        private static PatientController patientController;
        private static MedicalRecordController medicalRecordController;
        public ObservableCollection<AllergyDTO> Allergies { get; set; }




        public MedicalRecordView(Patient patient)
        {
            InitializeComponent();

            selected = patient;
            Allergies = new ObservableCollection<AllergyDTO>();
            allergyController = new AllergyController();
            patientController = new PatientController();
            medicalRecordController = new MedicalRecordController();
            foreach (AllergyDTO a in patientController.GetAllergies(selected.Person.JMBG))
            {
                Allergies.Add(a);

            }
            this.DataContext = this;
            pacijent.Text = patient.Person.Name + " " + patient.Person.Surname;
            if (medicalRecordController.GetOne(patient.Person.JMBG) == null)
            {
                visina.Text = "";
                tezina.Text = "";

            }
            else
            {
                visina.Text = medicalRecordController.GetOne(patient.Person.JMBG).Height.ToString();
                tezina.Text = medicalRecordController.GetOne(patient.Person.JMBG).Weight.ToString();
            }



            type.ItemsSource = Enum.GetValues(typeof(BloodType));
            if (medicalRecordController.GetOne(patient.Person.JMBG) != null)
            {
                type.SelectedItem = medicalRecordController.GetOne(patient.Person.JMBG).BloodType;
            }


        }

        private void OTKAZI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void IZMENI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var res = (from item in Allergies where item.IsSelected == true select item).ToList<AllergyDTO>();
            medicalRecordController.Update(selected, visina.Text, tezina.Text, res, type.SelectedItem.ToString());
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
