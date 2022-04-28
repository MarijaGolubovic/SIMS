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
    }
}
