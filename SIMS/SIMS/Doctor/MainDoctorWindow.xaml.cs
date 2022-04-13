using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS.Doctor
{
    /// <summary>
    /// Interaction logic for MainDoctorWindow.xaml
    /// </summary>
    public partial class MainDoctorWindow : Window
    {
        public MainDoctorWindow()
        {
            InitializeComponent();
        }

        private void AddApointment(object sender, RoutedEventArgs e)
        {
            var addApointmentWindow = new Doctor.Window1();
            addApointmentWindow.Show();
            this.Close();
        }

        private void ShowApointments(object sender, RoutedEventArgs e)
        {
            var allAppointmentsWindow = new AllAppointmentsWindow();
            allAppointmentsWindow.Show();
            this.Close();
        }
    }


}
