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
using System.Windows.Shapes;
using SIMS.Controller;
using SIMS.Model;
using SIMS.ViewModel.Sekretar;

namespace SIMS.View.Sekretar
{
    /// <summary>
    /// Interaction logic for CreateMeetingView.xaml
    /// </summary>
    public partial class CreateMeetingView : Window
    {
        public CreateMeetingViewModel CreateMeetingViewModel { get; set; }
        public static ObservableCollection<Meeting> Sastanci { get; set; }
        private MeetingController meetingController;
        private UserController userController;
        public String dateTime { get; set; }

        public static ObservableCollection<User> Users { get; set; }
        public CreateMeetingView()
        {
            InitializeComponent();
            this.CreateMeetingViewModel = new CreateMeetingViewModel();
            this.DataContext = this;

            meetingController = new MeetingController();

            userController = new UserController();
            Sastanci = new ObservableCollection<Meeting>();

            Users = new ObservableCollection<User>();
            foreach (User u in userController.GetAll())
            {
                if (u.Type != UserType.patient)
                {
                    Users.Add(u);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<User> usersList = new List<User>();

            foreach(User u in UsersLB.SelectedItems)
            {
                usersList.Add(u);
            }
            
            foreach (Meeting m in meetingController.FindSuggestionsForMeeting(DateTime.Parse(dateTime),usersList))
            {
                Sastanci.Add(m);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            meetingController.Create(SastanciDG.SelectedItem as Meeting);
            this.Close();

        }
    }
}
