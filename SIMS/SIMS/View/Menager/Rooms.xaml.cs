using SIMS.Controller;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : Window
    {
        public static ObservableCollection<Model.Room> Roomss { get; set; }
        public static Model.Room selectedRoom;

        internal RoomEquipmentController RoomEquipmentController { get => roomEquipmentController; set => roomEquipmentController = value; }

        public static Model.Room roomItemSelected;
        private Controller.RoomEquipmentController roomEquipmentController = new Controller.RoomEquipmentController();
        public Rooms()
        {
            InitializeComponent();
            this.DataContext = this;

            Serialization.Serializer<Model.Room> roomSerializer = new Serialization.Serializer<Model.Room>();
            List<Model.Room> rooms = roomSerializer.fromCSV("Room.txt");
            Roomss = new ObservableCollection<Model.Room>();

            foreach (Model.Room roomItem in rooms)
            {
                Roomss.Add(roomItem);
            }
        }

        private void UpdateBack_Click_Moving(object sender, RoutedEventArgs e)
        {
            // MovingWindow movingWindow = new MovingWindow();
            //movingWindow.Show();
            //this.Close();
        }



        private void UpdateBack_Click_Back(object sender, RoutedEventArgs e)
        {
            // MovingWindow movingWindow = new MovingWindow();
            // movingWindow.Show();
            // movingWindow.Close();
        }

        private void DataGridUpdate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            roomItemSelected = (Model.Room)DataGridUpdate.SelectedItem;
            // List<Model.RoomEqupment> roomEqupments = RoomEquipmentController.GetAll();
            //List<Model.Equpment> equpments = new List<Model.Equpment>();
            //foreach(Model.RoomEqupment roomEq in roomEqupments)
            /* {
                 if (roomEq.RoomId.Equals(roomItemSelected.Id))
                 {
                     List<Model.Equpment> roomEqupmentList = new List<Model.Equpment>();
                     foreach(Model.Equpment eq in roomEqupmentList)
                     {
                         equpments.Add(eq);
                     }

                 }
             }
            */
            //  MovingWindow.roomItemId = ((Model.Room)DataGridRoomsChose.SelectedItem).Id;

        }

        private void Rooms_MouseDoubleClick_OK(object sender, MouseButtonEventArgs e)
        {
            //   RoomsPanel roomsPanel = new RoomsPanel();
            //  roomsPanel.Owner = this;
            // roomsPanel.Show();
            // roomSelecred =(Model.Room) DataGridRoomsChose.SelectedItem;


            //  View.Menager.MovingWindow renovateWindow = new View.Menager.MovingWindow();
            // renovateWindow.Show();
            //this.Close();
        }

        private void DataGridUpdate_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            roomItemSelected = (Model.Room)DataGridUpdate.SelectedItem;
            View.Menager.MoveEquipment renovateWindow = new View.Menager.MoveEquipment();
            renovateWindow.Show();

            this.Close();
        }
    }
}
