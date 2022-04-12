using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SIMS.Model;

namespace SIMS.Menager
{
    /// <summary>
    /// Interaction logic for RoomsList.xaml
    /// </summary>
    public partial class RoomsList : Window
    {

        public static ObservableCollection<Model.Room> Rooms { get; set; }

        public RoomsList()
        {
            InitializeComponent();
            this.DataContext = this;
    
            Serialization.Serializer<Room> roomSerializer = new Serialization.Serializer<Room>();
            List<Room> rooms = roomSerializer.fromCSV("Room.txt");
            Rooms = new ObservableCollection<Room>();
            //Room room = new Room("1", 5,Model.RoomType.EXAMINATION_ROOM);

           // Rooms.Add(new Room("opb",12.1,Model.RoomType.OPPERATING_ROOM));
           // Rooms.Add(new Room("h21",15.2,Model.RoomType.HOSPITAL_ROOM));
           // Rooms.Add(new Room("h2", 15.2, Model.RoomType.HOSPITAL_ROOM));

            foreach(Room roomItem in rooms)
            {
                Rooms.Add(roomItem);
            }

        }

        private void dataGridRooms_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            String messageText = "Do you want to delete room?";
            String caption = "Delete room";
            MessageBoxButton messageButton = MessageBoxButton.YesNo;
            MessageBoxImage initBox = MessageBoxImage.Question;

            MessageBoxResult messageResult = MessageBox.Show(messageText, caption,messageButton,initBox);
            
         


            switch (messageResult)
            {
                case MessageBoxResult.Yes:
                    Serialization.Serializer<Room> roomSerializer = new Serialization.Serializer<Room>();
                    List<Room> rooms = roomSerializer.fromCSV("Room.txt");




                    Rooms.Remove((Room)dataGridRooms.SelectedItem);
                    roomSerializer.toCSV("Room.txt", Rooms.ToList());
                    break;
                case MessageBoxResult.No:
                    Menager.MainWindowMenager mainWindow = new MainWindowMenager();
                    mainWindow.Show();
                    this.Close();
                    break;


            }


        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            Menager.MainWindowMenager mainWindow = new MainWindowMenager();
            mainWindow.Show();
            this.Close();
        }
    }
}
