using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SIMS.Menager
{
    /// <summary>
    /// Interaction logic for UpdateRoomWindow.xaml
    /// </summary>
    public partial class UpdateRoomWindow : Window
    {
        public static ObservableCollection<Model.Room> Rooms { get; set; }
        public static Model.Room selectedRoom;
        public static int indexSelected = -1;
        public UpdateRoomWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Serialization.Serializer<Model.Room> roomSerializer = new Serialization.Serializer<Model.Room>();
            List<Model.Room> rooms = roomSerializer.fromCSV("Room.txt");
            Rooms = new ObservableCollection<Model.Room>();

            foreach (Model.Room roomItem in rooms)
            {
                Rooms.Add(roomItem);
            }
        }

        private void DataGridUpdate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectedRoom = (Model.Room)DataGridUpdate.SelectedItem;
            indexSelected = DataGridUpdate.SelectedIndex;
            Menager.UpdateForm updateForm = new Menager.UpdateForm();
            updateForm.Show();
            this.Close();
        }

        private void UpdateBack_Click(object sender, RoutedEventArgs e)
        {

            this.Close();

        }

    }
}
