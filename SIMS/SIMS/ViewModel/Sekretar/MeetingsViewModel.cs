using SIMS.Controller;
using SIMS.Model;
using SIMS.View.Sekretar;
using System;
using System.Collections.ObjectModel;

namespace SIMS.ViewModel.Sekretar
{
    public class MeetingsViewModel
    {
        public Action CloseAction { get; set; }
        public MyICommand CloseCMD { get; set; }
        public MyICommand CreateCMD { get; set; }

        public static ObservableCollection<Meeting> Sastanci { get; set; }

        private MeetingController meetingController;

        public MeetingsViewModel()
        {
            CloseCMD = new MyICommand(Close);
            CreateCMD = new MyICommand(OpenCreateViewModel);
            meetingController = new MeetingController();
            Sastanci = new ObservableCollection<Meeting>();
            foreach (Meeting m in meetingController.GetAll())
            {
                Sastanci.Add(m);
            }
        }

        private void OpenCreateViewModel()
        {
            CreateMeetingView createMeetingView = new CreateMeetingView();
            createMeetingView.Show();
        }



        private void Close()
        {
            CloseAction();
        }
    }
}
