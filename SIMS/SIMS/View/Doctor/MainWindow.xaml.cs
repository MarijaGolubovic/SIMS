using System;
using System.Windows;
using System.Windows.Controls;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

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

        private void MenuItem_Click_Zakazi(object sender, RoutedEventArgs e)
        {
            MainWindow.frame.Content = new AddAppointmentPage();
        }

    }
}
