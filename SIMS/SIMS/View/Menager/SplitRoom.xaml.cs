using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for SplitRoom.xaml
    /// </summary>
    public partial class SplitRoom : Page
    {
        Repository.RoomStorage roomStorage = new Repository.RoomStorage();
        Service.RoomService roomService = new Service.RoomService();
        public SplitRoom()
        {
            InitializeComponent();
            splitedRoomName.Text = Menager.RenovateWindow.selectedRoom.Id;

        }

        private void Button_Click_SplitRoom(object sender, RoutedEventArgs e)
        {
            Model.Room oldRoom = RenovateWindow.selectedRoom;
            Model.Room firstNewRoom = new Model.Room(firstRoomId.Text, Double.Parse(firstRoomSize.Text), Model.RoomType.HOSPITAL_ROOM);
            Model.Room secondNewRoom = new Model.Room(secondRoomId.Text, Double.Parse(secondRoomSize.Text), Model.RoomType.OPPERATING_ROOM);

            double newRoomSize = Double.Parse(firstRoomSize.Text) + Double.Parse(secondRoomSize.Text);
            if (roomService.IsRoomAlreadyExist(firstNewRoom))
            {
                MessageBox.Show("First room already existe");
            }
            else if (roomService.IsRoomAlreadyExist(secondNewRoom))
            {
                MessageBox.Show("Second room alreday exist!");
            }
            else if (newRoomSize != oldRoom.Size)
            {
                MessageBox.Show("Room size is incorect!");
            }
            else if (Menager.RenovateWindow.selectedRoom.Id.Contains("oba"))
            {
                MessageBox.Show("Room occupacy in this period!");
            }
            else
            {

                MessageBox.Show("Room successfully splited!");
                bool isRoomSplited = roomService.isSplitRoom(oldRoom, firstNewRoom, secondNewRoom);

                this.NavigationService.Navigate(new View.Menager.RenovateWindow());
            }



        }


        public Model.RoomType returnType(string roomId)
        {
            Model.RoomType roomType = Model.RoomType.HOSPITAL_ROOM;
            List<Model.Room> allRooms = new List<Model.Room>();
            foreach (Model.Room room in allRooms)
            {
                if (room.Id.Equals(roomId))
                    roomType = room.Type;
            }
            return roomType;
        }

        private void Button_Click_CANCELSplit(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RenovateWindow());
        }
    }
}
