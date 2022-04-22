using System.Windows;

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
    }
}
