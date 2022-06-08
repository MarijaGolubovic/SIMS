using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.ObjectModel;

namespace SIMS.ViewModel.Sekretar
{
    public class CreateMeetingViewModel
    {
        public Action CloseAction { get; set; }
        public MyICommand CloseCMD { get; set; }
        public MyICommand SearchCMD { get; set; }
        public static ObservableCollection<Meeting> Sastanci { get; set; }

        public static ObservableCollection<User> Users { get; set; }

        private MeetingController meetingController;
        private UserController userController;
        public String dateTime { get; set; }


        public CreateMeetingViewModel()
        {
            CloseCMD = new MyICommand(Close);
            SearchCMD = new MyICommand(Search);
            meetingController = new MeetingController();
            userController = new UserController();
            Sastanci = new ObservableCollection<Meeting>();
            Users = new ObservableCollection<User>();
            foreach (User u in userController.GetAll())
            {
                if (u.Type != UserType.patient)
                {
                    Users.Add(u);
                }
            }


        }
        private void Close()
        {
            CloseAction();
        }

        private void Search()
        {

        }
    }
}
