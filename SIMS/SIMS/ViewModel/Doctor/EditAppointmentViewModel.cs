using GalaSoft.MvvmLight.Messaging;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.ViewModel.Doctor
{
    internal class EditAppointmentViewModel:BindableBase
    {
        public List<AppointmentsForDoctorDTO> Appointments { get; set; }
        private readonly AppointmentController appontmentController = new AppointmentController();

        public static MyICommand EditCommand { get; set; }
        public MyICommand BackCommand { get; set; }

        private static AppointmentsForDoctorDTO selectedAppointment;
        public static AppointmentsForDoctorDTO SelectedAppointment
        {
            get { return selectedAppointment; }
            set
            {
                selectedAppointment = value;
                EditCommand.RaiseCanExecuteChanged();
            }
        }

        public EditAppointmentViewModel()
        {
            Appointments = appontmentController.GetAppointmentsForDoctor();
            EditCommand = new MyICommand(OnEditAppointment, CanEditAppointment);
            BackCommand = new MyICommand(OnBackDetails);
        }

        private void OnEditAppointment()
        {
            Messenger.Default.Send("EditRoomView");
        }

        private bool CanEditAppointment()
        {
            return SelectedAppointment != null;
        }

        private void OnBackDetails()
        {
            Messenger.Default.Send("AllAppointmentView");
        }
    }
}
