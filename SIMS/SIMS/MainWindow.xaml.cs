using System.Windows;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
