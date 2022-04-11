using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddRoomWindow.xaml
    /// </summary>
    public partial class AddRoomWindow : Window
    {
        public AddRoomWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
           
            //RoomsList.Rooms.Add(new Model.Room { Id=IDInput.Text, Size = Double.Parse(SizeInput.Text), Type=Model.RoomType.HOSPITAL_ROOM});

            Menager.RoomsList roomList = new Menager.RoomsList();
            roomList.Show();
            this.Close();
        }

    }
}
