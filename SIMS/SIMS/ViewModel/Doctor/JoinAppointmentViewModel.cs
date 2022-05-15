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
                FinishCommand.RaiseCanExecuteChanged();
            }
        }

        private readonly AppointmentController appointmentController = new AppointmentController();
        private readonly MedicalRecordController medicalRecordController = new MedicalRecordController();
        private readonly DiagnosisController diagnosisController = new DiagnosisController();

        public MyICommand BackCommand { get; set; }
        public MyICommand FinishCommand { get; set; }
        public MyICommand AddTherapyCommand { get; set; }

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
            FinishCommand = new MyICommand(OnFinish, CanFinish);
            AddTherapyCommand = new MyICommand(OnAddTherapy);
        }

        private void OnBack()
        {
            Messenger.Default.Send("BackFromJoinAppointmentView");
        }

        private void OnFinish()
        {
            appointmentController.Delete(SelectedAppointment.Id);
            Diagnosis d = new Diagnosis(Diagnosis, SelectedAppointment.DateAndTime, SelectedAppointment.Id, SelectedAppointment.Room, Patient, SelectedAppointment.Doctor);
            diagnosisController.Create(d);

            Messenger.Default.Send("FinishFromJoinAppointmentView");
        }

        private bool CanFinish()
        {
            return Diagnosis.Equals("");
        }

        private void OnAddTherapy()
        {
            Messenger.Default.Send("AddTherapy");
        }
    }
}
