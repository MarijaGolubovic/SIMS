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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for AddPolls.xaml
    /// </summary>
    public partial class AddPolls : Page
    {
        public AddPolls()
        {
            InitializeComponent();
        }

        private void Button_Click_Tutorial(object sender, RoutedEventArgs e)
        {
            
        }


        private void Button_Click_ADD(object sender, RoutedEventArgs e)
        {
            feedbackMessage.Foreground = System.Windows.Media.Brushes.Green;
            Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
            sb.Begin(feedbackMessage);

        }

        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.Menager.Report());
        }
    }
}
