using System.Windows;
using System.Windows.Input;

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
            Menager.MovingWindow movingWindow = new MovingWindow();
            movingWindow.Show();
            this.Close();
        }
    }
}
