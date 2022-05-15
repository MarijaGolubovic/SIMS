﻿using System;
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

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for RenovateWindow.xaml
    /// </summary>
    public partial class RenovateWindow : Page
    {
        public  static ObservableCollection<Model.Room> RoomRenovate { get; set; }
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

        private void Label_MouseDoubleClickRooms(object sender, MouseButtonEventArgs e)
        {
          ///  Menager.RoomsPanel roomsPanel = new RoomsPanel();
            //roomsPanel.Show();
            
        }

        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            //SIMS.Menager.MainWindowMenager mainWindowMenager = new SIMS.Menager.MainWindowMenager();
            //mainWindowMenager.Show();
            // this.Close();
            this.NavigationService.Navigate(new Report());
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            // Menager.RenovateForm renovateForm = new RenovateForm();
            //renovateForm.Show();
            //this.Close();
            selectedRoom = (Model.Room)dataGridRenovate.SelectedItem;
            indexSelected = dataGridRenovate.SelectedIndex;

            this.NavigationService.Navigate(new RenovateForm());
        }
    }
}
