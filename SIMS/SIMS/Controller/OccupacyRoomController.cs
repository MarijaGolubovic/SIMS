using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    class OccupacyRoomController
    {
        Service.OccupacyRoomService occupacyRoom = new Service.OccupacyRoomService();
        public List<Model.Room> GetById(String roomID)
        {
            return occupacyRoom.GetById(roomID);
        }

        public List<DateTime> getTimeForAppointmentWhenPriorityDoctor(String doctorId, DateTime dateOfAppointment)
        {
            return occupacyRoom.getTimeForAppointmentWhenPriorityDoctor(doctorId, dateOfAppointment);
        }
    }
}
