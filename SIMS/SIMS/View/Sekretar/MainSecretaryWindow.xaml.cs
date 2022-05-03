using System.Windows;
using SIMS.View.Sekretar;

namespace SIMS.Sekretar
{
    /// <summary>
    /// Interaction logic for MainSecretaryWindow.xaml
    /// </summary>
    public partial class MainSecretaryWindow : Window
    {
        public MainSecretaryWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nalozi nalozi = new Nalozi();
            nalozi.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppointmentView appointmentView = new AppointmentView();
            appointmentView.Show();

        }
    }
}
