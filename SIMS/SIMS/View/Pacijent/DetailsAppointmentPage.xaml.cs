using SIMS.Controller;
using SIMS.Model;
using System.Windows.Controls;

namespace SIMS.View.Pacijent
{
    /// <summary>
    /// Interaction logic for DetailsAppointmentPage.xaml
    /// </summary>
    public partial class DetailsAppointmentPage : Page
    {
        public string DateAndTime { get; set; }
        public string Doctor { get; set; }
        public string Details { get; set; }

        private readonly DiagnosisController diagnosisController = new DiagnosisController();
        public DetailsAppointmentPage(Appointment selectedItem)
        {
            InitializeComponent();
            this.DataContext = this;

            DateAndTime = selectedItem.DateAndTime.ToString();
            Doctor = selectedItem.Doctor.Person.Name + " " + selectedItem.Doctor.Person.Surname;
            Details = diagnosisController.GetOne(selectedItem.Id).DiagnosisText;

        }
    }
}
