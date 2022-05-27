using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using SIMS.Model;
using SIMS.Repository;

namespace SIMS.View.Pacijent
{
    /// <summary>
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : Window, INotifyPropertyChanged
    {
        private NotificationStorage notificationStorage = new NotificationStorage();
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Notificatoin> NotificationList { get; set; }
        public Notification()
        {
            InitializeComponent();
            this.DataContext = this;

            NotificationList = new ObservableCollection<Notificatoin>();
            foreach (Notificatoin n in notificationStorage.GetAllForPatient("2212010103158"))
            {
                NotificationList.Add(n);
            }
        }


    }
}
