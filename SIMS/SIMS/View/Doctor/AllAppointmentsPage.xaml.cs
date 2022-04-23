using SIMS.Controller;
using SIMS.Model;
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

namespace SIMS.View.Doctor
{
    public partial class AllAppointmentsPage : Page
    {
        public List<AppointmentsForDoctorDTO> Appointments { get; set; }
        private AppointmentController appointmentController { get; set; }
        public AllAppointmentsPage()
        {
            InitializeComponent();
            this.DataContext = this;

            appointmentController = new AppointmentController();
            Appointments = appointmentController.GetAppointmentsForDoctor();
        }
    }
}
