using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository
{
    class RoomEquipmentStorage
    {
        public List<Model.RoomEqupment> GetAll()
        {
            List<Model.RoomEqupment> roomEquipments = new List<Model.RoomEqupment>();
            Serialization.Serializer<Model.RoomEqupment> roomSerijalization = new Serialization.Serializer<Model.RoomEqupment>();
            roomEquipments = roomSerijalization.fromCSV("RoomEquipment.txt");

            return roomEquipments;
        }

        public Model.RoomEqupment GetOne(String roomID)
        {
            Model.RoomEqupment roomequipment = new Model.RoomEqupment();
            List<Model.RoomEqupment> roomEquipment = new List<Model.RoomEqupment>();
            Serialization.Serializer<Model.RoomEqupment> roomSerijalization = new Serialization.Serializer<Model.RoomEqupment>();
            roomEquipment = roomSerijalization.fromCSV("RoomEquipment.txt");

            foreach (Model.RoomEqupment roomInput in roomEquipment)
            {
                if (roomID.Equals(roomInput.RoomId))
                {
                    roomequipment = roomInput;
                }
            }

            return roomequipment;
        }

        public Boolean Delete(int roomID)
        {
            Boolean status = false;
            List<Model.RoomEqupment> rooms = new List<Model.RoomEqupment>();
            Serialization.Serializer<Model.RoomEqupment> roomSerijalization = new Serialization.Serializer<Model.RoomEqupment>();

            rooms = roomSerijalization.fromCSV("RoomEquipment.txt");
            foreach (Model.RoomEqupment roomInput in rooms)

            {
                if (roomID.Equals(roomInput.RoomId))
                {
                    rooms.Remove(roomInput);
                    status = true;
                }
            }
            return status;
        }

        public Boolean Create(Model.RoomEqupment room)
        {
            Boolean status = false;
            List<Model.RoomEqupment> rooms = new List<Model.RoomEqupment>();
            Serialization.Serializer<Model.RoomEqupment> roomSerijalization = new Serialization.Serializer<Model.RoomEqupment>();
            rooms = roomSerijalization.fromCSV("RoomEquipment.txt");
            rooms.Add(room);
            roomSerijalization.toCSV("RoomEquipment.txt", rooms);
            status = true;
            return status;
        }

        public Boolean Update(Model.RoomEqupment room)
        {
            throw new NotImplementedException();
        }
    }
}
