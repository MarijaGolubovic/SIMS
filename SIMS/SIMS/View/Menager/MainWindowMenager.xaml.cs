using System.Windows;

namespace SIMS.Menager
{
    /// <summary>
    /// Interaction logic for MainWindowMenager.xaml
    /// </summary>
    public partial class MainWindowMenager : Window
    {
        public MainWindowMenager()
        {
            InitializeComponent();
        }



        private void Label_MouseDoubleClickSignOut(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            View.Menager.LogWindow logWindow = new View.Menager.LogWindow();
            logWindow.Show();
            this.Close();
        }

        private void MenuItemAddRoom_Click(object sender, RoutedEventArgs e)
        {
            SIMS.Menager.AddRoomWindow addRoomWindow = new SIMS.Menager.AddRoomWindow();
            addRoomWindow.Show();
            this.Close();
        }

        private void MenuItemRoomUpdate_Click(object sender, RoutedEventArgs e)
        {
            SIMS.Menager.UpdateRoomWindow updateRoomWindow = new SIMS.Menager.UpdateRoomWindow();
            updateRoomWindow.Show();
            this.Close();
        }

        private void MenuItemRoomDelete_Click(object sender, RoutedEventArgs e)
        {
            SIMS.Menager.DeleteRoom deleteRoom = new SIMS.Menager.DeleteRoom();
            deleteRoom.Show();
            this.Close();
        }

        private void MenuItemRoomRenovate_Click(object sender, RoutedEventArgs e)
        {
            View.Menager.RenovateWindow renovateWindow = new View.Menager.RenovateWindow();
            renovateWindow.Show();
            this.Close();
        }
    }
}
