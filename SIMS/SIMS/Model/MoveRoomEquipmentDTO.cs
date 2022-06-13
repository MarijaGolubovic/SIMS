using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
   public class MoveRoomEquipmentDTO
    {
        
       
        public string Name { get; set; }
        public string RoomId { get; set; }
        public string Begin { get; set; }
        public string End { get; set; }

        public MoveRoomEquipmentDTO(string name, string roomId, string begin, string end)
        {
            Name = name;
            RoomId = roomId;
            Begin = begin;
            End = end;
        }

        public MoveRoomEquipmentDTO()
        {
        }
    }
}
