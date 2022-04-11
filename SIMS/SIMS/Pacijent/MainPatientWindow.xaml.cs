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
using System.Windows.Shapes;
using SIMS.Model;

namespace SIMS.Pacijent
{
    /// <summary>
    /// Interaction logic for MainPatientWindow.xaml
    /// </summary>
    public partial class MainPatientWindow : Window
    {
        public MainPatientWindow()
        {
            InitializeComponent();
        }

        private void AddAppointment(object sender, RoutedEventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment();
            addAppointment.Show();
        }

        private void AllAppointments(object sender, RoutedEventArgs e)
        {
            AllAppointments allAppointments = new AllAppointments();
            allAppointments.Show();
        }
    }
}
