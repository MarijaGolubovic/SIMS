using System.Windows;
using System.Windows.Controls;

namespace SIMS.View.Doctor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame frame { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            View.Doctor.AllAppointmentsPage allAppointmentsPage = new View.Doctor.AllAppointmentsPage();
            frame = MainFrame;
            frame.Content = allAppointmentsPage;

        }

    }
}
