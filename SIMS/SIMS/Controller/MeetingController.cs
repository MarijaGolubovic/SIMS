using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Model;
using SIMS.Service;

namespace SIMS.Controller
{
    public class MeetingController
    {
        private readonly MeetingService meetingService;

        public MeetingController()
        {
            meetingService = new MeetingService();
        }

        public List<Meeting> GetAll()
        {
            return meetingService.GetAll();
        }

        public Boolean Create(Meeting meeting)
        {
            return meetingService.Create(meeting);
        }

        public List<Meeting> FindSuggestionsForMeeting(DateTime dateTime, List<User> users)
        {
            return meetingService.FindSuggestionsForMeeting(dateTime, users);
        }


    }
}
