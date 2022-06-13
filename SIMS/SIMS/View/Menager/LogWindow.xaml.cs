using System.Windows;

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {

        public LogWindow()
        {
            InitializeComponent();

          //  Service.RoomEquipmentServices roomEquipmentServices = new Service.RoomEquipmentServices();
           // bool moveEquipment = roomEquipmentServices.MoveEquipmentToAnatherRoom(new Model.MoveRoomEquipmentDTO("neko", "soba12", "12-May-2022;12", "22-May-2022;22"));

//            Service.OccupacyRoomService occupacyRoomService = new Service.OccupacyRoomService();
  //          occupacyRoomService.RenovateRoom(new Model.Room(), new Model.BeginEndTime(), "121");
        }


        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
