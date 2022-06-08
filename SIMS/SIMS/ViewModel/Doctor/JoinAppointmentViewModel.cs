using SIMS.Controller;
using SIMS.Model;
using System.Collections.Generic;
using System;
using GalaSoft.MvvmLight.Messaging;
using ToastNotifications.Messages;

namespace SIMS.ViewModel.Doctor
{
    internal class JoinAppointmentViewModel : BindableBase
    {
        public Patient Patient { get; set; }
        public static Appointment SelectedAppointment { get; set; }
        public List<Allergy> Allergies { get; set; }
        public List<Therapy> Therapies { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public String Height { get; set; }
        public String Weight { get; set; }
        private String diagnosis;
        public String Diagnosis
        {
            get { return diagnosis; }
            set
            {
                diagnosis = value;
                OnPropertyChanged("Diagnosis");
                FinishCommand.RaiseCanExecuteChanged();
            }
        }

        private readonly AppointmentController appointmentController = new AppointmentController();
        private readonly MedicalRecordController medicalRecordController = new MedicalRecordController();
        private readonly DiagnosisController diagnosisController = new DiagnosisController();

        public MyICommand BackCommand { get; set; }
        public MyICommand FinishCommand { get; set; }
        public MyICommand AddTherapyCommand { get; set; }
        public MyICommand AddAppointmentCommand { get; set; }

        public JoinAppointmentViewModel()
        {
            SelectedAppointment = appointmentController.GetOne(AllAppointmentsViewModel.SelectedAppointment.appointmentId);
            Patient = SelectedAppointment.Patient;
            MedicalRecord = medicalRecordController.GetOne(Patient.Person.JMBG);
            Allergies = MedicalRecord.Allergies;
            Therapies = MedicalRecord.Therapy;
            Height = MedicalRecord.Height.ToString();
            Weight = MedicalRecord.Weight.ToString();

            BackCommand = new MyICommand(OnBack);
            FinishCommand = new MyICommand(OnFinish);
            AddTherapyCommand = new MyICommand(OnAddTherapy);
            AddAppointmentCommand = new MyICommand(OnAddAppointment);

            Diagnosis = "";
        }

        private void OnBack()
        {
            Messenger.Default.Send("AllAppointmentView");
        }

        private void OnFinish()
        {
            appointmentController.Delete(SelectedAppointment.Id);
            Diagnosis diagnosis = new Diagnosis(Diagnosis, SelectedAppointment.DateAndTime, SelectedAppointment.Id, SelectedAppointment.Room, Patient, SelectedAppointment.Doctor);
            diagnosisController.Create(diagnosis);

            Messenger.Default.Send("AllAppointmentView");
            MainWindowViewModel.notifier.ShowSuccess("Uspješno!");
        }

        private void OnAddTherapy()
        {
            Messenger.Default.Send("AddTherapy");
        }
        private void OnAddAppointment()
        {
            Messenger.Default.Send("AddAppointmentView");
        }
    }
}
