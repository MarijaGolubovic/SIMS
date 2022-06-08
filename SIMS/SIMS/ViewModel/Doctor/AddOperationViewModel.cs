using GalaSoft.MvvmLight.Messaging;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.ViewModel.Doctor
{
    internal class AddOperationViewModel : BindableBase
    {
        public MyICommand AddOperationCommand { get; set; }
        public MyICommand CancelCommand { get; set; }
        public List<Patient> Patients { get; set; }
        private readonly PatientController patientController = new PatientController();
        public DateTime SelectedDate { get; set; }
        public AddOperationViewModel()
        {
            Patients = patientController.GetAll();
            SelectedDate = DateTime.Now;
            AddOperationCommand = new MyICommand(OnAdd);
            CancelCommand = new MyICommand(OnCancel);
        }

        private void OnAdd()
        {
            Messenger.Default.Send("AddOperationView");
        }
        private void OnCancel()
        {
            Messenger.Default.Send("AllAppointmentView");
        }
    }
}
