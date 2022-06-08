using SIMS.Controller;
using SIMS.Model;
using System.Collections.Generic;
using System;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;

namespace SIMS.View.Sekretar
{
    /// <summary>
    /// Interaction logic for Nalozi.xaml
    /// </summary>
    public partial class AllPatientView : Window
    {

        public static ObservableCollection<Patient> Patients { get; set; }
        public static ObservableCollection<Patient> PatientsBlock { get; set; }
        private static PatientController patientController;
        private static UserController userController;
        public static List<User> users;
        public AllPatientView()
        {
            InitializeComponent();
            this.DataContext = this;

            Patients = new ObservableCollection<Patient>();
            PatientsBlock = new ObservableCollection<Patient>();
            userController = new UserController();
            patientController = new PatientController();

            foreach (Patient p in patientController.GetAllActiv())
            {
                Patients.Add(p);
            }


            foreach (Patient p in patientController.GetAllBlock())
            {
                PatientsBlock.Add(p);
            }



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
                selectedRow.AccountStatus.activatedAccount = false;
                patientController.Update(selectedRow);
                UpdateView();
            }
        }
        private void VIDI_Click_1(object sender, RoutedEventArgs e)
        {
            Patient selectedRow = AktivniNalazi.SelectedItem as Patient;
            MedicalRecordView medicalRecordView = new MedicalRecordView(selectedRow);
            medicalRecordView.Show();

        }
        private void VIDI_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedRow = BlokiraniNalozi.SelectedItem as Patient;
            MedicalRecordView medicalRecordView = new MedicalRecordView(selectedRow);
            medicalRecordView.Show();

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
                selectedRow.AccountStatus.activatedAccount = true;
                patientController.Update(selectedRow);
                UpdateView();
            }

        }

        public static void UpdateView()
        {
            Patients.Clear();
            PatientsBlock.Clear();
            foreach (Patient p in patientController.GetAllActiv())
            {
                Patients.Add(p);
            }

            foreach (Patient p in patientController.GetAllBlock())
            {
                PatientsBlock.Add(p);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void SearchActiv_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var tbx = sender as TextBox;
            if (tbx.Text != "")
            {
                var filteredList = patientController.GetAllActiv().Where(x => x.Username.ToLower().Contains(tbx.Text.ToLower()));
                //AktivniNalazi.ItemsSource = null;
                //AktivniNalazi.ItemsSource = filteredList;
                Patients.Clear();
                PatientsBlock.Clear();
                foreach (Patient p in filteredList)
                {
                    Patients.Add(p);
                }

                foreach (Patient p in patientController.GetAllBlock())
                {
                    PatientsBlock.Add(p);
                }
            }
            else
            {
                UpdateView();
                //AktivniNalazi.ItemsSource = patientActivList;
            }


        }

        private void searchBlocks_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tbx = sender as TextBox;
            if (tbx.Text != "")
            {
                var filteredList = patientController.GetAllBlock().Where(x => x.Username.ToLower().Contains(tbx.Text.ToLower()));
                Patients.Clear();
                PatientsBlock.Clear();
                foreach (Patient p in filteredList)
                {
                    PatientsBlock.Add(p);
                }

                foreach (Patient p in patientController.GetAllActiv())
                {
                    Patients.Add(p);
                }
            }
            else
            {
                UpdateView();
                //AktivniNalazi.ItemsSource = patientActivList;
            }

        }
    }
}
