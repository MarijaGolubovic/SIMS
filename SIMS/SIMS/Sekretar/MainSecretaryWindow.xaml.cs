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

namespace SIMS.Sekretar
{
    /// <summary>
    /// Interaction logic for MainSecretaryWindow.xaml
    /// </summary>
    public partial class MainSecretaryWindow : Window
    {
        public MainSecretaryWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nalozi nalozi = new Nalozi();
            nalozi.Show();
        }
    }
}
