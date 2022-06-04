using System.Windows;

namespace SIMS.View.DoctorMVVM
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            SIMS.MainWindow mainWindow = new SIMS.MainWindow();
            mainWindow.Show();
        }
    }
}
