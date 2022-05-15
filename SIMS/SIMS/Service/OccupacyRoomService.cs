using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    class OccupacyRoomService
    {
        private Repository.OccupacyRoomStorage occupacyRoomStorage = new Repository.OccupacyRoomStorage();

        public String RenovateRoom(Model.Room room, DateTime begin, DateTime end, String reason)
        {
            List<Model.RoomOccupacy> roomOccupacies = occupacyRoomStorage.GetAll();
            Serialization.Serializer<Model.RoomOccupacy> occupacySerializer = new Serialization.Serializer<Model.RoomOccupacy>();
            foreach (Model.RoomOccupacy roomItem in roomOccupacies)
            {
                if (roomItem.IDRoom.Equals(room.Id))
                {
                    if ((DateTime.Compare(roomItem.Begin, begin) <= 0) && (DateTime.Compare(end, roomItem.End) <= 0))
                    {
                        return "Room reserved in that period";
                    }
                    else if (DateTime.Compare(end, begin) < 0)
                    {
                        return "End period must be less than begin";
                    }
                    else
                    {
                        roomOccupacies.Add(new Model.RoomOccupacy(room.Id, begin, end, reason));
                        occupacySerializer.toCSV("OccupacyRoom.txt", roomOccupacies);
                        return "Room succesfully added to renovation list ";
                    }
                }else
                {
                    roomOccupacies.Add(new Model.RoomOccupacy(room.Id, begin, end, reason));
                    occupacySerializer.toCSV("OccupacyRoom.txt", roomOccupacies);
                    return "Room succesfully added to renovation list ";
                }
            }
            return "";
        }

        public bool RoomAlreadyOccupacy(Model.Room room, DateTime begin, DateTime end, String reason)
        {
            List<Model.RoomOccupacy> roomOccupacies = occupacyRoomStorage.GetAll();
            Serialization.Serializer<Model.RoomOccupacy> occupacySerializer = new Serialization.Serializer<Model.RoomOccupacy>();
            bool isOccupacy = false;

            foreach (Model.RoomOccupacy roomItem in roomOccupacies)
            {
                if (roomItem.IDRoom.Equals(room.Id))
                {
                    if ((DateTime.Compare(roomItem.Begin, begin) >= 0) && (DateTime.Compare(end, roomItem.End) <= 0))
                    {
                        isOccupacy = true;
                    }
                }
            }

            return isOccupacy;
        }

        public bool EndBeforeBegin( DateTime begin, DateTime end)
        {
            bool isEndBeforeBegin = false;   
                if (DateTime.Compare(end, begin) < 0)
                {
                isEndBeforeBegin = true;
                }
            
            return isEndBeforeBegin;
        }

        public List<Model.Room> GetById(String roomID)
        {
            return occupacyRoomStorage.GetById(roomID);
        }

        public List<RoomOccupacy> GetAll()
        {
            return occupacyRoomStorage.GetAll();
        }

        public OccupacyRoomService()
        {
        }

        public List<DateTime> getTimeForAppointmentWhenPriorityDoctor(String doctorId, DateTime dateOfAppointment)
        {
            List<DateTime> retList = new List<DateTime>();
            AppointmentController appointmentController = new AppointmentController();

            List<RoomOccupacy> listRo = GetAll();
            List<DateTime> timesOfDoctorAppointments = appointmentController.getTimesOfDoctorAppointments(doctorId, dateOfAppointment);

            timesOfDoctorAppointments.Sort();

            List<String> times = new List<String>();
            foreach(DateTime dt in timesOfDoctorAppointments)
            {
                times.Add(dt.ToString());
            }

            int hours = 09;
            int minutes = 00;
            int millisecons = 00;
            String startTime = hours + ":" + minutes + ":" + millisecons;



            foreach(String time in times)
            {
                String timeTmp = time.Split(' ')[1];
                int i = 1;
                while (true) 
                {
                    minutes = minutes + i;
                    startTime = hours + ":" + minutes + ":" + millisecons;
                    if (startTime.Equals(time.Split(' ')[1]))
                    {
                        if (i > 30)
                        {
                            DateTime dateTime = DateTime.Parse(dateOfAppointment.ToString().Split(' ')[0] + " " + startTime);
                            retList.Add(dateTime);
                        }
                        else {
                            break;
                        }
                    }
                    i++;
                }
            }

            return retList;
        }

    }

}
