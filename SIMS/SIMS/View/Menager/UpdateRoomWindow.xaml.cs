using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace SIMS.Menager
{
    /// <summary>
    /// Interaction logic for UpdateRoomWindow.xaml
    /// </summary>
    public partial class UpdateRoomWindow : Page
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



        private void UpdateBack_Click(object sender, RoutedEventArgs e)
        {

            //            this.Close();
            this.NavigationService.Navigate(new View.Menager.Report());
        }

        private void UpdateOK_Click(object sender, RoutedEventArgs e)
        {
            selectedRoom = (Model.Room)DataGridUpdate.SelectedItem;
            if (selectedRoom == null) { 
                errorMesage.Foreground = System.Windows.Media.Brushes.Red;
                UpdateOK.IsEnabled = false;
            }
            else
            {
                indexSelected = DataGridUpdate.SelectedIndex;
                this.NavigationService.Navigate(new UpdateForm());
            }
        }

        private void Button_Click_TUTORIAL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.Menager.Tutorials.UpdateRoomTutorial());
        }

        private void DataGridUpdate_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            errorMesage.Foreground = System.Windows.Media.Brushes.LightGray;
            UpdateOK.IsEnabled = true;
        }
    }
}
