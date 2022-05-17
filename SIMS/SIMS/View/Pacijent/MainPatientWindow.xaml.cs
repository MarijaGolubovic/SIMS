using SIMS.Model;
using SIMS.View.Pacijent;
using System;
using System.ComponentModel;
using System.Timers;
using System.Windows;
using SIMS.Controller;
using Tulpep.NotificationWindow;
using System.Windows.Navigation;

namespace SIMS.Pacijent
{
    /// <summary>
    /// Interaction logic for MainPatientWindow.xaml
    /// </summary>
    public partial class MainPatientWindow : Window, INotifyPropertyChanged
    {
        readonly User logedInUser;
        private string _username;
        private readonly NotificationController notificationController = new NotificationController();

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        protected virtual void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPatientWindow(User user)
        {
            InitializeComponent();
            this.DataContext = this;
            InitializeComponent();
            logedInUser = user;
            Username = user.Username;
            MainFrame.Content = new HomePage(logedInUser);

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 100;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        public void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (Model.Notificatoin n in notificationController.GetAllForPatient(logedInUser.Person.JMBG))
            {
                if ((n.NotificationDateTime - DateTime.Now).TotalMinutes <= 5)
                {
                        //PopupNotifier popup = new PopupNotifier();
                        //popup.TitleText = "Obavestenje!";
                        //popup.ContentText = n.Details;
                        //popup.Popup();

                }
            }
        }

        private void AddAppointment(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new AddAppointmentPage(logedInUser));
        }

        private void Notification_Click(object sender, RoutedEventArgs e)
        {
            Notification notification = new Notification();
            notification.Show();
        }

        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new HomePage(logedInUser);
        }

        private void Button_Click_Feedback(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Feedback();
        }
    }
}
