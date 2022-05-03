using System;
using SIMS.Model;
using SIMS.Service;

namespace SIMS.Controller
{
    public class RoomController
    {
        private RoomService roomService = new RoomService();

        public RoomController()
        {
        }
        public Room GetOne(String roomID)
        {
            return roomService.GetOne(roomID);
        }
    }
}
