using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.Menager
{
    /// <summary>
    /// Interaction logic for DeleteRoom.xaml
    /// </summary>
    public partial class DeleteRoom : Page
    {
        public static ObservableCollection<Model.Room> Rooms { get; set; }
        public DeleteRoom()
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


        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.Menager.Report());
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {

            Serialization.Serializer<Room> roomSerializer = new Serialization.Serializer<Room>();
            List<Room> rooms = roomSerializer.fromCSV("Room.txt");




            Rooms.Remove((Room)dataGridRooms.SelectedItem);
            roomSerializer.toCSV("Room.txt", Rooms.ToList());
            this.NavigationService.Navigate(new RoomsList());

            //  Menager.MainWindowMenager mainWindow = new MainWindowMenager();
            // mainWindow.Show();
            // this.Close();

            HiddenDeleteLabel.Visibility = Visibility.Visible;
            this.NavigationService.Navigate(new View.Menager.DeleteSuccesfully());




        }

        private void Button_Click_TUTORIJAL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.Menager.Tutorials.DelateRoomTutorial());
        }
    }
}
