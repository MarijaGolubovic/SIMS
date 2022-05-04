using SIMS.Model;
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

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for MovingWindow.xaml
    /// </summary>
   
    
    public partial class MovingWindow : Window
    {

       // public static ObservableCollection<Model.Equpment> MovingEquipment { get; set; }
        internal Repository.RoomEquipmentStorage equipmentStorage = new Repository.RoomEquipmentStorage();
        Model.Room roomItem;
        String period;
        private static Room roomItemSelected;
        internal Service.RoomEquipmentServices roomEquipmentService = new Service.RoomEquipmentServices();

        public MovingWindow()
        {
            
            InitializeComponent();
            Serialization.Serializer<Model.Room> roomSerializer = new Serialization.Serializer<Model.Room>();
            List<Model.Room> rooms = roomSerializer.fromCSV("Room.txt");
            List<Model.RoomEqupment> equpments = equipmentStorage.GetAll();
            Model.Room roomItem = View.Menager.MovingWindow.roomItemSelected;

             foreach(Room roomIt in rooms)
            {
                if (roomIt.Id.Equals(roomItem.Id))
                {
                    foreach (Model.RoomEqupment eq in equpments) {
                        if (roomItem.Id.Equals(eq.RoomId))
                        {
                           //MovingEquipment.Add((Equpment)eq.roomEquipment);
                        }

                    }
                }
            }
            


        }

        private void Label_MouseDoubleClickRooms(object sender, MouseButtonEventArgs e)
        {
            Menager.RoomsPanel roomsPanel = new RoomsPanel();
            roomsPanel.Show();
        }

        private void Label_MouseDoubleClickEqupment(object sender, MouseButtonEventArgs e)
        {
            Menager.EqupmentPanel equpmentPanel = new Menager.EqupmentPanel();
            equpmentPanel.Show();
        }

        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            SIMS.Menager.MainWindowMenager mainWindowMenager = new SIMS.Menager.MainWindowMenager();
            mainWindowMenager.Show();
            this.Close();
        }

        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            View.Menager.Rooms labelRooms = new View.Menager.Rooms();
            labelRooms.Show();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           List<Model.RoomEqupment> rommEq = new List<RoomEqupment>();
           
            View.Menager.Rooms labelRooms = new View.Menager.Rooms();
            foreach(Model.RoomEqupment eq in equipmentStorage.GetAll()) {
                if (roomItem.Id.Equals(eq.RoomId))
                {
                    rommEq.Add(eq);
                }
            
            }
            MessageBox.Show(roomEquipmentService.MovingRoomEqupment(roomItem, roomItemSelected, rommEq.ToList(), period));
            labelRooms.Show();
        }
    }
}
