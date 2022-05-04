using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using SIMS.Repository;
using SIMS.Model;

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
