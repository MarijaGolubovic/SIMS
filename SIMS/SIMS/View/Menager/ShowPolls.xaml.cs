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
        public ShowPolls()
        {
            InitializeComponent();
            this.DataContext = this;
            Serialization.Serializer<Polls> pollsSerializer = new Serialization.Serializer<Polls>();
            List<Model.Polls> allPolls = pollsSerializer.fromCSV("Polls.txt");
            //List<Model.Polls> allPolls = new List<Polls>();
            PollesData = new ObservableCollection<Model.Polls>();
           // allPolls.Add(new Polls("Hello Clinic", 12, 1, 2, 3, 12, 9.8));
            //allPolls.Add(new Polls("123",1,2,3,4,5,12.5));
            foreach (Model.Polls pollItem in allPolls)
            {
              PollesData.Add(pollItem);
            }
        }

        private void Button_Click_BACK(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Report());
        }
    }
}
