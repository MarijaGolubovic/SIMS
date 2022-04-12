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
    /// Interaction logic for MainWindowMenager.xaml
    /// </summary>
    public partial class MainWindowMenager : Window
    {
        public MainWindowMenager()
        {
            InitializeComponent();
        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            Menager.AddRoomWindow addRoomWindow = new Menager.AddRoomWindow();
            addRoomWindow.Show();
            this.Close();
        }

        private void UpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            Menager.UpdateRoomWindow updateWindow = new UpdateRoomWindow();
            updateWindow.Show();
            
            
        }

        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            Menager.RoomsList roomsList = new Menager.RoomsList();
            roomsList.Show();
            this.Close();
        }
    }
}
