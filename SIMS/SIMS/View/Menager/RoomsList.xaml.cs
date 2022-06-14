using SIMS.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SIMS.Menager
{
    /// <summary>
    /// Interaction logic for RoomsList.xaml
    /// </summary>
    public partial class RoomsList : Page
    {

        public static ObservableCollection<Model.Room> Rooms { get; set; }
        private Frame _mainFrameRooms;
        public RoomsList()
        {
            InitializeComponent();
            _mainFrameRooms = FindName("MainFrameMenager") as Frame;
            this.DataContext = this;

            Serialization.Serializer<Room> roomSerializer = new Serialization.Serializer<Room>();
            List<Room> rooms = roomSerializer.fromCSV("Room.txt");
            Rooms = new ObservableCollection<Room>();
           
            foreach (Room roomItem in rooms)
            {
                Rooms.Add(roomItem);
            }
            HiddenDeleteLabel.Foreground = System.Windows.Media.Brushes.Green;
            Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
            sb.Begin(HiddenDeleteLabel);

        }



        private void Back_Click(object sender, RoutedEventArgs e)
        {

            //   Menager.MainWindowMenager mainWindow = new MainWindowMenager();
            // mainWindow.Show();
            //this.Close();
            this.NavigationService.Navigate(new AddRoomWindow());
        }

    }
}
