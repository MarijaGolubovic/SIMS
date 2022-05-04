using System.Windows;
using SIMS.Controller;
using SIMS.Model;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserController userController;
        public MainWindow()
        {
            InitializeComponent();
            userController = new UserController();
        }

        private void Button_Click_Patient(object sender, RoutedEventArgs e)
        {
            Pacijent.MainPatientWindow patientWindow = new Pacijent.MainPatientWindow();
            patientWindow.Show();

        }


        private void Button_Click_Secretary(object sender, RoutedEventArgs e)
        {
            Sekretar.MainSecretaryWindow secretaryWindow = new Sekretar.MainSecretaryWindow();
            secretaryWindow.Show();
        }

        private void Button_Click_Menager(object sender, RoutedEventArgs e)
        {
            Menager.MainWindowMenager menagerWindow = new Menager.MainWindowMenager();
            menagerWindow.Show();
            this.Close();
        }

        private void Button_Click_Doctor(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Doctor2(object sender, RoutedEventArgs e)
        {
            View.Doctor.MainWindow doctorWindow = new View.Doctor.MainWindow();
            doctorWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text=="" || Password.Text == "")
            {
                string messageBoxText = "Polja Username i Password su obavezna";
                string caption = "Upozorenje";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            } else
            {
                User user = userController.FindUserByUsername(Username.Text);
                if (user==null)
                {
                    string messageBoxText = "Korisnik sa ovim usernameom ne postoji";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result;
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                } else if (!userController.CheckUserPassword(Username.Text, Password.Text))
                {
                    string messageBoxText = "Pogresan password";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result;
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                } else
                {
                    if (user.Type==UserType.doctor)
                    {
                        SIMS.View.Doctor.MainWindow.LoggedInUser = user;
                        View.Doctor.MainWindow doctorWindow = new View.Doctor.MainWindow();
                        doctorWindow.Show();
                        this.Close();
                    }

                    if (user.Type == UserType.patient)
                    {
                        Pacijent.MainPatientWindow patientWindow = new Pacijent.MainPatientWindow();
                        patientWindow.Show();
                    }

                    if (user.Type == UserType.menager)
                    {
                        Menager.MainWindowMenager menagerWindow = new Menager.MainWindowMenager();
                        menagerWindow.Show();
                        this.Close();
                    }
                    if (user.Type == UserType.secretary)
                    {
                        Sekretar.MainSecretaryWindow secretaryWindow = new Sekretar.MainSecretaryWindow();
                        secretaryWindow.Show();
                    }



                }
            }
        }
    }
}
