using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Model;
using SIMS.Repository;

namespace SIMS.Service
{
    public class MeetingService
    {
        private MeetingStorage meetingStorage;
        private readonly AppointmentService appointmentService = new AppointmentService();
        private readonly RoomService roomService = new RoomService();

        public MeetingService()
        {
            meetingStorage = new MeetingStorage();
        }

        public List<Meeting> GetAll()
        {
            return meetingStorage.GetAll();
        }

        public Boolean Create (Meeting meeting)
        {
            return meetingStorage.Create(meeting);
        }

        public List<Meeting> FindSuggestionsForMeeting(DateTime dateTime, List<User> users)
        {
            List<Meeting> suggestedMeetings = new List<Meeting>();
            Room room = CheckAvaliableRoom(dateTime);
            Boolean areUsersAvailable = appointmentService.CheckingAvailabilityOfDoctors(dateTime, users) && CheckingAvailabilityOfUsers(dateTime, users);
            if (room==null || !areUsersAvailable)
            {
                return suggestedMeetings;
            } else
            {
                suggestedMeetings.Add(new Meeting(dateTime, room.Id, users));
                return suggestedMeetings;
            }        
        }
        public Room CheckAvaliableRoom(DateTime dateTime)
        {
            List<Room> rooms = roomService.GetAll();
            List<Meeting> meetings = GetAll();

            foreach (Room r in rooms)
            {
                if (r.Type==RoomType.MEETING_ROOM)
                {
                    if (!meetings.Exists(a => a.DateTime == dateTime && a.RoomID.Equals(r.Id)))
                    {
                        return r;
                    }
                }

            }
            return null;
        }
        public Boolean CheckingAvailabilityOfUsers(DateTime dateTime, List<User> users)
        {
            List<Meeting> meetings = GetAll();

            foreach (User u in users)
            {
                foreach(Meeting m in meetings)
                {
                    if (m.Users.Exists(p => p.Person.JMBG.Equals(u.Person.JMBG) && m.DateTime == dateTime))
                    {
                        return false;
                    }
                }

            }

            return true;
        }

    }
}
