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
            //Room room = new Room("1", 5,Model.RoomType.EXAMINATION_ROOM);
            Rooms.Add(new Room("opb",12.1,Model.RoomType.OPPERATING_ROOM));
            Rooms.Add(new Room("h21",15.2,Model.RoomType.HOSPITAL_ROOM));
            Rooms.Add(new Room("h2", 15.2, Model.RoomType.HOSPITAL_ROOM));
        }
    }
}
