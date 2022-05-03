using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Repository;
using SIMS.Model;

namespace SIMS.Service
{
    public class RoomService
    {
        private RoomStorage roomStorage = new RoomStorage();

        public RoomService()
        {
        }

        public Room GetOne(String roomID)
        {
            return roomStorage.GetOne(roomID);
        }

        public List<Room> GetAll() {
            return roomStorage.GetAll();
        }

        public Boolean Delete(int roomID) {

            return roomStorage.Delete(roomID);
        }

        public Boolean Create(Room room) {

            return roomStorage.Create(room);
        
        }

        public List<Room> GetByType(RoomType type) {

            return roomStorage.GetByType(type);

        }

        public string RenovateRoom(Room room, string method, DateTime begin, DateTime end, string reason) {
            Serialization.Serializer<Model.RoomOccupacy> roomSerializer = new Serialization.Serializer<Model.RoomOccupacy>();
            List<Model.RoomOccupacy> rooms = roomSerializer.fromCSV("OccupacyRoom.txt");
            String message="Room Succesfully added";
            Boolean flag = false;
            Model.RoomOccupacy roomIt = null
                ;

            foreach (Model.RoomOccupacy roomItem in rooms)
            {
                if (roomItem.IDRoom.Equals(room.Id))
                {
                    roomIt = roomItem;
                }
            }

            if (flag)
            {
                if (DateTime.Compare(roomIt.Begin, begin) <= 0 && DateTime.Compare(roomIt.End, end) <= 0)
                {

                    return message = "Room is reserved in this period";
                }
                else if (DateTime.Compare(end, begin) < 0)
                {
                    return message = "End period is erlier than begin";

                }
                else
                {
                    rooms.Add(new RoomOccupacy(room.Id, begin, end, reason));
                    roomSerializer.toCSV("OccupacyRoom.txt", rooms);
                    return message = "Room sucessfully added to renovation";

                }
            }
            return message;
        }


    }
}
