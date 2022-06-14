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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for TutorialVideo.xaml
    /// </summary>
    public partial class TutorialVideo : Page
    {
        public TutorialVideo()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
           
            timer.Start();
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            video.Pause();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            video.Play();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            video.Stop();
        }
    }
}
