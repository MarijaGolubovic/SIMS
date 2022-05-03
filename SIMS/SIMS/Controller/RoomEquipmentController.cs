using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    class RoomEquipmentController
    {
        Service.RoomEquipmentServices roomEquipment = new Service.RoomEquipmentServices();

        public List<Model.RoomEqupment> GetAll()
        {
            return roomEquipment.GetAll();
        }

        public Model.RoomEqupment GetOne(String roomID)
        {
            return roomEquipment.GetOne(roomID);
        }

        public Boolean Delete(int roomID)
        {
            return roomEquipment.Delete(roomID);
        }

        public Boolean Create(Model.RoomEqupment room)
        {
            return roomEquipment.Create(room);
        }

    }
}
