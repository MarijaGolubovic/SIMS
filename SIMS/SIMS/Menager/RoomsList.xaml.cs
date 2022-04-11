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

        public ObservableCollection<Room> Rooms
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

        }
    }
}
