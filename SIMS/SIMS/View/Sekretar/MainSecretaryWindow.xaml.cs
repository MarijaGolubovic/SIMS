using System.Windows;
using SIMS.ViewModel.Sekretar;

namespace SIMS.View.Sekretar
{
    /// <summary>
    /// Interaction logic for MainSecretaryWindow.xaml
    /// </summary>
    public partial class MainSecretaryWindow : Window
    {
        public MainSecretaryWindowViewModel MainSecretaryWindowView { get; set; }
        public MainSecretaryWindow()
        {
            InitializeComponent();
            this.MainSecretaryWindowView = new MainSecretaryWindowViewModel();
            this.DataContext = this.MainSecretaryWindowView;
        }

    }
}
