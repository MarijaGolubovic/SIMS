using GalaSoft.MvvmLight.Messaging;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastNotifications.Messages;

namespace SIMS.ViewModel.Doctor
{
    internal class SuggestedAppointmentsViewModel : BindableBase
    {
        public MyICommand ConfirmCommand { get; set; }
        public  List<Appointment> Appointments { get; set; }
        private readonly AppointmentController appointmentController = new AppointmentController();

        private Appointment selectedAppointment;
        public Appointment SelectedAppointment 
        {
            get { return selectedAppointment; }
            set 
            {
                selectedAppointment = value;
                ConfirmCommand.RaiseCanExecuteChanged();
            }
        }

        public SuggestedAppointmentsViewModel()
        {
            AppointmentForPatientDTO appointmentForPatient = new AppointmentForPatientDTO(AddAppointmentViewModel.SelectedDoctor, AddAppointmentViewModel.formDateTime(), MainWindowViewModel.LoggedInUser, AddAppointmentViewModel.DoctorPriority);
            Appointments = appointmentController.FindSuggestedAppointments(appointmentForPatient);
            ConfirmCommand = new MyICommand(OnConfirm, CanConfirm);
        }

        private void OnConfirm()
        {
            SelectedAppointment.Patient = AddAppointmentViewModel.SelectedPatient;
            appointmentController.Create(SelectedAppointment, appointmentController.FormRoomOccupacyFromAppointment(SelectedAppointment));
            Messenger.Default.Send("AllAppointmentView");
            MainWindowViewModel.notifier.ShowSuccess("Uspješno!");
        }

        private bool CanConfirm()
        {
            return SelectedAppointment != null;
        }
    }
}
