using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository
{
    class OccupacyRoomStorage
    {
        public List<Model.Room> GetById(String roomID)
        {
            Model.Room room = new Model.Room();
            List<Model.Room> findRooms = new List<Model.Room>();
            List<Model.Room> rooms = new List<Model.Room>();
            Serialization.Serializer<Model.Room> roomSerijalization = new Serialization.Serializer<Model.Room>();
            rooms = roomSerijalization.fromCSV("OccupacyRoom.txt");

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

        
    }
}
