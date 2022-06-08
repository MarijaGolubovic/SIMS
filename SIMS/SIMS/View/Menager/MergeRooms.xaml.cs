using SIMS.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for MergeRooms.xaml
    /// </summary>
    public partial class MergeRooms : Page
    {
        Repository.RoomStorage roomStorage = new Repository.RoomStorage();
        Service.RoomService roomService = new Service.RoomService();
        public MergeRooms()
        {
            InitializeComponent();
            oldRoomBox.Text = RenovateWindow.selectedRoom.Id;
        }

        private void Button_Click_CANCELMerge(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RenovateWindow());
        }

        private void Button_Click_OKMergeRoom(object sender, RoutedEventArgs e)
        {
            Model.Room oldRoom = roomStorage.GetRoomById(oldRoomBox.Text);
            Model.Room otherMergedRoom = roomStorage.GetRoomById(otherMergedRoomBox.Text);

            double newRoomSize = oldRoom.Size + otherMergedRoom.Size;
            Model.RoomType newRoomType = Model.RoomType.HOSPITAL_ROOM;
            int selectedItemInCombobox = -1;
            selectedItemInCombobox = newRoomTypeBox.SelectedIndex;

            if (otherMergedRoom == null)
            {
                MessageBox.Show("Other merged room not exist!");
            }



            switch (selectedItemInCombobox)
            {
                case 0:
                    newRoomType = Model.RoomType.OPPERATING_ROOM;
                    break;
                case 1:
                    newRoomType = Model.RoomType.EXAMINATION_ROOM;
                    break;
                case 2:
                    newRoomType = Model.RoomType.HOSPITAL_ROOM;
                    break;
                case 3:
                    newRoomType = Model.RoomType.WAREHOUSE;
                    break;
            }

            Model.Room newRoom = new Model.Room(newRoomBox.Text, newRoomSize, newRoomType);

            if (!roomService.IsRoomAlreadyExist(otherMergedRoom))
            {
                MessageBox.Show("Other merged room don't exist!");
            }
            else if (Menager.RenovateWindow.selectedRoom.Id.Contains("oba"))
            {
                MessageBox.Show("Room occupaccy in this period!");
            }
            else
            {
                MessageBox.Show("Room successfuly merged!");

                List<Room> rooms = new List<Room>();
                Serialization.Serializer<Room> roomSerijalization = new Serialization.Serializer<Room>();
                rooms = roomSerijalization.fromCSV("Room.txt");
                //roomStorage.Create(newRoom);
                roomService.IsRoomMerge(oldRoom, otherMergedRoom, newRoom);
                rooms.Remove(otherMergedRoom);
                //roomStorage.Delete(oldRoomBox.Text);

                roomSerijalization.toCSV("Room.txt", rooms);

                this.NavigationService.Navigate(new RenovateWindow());
            }



        }
    }
}
