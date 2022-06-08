using SIMS.Controller;
using SIMS.Model;
using System.Collections.Generic;
using System;
using GalaSoft.MvvmLight.Messaging;

namespace SIMS.ViewModel.Doctor
{
    internal class DetailedAppointmentViewModel : BindableBase
    {
        public Patient Patient { get; set; }
        public Appointment SelectedAppointment { get; set; }
        public String Date { get; set; }
        public List<Allergy> Allergies { get; set; }
        public List<Therapy> Therapies { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public String Height { get; set; }
        public String Weight { get; set; }

        private readonly AppointmentController appointmentController = new AppointmentController();
        private readonly MedicalRecordController medicalRecordController = new MedicalRecordController();
        public MyICommand BackCommand { get; set; }

        public DetailedAppointmentViewModel()
        {
            SelectedAppointment = appointmentController.GetOne(AllAppointmentsViewModel.SelectedAppointment.appointmentId);
            Patient = SelectedAppointment.Patient;
            Date = Patient.Person.DateOfBirth.Date.ToString().Split(' ')[0];
            MedicalRecord = medicalRecordController.GetOne(Patient.Person.JMBG);
            Allergies = MedicalRecord.Allergies;
            Therapies = MedicalRecord.Therapy;
            Height = MedicalRecord.Height.ToString();
            Weight = MedicalRecord.Weight.ToString();

            BackCommand = new MyICommand(OnBack);
        }

        private void OnBack()
        {
            Messenger.Default.Send("AllAppointmentView");
        }
    }
}
