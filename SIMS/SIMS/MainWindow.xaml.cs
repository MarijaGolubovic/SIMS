using SIMS.Controller;
using SIMS.Model;
using SIMS.View.Sekretar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserController userController;
        private PatientController patientController;
        public MainWindow()
        {
            InitializeComponent();
            userController = new UserController();
            patientController = new PatientController();
        }


        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text == "" || Password.Text == "")
            {
                string messageBoxText = "Polja Username i Password su obavezna";
                string caption = "Upozorenje";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else
            {
                User user = userController.FindUserByUsername(Username.Text);
                if (user == null)
                {
                    string messageBoxText = "Korisnik sa ovim usernameom ne postoji";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result;
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                }
                else if (!userController.CheckUserPassword(Username.Text, Password.Text))
                {
                    string messageBoxText = "Pogresan password";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result;
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                }
                else
                {
                    if (user.Type == UserType.doctor)
                    {
                        ViewModel.Doctor.MainWindowViewModel.LoggedInUser = user;
                        View.DoctorMVVM.MainWindow doctorWindow = new View.DoctorMVVM.MainWindow();
                        doctorWindow.Show();
                        this.Close();
                    }

                    if (user.Type == UserType.patient)
                    {
                        Patient patient = patientController.GetOne(user.Person.JMBG);
                        if (patient.OffenceCounter < 5)
                        {
                            Pacijent.MainPatientWindow patientWindow = new Pacijent.MainPatientWindow(user);
                            patientWindow.Show();
                        }
                        else
                        {
                            patientController.UpdatePatient(patient);
                            string messageBoxText = "Vas profil je blokiran!";
                            string caption = "Greska";
                            MessageBoxButton button = MessageBoxButton.OK;
                            MessageBoxImage icon = MessageBoxImage.Warning;
                            MessageBoxResult result;
                            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                        }
                    }

                    if (user.Type == UserType.menager)
                    {
                        Menager.MainWindowMenager menagerWindow = new Menager.MainWindowMenager();
                        menagerWindow.Show();
                        this.Close();
                    }
                    if (user.Type == UserType.secretary)
                    {
                        MainSecretaryWindow secretaryWindow = new MainSecretaryWindow();
                        secretaryWindow.Show();
                    }



                }
            }
        }

      
    }
}
