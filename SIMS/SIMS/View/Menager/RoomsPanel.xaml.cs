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

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for RoomsPanel.xaml
    /// </summary>
    public partial class RoomsPanel : Window
    {
        public RoomsPanel()
        {
            InitializeComponent();
        }

        private void Label_MouseDoubleClickAdd(object sender, MouseButtonEventArgs e)
        {
           SIMS.Menager.AddRoomWindow addRoomWindow = new SIMS.Menager.AddRoomWindow();
            addRoomWindow.Show();
            this.Close();
            
        }

        private void Label_MouseDoubleClick_Update(object sender, MouseButtonEventArgs e)
        {
            SIMS.Menager.UpdateRoomWindow updateRoomWindow = new SIMS.Menager.UpdateRoomWindow();
            updateRoomWindow.Show();
            this.Close();
        }

        private void Label_MouseDoubleClick_Delete(object sender, MouseButtonEventArgs e)
        {
            SIMS.Menager.DeleteRoom deleteRoom = new SIMS.Menager.DeleteRoom();
            deleteRoom.Show();
            this.Close();
            
        }

      
        private void Label_MouseDoubleClick_Renovate(object sender, MouseButtonEventArgs e)
        {
            Menager.RenovateWindow renovateWindow = new RenovateWindow();
            renovateWindow.Show();
            this.Close();

        }

        private void Label_MouseDoubleClick_Occupancy(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
