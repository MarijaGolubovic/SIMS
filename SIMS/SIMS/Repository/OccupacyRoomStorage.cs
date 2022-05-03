using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository
{
    class OccupacyRoomStorage
    {
        public OccupacyRoomStorage()
        {
        }

        public List<Model.RoomOccupacy> GetAll()
        {
            Serialization.Serializer<Model.RoomOccupacy> occupacyRoomSerializer = new Serialization.Serializer<Model.RoomOccupacy>();
            List<Model.RoomOccupacy> occupacy = occupacyRoomSerializer.fromCSV("OccypacyRoom.txt");

            return occupacy;
        }
        public List<Model.Room> GetById(String roomID)
        {
            Model.Room room = new Model.Room();
            List<Model.Room> findRooms = new List<Model.Room>();
            List<Model.Room> rooms = new List<Model.Room>();
            Serialization.Serializer<Model.Room> roomSerijalization = new Serialization.Serializer<Model.Room>();
            rooms = roomSerijalization.fromCSV("OccypacyRoom.txt");

            foreach (Model.Room roomInput in rooms)
            {
                if (roomID.Equals(roomInput.Id))
                {
                    room = roomInput;
                    findRooms.Add(roomInput);

                }
            }

            return findRooms;
        }


        public Model.RoomOccupacy GetOne(int appointmentID)
        {
            Serialization.Serializer<Model.RoomOccupacy> roomOccupacySerializer = new Serialization.Serializer<Model.RoomOccupacy>();
            List<Model.RoomOccupacy> roomOccupacies = roomOccupacySerializer.fromCSV("OccypacyRoom.txt");
            Model.RoomOccupacy occupacy = new Model.RoomOccupacy();

            foreach (Model.RoomOccupacy occupacyRoom in roomOccupacies)
            {
                if (occupacyRoom.IDRoom.Equals(appointmentID))
                {
                    occupacy = occupacyRoom;
                    break;
                }
            }
            return occupacy;
        }

        public Boolean Create(Model.RoomOccupacy roomOccypacy)
        {
            Serialization.Serializer<Model.RoomOccupacy> occupacySerializer = new Serialization.Serializer<Model.RoomOccupacy>();
            List<Model.RoomOccupacy> occupacies = new List<Model.RoomOccupacy>();
            foreach (Model.RoomOccupacy occ in occupacySerializer.fromCSV("OccypacyRoom.txt"))
            {
                occupacies.Add(occ);
            }
            occupacies.Add(roomOccypacy);
            occupacySerializer.toCSV("OccypacyRoom.txt", occupacies);
            return true;
        }


        public String fileName;

    }
}
