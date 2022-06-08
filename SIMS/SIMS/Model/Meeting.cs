using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace SIMS.Model
{
    public class Meeting : Serialization.Serializable
    {
        public DateTime DateTime { get; set; }
        public string RoomID { get; set; }
        public List<String> UsersID { get; set; }
        public List<User> Users { get; set; }

        public void fromCSV(string[] values)
        {
            if (values == null)
                return;
            DateTime = DateTime.Parse(values[0]);
            RoomID = values[1];
            UsersID = new List<string>();
            Users = new List<User>();
            for (int i = 2; i < values.Length; i++)
            {
                UsersID.Add(values[i]);
            }
        }

        public string[] toCSV()
        {
            string[] csvValues =
                {
                DateTime.ToString(),
                RoomID
                };
            int i = 2;
            foreach (string s in UsersID)
            {
                Array.Resize(ref csvValues, i + 1);
                csvValues[i] = s;
                i++;
            }

            return csvValues;
        }

        public Meeting(DateTime dateTime, string roomID, List<User> users)
        {
            DateTime = dateTime;
            RoomID = roomID;
            Users = users;
            UsersID = new List<string>();
            foreach (User u in users)
            {
                UsersID.Add(u.Person.JMBG);
            }
        }

        public Meeting()
        {
        }
        public Boolean CheckDateTime(DateTime dateTime)
        {
            return DateTime.Equals(dateTime);
        }

        public Boolean CheckRoom(Room roomC)
        {
            return RoomID.Equals(roomC.Id);
        }
        public Boolean CheckUsersAndDateTime(DateTime dateTime, List<User> users)
        {
            foreach (User user in users)
            {
                if (Users.Exists(u => u.CheckUser(user)) && CheckDateTime(dateTime))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
