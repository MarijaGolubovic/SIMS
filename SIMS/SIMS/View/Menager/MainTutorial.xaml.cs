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

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for MainTutorial.xaml
    /// </summary>
    public partial class MainTutorial : Page
    {
        public static Frame frame { get; set; }
        public static Frame _mainTutorial;
        public MainTutorial()
        {
            InitializeComponent();
            _mainTutorial = this.FindName("MainTutorialFrame") as Frame;
            _mainTutorial.NavigationService.Navigate(new TutorialVideo());
        }

        private void Button_Click_TutorialADD(object sender, RoutedEventArgs e)
        {
            _mainTutorial.NavigationService.Navigate(new Tutorials.AddRoomTutorial());
        }

        private void Button_Click_DELETE(object sender, RoutedEventArgs e)
        {
           _mainTutorial.NavigationService.Navigate(new Tutorials.DelateRoomTutorial());
        }

        private void Button_Click_EDIT(object sender, RoutedEventArgs e)
        {
            _mainTutorial.NavigationService.Navigate(new Tutorials.UpdateRoomTutorial());
        }

        private void Button_Click_RENOVATE(object sender, RoutedEventArgs e)
        {
            _mainTutorial.NavigationService.Navigate(new Tutorials.RenovateRoomTutorial());
        }

        private void Button_Click_ADD_MEDICINE(object sender, RoutedEventArgs e)
        {
            _mainTutorial.NavigationService.Navigate(new Tutorials.AddMedicineTutorial());
        }

        private void Button_Click_UPDATE_MEDICINE(object sender, RoutedEventArgs e)
        {
            _mainTutorial.NavigationService.Navigate(new Tutorials.UpdateMedicineTutorial());
        }

        private void Button_Click_DELETE_MEDICINE(object sender, RoutedEventArgs e)
        {
            _mainTutorial.NavigationService.Navigate(new Tutorials.DeleteMedicineTutorial());
        }

        private void Button_Click_ADD_POLL(object sender, RoutedEventArgs e)
        {
            _mainTutorial.NavigationService.Navigate(new Tutorials.AddPollTutorial());
        }

        private void Button_Click_DELETE_POLL(object sender, RoutedEventArgs e)
        {
            _mainTutorial.NavigationService.Navigate(new Tutorials.DeletePollTutorial());
        }

        private void Button_Click_DISTRIBUTION(object sender, RoutedEventArgs e)
        {
            _mainTutorial.NavigationService.Navigate(new Tutorials.DistributionEquipmentTutorial());
        }

        private void Button_Click_ORDERING(object sender, RoutedEventArgs e)
        {
            _mainTutorial.NavigationService.Navigate(new Tutorials.OrderingEquipmentTutorial());
        }

        private void Button_Click_MOVING_EQUIPMENT(object sender, RoutedEventArgs e)
        {
            _mainTutorial.NavigationService.Navigate(new Tutorials.MoveEquipmentTutorial());
        }

        private void Button_Click_VIDEO_TUTORIAL(object sender, RoutedEventArgs e)
        {
            _mainTutorial.NavigationService.Navigate(new TutorialVideo());
        }
    }
}
