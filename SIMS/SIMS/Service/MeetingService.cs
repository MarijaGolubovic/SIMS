using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Service
{
    //*******DANIJELA********
    public class MeetingService
    {
        private IMeetingStorage meetingStorage;
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

        public Boolean Create(Meeting meeting)
        {
            return meetingStorage.Create(meeting);
        }

        public List<Meeting> FindSuggestionsForMeeting(DateTime dateTime, List<User> users)
        {
            List<Meeting> suggestedMeetings = new List<Meeting>();
            Room room = CheckAvaliableRoom(dateTime);
            Boolean areUsersAvailable = appointmentService.CheckingAvailabilityOfDoctors(dateTime, users) && CheckingAvailabilityOfUsers(dateTime, users);
            if (room == null || !areUsersAvailable)
            {
                return suggestedMeetings;
            }
            else
            {
                suggestedMeetings.Add(new Meeting(dateTime, room.Id, users));
                return suggestedMeetings;
            }
        }
        public Room CheckAvaliableRoom(DateTime dateTime)
        {
            List<Room> rooms = roomService.GetAll();
            List<Meeting> meetings = GetAll();

            foreach (Room room in rooms)
            {
                if (room.IsRoomForMeeting())
                {
                    if (!meetings.Exists(meeting => meeting.CheckDateTime(dateTime) && meeting.CheckRoom(room)))
                    {
                        return room;
                    }
                }

            }
            return null;
        }
        public Boolean CheckingAvailabilityOfUsers(DateTime dateTime, List<User> users)
        {
            List<Meeting> meetings = GetAll();
            foreach (Meeting meeting in meetings)
            {
                if (!meeting.CheckUsersAndDateTime(dateTime, users))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
