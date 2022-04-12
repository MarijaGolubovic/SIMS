using System;
using System.Collections.ObjectModel;
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

        public static ObservableCollection<Room> Rooms
        {
            get;
            set;
        }

        public RoomsList()
        {
            InitializeComponent();
            this.DataContext = this;

            Rooms = new ObservableCollection<Room>();
            //Room room = new Room("1", 5,Model.RoomType.EXAMINATION_ROOM);
            Rooms.Add(new Room("opb", 12.1, Model.RoomType.OPPERATING_ROOM));
            Rooms.Add(new Room("h21", 15.2, Model.RoomType.HOSPITAL_ROOM));
            Rooms.Add(new Room("h2", 15.2, Model.RoomType.HOSPITAL_ROOM));
        }

        private void dataGridRooms_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            String messageText = "Do you want to delete room?";
            String caption = "Delete room";
            MessageBoxButton messageButton = MessageBoxButton.YesNo;
            MessageBoxImage initBox = MessageBoxImage.Question;
            MessageBoxResult messageResult = MessageBox.Show(messageText, caption, messageButton, initBox);
            Room room = (Room)dataGridRooms.SelectedItem;

            switch (messageResult)
            {
                case MessageBoxResult.Yes:
                    Rooms.Remove(room);
                    break;
                case MessageBoxResult.No:
                    Menager.MainWindowMenager mainWindow = new MainWindowMenager();
                    mainWindow.Show();
                    this.Close();
                    break;


            }


        }
    }
}
