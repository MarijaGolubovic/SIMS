using GalaSoft.MvvmLight.Messaging;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using ToastNotifications.Messages;

namespace SIMS.ViewModel.Doctor
{
    internal class AddAppointmentViewModel : BindableBase
    {
        public MyICommand AddAppointmentCommand { get; set; }
        public MyICommand CancelCommand { get; set; }
        public static DateTime SelectedDate { get; set; }
        public static String SelectedTime { get; set; }

        private static bool doctroPriority;
        public static bool DoctorPriority
        {
            get { return doctroPriority; }
            set
            {
                doctroPriority = value;
            }
        }
        public List<Patient> Patients { get; set; }
        private static Patient selectedPatient;
        private static Model.Doctor selectedDoctor;
        public static Patient SelectedPatient
        {
            get { return selectedPatient; }
            set { selectedPatient = value; }
        }

        public static Model.Doctor SelectedDoctor
        {
            get { return selectedDoctor; }
            set { selectedDoctor = value; }
        }
        public List<Model.Doctor> Doctors { get; set; }

        private readonly PatientController patientController = new PatientController();
        private readonly DoctorController doctorController = new DoctorController();
        private readonly AppointmentController appointmentController = new AppointmentController();

        public AddAppointmentViewModel()
        {
            Patients = patientController.GetAll();
            Doctors = doctorController.GetAll();
            AddAppointmentCommand = new MyICommand(OnAdd);
            CancelCommand = new MyICommand(OnCancel);
            SelectedDate = DateTime.Now;
        }
        public static DateTime formDateTime()
        {
            string date = SelectedDate.ToString().Split(' ')[0];
            string time = SelectedTime.ToString().Split(' ')[1];
            string dateTime = date + " " + time;
            DateTime retValue = DateTime.Parse(dateTime);

            return retValue;
        }
        private void OnAdd()
        {
            if (appointmentController.CheckIfDateIsValidForDoctor(formDateTime()))
            {
                AppointmentForPatientDTO appointmentForPatient = new AppointmentForPatientDTO(SelectedDoctor, formDateTime(), SelectedPatient, DoctorPriority);
                if (appointmentController.CheckIfAvailable(appointmentForPatient))
                    AddAppointment(appointmentForPatient);
                else
                    ShowSuggestedAppointments();
            }
            else
                MainWindowViewModel.notifier.ShowInformation("Nije moguce zakazati termin u proslosti!");
        }

        private void ShowSuggestedAppointments()
        {
            Messenger.Default.Send("SuggestedAppointmentsViewModel");
            MainWindowViewModel.notifier.ShowInformation("Odabrani termin je zauzet!");
        }

        private void AddAppointment(AppointmentForPatientDTO appointmentForPatient)
        {
            Appointment appointment = new Appointment(appointmentForPatient.DateTime, appointmentController.GenerateAppointmentID(), appointmentController.FindRoomForAppointment(appointmentForPatient), patientController.GetOne(appointmentForPatient.User.Person.JMBG), appointmentForPatient.Doctor);
            _ = appointmentController.Create(appointment, appointmentController.FormRoomOccupacyFromAppointment(appointment));
            Messenger.Default.Send("AllAppointmentView");
            MainWindowViewModel.notifier.ShowSuccess("Uspješno!");
        }

        private void OnCancel()
        {
            Messenger.Default.Send("AllAppointmentView");
        }

    }
}
