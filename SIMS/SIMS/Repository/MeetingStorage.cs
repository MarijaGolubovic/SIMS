using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Repository
{
    public class MeetingStorage : IMeetingStorage
    {
        public List<Meeting> GetAll()
        {
            Serialization.Serializer<Meeting> meetingSerializer = new Serialization.Serializer<Meeting>();
            List<Meeting> meetings = meetingSerializer.fromCSV("meetings.txt");
            UserStorage userStorage = new UserStorage();

            foreach (Meeting m in meetings)
            {
                foreach (string s in m.UsersID)
                {
                    m.Users.Add(userStorage.GetOne(s));
                }
            }

            return meetings;

        }

        public Boolean Create(Meeting meeting)
        {
            List<Meeting> meetings = GetAll();
            meetings = GetAll();
            meetings.Add(meeting);
            Serialization.Serializer<Meeting> meetingSerializer = new Serialization.Serializer<Meeting>();
            meetingSerializer.toCSV("meetings.txt", meetings);
            return true;

        }
    }
}
