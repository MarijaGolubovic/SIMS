using SIMS.Controller;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Controls;

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : Page
    {
        public static ObservableCollection<Model.Room> Roomss { get; set; }

        public static Model.Room roomItemSelected = new Model.Room();
        private Controller.RoomEquipmentController roomEquipmentController = new Controller.RoomEquipmentController();
        public Rooms()
        {
            InitializeComponent();
            this.DataContext = this;

            roomItemSelected = (Model.Room)DataGridUpdate.SelectedItem;
            Serialization.Serializer<Model.Room> roomSerializer = new Serialization.Serializer<Model.Room>();
            List<Model.Room> rooms = roomSerializer.fromCSV("Room.txt");
            Roomss = new ObservableCollection<Model.Room>();

            foreach (Model.Room roomItem in rooms)
            {
                Roomss.Add(roomItem);
            }
        }

        private void UpdateBack_Click_Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Menager.Report());
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            roomItemSelected = (Model.Room)DataGridUpdate.SelectedItem;
            
            if (roomItemSelected == null)
            {
                errorMessage.Foreground = System.Windows.Media.Brushes.Red;
                buttonOK.IsEnabled = false;
            }else
            { 
                
                this.NavigationService.Navigate(new Menager.MoveEquipment());
                
            }
        }

        private void DataGridUpdate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            buttonOK.IsEnabled = true;
            errorMessage.Foreground = System.Windows.Media.Brushes.LightGray;
        }
    }
}
