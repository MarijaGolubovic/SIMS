using System.Windows;

namespace SIMS.Menager
{
    /// <summary>
    /// Interaction logic for AddRoomWindow.xaml
    /// </summary>
    public partial class AddRoomWindow : Window
    {
        public AddRoomWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {

            //RoomsList.Rooms.Add(new Model.Room { Id=IDInput.Text, Size = Double.Parse(SizeInput.Text), Type=Model.RoomType.HOSPITAL_ROOM});

            Menager.RoomsList roomList = new Menager.RoomsList();
            roomList.Show();
            this.Close();
        }

    }
}
