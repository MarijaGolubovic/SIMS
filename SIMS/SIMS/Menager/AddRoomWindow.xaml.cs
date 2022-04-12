using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace SIMS.Menager
{
    /// <summary>
    /// Interaction logic for AddRoomWindow.xaml
    /// </summary>
    public partial class AddRoomWindow : Window
    {
        public static ObservableCollection<Model.Room> Rooms { get; set; }
        public AddRoomWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Rooms = new ObservableCollection<Model.Room>();
            foreach(Model.Room roomItem in Model.RoomStorage.GetAll())
            {
                Rooms.Add(roomItem);
            }
          
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {

            Serialization.Serializer<Model.Room> roomSerializer = new Serialization.Serializer<Model.Room>();
            List<Model.Room> rooms = roomSerializer.fromCSV("Room.txt");
            RoomsList.Rooms = new ObservableCollection<Model.Room>();

            foreach(Model.Room roomItem in rooms)
            {
                RoomsList.Rooms.Add(roomItem);
            }

            Model.RoomType roomType = Model.RoomType.HOSPITAL_ROOM ;
            if (comboboxField.SelectedIndex == 0) {
                roomType = Model.RoomType.OPPERATING_ROOM;
            }else if(comboboxField.SelectedIndex == 1)
            {
                 roomType = Model.RoomType.EXAMINATION_ROOM;
            }else if(comboboxField.SelectedIndex == 2)
            {
                 roomType = Model.RoomType.HOSPITAL_ROOM;
            }
            else
            {
                roomType = Model.RoomType.WAREHOUSE;
            }
               

            
            Model.Room newRoom= (new Model.Room { Id=IDInput.Text, Size = Double.Parse(SizeInput.Text), Type =roomType});

            RoomsList.Rooms.Add(newRoom);
            roomSerializer.toCSV("Room.txt", RoomsList.Rooms.ToList());

            Menager.RoomsList roomList = new Menager.RoomsList();
            roomList.Show();
            this.Close();
        }

        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            Menager.MainWindowMenager mainWindow = new MainWindowMenager();
            mainWindow.Show();
            this.Close();

        }
    }
}
