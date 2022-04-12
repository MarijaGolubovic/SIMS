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
    /// Interaction logic for UpdateForm.xaml
    /// </summary>
    public partial class UpdateForm : Window

    {
        Model.Room roomItem;
        public static ObservableCollection<Model.Room> Rooms { get; set; }

        public UpdateForm()
        {
            roomItem = Menager.UpdateRoomWindow.selectedRoom; 
            InitializeComponent();
            IDInput.Text = roomItem.Id;
            SizeInput.Text = roomItem.Size.ToString();
            //comboboxField.SelectedItem = roomItem.Type;
            //int selectedItem = -1;

            if(roomItem.Type.Equals( Model.RoomType.OPPERATING_ROOM))
            {
                comboboxField.SelectedIndex = 0;
            }else if(roomItem.Type.Equals(Model.RoomType.EXAMINATION_ROOM))
            {
                comboboxField.SelectedIndex = 1;
            }else if(roomItem.Type.Equals( Model.RoomType.HOSPITAL_ROOM))
            {
                comboboxField.SelectedIndex = 2;
            }
            else
            {
                comboboxField.SelectedIndex = 3;
            }

           
            

        }

        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {

            Serialization.Serializer<Model.Room> roomSerializer = new Serialization.Serializer<Model.Room>();
            List<Model.Room> rooms = roomSerializer.fromCSV("Room.txt");
            RoomsList.Rooms = new ObservableCollection<Model.Room>();

            foreach (Model.Room roomItem in rooms)
            {
                RoomsList.Rooms.Add(roomItem);
            }

            Model.RoomType roomType = Model.RoomType.HOSPITAL_ROOM;
            if (comboboxField.SelectedIndex == 0)
            {
                roomType = Model.RoomType.OPPERATING_ROOM;
            }
            else if (comboboxField.SelectedIndex == 1)
            {
                roomType = Model.RoomType.EXAMINATION_ROOM;
            }
            else if (comboboxField.SelectedIndex == 2)
            {
                roomType = Model.RoomType.HOSPITAL_ROOM;
            }
            else
            {
                roomType = Model.RoomType.WAREHOUSE;
            }



            Model.Room newRoom = (new Model.Room { Id = IDInput.Text, Size = Double.Parse(SizeInput.Text), Type = roomType });

            RoomsList.Rooms.Add(newRoom);
            roomSerializer.toCSV("Room.txt", RoomsList.Rooms.ToList());

            Menager.UpdateRoomWindow updateRoomWindow = new UpdateRoomWindow();
            updateRoomWindow.Show();

        }
    }
}
