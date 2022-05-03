using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    class OccupacyRoomService
    {
        private Repository.OccupacyRoomStorage occupacyRoom = new Repository.OccupacyRoomStorage();

        public List<Model.Room> GetById(String roomID)
        {
            return occupacyRoom.GetById(roomID);
        }

        public OccupacyRoomService()
        {
        }
    }

}
