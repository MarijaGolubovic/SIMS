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

    }
}
