using GalaSoft.MvvmLight.Messaging;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using ToastNotifications.Messages;

namespace SIMS.ViewModel.Doctor
{
    internal class DaysOffRequestViewModel : BindableBase
    {
        public MyICommand FinishCommand { get; set; }
        public MyICommand BackCommand { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsUrgently { get; set; }
        public String Reason { get; set; }

        private readonly DaysOffRequestController daysOffRequestCotnroller = new DaysOffRequestController();
        public DaysOffRequestViewModel()
        {
            StartDate = DateTime.Now.AddDays(StartDate.Day + 2);
            EndDate = DateTime.Now.AddDays(EndDate.Day + 2);
            FinishCommand = new MyICommand(OnFinish);
            BackCommand = new MyICommand(OnBack);
        }

        private void OnFinish()
        {
            DaysOffRequest request = new DaysOffRequest(StartDate, EndDate, Reason, IsUrgently);

            bool IsDatesValid = daysOffRequestCotnroller.IsSelectedDatesValid(request.StartDate, request.EndDate);
            bool IsThereDoctorsWithSameSpetialization = daysOffRequestCotnroller.IsThereDoctorsWithSameSpetialization(request, ViewModel.Doctor.MainWindowViewModel.LoggedInUser.Person.JMBG);


            if (IsUrgently && IsDatesValid)
            {
                daysOffRequestCotnroller.Create(request);
                MainWindowViewModel.notifier.ShowSuccess("Uspješno!");
                Messenger.Default.Send("AllAppointmentView");
            }
            else if (!IsDatesValid)
            {
                MainWindowViewModel.notifier.ShowError("Niste unijeli validne datume!");
            }
            else if (IsThereDoctorsWithSameSpetialization)
            {
                MainWindowViewModel.notifier.ShowError("Doktor iste specijalizacije je vec zakazao slobodne dane u tom periodu!");
            }
            else if (IsDatesValid)
            {
                daysOffRequestCotnroller.Create(request);
                MainWindowViewModel.notifier.ShowSuccess("Uspješno!");
                Messenger.Default.Send("AllAppointmentView");
            }
            else
            {
                MainWindowViewModel.notifier.ShowError("Neuspješno");
            }
        }

        private void OnBack()
        {
            Messenger.Default.Send("AllAppointmentView");
        }

    }
}
