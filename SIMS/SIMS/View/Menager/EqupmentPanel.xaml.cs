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
    /// Interaction logic for EqupmentPanel.xaml
    /// </summary>
    public partial class EqupmentPanel : Window
    {
        public EqupmentPanel()
        {
            InitializeComponent();
        }

        private void Label_MouseDoubleClick_Moving(object sender, MouseButtonEventArgs e)
        {
            Menager.MoveEquipment movingWindow = new MoveEquipment();
            movingWindow.Show();
            this.Close();
        }
    }
}
