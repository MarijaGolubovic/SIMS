using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using static System.Net.Mime.MediaTypeNames;
using System.Windows;
using ToastNotifications.Messages;

namespace SIMS.ViewModel.Doctor
{
    internal class DaysOffRequestViewModel : BindableBase
    {
        public MyICommand FinishCommand { get; set; }
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
        }

        private void OnFinish()
        {
            DaysOffRequest request = new DaysOffRequest(StartDate, EndDate, Reason, IsUrgently);

            if(IsUrgently && daysOffRequestCotnroller.IsSelectedDatesValid(request.StartDate, request.EndDate))
            {
                daysOffRequestCotnroller.Create(request);
                notifier.ShowSuccess("Uspješno");
            }
            else if(!daysOffRequestCotnroller.IsThereDoctorsWithSameSpetialization(ViewModel.Doctor.MainWindowViewModel.LoggedInUser.Person.JMBG))
            {
                daysOffRequestCotnroller.Create(request);
                notifier.ShowError("");
            }
            else if(daysOffRequestCotnroller.IsSelectedDatesValid(request.StartDate, request.EndDate))
            {
                daysOffRequestCotnroller.Create(request);
                notifier.ShowError("Neuspješno");
            }
            else
            {
                notifier.ShowError("Neuspješno");
            }
            
        }

        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: System.Windows.Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = System.Windows.Application.Current.Dispatcher;
        });

    }
}
