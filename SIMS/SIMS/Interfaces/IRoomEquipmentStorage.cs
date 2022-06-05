using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Interfaces
{
    internal interface IRoomEquipmentStorage
    {
        public List<Model.RoomEqupment> GetAll();
        public Model.RoomEqupment GetOne(String roomID);
        public Boolean Delete(int roomID);
        public Boolean Create(Model.RoomEqupment room);
    }
}
