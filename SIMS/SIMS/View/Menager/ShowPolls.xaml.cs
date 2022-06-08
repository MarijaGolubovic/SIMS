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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SIMS.Model;
namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for ShowPolls.xaml
    /// </summary>
    public partial class ShowPolls : Page
    {
        public static ObservableCollection<Model.Polls> PollesData { get; set; }
        Repository.PollsStorage pollsStorage = new Repository.PollsStorage();
        Service.PollsService pollsService = new Service.PollsService();
        public ShowPolls()
        {
            InitializeComponent();
            this.DataContext = this;
            Serialization.Serializer<Polls> pollsSerializer = new Serialization.Serializer<Polls>();
            List<Model.Polls> allPolls = pollsSerializer.fromCSV("Polls.txt");
            
            PollesData = new ObservableCollection<Model.Polls>();
            pollsService.SetAverage();
            List<Polls> polls = new List<Polls>();
            foreach (Model.Polls pollItem in allPolls)
            {
              pollItem.Average =  pollsService.CalculateAverage(pollItem);
              PollesData.Add(pollItem);
                polls.Add(pollItem);
            }
            Serialization.Serializer<Polls> pollsSerijalization = new Serialization.Serializer<Polls>();
            pollsSerijalization.toCSV("Polls.txt", polls);
        }

        private void Button_Click_BACK(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Report());
        }
    }
}
