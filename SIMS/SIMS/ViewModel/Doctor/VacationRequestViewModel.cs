using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastNotifications.Messages;

namespace SIMS.ViewModel.Doctor
{
    internal class VacationRequestViewModel: BindableBase
    {
        public MyICommand FinishCommand { get; set; }
        public MyICommand BackCommand { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public VacationRequestViewModel()
        {
            StartDate = DateTime.Now.AddDays(StartDate.Day + 2);
            EndDate = DateTime.Now.AddDays(EndDate.Day + 2);
            FinishCommand = new MyICommand(OnFinish);
            BackCommand = new MyICommand(OnBack);
        }

        private void OnFinish()
        {
            Messenger.Default.Send("allReqs");
            MainWindowViewModel.notifier.ShowSuccess("Uspješno!");
        }
        private void OnBack()
        {
            Messenger.Default.Send("AllAppointmentView");
        }
    }
}
