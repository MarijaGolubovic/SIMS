using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Interfaces
{
    internal interface IRoomStorage
    {
        public List<Room> GetAll();
        public Room GetOne(String roomID);
        public Boolean Delete(string roomID);
        public Boolean Create(Room room);
        public Model.Room GetRoomById(string idRoom);
        public List<Room> GetByType(RoomType type);
    }
}
