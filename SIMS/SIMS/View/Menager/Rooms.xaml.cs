using SIMS.Controller;
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
using static System.Net.Mime.MediaTypeNames;

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : Window
    {
        public static ObservableCollection<Model.Room> RoomsChoose { get; set; }
        
        internal RoomEquipmentController RoomEquipmentController { get => roomEquipmentController; set => roomEquipmentController = value; }

        public static Model.Room roomItemSelected;
        private Controller.RoomEquipmentController roomEquipmentController = new Controller.RoomEquipmentController();
        public Rooms()
        {
            InitializeComponent();
            this.DataContext = this;
            //roomItemSelected =(Model.Room) DataGridRoomsChose.SelectedItem;
            //string id = roomItemSelected.Id;
            //MovingWindow.roomIdChoose1.Text = id;
            Serialization.Serializer<Model.Room> roomSerializer = new Serialization.Serializer<Model.Room>();
            List<Model.Room> rooms = roomSerializer.fromCSV("Room.txt");
            RoomsChoose = new ObservableCollection<Model.Room>();

            foreach (Model.Room roomItem in rooms)
            {
                RoomsChoose.Add(roomItem);
            }
        }

        private void UpdateBack_Click_Moving(object sender, RoutedEventArgs e)
        {
            MovingWindow movingWindow = new MovingWindow();
            movingWindow.Show();
            this.Close();
        }

        private void Label_MouseDoubleClickEqupment(object sender, MouseButtonEventArgs e)
        {
            EqupmentPanel equpmentPanel = new EqupmentPanel();
            equpmentPanel.Owner = this;
            equpmentPanel.Show();
        }

        private void UpdateBack_Click_Back(object sender, RoutedEventArgs e)
        {
            MovingWindow movingWindow = new MovingWindow();
            movingWindow.Show();
            movingWindow.Close();
        }

        private void DataGridUpdate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
         //   roomItemSelected = (Model.Room)DataGridRoomsChose.SelectedItem;
            List<Model.RoomEqupment> roomEqupments = RoomEquipmentController.GetAll();
            List<Model.Equpment> equpments = new List<Model.Equpment>();
            foreach(Model.RoomEqupment roomEq in roomEqupments)
            {
                if (roomEq.RoomId.Equals(roomItemSelected.Id))
                {
                    List<Model.Equpment> roomEqupmentList = new List<Model.Equpment>();
                    foreach(Model.Equpment eq in roomEqupmentList)
                    {
                        equpments.Add(eq);
                    }
                    
                }
            }

            MovingWindow.roomItemId = ((Model.Room)DataGridRoomsChose.SelectedItem).Id;

            this.Close();
        }

        private void Rooms_MouseDoubleClick_OK(object sender, MouseButtonEventArgs e)
        {
            RoomsPanel roomsPanel = new RoomsPanel();
            roomsPanel.Owner = this;
            roomsPanel.Show();
        }
    }
}
