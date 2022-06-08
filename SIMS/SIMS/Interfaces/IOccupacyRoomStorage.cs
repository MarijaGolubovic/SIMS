using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Interfaces
{
    internal interface IOccupacyRoomStorage
    {
        public Boolean Delete(RoomOccupacy roomOccupacy);
        public List<Model.RoomOccupacy> GetAll();
        public List<Model.Room> GetById(String roomID);
        public Model.RoomOccupacy GetOne(int appointmentID);
        public Boolean Create(Model.RoomOccupacy roomOccypacy);
    }
}
