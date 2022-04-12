using SIMS.Model;
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
    /// Interaction logic for RoomsList.xaml
    /// </summary>
    public partial class RoomsList : Window
    {

        public static ObservableCollection<Room> Rooms
        {
            get;
            set;
        }

        public RoomsList()
        {
            InitializeComponent();
            this.DataContext = this;

            Rooms = new ObservableCollection<Room>();
            Rooms.Add(new Room { Id="opb", Size=12.1, Type=Model.RoomType.OPPERATING_ROOM});
            Rooms.Add(new Room { Id = "h21", Size =15.2 , Type = Model.RoomType.HOSPITAL_ROOM });
            Rooms.Add(new Room { Id = "h2", Size = 15.2, Type = Model.RoomType.HOSPITAL_ROOM });

        }

        private void dataGridRooms_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            String messageText = "Do you want to delete room?";
            String caption = "Delete room";
            MessageBoxButton messageButton = MessageBoxButton.YesNo;
            MessageBoxImage initBox = MessageBoxImage.Question;
            MessageBoxResult messageResult = MessageBox.Show(messageText, caption,messageButton,initBox);
            Room room = (Room)dataGridRooms.SelectedItem;

            switch (messageResult)
            {
                case MessageBoxResult.Yes:
                    Rooms.Remove(room);
                    break;
                case MessageBoxResult.No:
                    Menager.MainWindowMenager mainWindow = new MainWindowMenager();
                    mainWindow.Show();
                    this.Close();
                    break;


            }
           
            
        }
    }
}
