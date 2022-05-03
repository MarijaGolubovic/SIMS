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

        public static List<Model.RoomOccupacy> GetAll()
        {
            Serialization.Serializer<Model.RoomOccupacy> occupacyRoomSerializer = new Serialization.Serializer<Model.RoomOccupacy>();
            List<Model.RoomOccupacy> occupacy = occupacyRoomSerializer.fromCSV("OccupacyRoom.txt");

            return occupacy;
        }

        public Model.RoomOccupacy GetOne(int appointmentID)
        {
            Serialization.Serializer<Model.RoomOccupacy> roomOccupacySerializer = new Serialization.Serializer<Model.RoomOccupacy>();
            List<Model.RoomOccupacy> roomOccupacies = roomOccupacySerializer.fromCSV("OccupacyRoom.txt");
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
            occupacySerializer.toCSV("OccupacyRoom.txt", occupacies);
            return true;
        }


        public String fileName;

    }
}
