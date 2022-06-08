using SIMS.Controller;
using SIMS.Model;
using SIMS.Controller;
using SIMS.Model;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Model;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;

namespace SIMS.ViewModel.Doctor
{
    internal class AllAppointmentsViewModel : BindableBase
    {
        public List<AppointmentsForDoctorDTO> Appointments { get; set; }
        private readonly AppointmentController appontmentController = new AppointmentController();

        public static MyICommand JoinAppointmentCommand { get; set; }
        public static MyICommand ShowDetailsCommand { get; set; }

        private static AppointmentsForDoctorDTO selectedAppointment;
        public static AppointmentsForDoctorDTO SelectedAppointment
        {
            get { return selectedAppointment; }
            set
            {
                selectedAppointment = value;
                ShowDetailsCommand.RaiseCanExecuteChanged();
                JoinAppointmentCommand.RaiseCanExecuteChanged();
            }
        }

        public AllAppointmentsViewModel()
        {
            Appointments = appontmentController.GetAppointmentsForDoctor();
            JoinAppointmentCommand = new MyICommand(OnJoinAppointment, CanJoinAppointment);
            ShowDetailsCommand = new MyICommand(OnShowDetails, CanShowDetails);
        }

        private void OnJoinAppointment()
        {
            Messenger.Default.Send("JoinAppointmentView");
        }

        private bool CanJoinAppointment()
        {
            return SelectedAppointment != null;
        }

        private void OnShowDetails()
        {
            Messenger.Default.Send("DetailedAppointmentView");
        }

        private bool CanShowDetails()
        {
            return SelectedAppointment != null;
        }

    }
}
