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
    /// Interaction logic for UpdateRoomWindow.xaml
    /// </summary>
    public partial class UpdateRoomWindow : Window
    {
        public static ObservableCollection<Model.Room> Rooms { get; set; }
        public static Model.Room selectedRoom;
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
           selectedRoom= (Model.Room) DataGridUpdate.SelectedItem;
            Menager.UpdateForm updateForm = new Menager.UpdateForm();
            updateForm.Show();
        }

        private void UpdateBack_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();

        }
    }
}
