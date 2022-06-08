using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for RenovateWindow.xaml
    /// </summary>
    public partial class RenovateWindow : Page
    {
        public static ObservableCollection<Model.Room> RoomRenovate { get; set; }
        public static Model.Room selectedRoom;
        public static int indexSelected = -1;
        public RenovateWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Serialization.Serializer<Model.Room> roomSerializer = new Serialization.Serializer<Model.Room>();
            List<Model.Room> rooms = roomSerializer.fromCSV("Room.txt");
            RoomRenovate = new ObservableCollection<Model.Room>();

            foreach (Model.Room roomItem in rooms)
            {
                RoomRenovate.Add(roomItem);
            }
        }


        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Report());
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            selectedRoom = (Model.Room)dataGridRenovate.SelectedItem;
            indexSelected = dataGridRenovate.SelectedIndex;

            this.NavigationService.Navigate(new RenovateForm());
        }

        private void Button_Click_TUTORIAL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.Menager.Tutorials.RenovateRoomTutorial());
        }
    }
}
