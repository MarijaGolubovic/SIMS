using SIMS.Controller;
using SIMS.Service;
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

namespace SIMS.View.Doctor
{
    /// <summary>
    /// Interaction logic for SelectTimeOfAppointmentPriorityDoctorPage.xaml
    /// </summary>
    public partial class SelectTimeOfAppointmentPriorityDoctorPage : Page
    {
        public List<String> timeList = new List<String>();
        private readonly OccupacyRoomController occupacyContoller = new OccupacyRoomController();
        public SelectTimeOfAppointmentPriorityDoctorPage()
        {
            InitializeComponent();
            this.DataContext = this;

            Time_Combobox.ItemsSource = occupacyContoller.getTimeForAppointmentWhenPriorityDoctor(AddAppointmentPage.appointment.Doctor.Person.JMBG, AddAppointmentPage.appointment.DateAndTime).ToString().Split(' ');
        }
    }
}
