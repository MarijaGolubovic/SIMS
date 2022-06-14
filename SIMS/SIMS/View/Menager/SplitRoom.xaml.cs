using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

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
            firstRoomSize.Text = (RenovateWindow.selectedRoom.Size/2).ToString();
            secondRoomSize.Text = (RenovateWindow.selectedRoom.Size / 2).ToString();

        }

        private void Button_Click_SplitRoom(object sender, RoutedEventArgs e)
        {
            Model.Room oldRoom = RenovateWindow.selectedRoom;
            Model.Room firstNewRoom = new Model.Room(firstRoomId.Text, Double.Parse(firstRoomSize.Text), Model.RoomType.HOSPITAL_ROOM);
            Model.Room secondNewRoom = new Model.Room(secondRoomId.Text, Double.Parse(secondRoomSize.Text), Model.RoomType.OPPERATING_ROOM);
            
            double newRoomSize = Double.Parse(firstRoomSize.Text) + Double.Parse(secondRoomSize.Text);
            if (firstRoomId.Text.Equals("") || secondRoomId.Text.Equals(""))
            {
                allError.Foreground = System.Windows.Media.Brushes.Red ;
                buttonSplit.IsEnabled = false;
            }
            else
            {
                if (roomService.IsRoomAlreadyExist(firstNewRoom))
                {
                    feedbackMessage.Text = "First room already existe!";
                    feedbackMessage.Foreground = System.Windows.Media.Brushes.Red;
                    Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                    sb.Begin(feedbackMessage);
                }
                else if (roomService.IsRoomAlreadyExist(secondNewRoom))
                {

                    feedbackMessage.Text = "Second room alreday exist!";
                    feedbackMessage.Foreground = System.Windows.Media.Brushes.Red;
                    Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                    sb.Begin(feedbackMessage);
                }
                else if (newRoomSize != oldRoom.Size)
                {
                    feedbackMessage.Text = "Room size is incorect!";
                    feedbackMessage.Foreground = System.Windows.Media.Brushes.Red;
                    Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                    sb.Begin(feedbackMessage);

                }
                else if (Menager.RenovateWindow.selectedRoom.Id.Contains("oba"))
                {
                    feedbackMessage.Text = "Room occupacy in this period!";
                    feedbackMessage.Foreground = System.Windows.Media.Brushes.Red;
                    Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                    sb.Begin(feedbackMessage);

                }
                else
                {

                    feedbackMessage.Text = "Room successfully splited";
                    feedbackMessage.Foreground = System.Windows.Media.Brushes.Green;
                    Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                    sb.Begin(feedbackMessage);

                    this.NavigationService.Navigate(new View.Menager.RenovateWindow());
                   // bool isRoomSplited = roomService.isSplitRoom(oldRoom, firstNewRoom, secondNewRoom);

                   
                }

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

        private void firstRoomSize_LostFocus(object sender, RoutedEventArgs e)
        {
            double oldSize = RenovateWindow.selectedRoom.Size;
            double firstSize = double.Parse(firstRoomSize.Text);
            secondRoomSize.Text = (oldSize - firstSize).ToString();
        }

        private void firstRoomId_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            if (firstRoomId.Text.Equals(""))
            {
                firstRoomId.Foreground = System.Windows.Media.Brushes.Red;
                firstRoomId.Text = "Enter room id!";
            }
            else
            {
                firstRoomId.Foreground = System.Windows.Media.Brushes.Black;
            }
        }


        private void firstRoomId_GotFocus(object sender, RoutedEventArgs e)
        {
            firstRoomId.Foreground = System.Windows.Media.Brushes.Black;
            buttonSplit.IsEnabled = true;
            allError.Foreground= System.Windows.Media.Brushes.LightGray;
        }

        private void secondRoomId_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            if (secondRoomId.Text.Equals(""))
            {
                secondRoomId.Foreground = System.Windows.Media.Brushes.Red;
                secondRoomId.Text = "Enter room id!";
            }
            else
            {
                secondRoomId.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void secondRoomId_GotFocus(object sender, RoutedEventArgs e)
        {
            secondRoomId.Foreground = System.Windows.Media.Brushes.Black;
            allError.Foreground = System.Windows.Media.Brushes.LightGray;
            buttonSplit.IsEnabled = true;
        }
    }
}
