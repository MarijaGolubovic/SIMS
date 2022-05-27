using SIMS.Model;
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

namespace SIMS.View.Pacijent
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public User logedInUser;
        public HomePage(User user)
        {
            InitializeComponent();
            logedInUser = user;
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Appointments(logedInUser));
        }

        private void Button_Click_Right(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_Left(object sender, RoutedEventArgs e)
        {

        }
    }
}
