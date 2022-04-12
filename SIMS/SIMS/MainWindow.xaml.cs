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

        private void Button_Click_Menager(object sender, RoutedEventArgs e)
        {
            Menager.MainWindowMenager menagerWindow = new Menager.MainWindowMenager();
            menagerWindow.Show();
            this.Close();
        }
    }
}
