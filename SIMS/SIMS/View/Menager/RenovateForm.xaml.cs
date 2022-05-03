using System;
using System.Collections.Generic;
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
    /// Interaction logic for RenovateForm.xaml
    /// </summary>
    public partial class RenovateForm : Window
    {
        public static System.Collections.ObjectModel.ObservableCollection<Model.Room> RoomRenovate { get; set; }
        Model.Room roomItem;

        public RenovateForm()
        {
            roomItem = Menager.RenovateWindow.selectedRoom;
            InitializeComponent();

            idRenovateRoom.Text = roomItem.Id;
            sizeRenovateRoom.Text = roomItem.Size.ToString();
            TypeRenovateRoom.Text = roomItem.Type.ToString();
            
        }

        private void Label_MouseDoubleClickRooms(object sender, MouseButtonEventArgs e)
        {
            Menager.RenovateForm renovateForm = new RenovateForm();
            renovateForm.Show();
            this.Close();
        }

        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            Menager.RenovateWindow renovateWindow = new RenovateWindow();
            renovateWindow.Show();
            this.Close();
        }

        private void Button_ClickOK(object sender, RoutedEventArgs e)
        {
            Service.RoomService roomService = new Service.RoomService();
            Serialization.Serializer<Model.Room> roomSerializer = new Serialization.Serializer<Model.Room>();
            List<Model.Room> rooms = roomSerializer.fromCSV("Room.txt");
            

            foreach (Model.Room roomItem in rooms)
            {
                if (roomItem.Id.Equals(idRenovateRoom.Text))
                {
                    MessageBox.Show(roomService.RenovateRoom(roomItem, renovationMethod.Text, DatePickerBegin.SelectedDate.Value, DatePickerEnd.SelectedDate.Value, "Renovation"));
                }
            }

           
        }
    }
}
