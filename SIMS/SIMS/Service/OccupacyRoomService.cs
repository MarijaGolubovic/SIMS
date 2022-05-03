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
                }else
                {
                    roomOccupacies.Add(new Model.RoomOccupacy(room.Id, begin, end, reason));
                    occupacySerializer.toCSV("OccupacyRoom.txt", roomOccupacies);
                    return "Room succesfully added to renovation list ";
                }
            }
            return "";
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

        public Model.RoomOccupacy getTimeForAppointmentWhenPriorityDoctor(String doctorId, DateTime dateOfAppointment)
        {
            RoomOccupacy ro = new RoomOccupacy();
            AppointmentController appointmentController = new AppointmentController();

            List<RoomOccupacy> listRo = GetAll();
            List<DateTime> timesOfDoctorAppointments = appointmentController.getTimesOfDoctorAppointments(doctorId);



            return ro;
        }

    }

}
