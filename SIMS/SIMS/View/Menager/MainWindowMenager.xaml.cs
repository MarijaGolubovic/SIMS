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

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            Menager.AddRoomWindow addRoomWindow = new Menager.AddRoomWindow();
            addRoomWindow.Show();
            this.Close();
        }

        private void UpdateRoom_Click(object sender, RoutedEventArgs e)
        {

            Menager.UpdateRoomWindow updateWindow = new UpdateRoomWindow();
            updateWindow.Show();
            
            
        }

        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            Menager.RoomsList roomsList = new Menager.RoomsList();
            roomsList.Show();
            this.Close();
        }

        private void Label_MouseDoubleClickRooms(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            View.Menager.RoomsPanel roomsPanel = new View.Menager.RoomsPanel();
            roomsPanel.Owner = this;
            roomsPanel.Show();

        }

        private void Label_MouseDoubleClickEqupment(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            View.Menager.EqupmentPanel equpmentPanel = new View.Menager.EqupmentPanel();
            equpmentPanel.Owner = this;
            equpmentPanel.Show();
        }

        private void Label_MouseDoubleClickSignOut(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            View.Menager.LogWindow logWindow = new View.Menager.LogWindow();
            logWindow.Show();
            this.Close();
        }
    }
}
