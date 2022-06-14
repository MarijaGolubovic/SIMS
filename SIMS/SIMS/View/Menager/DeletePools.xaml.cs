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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for DeletePools.xaml
    /// </summary>
    public partial class DeletePools : Page
    {

        public static ObservableCollection<Model.PollDTO> Polls { get; set; }
        public static Model.PollDTO selectedItem;
        public DeletePools()
        {
            InitializeComponent();
            this.DataContext = this;

            Polls = new ObservableCollection<Model.PollDTO>();

            Polls.Add(new Model.PollDTO("Poll 1"));
            Polls.Add(new Model.PollDTO("Poll 2"));
            Polls.Add(new Model.PollDTO("Poll 3"));
            Polls.Add(new Model.PollDTO("Poll 4"));
            Polls.Add(new Model.PollDTO("Poll 5"));
            Polls.Add(new Model.PollDTO("Poll 6"));
            Polls.Add(new Model.PollDTO("Poll 7"));
            Polls.Add(new Model.PollDTO("Poll 8"));
            Polls.Add(new Model.PollDTO("Poll 9"));
            Polls.Add(new Model.PollDTO("Poll 10"));

        }

        private void buttonDelete_DELETE(object sender, RoutedEventArgs e)
        {

            
            selectedItem = (Model.PollDTO)DataGridDeletePoll.SelectedItem;
            if (selectedItem != null)
            {

                Polls.Remove(selectedItem);

                if (selectedItem != null)
                {
                    DataGridDeletePoll.ItemsSource = Polls;
                    DataGridDeletePoll.Items.Refresh();
                }
                feedbackMessage.Foreground = System.Windows.Media.Brushes.Green;
                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(feedbackMessage);
            }
            else
            {
                errorMessage.Foreground= System.Windows.Media.Brushes.Red;
                buttonDelete.IsEnabled = false;
            }
        }

        private void buttonCancel_CANCEL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Menager.Report());
        }

        private void DataGridDeletePoll_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            errorMessage.Foreground = System.Windows.Media.Brushes.LightGray;
            buttonDelete.IsEnabled = true;

        }

        private void Button_Click_TUTORIAL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Tutorials.DeletePollTutorial());
        }

      
    }
}
