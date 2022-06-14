using SIMS.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

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
            if (otherRoom.SelectedItem == null && newRoomBox.Text.Equals(""))
            {
                allError.Foreground = System.Windows.Media.Brushes.Red;
                buttonOK.IsEnabled = false;
            }
            else if (otherRoom.SelectedItem == null)
            {
                otherRoomError.Foreground = System.Windows.Media.Brushes.Red;
                buttonOK.IsEnabled = false;
            }
            else if (newRoomBox.Text.Equals(""))
            {
                newRoomError.Foreground = System.Windows.Media.Brushes.Red;
                buttonOK.IsEnabled = false;
            }
            else
            {
                Model.Room oldRoom = roomStorage.GetRoomById(oldRoomBox.Text);
                Model.Room otherMergedRoom = new Room();
                foreach(Model.Room roomItem in roomStorage.GetAll())
                {
                    if (roomItem.Id.Equals(otherRoom.SelectedItem))
                    {
                        otherMergedRoom = roomItem;
                    }
                }
               

                double newRoomSize = oldRoom.Size + otherMergedRoom.Size;
                Model.RoomType newRoomType = Model.RoomType.HOSPITAL_ROOM;
                int selectedItemInCombobox = -1;
                selectedItemInCombobox = newRoomTypeBox.SelectedIndex;

               



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
                    feedbackMessage.Text = "Other merged room don't exist!";
                    feedbackMessage.Foreground = System.Windows.Media.Brushes.Red;
                    Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                    sb.Begin(feedbackMessage);
                }
                else if (Menager.RenovateWindow.selectedRoom.Id.Contains("oba"))
                {
                    feedbackMessage.Text = "Room occupaccy in this period!";
                    feedbackMessage.Foreground = System.Windows.Media.Brushes.Red;
                    Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                    sb.Begin(feedbackMessage);
                    
                }
                else
                {
                    feedbackMessage.Text = "Room successfully merged!";
                    feedbackMessage.Foreground = System.Windows.Media.Brushes.Green;
                    Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                    sb.Begin(feedbackMessage);
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

        private void otherRoom_GotFocus(object sender, RoutedEventArgs e)
        {
            allError.Foreground = System.Windows.Media.Brushes.LightGray;
            otherRoomError.Foreground = System.Windows.Media.Brushes.LightGray;
            buttonOK.IsEnabled = true;
        }

        private void newRoomBox_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            allError.Foreground = System.Windows.Media.Brushes.LightGray;
            newRoomError.Foreground = System.Windows.Media.Brushes.LightGray;
            buttonOK.IsEnabled = true;
        }
    }
}
