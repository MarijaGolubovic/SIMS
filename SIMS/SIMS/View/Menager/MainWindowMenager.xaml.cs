using System.Windows;
using System.Windows.Controls;

namespace SIMS.Menager
{
    /// <summary>
    /// Interaction logic for MainWindowMenager.xaml
    /// </summary>
    public partial class MainWindowMenager : Window
    {
        public static Frame frame { get; set; }
        public static Frame _mainFrame;
        public MainWindowMenager()
        {
            InitializeComponent();
            _mainFrame = this.FindName("MainFrameMenager") as Frame;
            // _mainFrame.NavigationService.Navigate(new MainWindowMenager());
        }



        private void Label_MouseDoubleClickSignOut(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            View.Menager.LogWindow logWindow = new View.Menager.LogWindow();
            logWindow.Show();
            this.Close();
        }

        private void MenuItemAddRoom_Click(object sender, RoutedEventArgs e)
        {
            // SIMS.Menager.AddRoomWindow addRoomWindow = new SIMS.Menager.AddRoomWindow();
            // addRoomWindow.Show();
            //this.Close();
            //MainWindowMenager.frame.Content = new AddRoomWindow();
            _mainFrame.NavigationService.Navigate(new AddRoomWindow());
        }

        private void MenuItemRoomUpdate_Click(object sender, RoutedEventArgs e)
        {
            // SIMS.Menager.UpdateRoomWindow updateRoomWindow = new SIMS.Menager.UpdateRoomWindow();
            //updateRoomWindow.Show();
            //this.Close();
            _mainFrame.NavigationService.Navigate(new UpdateRoomWindow());
        }

        private void MenuItemRoomDelete_Click(object sender, RoutedEventArgs e)
        {
            // SIMS.Menager.DeleteRoom deleteRoom = new SIMS.Menager.DeleteRoom();
            //deleteRoom.Show();
            //this.Close();
            _mainFrame.NavigationService.Navigate(new DeleteRoom());
        }

        private void MenuItemRoomRenovate_Click(object sender, RoutedEventArgs e)
        {
            // View.Menager.RenovateWindow renovateWindow = new View.Menager.RenovateWindow();
            // renovateWindow.Show();
            //this.Close();
            _mainFrame.NavigationService.Navigate(new View.Menager.RenovateWindow());
        }

        private void MenuItem_ClickMoveEquipment(object sender, RoutedEventArgs e)
        {
            View.Menager.Rooms moveWindow = new View.Menager.Rooms();
            moveWindow.Show();
            this.Close();
        }

        private void MenuItem_BackToHomePage(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new View.Menager.Report());
        }

        private void MenuItem_Click_AddMedicine(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new View.Menager.AddMedicine());
        }

        private void MenuItem_Click_EditMedicine(object sender, RoutedEventArgs e)
        {
            View.Menager.EditMedicine editMedicine = new View.Menager.EditMedicine();
            editMedicine.Show();
        }

        private void MenuItem_Click_CorrectMedicine(object sender, RoutedEventArgs e)
        {
            View.Menager.CorrectWindow correctWindow = new View.Menager.CorrectWindow();
            correctWindow.Show();
        }
    }
}
