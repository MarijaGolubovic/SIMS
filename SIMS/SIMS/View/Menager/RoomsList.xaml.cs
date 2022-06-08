using SIMS.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

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
            //Room room = new Room("1", 5,Model.RoomType.EXAMINATION_ROOM);

            // Rooms.Add(new Room("opb",12.1,Model.RoomType.OPPERATING_ROOM));
            // Rooms.Add(new Room("h21",15.2,Model.RoomType.HOSPITAL_ROOM));
            // Rooms.Add(new Room("h2", 15.2, Model.RoomType.HOSPITAL_ROOM));

            foreach (Room roomItem in rooms)
            {
                Rooms.Add(roomItem);
            }

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
