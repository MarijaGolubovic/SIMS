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
    /// Interaction logic for RenovateWindow.xaml
    /// </summary>
    public partial class RenovateWindow : Window
    {
        public RenovateWindow()
        {
            InitializeComponent();
        }

        private void Label_MouseDoubleClickRooms(object sender, MouseButtonEventArgs e)
        {
            Menager.RoomsPanel roomsPanel = new RoomsPanel();
            roomsPanel.Show();
            
        }
    }
}
